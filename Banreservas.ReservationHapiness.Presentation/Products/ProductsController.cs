using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MAP.OSP.Application.Features.Products.Queries.GetProductsList;

namespace MAP.OSP.Presentation.Products
{
    public class ProductsController : Controller
    {
        private readonly IGetProductsListQuery _query;

        public ProductsController(IGetProductsListQuery query)
        {
            _query = query;
        }

        public ViewResult Index()
        {
            var products = _query.Execute();

            return View(products);
        }
    }
}