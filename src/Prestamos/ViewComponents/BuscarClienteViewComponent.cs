﻿using AutoMapper;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Negocios;
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

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await InvokeAsync(new BuscarClienteViewModel());
        }

        public async Task<IViewComponentResult> InvokeAsync(BuscarClienteViewModel model)
        {
            var clientes = db.Clientes as IQueryable<Cliente>;

            if (!String.IsNullOrEmpty(model.Cedula))
                clientes = clientes.Where(c => c.Cedula.Contains(model.Cedula));

            if (!String.IsNullOrEmpty(model.Nombre))
                clientes = clientes.Where(c => c.PrimerNombre.Contains(model.Nombre) || c.SegundoNombre.Contains(model.Nombre));

            if (!String.IsNullOrEmpty(model.Apellido))
                clientes = clientes.Where(c => c.PrimerApellido.Contains(model.Apellido) || c.SegundoApellido.Contains(model.Apellido));

            ViewBag.clientes = Mapper.Map<IEnumerable<ClienteViewModel>>(await clientes.ToListAsync());
            return View(model);
        }

    }
}
