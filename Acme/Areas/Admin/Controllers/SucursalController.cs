using Acme.AccesoDatos.Repositorio.IRepositorio;
using Acme.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acme.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SucursalController : Controller
    {

        private readonly IUnidadTrabajo _unidadTrabajo;

        public SucursalController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Sucursal sucursal = new Sucursal();
            if (id == null)
            {
                // esto es para crear un nuevo registro
                return View(sucursal);

            }
            // esto es para actualizar
            sucursal = _unidadTrabajo.Sucursal.Obtener(id.GetValueOrDefault());
            if (sucursal == null)
            {
                return NotFound();
            }

            return View(sucursal);
        }




        #region API
        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            var todos = _unidadTrabajo.Sucursal.ObtenerTodos();
            return Json(new { data = todos });
        }
        #endregion
    }
}
