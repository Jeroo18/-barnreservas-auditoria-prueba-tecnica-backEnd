using System;
using System.Collections.Generic;
using System.Linq;
using Banreservas.ReservationHapiness.Application.Interfaces;
using Banreservas.ReservationHapiness.Infrastructure.Network;

namespace Banreservas.ReservationHapiness.Infrastructure.Inventory
{
    public class InventoryService 
        : IInventoryService
    {
        // Note: these are hard coded to keep the demo simple
        private const string AddressTemplate = "http://abc123.com/inventory/products/{0}/notifysaleoccured/";
        private const string JsonTemplate = "{{\"quantity\": {0}}}";

        private readonly IHttpClientWrapper _client;

        public InventoryService(IHttpClientWrapper client)
        {
            _client = client;
        }

        public void NotifySaleOccurred(int productId, int quantity)
        {
            var address = string.Format(AddressTemplate, productId);

            var json = string.Format(JsonTemplate, quantity);

            _client.Post(address, json);
        }
    }
}
