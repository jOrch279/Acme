using Acme.AccesoDatos.Data;
using Acme.AccesoDatos.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.AccesoDatos.Repositorio
{
    public class UnidadTrabajo :IUnidadTrabajo
    {
        private readonly ApplicationDbContext _db;
       

        public IScursalRepositorio Sucursal { get; private set; }

        public UnidadTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Sucursal = new SucursalRepositorio(_db);

        }

        public void Guardar()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
