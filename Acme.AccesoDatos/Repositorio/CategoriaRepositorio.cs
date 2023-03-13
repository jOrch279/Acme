using Acme.AccesoDatos.Data;
using Acme.AccesoDatos.Repositorio.IRepositorio;
using Acme.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.AccesoDatos.Repositorio
{
    class CategoriaRepositorio : Repositorio<Categoria>, ICategoriaRepositorio
    {

        private readonly ApplicationDbContext _db;
        
        public CategoriaRepositorio(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }
        

        public void Actualizar(Categoria categoria)
        {
            var categoriaDB = _db.Categorias.FirstOrDefault(b => b.Id == categoria.Id);
            if(categoriaDB != null)
            {
                categoriaDB.Nombre = categoria.Nombre;
                categoriaDB.Estado = categoria.Estado;
            }
        }
    }
}
