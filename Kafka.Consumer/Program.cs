using Confluent.Kafka;

string groupId = args.Length > 0 ? args[0] : "test-consumer-group";

var config = new ConsumerConfig()
{
    BootstrapServers = "localhost:9092",
    GroupId = groupId,
    AutoOffsetReset = AutoOffsetReset.Earliest,
    EnableAutoCommit = true
};

using var consumer = new ConsumerBuilder<string, string>(config).Build();

while (true)
{
    Console.WriteLine("Mesajı bekliyorum....");
    consumer.Subscribe("test-topic");

    var result = consumer.Consume();

    Console.WriteLine($"Key: {result.Message.Key}, Value: {result.Message.Value}, Partition Offset: {result.TopicPartitionOffset}");
}