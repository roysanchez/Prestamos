using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Prestamos.Models;
using Prestamos.ViewModels.Cliente;
using Negocios;
using AutoMapper;
using Prestamos.Extensions;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Prestamos.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private const string BaseBindString = "PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, FechaNacimiento";
        private const string EditBindString = "Id, " + BaseBindString;
        private const string CreateBindString = "Cedula, " + BaseBindString;
        private readonly PrestamoContext db;
        private readonly IMapper mapper;

        public ClienteController(PrestamoContext prestamoContext, IMapper mapperConfig)
        {
            db = prestamoContext;
            mapper = mapperConfig;
        }

        // GET: /<controller>/
        [HttpGet]
        public async Task<IEnumerable<Cliente>> Get()
        {
            return await db.Clientes.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente =  await BuscarClienteId(id);

            if (cliente == null)
                return new HttpNotFoundResult();

            return new ObjectResult(cliente);
        }

        //TODO Sustituir todos los sitios donde se llame esto por Find, cuando se implemente
        private async Task<Cliente> BuscarClienteId(int? id)
        {
            return await db.Clientes.Where(c => c.Id == id).FirstOrDefaultAsync();
        }
        /*
        public async Task<IActionResult> BuscarClienteCedula(string cedula)
        {
            var cliente = await db.Clientes.Where(c => c.Cedula == cedula)
                                           .FirstOrDefaultAsync();
            
            return Json(mapper.Map<ClienteViewModel>(cliente));
        }

        [HttpPost]
        public async Task<IActionResult> BuscarClientes(BuscarClienteViewModel model)
        {
            var clientes = db.Clientes as IQueryable<Cliente>;

            if (!String.IsNullOrEmpty(model.Cedula))
                clientes = clientes.Where(c => c.Cedula.Contains(model.Cedula));

            if (!String.IsNullOrEmpty(model.Nombre))
                clientes = clientes.Where(c => c.PrimerNombre.Contains(model.Nombre) || c.SegundoNombre.Contains(model.Nombre));

            if (!String.IsNullOrEmpty(model.Apellido))
                clientes = clientes.Where(c => c.PrimerApellido.Contains(model.Apellido) || c.SegundoApellido.Contains(model.Apellido));
            
            return Json(mapper.Map<IEnumerable<ClienteViewModel>>(await clientes.ToListAsync()));
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            //var clientes = Mapper.Map<IEnumerable<ClienteViewModel>>(await db.Clientes.ToListAsync());
            var clientes = mapper.Map<IEnumerable<ClienteViewModel>>(await db.Clientes.ToListAsync());
            return View(clientes);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id.HasValue)
            {
                var cliente = await BuscarClienteId(id);
                if (cliente == null)
                    return base.HttpNotFound();

                return View(mapper.Map<ClienteViewModel>(cliente));
            }
            else
            {
                return base.HttpBadRequest();
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id.HasValue)
            {
                var cliente = await BuscarClienteId(id);
                if (cliente == null)
                    return base.HttpNotFound();

                return View(mapper.Map<ClienteViewModel>(cliente));
            }
            else
            {
                return base.HttpBadRequest();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind(include: EditBindString)]ClienteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cliente = await BuscarClienteId(model.Id);
                cliente.MergeWith(mapper.Map<Cliente>(model));

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(include: CreateBindString)]ClienteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cliente = mapper.Map<Cliente>(model);
                db.Entry(cliente).State = EntityState.Added;

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id.HasValue)
            {
                var cliente = await BuscarClienteId(id);
                if (cliente == null)
                    return base.HttpNotFound();

                return View(mapper.Map<ClienteViewModel>(cliente));
            }
            else
            {
                return base.HttpBadRequest();
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCofirmed(int? id)
        {
            if (id.HasValue)
            {
                var cliente = await BuscarClienteId(id);
                db.Clientes.Remove(cliente);

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("id", "El id es obligatorio");
                return View(id);
            }
        }
        */
    }
}
