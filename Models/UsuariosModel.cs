using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Login.config;
using System.Data;
using System.Data.SqlClient;

namespace Login.Models
{
    class UsuariosModel
    {
        public int ID { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }

        // Constructor vacío
        public UsuariosModel() { }

        // Método para insertar un nuevo usuario y retornar el registro insertado
        public static UsuariosModel Insertar(UsuariosModel usuario)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "INSERT INTO usuario (nombre_usuario, password, roles) " +
                                   "OUTPUT INSERTED.ID, INSERTED.nombre_usuario, INSERTED.password, INSERTED.roles " +
                                   "VALUES (@NombreUsuario, @Password, @Roles)";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                        comando.Parameters.AddWithValue("@Password", usuario.Password);
                        comando.Parameters.AddWithValue("@Roles", usuario.Roles);

                        using (var lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                return new UsuariosModel
                                {
                                    ID = Convert.ToInt32(lector["ID"]),
                                    NombreUsuario = lector["nombre_usuario"].ToString(),
                                    Password = lector["password"].ToString(),
                                    Roles = lector["roles"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                ErrorHandler.ManejarErrorSql(ex, "Error al insertar el usuario.");
            }
            catch (Exception ex)
            {
                ErrorHandler.ManejarErrorGeneral(ex, "Error al insertar el usuario.");
            }
            return null;
        }

        // Método para actualizar un usuario existente y retornar "OK"
        public static string Actualizar(UsuariosModel usuario)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "UPDATE usuario SET nombre_usuario = @NombreUsuario, password = @Password, " +
                                   "roles = @Roles WHERE ID = @ID";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID", usuario.ID.ToString());
                        comando.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario.ToString());
                        comando.Parameters.AddWithValue("@Password", usuario.Password.ToString());
                        comando.Parameters.AddWithValue("@Roles", usuario.Roles.ToString());
                        comando.ExecuteNonQuery();
                    }
                }
                return "OK";
            }
            catch (SqlException ex)
            {
                ErrorHandler.ManejarErrorSql(ex, "Error al actualizar el usuario.");
                return "Error SQL";
            }
            catch (Exception ex)
            {
                ErrorHandler.ManejarErrorGeneral(ex, "Error al actualizar el usuario.");
                return "Error";
            }
        }

        // Método para eliminar un usuario y retornar "OK"
        public static string Eliminar(int idUsuario)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "DELETE FROM usuario WHERE ID = @ID";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID", idUsuario);
                        comando.ExecuteNonQuery();
                    }
                }
                return "OK";
            }
            catch (SqlException ex)
            {
                ErrorHandler.ManejarErrorSql(ex, "Error al eliminar el usuario.");
                return "Error SQL";
            }
            catch (Exception ex)
            {
                ErrorHandler.ManejarErrorGeneral(ex, "Error al eliminar el usuario.");
                return "Error";
            }
        }

        // Método para obtener un usuario por ID
        public static UsuariosModel ObtenerPorId(int idUsuario)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "SELECT * FROM usuario WHERE ID = @ID";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID", idUsuario);

                        using (var lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                return new UsuariosModel
                                {
                                    ID = Convert.ToInt32(lector["ID"]),
                                    NombreUsuario = lector["nombre_usuario"].ToString(),
                                    Password = lector["password"].ToString(),
                                    Roles = lector["roles"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                ErrorHandler.ManejarErrorSql(ex, "Error al obtener el usuario.");
            }
            catch (Exception ex)
            {
                ErrorHandler.ManejarErrorGeneral(ex, "Error al obtener el usuario.");
            }
            return null;
        }

        // Método para obtener todos los usuarios
        public static List<UsuariosModel> ObtenerTodos()
        {
            var usuarios = new List<UsuariosModel>();

            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "SELECT * FROM usuario";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        using (var lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                usuarios.Add(new UsuariosModel
                                {
                                    ID = Convert.ToInt32(lector["ID"]),
                                    NombreUsuario = lector["nombre_usuario"].ToString(),
                                    Password = lector["password"].ToString(),
                                    Roles = lector["roles"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                ErrorHandler.ManejarErrorSql(ex, "Error al obtener la lista de usuarios.");
            }
            catch (Exception ex)
            {
                ErrorHandler.ManejarErrorGeneral(ex, "Error al obtener la lista de usuarios.");
            }

            return usuarios;
        }
        public static UsuariosModel Autenticar(string nombreUsuario, string password)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    string consulta = "SELECT * FROM usuario WHERE nombre_usuario = @NombreUsuario AND password = @Password";
                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                        comando.Parameters.AddWithValue("@Password", password);
                        using (var lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {

                                //password de la base no tiene conocimeinto el atacante
                                //siempre va aser difeernte al password que ingresa por la caja de texto

                                return new UsuariosModel
                                {
                                    ID = Convert.ToInt32(lector["ID"]),
                                    NombreUsuario = lector["nombre_usuario"].ToString(),
                                    Password = lector["password"].ToString(),
                                    Roles = lector["roles"].ToString()
                                };
                            }
                            else
                            {
                                // Retorna null si las credenciales no son válidas
                                return null;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Manejar el error de SQL
                throw new Exception("Error de SQL al autenticar el usuario: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Manejar cualquier otro tipo de error
                throw new Exception("Error al autenticar el usuario: " + ex.Message);
            }
        }

        //                                          ' or 1=1 --            123456
        public  UsuariosModel OtroAutenticar(string nombreUsuario, string password)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                                                                                    //' or 1=1 --    
                    string consulta = "SELECT * FROM usuario WHERE nombre_usuario ='" + nombreUsuario + "'";
                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        using (var lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                //md5                       //123
                                if (lector["password"].ToString() == password)
                                {
                                    //password de la base no tiene conocimeinto el atacante
                                    //siempre va a ser diferente al password que ingresa por la caja de texto
                                    return new UsuariosModel
                                    {
                                        ID = Convert.ToInt32(lector["ID"]),
                                        NombreUsuario = lector["nombre_usuario"].ToString(),
                                        Password = lector["password"].ToString(),
                                        Roles = lector["roles"].ToString()
                                    };
                                }
                                else {
                                    return null;
                                }

                               
                            }
                            else
                            {
                                // Retorna null si las credenciales no son válidas
                                return null;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Manejar el error de SQL
                throw new Exception("Error de SQL al autenticar el usuario: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Manejar cualquier otro tipo de error
                throw new Exception("Error al autenticar el usuario: " + ex.Message);
            }
        }

    }
}
