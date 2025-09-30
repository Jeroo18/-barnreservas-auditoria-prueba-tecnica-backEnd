using System;
using Microsoft.AspNetCore.Mvc;
using MAP.OSP.Application.Features.Employees.Queries.GetEmployeesList;

namespace MAP.OSP.Presentation.Employees
{
    public class EmployeesController : Controller
    {
        private readonly IGetEmployeesListQuery _query;

        public EmployeesController(IGetEmployeesListQuery query)
        {
            _query = query;
        }

        public ViewResult Index()
        {
            var employees = _query.Execute();

            return View(employees);
        }
    }
}