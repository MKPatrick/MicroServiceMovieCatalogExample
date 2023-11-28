using Microsoft.Extensions.Options;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using MovieStreaming.Application.Configuration;
using MediatR;
using System.Text;
using MovieStreaming.Application.Commands;
using Polly.Registry;
using MovieStreaming.Application.Helper;
using Polly;

namespace MovieStreaming.Application.Messaging
{
	public class MovieDeletedConsumer : IHostedService
	{
		private readonly IServiceScopeFactory scopeFactory;
		private readonly IOptions<RabbitMQConfiguration> rabbitMQConfiguration;
		private IConnection connection;
		private IChannel channel;
		private ResiliencePipeline resiliencePipeline;
		public MovieDeletedConsumer(IServiceScopeFactory scopeFactory, IOptions<RabbitMQConfiguration> options, ResiliencePipelineProvider<string> resiliencePipelineProvider)
		{
			this.scopeFactory = scopeFactory;
			this.rabbitMQConfiguration = options;
			this.resiliencePipeline = resiliencePipelineProvider.GetPipeline(Consts.Retrypipeline);
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
			   channel.ExchangeDeclare(exchange: "movie.deleted", type: ExchangeType.Fanout, durable: true);
			   channel.QueueDeclare(queue: "stream.movie.deleted", durable: true, exclusive: false, autoDelete: false, arguments: null);

			   // Bind the queue to the exchange
			   channel.QueueBind(queue: "stream.movie.deleted", exchange: "movie.deleted", routingKey: "movie.deleted");

			   var consumer = new EventingBasicConsumer(channel);
			   consumer.Received += async (model, ea) =>
				{
			   var body = ea.Body.ToArray();
			   var message = Encoding.UTF8.GetString(body);
			   await HandleDelete(Convert.ToInt32(message));
		   };
			   channel.BasicConsume(queue: "stream.movie.deleted",
									 autoAck: true,
									 consumer: consumer);
		   });
		}

		async Task HandleDelete(int MovieID)
		{
			using (var scope = scopeFactory.CreateScope())
			{
				var scopedService = scope.ServiceProvider.GetRequiredService<IMediator>();
				await scopedService.Send(new DeleteMovieStreamByMovieIDCommand(MovieID));
				Console.WriteLine($"DELETED MOVIE from Stream {MovieID}");
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
