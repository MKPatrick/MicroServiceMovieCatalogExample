using Microsoft.Extensions.Options;
using MovieCatalog.Application.Configuration;
using RabbitMQ.Client;
using System.Text;

namespace MovieCatalog.Application.Messaging
{
	public class MovieDeleteProduce : IMovieDeleteProduce
	{
		private readonly IOptions<RabbitMQConfiguration> optionsRabbit;

		public MovieDeleteProduce(IOptions<RabbitMQConfiguration> optionsRabbit)
		{
			this.optionsRabbit = optionsRabbit;
		}

		public void SendMovieDeleteProduce(int MovieID)
		{
			//Here we specify the Rabbit MQ Server. we use rabbitmq docker image and use it
			var factory = new ConnectionFactory
			{
				HostName = optionsRabbit.Value.HostName,
				UserName = optionsRabbit.Value.UserName,
				Password = optionsRabbit.Value.Password,
				Port = optionsRabbit.Value.Port
			};
			//Create the RabbitMQ connection using connection factory details as i mentioned above
			var connection = factory.CreateConnection();

			using var channel = connection.CreateModel();
			//declare the queue after mentioning name and a few property related to that
			channel.ExchangeDeclare("movie.deleted", ExchangeType.Fanout, true, false, null);
			//put the data on to the product queue
			channel.BasicPublish(exchange: "movie.deleted",
						 routingKey: "",
						 basicProperties: null,
						 body: Encoding.UTF8.GetBytes(MovieID.ToString()));
		}
	}
}