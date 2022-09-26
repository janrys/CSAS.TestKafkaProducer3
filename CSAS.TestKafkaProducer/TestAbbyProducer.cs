using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using cz.csas.avroschemas.abbyadministeredpayments.v03_01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSAS.TestKafkaProducer
{
    public class TestAbbyProducer
    {
        private ProducerConfig producerConfig;
        private SchemaRegistryConfig schemaRegistryConfig;
        private AvroSerializerConfig avroSerializerConfig;
        private string topicName;


        public TestAbbyProducer(string bootstrapServers, string schemaRegistryUrl, string topicName)
        {
            if (string.IsNullOrEmpty(bootstrapServers))
            {
                throw new ArgumentException($"'{nameof(bootstrapServers)}' cannot be null or empty", nameof(bootstrapServers));
            }

            if (string.IsNullOrEmpty(schemaRegistryUrl))
            {
                throw new ArgumentException($"'{nameof(schemaRegistryUrl)}' cannot be null or empty", nameof(schemaRegistryUrl));
            }

            if (string.IsNullOrEmpty(topicName))
            {
                throw new ArgumentException($"'{nameof(topicName)}' cannot be null or empty", nameof(topicName));
            }

            this.producerConfig = new ProducerConfig
            {
                BootstrapServers = bootstrapServers,
                ApiVersionRequestTimeoutMs = 30000
            };

            this.schemaRegistryConfig = new SchemaRegistryConfig
            {
                Url = schemaRegistryUrl
            };

            this.avroSerializerConfig = new AvroSerializerConfig
            {
                BufferBytes = 100
            };

            this.topicName = topicName;
        }

        public async Task Send(string key, AbbyAdministeresPayments record)
        {
            if (String.IsNullOrEmpty(key))
            {
                key = Guid.NewGuid().ToString();
            }

            if (record is null)
            {
                throw new ArgumentNullException(nameof(record));
            }

            CancellationTokenSource cts = new CancellationTokenSource();
            using (CachedSchemaRegistryClient schemaRegistry = new CachedSchemaRegistryClient(schemaRegistryConfig))
            using (IProducer<string, AbbyAdministeresPayments> producer =
                new ProducerBuilder<string, AbbyAdministeresPayments>(producerConfig)
                    //.SetKeySerializer(Serializers.Utf8)
                    .SetKeySerializer(new AvroSerializer<string>(schemaRegistry, avroSerializerConfig))
                    .SetValueSerializer(new AvroSerializer<AbbyAdministeresPayments>(schemaRegistry, avroSerializerConfig))
                    .SetErrorHandler(errorHandler)
                    .Build())
            {
                await producer
                    .ProduceAsync(topicName, new Message<string, AbbyAdministeresPayments> { Key = key, Value = record })
                    .ContinueWith(task =>
                    {
                        if (!task.IsFaulted)
                        {
                            Console.WriteLine($"produced to: {task.Result.TopicPartitionOffset}");
                        }

                        Console.WriteLine($"error producing message: {task.Exception.InnerException}");
                    });
            }

            cts.Cancel();
        }

        private void errorHandler(IProducer<string, AbbyAdministeresPayments> producer, Error error)
        {
            Console.WriteLine(producer);
            Console.WriteLine(error);
        }
    }
}

