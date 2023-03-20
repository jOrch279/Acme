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



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Sucursal sucursal)
        {
            if (ModelState.IsValid)
            {
                if (sucursal.Id ==0)
                {
                    _unidadTrabajo.Sucursal.Agregar(sucursal);
                }
                else
                {
                    _unidadTrabajo.Sucursal.Actualizar(sucursal);
                }
                _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
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

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var sucursalDb = _unidadTrabajo.Sucursal.Obtener(id);
            if (sucursalDb == null)
            {
                return Json(new { success = false, message = "Error al borrar" });
            }
            _unidadTrabajo.Sucursal.Remover(sucursalDb);
            _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Bodega borrada" });
        }

        #endregion
    }
}
