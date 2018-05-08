using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GggWebApplication.Controllers
{
    /// <summary>
    /// Filters in ASP.NET Core MVC allow you to run code before or
    /// after specific stages in the request processing pipeline
    /// https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-2.1
    /// </summary>
    public class FilterExamplesController : Controller
    {
        // GET: FilterExamples
        public ActionResult Index()
        {
            return View();
        }

        // GET: FilterExamples/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FilterExamples/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FilterExamples/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FilterExamples/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FilterExamples/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FilterExamples/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FilterExamples/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}