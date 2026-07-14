using Confluent.Kafka;

var config = new ProducerConfig()
{
    BootstrapServers = "localhost:9092"
};

using var producer = new ProducerBuilder<string, string>(config).Build();

while (true)
{
    Console.Write("Message: ");

    var message = Console.ReadLine()!;

    var result = await producer.ProduceAsync("test-topic", new Message<string, string>()
    {
        Key = Guid.NewGuid().ToString(),
        Value = message
    });

    Console.WriteLine($"Message sent. Offset: {result.TopicPartitionOffset}");
}