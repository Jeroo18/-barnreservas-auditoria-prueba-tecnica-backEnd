using System;
using System.Collections.Generic;
using System.Linq;

namespace Banreservas.ReservationHapiness.Infrastructure.Network
{
    public interface IHttpClientWrapper
    {
        void Post(string address, string json);
    }
}