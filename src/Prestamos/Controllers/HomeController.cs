using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Prestamos.Models;
using Microsoft.Data.Entity;

namespace Prestamos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly PrestamoContext _prestamoContext;
        private static bool _databaseChecked;

        public HomeController(
            ApplicationDbContext applicationDbContext,
            PrestamoContext prestamoContext)
        {
            _applicationDbContext = applicationDbContext;
            _prestamoContext = prestamoContext;
        }

        public IActionResult Index()
        {
            EnsureDatabaseCreated(_applicationDbContext, _prestamoContext);
            return View();
        }

        public IActionResult Prueba()
        {



            return Json(new { roy = "Es el mejor" });
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }

        // The following code creates the database and schema if they don't exist.
        // This is a temporary workaround since deploying database through EF migrations is
        // not yet supported in this release.
        // Please see this http://go.microsoft.com/fwlink/?LinkID=615859 for more information on how to do deploy the database
        // when publishing your application.
        private static void EnsureDatabaseCreated(ApplicationDbContext _appcontext, PrestamoContext _prescontext)
        {
            if (!_databaseChecked)
            {
                _databaseChecked = true;
                _appcontext.Database.Migrate();
                _prescontext.Database.Migrate();
            }
        }
    }
}
