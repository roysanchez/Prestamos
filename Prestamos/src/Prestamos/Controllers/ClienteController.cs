using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Prestamos.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Prestamos.Controllers
{
    public class ClienteController : Controller
    {
        private readonly PrestamoContext _prestamoContext;

        public ClienteController(PrestamoContext prestamoContext)
        {
            _prestamoContext = prestamoContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
