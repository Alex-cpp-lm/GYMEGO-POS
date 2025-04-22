using Dapper;
using ImpresionPOS58.OBJETOS;
using System.Collections.Generic;
using System.Linq;

namespace ImpresionPOS58.DAOs
{
    public class VentaMembresiaDAO
    {
        public List<VentaMembresia> ObtenerTodos()
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = "SELECT * FROM ventas_membresia";
                return conn.Query<VentaMembresia>(query).ToList();
            }
        }

        public VentaMembresia ObtenerPorId(int id)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = "SELECT * FROM ventas_membresia WHERE idventas_membresia = @Id";
                return conn.QueryFirstOrDefault<VentaMembresia>(query, new { Id = id });
            }
        }

        public int Insertar(VentaMembresia v)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = @"INSERT INTO ventas_membresia (fecha, total, Cliente_idCliente, Membresia_idMembresia, Usuario_idUsuario) 
                                 VALUES (@Fecha, @Total, @ClienteId, @MembresiaId, @UsuarioId);
                                    SELECT LAST_INSERT_ID();";
                return conn.ExecuteScalar<int>(query, v);
            }
        }

        public void Actualizar(VentaMembresia v)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = @"UPDATE ventas_membresia SET 
                                 fecha = @Fecha, 
                                 total = @Total, 
                                 Cliente_idCliente = @ClienteId,
                                 Membresia_idMembresia = @MembresiaId,
                                 Usuario_idUsuario = @UsuarioId
                                 WHERE idventas_membresia = @Idventas_membresia";
                conn.Execute(query, v);
            }
        }

        public void Eliminar(int id)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = "DELETE FROM ventas_membresia WHERE idventas_membresia = @Id";
                conn.Execute(query, new { Id = id });
            }
        }
    }
}
