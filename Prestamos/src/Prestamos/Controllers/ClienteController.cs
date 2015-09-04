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

        //TODO Buscar un patron de EF7 para no tener que repetir el mismo query, talvez el patro repositorio?
        public IActionResult Details(int? id)
        {
            if(id.HasValue)
            {
                //TODO CORECLR Cambiar de where a Find cuando este implementado
                var cliente = db.Clientes.Where(c => c.Id == id).FirstOrDefault();
                if (cliente == null)
                    return base.HttpNotFound();

                return View(cliente);
            }
            else
            {
                return base.HttpBadRequest();
            }
        }

        public IActionResult Edit(int? id)
        {
            if(id.HasValue)
            {
                //TODO CORECLR Cambiar de where a Find cuando este implementado
                var cliente = db.Clientes.Where(c => c.Id == id).FirstOrDefault();
                if (cliente == null)
                    return base.HttpNotFound();

                return View(cliente);
            }
            else
            {
                return base.HttpBadRequest();
            }
        }
    }
}
