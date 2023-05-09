using Confluent.Kafka;
using CQRS.Core.Consumers;
using Microsoft.Extensions.Options;
using Post.Query.Infrastructure.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Query.Infrastructure.Consumers
{
    public class EventConsumer : IEventConsumer
    {
        private readonly ConsumerConfig _config;
        private readonly IEventHandler _eventHandler;

        public EventConsumer(IOptions<ConsumerConfig> config, IEventHandler eventHandler)
        {
            _config = config.Value;
            _eventHandler = eventHandler;
        }

        public void Consumer(string topic)
        {
            using var consumer = new ConsumerBuilder<string, string>(_config)
                .SetKeyDeserializer(Deserializers.Utf8)
                .SetValueDeserializer(Deserializers.Utf8)
                .Build();

            consumer.Subscribe(topic);

            while(true)
            {
                var consumerResult = consumer.Consume();
            }
        }
    }
}
