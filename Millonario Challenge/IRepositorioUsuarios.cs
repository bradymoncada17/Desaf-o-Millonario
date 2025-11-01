using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Millonario_Challenge;

namespace Millonario_Challenge
{
    public interface IRepositorioUsuarios
    {
        Usuario ObtenerPorNombre(string nombreUsuario);
        int CrearUsuario(string nombreUsuario, string nombreCompleto);
        List<Usuario> ObtenerTodos();
    }
}
