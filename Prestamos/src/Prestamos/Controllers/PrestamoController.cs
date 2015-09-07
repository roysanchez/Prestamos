using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Prestamos.Models;
using AutoMapper;
using Microsoft.Data.Entity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Prestamos.Controllers
{
    public class PrestamoController : Controller
    {
        private readonly PrestamoContext db;

        public PrestamoController(PrestamoContext prestamoContext)
        {
            db = prestamoContext;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var prest = Mapper.Map<IEnumerable<PrestamoViewModel>>(await db.Prestamos.ToListAsync());
            return View(prest);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
