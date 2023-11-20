using MovieRating.Application.Services;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using Microsoft.Extensions.Options;
using MovieRating.Application.Configuration;

namespace MovieRating.Application.Messaging
{
	public class MovieDeletedConsumer : IHostedService
	{
		private readonly IServiceScopeFactory scopeFactory;
		private readonly IOptions<RabbitMQConfiguration> rabbitMQConfiguration;
		private IConnection connection;
		private IChannel channel;
		public MovieDeletedConsumer(IServiceScopeFactory scopeFactory,IOptions<RabbitMQConfiguration> options)
		{
			this.scopeFactory = scopeFactory;
			this.rabbitMQConfiguration = options;
		}

		private void SetupRabbitMQ()
		{
			var factory = new ConnectionFactory
			{
				HostName = rabbitMQConfiguration.Value.HostName,
				UserName = rabbitMQConfiguration.Value.UserName,
				Password = rabbitMQConfiguration.Value.Password,
				Port= rabbitMQConfiguration.Value.Port,
			};
			//Create the RabbitMQ connection using connection factory details as i mentioned above
			connection = factory.CreateConnection();

			channel = connection.CreateChannel();

			// Declare the exchange and queue
			channel.ExchangeDeclare(exchange: "movie.deleted", type: ExchangeType.Fanout, durable: true);
			channel.QueueDeclare(queue: "rating.movie.deleted", durable: true, exclusive: false, autoDelete: false, arguments: null);

			// Bind the queue to the exchange
			channel.QueueBind(queue: "rating.movie.deleted", exchange: "movie.deleted", routingKey: "movie.deleted");

			var consumer = new EventingBasicConsumer(channel);
			consumer.Received += async (model, ea) =>
			{
				var body = ea.Body.ToArray();
				var message = Encoding.UTF8.GetString(body);
				await HandleDelete(Convert.ToInt32(message));
			};
			channel.BasicConsume(queue: "rating.movie.deleted",
								 autoAck: true,
								 consumer: consumer);
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
