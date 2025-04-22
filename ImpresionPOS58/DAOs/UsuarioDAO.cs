using Dapper;
using ImpresionPOS58.OBJETOS;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ImpresionPOS58.DAOs
{
    public class UsuarioDAO
    {
        public List<Usuario> ObtenerTodos()
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = "SELECT * FROM Usuario";
                return conn.Query<Usuario>(query).ToList();
            }
        }

        public Usuario ObtenerPorId(int id)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = "SELECT * FROM Usuario WHERE idUsuario = @Id";
                return conn.QueryFirstOrDefault<Usuario>(query, new { Id = id });
            }
        }

        public void Insertar(Usuario usuario)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = @"INSERT INTO Usuario ( username, password, nombre_completo, Rango_idRango, celular, correoElectronico, domicilio, foto) 
                                 VALUES ( @Username, @Password, @NombreCompleto, @RangoId, @Celular, @CorreoElectronico, @Domicilio, @Foto)";
                conn.Execute(query, usuario);
            }
        }

        public void Actualizar(Usuario usuario)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = @"UPDATE Usuario SET 
                                 username = @Username, 
                                 password = @Password, 
                                 nombre_completo = @NombreCompleto, 
                                 Rango_idRango = @RangoId, 
                                 celular = @Celular, 
                                 correoElectronico = @CorreoElectronico, 
                                 domicilio = @Domicilio, 
                                 foto = @Foto
                                 WHERE idUsuario = @IdUsuario";
                conn.Execute(query, usuario);
            }
        }

        public void Eliminar(int id)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = "DELETE FROM Usuario WHERE idUsuario = @Id";
                conn.Execute(query, new { Id = id });
            }
        }
        public Usuario ObtenerPorCredenciales(string nombreUsuario, string contraseña)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = "SELECT * FROM Usuario WHERE username = @NombreUsuario AND password = @Contraseña";
                return conn.QueryFirstOrDefault<Usuario>(query, new { NombreUsuario = nombreUsuario, Contraseña = contraseña });
            }
        }

    }
}
