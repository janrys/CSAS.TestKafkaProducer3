using AutoFixture;
using CSAS.TestKafkaProducer;
using cz.csas.avroschemas.abbyadministeredpayments.v03_01;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace CSAS.Test.TestKafkaProducer
{
    [TestClass]
    public class TestAbbyProducerTest
    {
        [TestMethod]
        public async Task SendTest()
        {
            string boostrapServers = "dpkafda11.vs.csin.cz:9092";
            string schemaRegistryUrl = "http://deva-mw-kafka.vs.csin.cz:9081";
            string topicName = "dotNetLibraryTest1";
            TestAbbyProducer sut = new TestAbbyProducer(boostrapServers, schemaRegistryUrl, topicName);
            AbbyAdministeresPayments record = null;

            for (int i = 0; i < 50; i++)
            {
                record = new Fixture().Create<AbbyAdministeresPayments>();
                await sut.Send($"{Guid.NewGuid()}".ToString(), record);

            }
            Assert.IsFalse(String.IsNullOrEmpty(record.claimId));
        }
    }
}
