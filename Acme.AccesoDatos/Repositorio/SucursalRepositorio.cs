using Acme.Modelos;
using Acme.AccesoDatos.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.AccesoDatos.Data;

namespace Acme.AccesoDatos.Repositorio
{
    public class SucursalRepositorio : Repositorio<Sucursal>, IScursalRepositorio
    {
        private readonly ApplicationDbContext _db;
        public SucursalRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Sucursal sucursal)
        {
            var sucursalDb = _db.Sucursales.FirstOrDefault(b => b.Id == sucursal.Id);
            if (sucursalDb.Nombre != null)
            {
                sucursalDb.Nombre = sucursal.Nombre;
                sucursalDb.Descripcion = sucursal.Descripcion;
                sucursalDb.Estado = sucursal.Estado;

                
            }
        }


    }
}
