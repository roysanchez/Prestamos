using AutoMapper;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Prestamos.Models;
using Prestamos.ViewModels.Cliente;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prestamos.ViewComponents
{
    public class BuscarClienteViewComponent : ViewComponent
    {
        private readonly PrestamoContext db;

        public BuscarClienteViewComponent(PrestamoContext context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string nombre)
        {
            var clientes = await db.Clientes.Where(c => c.PrimerNombre.Contains(nombre) || c.SegundoNombre.Contains(nombre)).ToListAsync();
                        
            return View(Mapper.Map<IEnumerable<ClienteViewModel>>(clientes));
        }

    }
}
