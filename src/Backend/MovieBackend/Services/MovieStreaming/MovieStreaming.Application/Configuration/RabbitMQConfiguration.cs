namespace MovieStreaming.Application.Configuration
{
	public class RabbitMQConfiguration
	{
		public const string Position = "RabbitMQConfiguration";
		public string HostName { get; set; }
		public int Port { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
	}
}
