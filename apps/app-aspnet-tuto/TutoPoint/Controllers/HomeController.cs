using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TutoPoint.Models;
using TutoPoint.Repositories;

namespace TutoPoint.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (FirstAppDemoDbContext context = new FirstAppDemoDbContext())
            {
                SQLEmployeeData sqlEmployeeData = new SQLEmployeeData(context);
                IEnumerable<Employee> employees = sqlEmployeeData.GetAll();
                HomePageViewModel viewModel = new HomePageViewModel();
                viewModel.Employees = employees;
                return View(viewModel);
            }
        }
        public RedirectToActionResult Add()
        {
            Employee employee = new Employee
            {
                Name = "employee - " + Guid.NewGuid().ToString().Substring(0, 5)
            };
            using (FirstAppDemoDbContext context = new FirstAppDemoDbContext())
            {
                SQLEmployeeData sqlData = new SQLEmployeeData(context);
                sqlData.Add(employee);
            }

            return RedirectToAction("Index");
        }

        public class HomePageViewModel
        {
            public IEnumerable<Employee> Employees { get; set; }
        }

        public ObjectResult Index5()
        {
            Employee employee = new Employee
            {
                Id = Guid.NewGuid(),
                Name = "Mark Upston"
            };
            ObjectResult objectResult = new ObjectResult(employee);
            return objectResult;
        }
        public ContentResult Index4()
        {
            ContentResult contentResult = Content("Hello, World! this message is from Home Controller using the Action Result");
            return contentResult;
        }
        public string Index3()
        {
            return "Hello, World! this message is from Home Controller...";
        }
        public IActionResult Index2()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            throw new System.NotImplementedException();
        }


    }
}