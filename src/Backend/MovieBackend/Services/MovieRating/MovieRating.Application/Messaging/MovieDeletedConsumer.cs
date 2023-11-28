using MovieRating.Application.Services;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using Microsoft.Extensions.Options;
using MovieRating.Application.Configuration;
using Polly.Registry;
using Polly;
using MovieRating.Application.Helper;

namespace MovieRating.Application.Messaging
{
	public class MovieDeletedConsumer : IHostedService
	{
		private const string exchangetopic = "movie.deleted";
		private const string queuetopic = "rating.movie.deleted";
		private readonly IServiceScopeFactory scopeFactory;
		private readonly IOptions<RabbitMQConfiguration> rabbitMQConfiguration;
		private readonly ResiliencePipeline resiliencePipeline;
		private IConnection connection;
		private IChannel channel;
		public MovieDeletedConsumer(IServiceScopeFactory scopeFactory, IOptions<RabbitMQConfiguration> options, ResiliencePipelineProvider<string> resiliencePipelineProvider)
		{
			this.scopeFactory = scopeFactory;
			this.rabbitMQConfiguration = options;
			this.resiliencePipeline = resiliencePipelineProvider.GetPipeline(Consts.RetryPipeLine);
		}

		private void SetupRabbitMQ()
		{
			resiliencePipeline.Execute(token =>
		   {
			   var factory = new ConnectionFactory
			   {
				   HostName = rabbitMQConfiguration.Value.HostName,
				   UserName = rabbitMQConfiguration.Value.UserName,
				   Password = rabbitMQConfiguration.Value.Password,
				   Port = rabbitMQConfiguration.Value.Port,
			   };
			   //Create the RabbitMQ connection using connection factory details as i mentioned above
			   connection = factory.CreateConnection();

			   channel = connection.CreateChannel();

			   // Declare the exchange and queue
			   channel.ExchangeDeclare(exchange: exchangetopic, type: ExchangeType.Fanout, durable: true);
			   channel.QueueDeclare(queue: queuetopic, durable: true, exclusive: false, autoDelete: false, arguments: null);

			   // Bind the queue to the exchange
			   channel.QueueBind(queue: queuetopic, exchange: exchangetopic, routingKey: exchangetopic);

			   var consumer = new EventingBasicConsumer(channel);
			   consumer.Received += async (model, ea) =>
			   {
				   var body = ea.Body.ToArray();
				   var message = Encoding.UTF8.GetString(body);
				   await HandleDelete(Convert.ToInt32(message));
			   };
			   channel.BasicConsume(queue: queuetopic,
									autoAck: true,
									consumer: consumer);
		   });

		}

		async Task HandleDelete(int MovieID)
		{
			using (var scope = scopeFactory.CreateScope())
			{
				var scopedService = scope.ServiceProvider.GetRequiredService<IMovieRatingService>();
				await scopedService.DeleteRatingsFromMovie(MovieID);
				Console.WriteLine($"DELETED MOVIE {MovieID}");
			}

		}



		public Task StartAsync(CancellationToken cancellationToken)
		{
			SetupRabbitMQ();

			return Task.CompletedTask;
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			return Task.CompletedTask;
		}
	}
}
