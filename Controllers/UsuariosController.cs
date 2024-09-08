using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Login.Models;

namespace Login.Controllers
{
    class UsuariosController
    {
        // Método para insertar un usuario
        public UsuariosModel InsertarUsuario(UsuariosModel usuario)
        {
            return UsuariosModel.Insertar(usuario);
        }

        // Método para actualizar un usuario
        public string ActualizarUsuario(UsuariosModel usuario)
        {
            return UsuariosModel.Actualizar(usuario);
        }

        // Método para eliminar un usuario
        public string EliminarUsuario(int idUsuario)
        {
            return UsuariosModel.Eliminar(idUsuario);
        }

        // Método para obtener un usuario por ID
        public UsuariosModel ObtenerUsuarioPorId(int idUsuario)
        {
            return UsuariosModel.ObtenerPorId(idUsuario);
        }

        // Método para obtener todos los usuarios
        public List<UsuariosModel> ObtenerTodosLosUsuarios()
        {
            return UsuariosModel.ObtenerTodos();
        }

        // Método para autenticar un usuario (login)
        public UsuariosModel AutenticarUsuario(string nombreUsuario, string password)
        {
            return UsuariosModel.Autenticar(nombreUsuario, password);
        }
    }
}
