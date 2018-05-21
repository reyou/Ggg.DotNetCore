using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TutoPoint.Models;
using TutoPoint.Repositories;
using ContentResult = Microsoft.AspNetCore.Mvc.ContentResult;
using Controller = Microsoft.AspNetCore.Mvc.Controller;

namespace TutoPoint.Controllers
{
    /// <summary>
    /// https://www.tutorialspoint.com/asp.net_core/asp.net_core_authorize_attribute.htm
    /// https://msdn.microsoft.com/en-us/library/system.web.mvc.authorizeattribute(v=vs.118).aspx
    /// Specifies that access to a controller or action method is restricted
    /// to users who meet the authorization requirement.
    /// </summary>
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Details(Guid id)
        {
            FirstAppDemoDbContext context = new FirstAppDemoDbContext();
            SQLEmployeeData sqlData = new SQLEmployeeData(context);
            Employee model = sqlData.Get(id);

            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        /// <summary>
        /// Represents an attribute that marks controllers and actions to
        /// skip the AuthorizeAttribute during authorization.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
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

        /// <summary>
        /// https://www.tutorialspoint.com/asp.net_core/asp.net_core_razor_edit_form.htm
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IActionResult Edit(Guid id)
        {
            FirstAppDemoDbContext context = new FirstAppDemoDbContext();
            SQLEmployeeData sqlData = new SQLEmployeeData(context);
            Employee model = sqlData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// https://www.tutorialspoint.com/asp.net_core/asp.net_core_razor_edit_form.htm
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IActionResult Edit(Guid id, Employee input)
        {
            var context = new FirstAppDemoDbContext();
            SQLEmployeeData sqlData = new SQLEmployeeData(context);
            var employee = sqlData.Get(id);

            if (employee != null && ModelState.IsValid)
            {
                employee.Name = input.Name;
                context.SaveChanges();
                return RedirectToAction("Details", new { id = employee.Id });
            }
            return View(employee);
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IActionResult Create(Employee input)
        {
            FirstAppDemoDbContext context = new FirstAppDemoDbContext();
            SQLEmployeeData sqlData = new SQLEmployeeData(context);
            if (string.IsNullOrEmpty(input.Name))
            {
                input.Name = Guid.NewGuid().ToString();
            }
            Employee employee = new Employee()
            {
                Name = input.Name
            };
            sqlData.Add(employee);

            if (ModelState.IsValid)
            {
                employee.Name = input.Name;
                context.SaveChanges();
                return RedirectToAction("Details", new { id = employee.Id });
            }
            return View(employee);
        }

    }
}