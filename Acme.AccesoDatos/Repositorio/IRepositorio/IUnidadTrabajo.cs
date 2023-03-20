using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.AccesoDatos.Repositorio.IRepositorio
{
    public interface IUnidadTrabajo :IDisposable
    {
        IScursalRepositorio Sucursal { get;  }
        ICategoriaRepositorio Categoria { get; }

        void Guardar();
    }
}
