using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using cz.csas.avroschemas.administeredpayment_processpayment.v03_01;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CSAS.Abby.KafkaClient
{
    public class AbbyProducer
    {
        private readonly AbbyProducerConfiguration configuration;
        private ProducerConfig producerConfig;
        private SchemaRegistryConfig schemaRegistryConfig;
        private AvroSerializerConfig avroSerializerConfig;

        /// <summary>
        /// Loads the native Kafka librd library. Usually you don't to load it explicitly. 
        /// </summary>
        /// <param name="libraryPath">Path to Kafka native library including library name, e.g. D:\KafkaLibrary\\x64\\librdkafka.dll</param>
        public static void LoadKafkaNativeLibraries(string libraryPath)
        {
            Library.Load(libraryPath);
        }

        public AbbyProducer(AbbyProducerConfiguration configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.InitConfigurations();
        }

        public AbbyProducer(string configurationFilePath)
        {
            if (string.IsNullOrEmpty(configurationFilePath))
            {
                throw new ArgumentException($"'{nameof(configurationFilePath)}' cannot be null or empty.", nameof(configurationFilePath));
            }

            if (!File.Exists(configurationFilePath))
            {
                throw new Exception($"File {configurationFilePath} does not exist");
            }

            try
            {
                using (StreamReader fileReader = File.OpenText(configurationFilePath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    this.configuration = (AbbyProducerConfiguration)serializer.Deserialize(fileReader, typeof(AbbyProducerConfiguration));
                }
            }
            catch (Exception exception)
            {
                throw new Exception($"Cannot read configuration from file {configurationFilePath}", exception);
            }

            this.InitConfigurations();
        }

        private void InitConfigurations()
        {
            if (string.IsNullOrEmpty(this.configuration.BootstrapServers))
            {
                throw new ArgumentException($"'{nameof(this.configuration.BootstrapServers)}' cannot be null or empty", nameof(this.configuration.BootstrapServers));
            }

            if (string.IsNullOrEmpty(this.configuration.SchemaRegistryUrl))
            {
                throw new ArgumentException($"'{nameof(this.configuration.SchemaRegistryUrl)}' cannot be null or empty", nameof(this.configuration.SchemaRegistryUrl));
            }

            if (string.IsNullOrEmpty(this.configuration.TopicName))
            {
                throw new ArgumentException($"'{nameof(this.configuration.TopicName)}' cannot be null or empty", nameof(this.configuration.TopicName));
            }

            this.producerConfig = new ProducerConfig
            {
                BootstrapServers = this.configuration.BootstrapServers,
                ApiVersionRequestTimeoutMs = 30000
            };

            this.schemaRegistryConfig = new SchemaRegistryConfig
            {
                Url = this.configuration.SchemaRegistryUrl,
            };

            this.avroSerializerConfig = new AvroSerializerConfig
            {
                BufferBytes = 100,
                AutoRegisterSchemas = this.configuration.AutoRegisterSchema,
                SubjectNameStrategy = SubjectNameStrategy.Topic,
                UseLatestVersion = true,
            };

            if (this.configuration.UseSsl)
            {
                if (string.IsNullOrEmpty(this.configuration.CertCaPath))
                {
                    throw new ArgumentException($"'{nameof(this.configuration.CertCaPath)}' cannot be null or empty", nameof(this.configuration.CertCaPath));
                }

                if (!File.Exists(this.configuration.CertCaPath))
                {
                    throw new Exception($"File {this.configuration.CertCaPath} does not exist");
                }

                if (string.IsNullOrEmpty(this.configuration.ClientCertPath))
                {
                    throw new ArgumentException($"'{nameof(this.configuration.ClientCertPath)}' cannot be null or empty", nameof(this.configuration.ClientCertPath));
                }

                if (!File.Exists(this.configuration.ClientCertPath))
                {
                    throw new Exception($"File {this.configuration.ClientCertPath} does not exist");
                }

                if (string.IsNullOrEmpty(this.configuration.ClientKeyPath))
                {
                    throw new ArgumentException($"'{nameof(this.configuration.ClientKeyPath)}' cannot be null or empty", nameof(this.configuration.ClientKeyPath));
                }

                if (!File.Exists(this.configuration.ClientKeyPath))
                {
                    throw new Exception($"File {this.configuration.ClientKeyPath} does not exist");
                }

                if (string.IsNullOrEmpty(this.configuration.ClientKeyPassword))
                {
                    throw new ArgumentException($"'{nameof(this.configuration.ClientKeyPassword)}' cannot be null or empty", nameof(this.configuration.ClientKeyPassword));
                }

                this.producerConfig.SecurityProtocol = SecurityProtocol.Ssl;
                this.producerConfig.SslCaLocation = this.configuration.CertCaPath;
                this.producerConfig.SslCertificateLocation = this.configuration.ClientCertPath;
                this.producerConfig.SslKeyLocation = this.configuration.ClientKeyPath;
                this.producerConfig.SslKeyPassword = this.configuration.ClientKeyPassword;
            }
        }


        public async Task Send(params KeyValuePair<string, AdministeredPayment_processPayment>[] records)
        {
            if (records is null)
            {
                throw new ArgumentNullException(nameof(records));
            }

            if (records.Any(r => r.Value == null))
            {
                throw new ArgumentNullException(nameof(records), "All records must have a value");
            }

            //var schemaRegistryTest = new CachedSchemaRegistryClient(schemaRegistryConfig);
            //var schemas = await schemaRegistryTest.GetLatestSchemaAsync(this.configuration.TopicName+"-value");
            //var isCompatible = await schemaRegistryTest.IsCompatibleAsync(this.configuration.TopicName + "-value"
            //    , new Schema(records[0].Value.Schema.ToString(), SchemaType.Avro));



            //var avroSerializerTest = new AvroSerializer<AdministeredPayment_processPayment>(schemaRegistryTest, avroSerializerConfig);
            //var message = await avroSerializerTest.SerializeAsync(records[0].Value, new SerializationContext(MessageComponentType.Value, this.configuration.TopicName));
            

            CancellationTokenSource cts = new CancellationTokenSource();
            using (CachedSchemaRegistryClient schemaRegistry = new CachedSchemaRegistryClient(schemaRegistryConfig))
            using (IProducer<string, AdministeredPayment_processPayment> producer =
                new ProducerBuilder<string, AdministeredPayment_processPayment>(producerConfig)
                    .SetKeySerializer(Serializers.Utf8)
                    .SetValueSerializer(new AvroSerializer<AdministeredPayment_processPayment>(schemaRegistry, avroSerializerConfig))
                    .SetErrorHandler(errorHandler)
                    .Build())
            {
                foreach (KeyValuePair<string, AdministeredPayment_processPayment> record in records)
                {
                    string key = string.IsNullOrEmpty(record.Key) ? this.GenerateNewMessageKey() : record.Key;

                    await producer
                   .ProduceAsync(this.configuration.TopicName, new Message<string, AdministeredPayment_processPayment> { Key = key, Value = record.Value })
                    .ContinueWith(task =>
                    {
                        if (task.IsFaulted)
                        {
                            Console.WriteLine($"error producing message: {task.Exception.InnerException}");
                            throw new Exception("Error occured during message send", task.Exception.InnerException);
                        }
                        else
                        {
                            Console.WriteLine($"produced to: {task.Result.TopicPartitionOffset}");
                        }
                    });
                }
            }

            cts.Cancel();
        }

        public Task Send(params AdministeredPayment_processPayment[] records)
        {
            if (records is null)
            {
                throw new ArgumentNullException(nameof(records));
            }

            return this.Send(records.Select(r => new KeyValuePair<string, AdministeredPayment_processPayment>(this.GenerateNewMessageKey(), r)).ToArray());
        }

        public Task Send(AdministeredPayment_processPayment record) => this.Send(this.GenerateNewMessageKey(), record);
        public Task Send(string key, AdministeredPayment_processPayment record) => this.Send(new KeyValuePair<string, AdministeredPayment_processPayment>(key, record));

        public async Task SendFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException($"'{nameof(filePath)}' cannot be null or empty.", nameof(filePath));
            }

            if (!File.Exists(filePath))
            {
                throw new Exception($"File {filePath} does not exist");
            }

            AdministeredPayment_processPayment[] messages;
            try
            {
                using (StreamReader fileReader = File.OpenText(filePath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    messages = (AdministeredPayment_processPayment[])serializer.Deserialize(fileReader, typeof(AdministeredPayment_processPayment[]));
                }
            }
            catch (Exception exception)
            {
                throw new Exception($"Cannot read message file {filePath}", exception);
            }

            if (messages != null && messages.Any())
            {
                await this.Send(messages);
            }
        }

        private string GenerateNewMessageKey() => Guid.NewGuid().ToString();

        private void errorHandler(IProducer<string, AdministeredPayment_processPayment> producer, Error error)
        {
            Console.WriteLine(producer);
            Console.WriteLine(error);
            throw new Exception($"Error occured during message send. Error {error.Code} {error.Reason}, is local: {error.IsLocalError}, is from broker: {error.IsBrokerError}");
        }
    }
}
