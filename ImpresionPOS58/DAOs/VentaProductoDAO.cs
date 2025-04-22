using Dapper;
using ImpresionPOS58.OBJETOS;
using System.Collections.Generic;
using System.Linq;

namespace ImpresionPOS58.DAOs
{
    public class VentaProductoDAO
    {
        public List<VentaProducto> ObtenerTodos()
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = "SELECT * FROM Ventas_producto";
                return conn.Query<VentaProducto>(query).ToList();
            }
        }

        public VentaProducto ObtenerPorId(int id)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = "SELECT * FROM Ventas_producto WHERE idVentas = @Id";
                return conn.QueryFirstOrDefault<VentaProducto>(query, new { Id = id });
            }
        }

        public int InsertarYObtenerId(VentaProducto v)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = @"INSERT INTO Ventas_producto (fecha, Total, Usuario_idUsuario) 
                         VALUES (@Fecha, @Total, @UsuarioId);
                         SELECT LAST_INSERT_ID();";

                return conn.ExecuteScalar<int>(query, new
                {
                    Fecha = v.Fecha,
                    Total = v.Total,
                    UsuarioId = v.UsuarioId
                });
            }
        }


        public void Actualizar(VentaProducto v)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = @"UPDATE Ventas_producto SET 
                                 fecha = @Fecha, 
                                 Total = @Total, 
                                 Usuario_idUsuario = @UsuarioId
                                 WHERE idVentas = @IdVentas";
                conn.Execute(query, v);
            }
        }

        public void Eliminar(int id)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = "DELETE FROM Ventas_producto WHERE idVentas = @Id";
                conn.Execute(query, new { Id = id });
            }
        }
    }
}
