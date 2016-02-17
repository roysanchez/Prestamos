using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Prestamos.Models;
using Prestamos.ViewModels.Prestamo;
using AutoMapper;
using Microsoft.Data.Entity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Prestamos.Controllers
{
    public class PrestamoController : Controller
    {
        private readonly PrestamoContext db;
        private readonly IMapper mapper;

        public PrestamoController(PrestamoContext prestamoContext, IMapper mapperConfig)
        {
            db = prestamoContext;
            mapper = mapperConfig;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            //var prest = Mapper.Map<IEnumerable<PrestamoViewModel>>(await db.Prestamos.ToListAsync());
            var prest = mapper.Map<IEnumerable<PrestamoViewModel>>(await db.Prestamos.ToListAsync());
            return View(prest);
        }

        public IActionResult Create()
        {
            return View(new PrestamoViewModel() { Deudor = new ViewModels.Cliente.ClienteViewModel()});
        }

        [HttpPost]
        public IActionResult Create(PrestamoViewModel model)
        {
            if(ModelState.IsValid)
            {

            }

            return View(model);
        }
    }
}
