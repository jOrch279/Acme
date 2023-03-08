using Acme.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.AccesoDatos.Repositorio.IRepositorio
{
    public interface IScursalRepositorio :IRepositorio<Sucursal>
    {
        void Actualizar(Sucursal sucursal);


    }
}
