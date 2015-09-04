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
        private readonly PrestamoContext db;

        public ClienteController(PrestamoContext prestamoContext)
        {
            db = prestamoContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var clientes = db.Clientes.ToList();
            return View(clientes);
        }
    }
}
