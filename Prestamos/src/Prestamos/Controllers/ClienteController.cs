using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using Prestamos.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Prestamos.Controllers
{
    
    public class ClienteController : Controller
    {
        PrestamoContext _db;

        public ClienteController(PrestamoContext prestamoContext)
        {
            _db = prestamoContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var c = _db.Clientes.Count();

            return View();
        }



    }
}
