using System;
using System.Collections.Generic;
using System.Linq;

namespace Banreservas.ReservationHapiness.Application.Interfaces
{
    public interface IInventoryService
    {
        void NotifySaleOccurred(int productId, int quantity);
    }
}
