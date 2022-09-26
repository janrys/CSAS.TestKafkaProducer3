using cz.csas.avroschemas.administeredpayment_processpayment.v03_01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSAS.Abby.KafkaClient.Console
{
    class Program
    {
        private const int MESSAGE_COUNT_LIMIT = 10;

        static async Task Main(string[] args)
        {
            /// -nlp
            string nativeLibraryPath = @"d:\Data\Sources\CSAS\CSAS.TestKafkaProducer\CSAS.Abby.KafkaClient\bin\Debug\librdkafka\x86\librdkafka.dll";
            /// -ssl
            Boolean useSsl = false;
            /// -topic
           //string topicName = "dotNetLibraryTest1";
            string topicName = "CMD.AdministeredPayment_processPayment";
            /// -bootstrap
            //string bootstrapServers = "dpkafda11.vs.csin.cz:9092";
            string bootstrapServers = "tpkafast21.vs.csin.cz:9092";
            /// -schemareg
            //string schemaRegistryUrl = "http://deva-mw-kafka.vs.csin.cz:9081";
            string schemaRegistryUrl = "http://tpkafast21.vs.csin.cz:9081";
            /// -cpath
            string certCaPath = null;
            /// -clcpath
            string clientCertPath = null;
            /// -clkpath
            string clientKeyPath = null;
            /// -clkpass
            string clientKeyPassword = null;

            if (args != null && args.Any())
            {
                string argument = args.FirstOrDefault(a => a.StartsWith("-nlp"));

                if (!string.IsNullOrEmpty(argument))
                {
                    nativeLibraryPath = argument.Replace("-nlp:", "").Trim();
                }

                argument = args.FirstOrDefault(a => a.StartsWith("-ssl"));

                if (!string.IsNullOrEmpty(argument))
                {
                    argument = argument.Replace("-ssl:", "").Trim();

                    if (Boolean.TryParse(argument, out bool parsedBoolean))
                    {
                        useSsl = parsedBoolean;
                    }
                }

                argument = args.FirstOrDefault(a => a.StartsWith("-topic"));

                if (!string.IsNullOrEmpty(argument))
                {
                    topicName = argument.Replace("-topic:", "").Trim();
                }

                argument = args.FirstOrDefault(a => a.StartsWith("-bootstrap"));

                if (!string.IsNullOrEmpty(argument))
                {
                    bootstrapServers = argument.Replace("-bootstrap:", "").Trim();
                }

                argument = args.FirstOrDefault(a => a.StartsWith("-schemareg"));

                if (!string.IsNullOrEmpty(argument))
                {
                    schemaRegistryUrl = argument.Replace("-schemareg:", "").Trim();
                }

                argument = args.FirstOrDefault(a => a.StartsWith("-cpath"));

                if (!string.IsNullOrEmpty(argument))
                {
                    certCaPath = argument.Replace("-cpath:", "").Trim();
                }

                argument = args.FirstOrDefault(a => a.StartsWith("-clcpath"));

                if (!string.IsNullOrEmpty(argument))
                {
                    clientCertPath = argument.Replace("-clcpath:", "").Trim();
                }

                argument = args.FirstOrDefault(a => a.StartsWith("-clkpath"));

                if (!string.IsNullOrEmpty(argument))
                {
                    clientKeyPath = argument.Replace("-clkpath:", "").Trim();
                }

                argument = args.FirstOrDefault(a => a.StartsWith("-clkpass"));

                if (!string.IsNullOrEmpty(argument))
                {
                    clientKeyPassword = argument.Replace("-clkpass:", "").Trim();
                }
            }

            if (!string.IsNullOrEmpty(nativeLibraryPath))
            {
                AbbyProducer.LoadKafkaNativeLibraries(nativeLibraryPath);
            }

            AbbyProducerConfiguration configuration = new AbbyProducerConfiguration()
            {
                UseSsl = useSsl,
                TopicName = topicName,
                BootstrapServers = bootstrapServers,
                SchemaRegistryUrl = schemaRegistryUrl,
                CertCaPath = certCaPath,
                ClientCertPath = clientCertPath,
                ClientKeyPath = clientKeyPath,
                ClientKeyPassword = clientKeyPassword,
                AutoRegisterSchema = false,
            };

            AbbyProducer producer = new AbbyProducer(configuration);
            foreach (AdministeredPayment_processPayment record in GenerateRecord())
            {
                await producer.Send(record);
            }

            System.Console.WriteLine("Messages send. Press ENTER");
            System.Console.ReadLine();
        }

        private static IEnumerable<AdministeredPayment_processPayment> GenerateRecord()
        {
            int messageGenerated = 0;

            while (messageGenerated < MESSAGE_COUNT_LIMIT)
            {
                messageGenerated++;
                yield return new AdministeredPayment_processPayment()
                {
                    channel = $"channel-{messageGenerated}",
                    externalLiabilityIds = new List<ExternalLiability>(
                        new ExternalLiability[] { new ExternalLiability() { externalLiabilityId = $"externalLiabilityId-{messageGenerated}" } }
                        ),
                    orgUnitId = $"orgUnitId-{messageGenerated}",
                    paymentInstruction = new PaymentInstruction()
                    {
                        domesticAccount = new DomesticAccount()
                        {
                            accountNumber = $"accountNumber-{messageGenerated}",
                            accountPrefix = $"accountPrefix-{messageGenerated}",
                            bankCode = $"bankCode-{messageGenerated}",
                        },
                        foreignAccount = new ForeignAccount()
                        {
                            accountName = $"accountName-{messageGenerated}",
                            bic = $"bic-{messageGenerated}",
                            iban = $"banibankCode-{messageGenerated}",
                            notice = $"notice-{messageGenerated}",
                        }
                    },
                    paymentReceiver = new PaymentReceiver()
                    {
                        liabilityPaymentRoleType = $"liabilityPaymentRoleType-{messageGenerated}",
                        verified = true,
                        permanentAddress = new PermanentAddress()
                        {
                            l1_recipient = $"l1_recipient-{messageGenerated}",
                            l2_supplement = $"l2_supplement-{messageGenerated}",
                            l3_street = $"l3_street-{messageGenerated}",
                            l4_city = $"l4_city-{messageGenerated}",
                            l5_zipcode = $"l5_zipcode-{messageGenerated}",
                            l6_country = $"l6_country-{messageGenerated}",
                        },
                        idCard = new IdCard()
                        {
                            cardNumber = $"cardNumber-{messageGenerated}",
                            cardType = $"cardType-{messageGenerated}",
                            issuer = $"issuer-{messageGenerated}",
                            issuerCountry = $"issuerCountry-{messageGenerated}",
                            validUntil = DateTime.UtcNow,
                        },
                        person = new Person()
                        {
                            additionalDegree = $"additionalDegree-{messageGenerated}",
                            birthCountry = $"birthCountry-{messageGenerated}",
                            birthPlace = $"birthPlace-{messageGenerated}",
                            citizenships = new List<Citizenship>(
                                          new Citizenship[] { new Citizenship() { citizenship = "" } }),
                            degree = $"degree-{messageGenerated}",
                            email = $"email-{messageGenerated}",
                            forename = $"forename-{messageGenerated}",
                            gender = $"gender-{messageGenerated}",
                            personalId = $"personalId-{messageGenerated}",
                            surname = $"surname-{messageGenerated}",
                            taxResidency = $"taxResidency-{messageGenerated}",
                        }
                    },
                    requestDate = DateTime.UtcNow,
                    requestId = $"requestId-{messageGenerated}",
                    token = $"token-{messageGenerated}",
                    userName = $"userName-{messageGenerated}",
                };
            }
        }
    }
}
