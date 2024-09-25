using FonRadar.Service.Abstract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonRadar.Service.Concrete
{
    public class PublisEvent:IPublisEvent
    {
        private readonly IServiceProvider _serviceProvider;

        public PublisEvent(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Publish<TEvent>(TEvent eventMessage)
        {
            var subscribers = _serviceProvider.GetServices<IHandlerEvent<TEvent>>();
            foreach (var subscriber in subscribers)
            {
                subscriber.Handle(eventMessage);
            }
        }
    }
}
