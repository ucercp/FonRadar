using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonRadar.Service.Abstract
{
    public interface IPublisEvent
    {
        void Publish<TEvent>(TEvent eventMessage);
    }
}
