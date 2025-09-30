using System;
using Microsoft.AspNetCore.Mvc;
using MAP.OSP.Application.Features.Customers.Queries.GetCustomerList;

namespace MAP.OSP.Presentation.Customers
{
    public class CustomersController : Controller
    {
        private readonly IGetCustomersListQuery _query;

        public CustomersController(IGetCustomersListQuery query)
        {
            _query = query;
        }

        public ViewResult Index()
        {
            var customers = _query.Execute();

            return View(customers);
        }
    }
}