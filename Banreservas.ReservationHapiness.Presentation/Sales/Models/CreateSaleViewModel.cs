using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MAP.OSP.Application.Features.Sales.Commands.CreateSale;

namespace MAP.OSP.Presentation.Sales.Models
{
    public class CreateSaleViewModel
    {
        public List<SelectListItem> Customers { get; set; }

        public List<SelectListItem> Employees { get; set; }

        public List<SelectListItem> Products { get; set; }

        public CreateSaleModel Sale { get; set; }
    }
}