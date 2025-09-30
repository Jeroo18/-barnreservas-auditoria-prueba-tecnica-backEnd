using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banreservas.ReservationHapiness.Application.Models.Authentication
{
    public class RequestResult<T>
    {
        public IList<T> Data { get; set; }
        public int Total { get; set; }
    }
}
