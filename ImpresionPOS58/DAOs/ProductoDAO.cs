using Dapper;
using ImpresionPOS58.OBJETOS;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ImpresionPOS58.DAOs
{
    public class ProductoDAO
    {
        public List<Producto> ObtenerTodos()
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = "SELECT * FROM Producto  order by cantidad desc";
                return conn.Query<Producto>(query).ToList();
            }
        }

        public Producto ObtenerPorId(int id)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = "SELECT * FROM Producto WHERE idProducto = @Id";
                return conn.QueryFirstOrDefault<Producto>(query, new { Id = id });
            }
        }

        public void Insertar(Producto producto)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = @"INSERT INTO Producto (idProducto, nombre, descripcion, precio, cantidad, foto) 
                                 VALUES (@IdProducto, @Nombre, @Descripcion, @Precio, @Cantidad, @Foto)";
                conn.Execute(query, producto);
            }
        }

        public void Actualizar(Producto producto)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = @"UPDATE Producto SET 
                                 nombre = @Nombre, 
                                 descripcion = @Descripcion, 
                                 precio = @Precio, 
                                 cantidad = @Cantidad, 
                                 foto = @Foto
                                 WHERE idProducto = @IdProducto";
                conn.Execute(query, producto);
            }
        }

        public void Eliminar(int id)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = "DELETE FROM Producto WHERE idProducto = @Id";
                conn.Execute(query, new { Id = id });
            }
        }
        public List<Producto> BuscarPorNombreOCodigo(string texto)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = @"SELECT * FROM Producto 
                         WHERE nombre LIKE @Texto OR codigo LIKE @Texto";

                return conn.Query<Producto>(query, new { Texto = $"%{texto}%" }).ToList();
            }
        }

        public void DescontarInventarioPorVenta(List<Producto> productos)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = @"UPDATE Producto 
                         SET cantidad = cantidad - @CantidadVendida 
                         WHERE idProducto = @IdProducto";

                foreach (var producto in productos)
                {
                    conn.Execute(query, new
                    {
                        IdProducto = producto.IdProducto,
                        CantidadVendida = producto.CantidadEnTicket
                    });
                }
            }
        }
    }
}
