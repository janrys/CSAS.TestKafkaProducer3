using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAS.Abby.KafkaClient
{
    public class AbbyProducerConfiguration
    {
        public string BootstrapServers { get; set; }
        public string SchemaRegistryUrl { get; set; }
        public string TopicName { get; set; }
        public bool UseSsl { get; set; }
        public string CertCaPath { get; set; }
        public string ClientCertPath { get; set; }
        public string ClientKeyPath { get; set; }
        public string ClientKeyPassword { get; set; }
        public bool AutoRegisterSchema { get; set; } = false;
    }
}
