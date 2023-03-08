using Acme.AccesoDatos.Repositorio.IRepositorio;
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
