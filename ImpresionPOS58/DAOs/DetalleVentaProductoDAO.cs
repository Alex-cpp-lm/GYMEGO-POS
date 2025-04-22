using Dapper;
using ImpresionPOS58.OBJETOS;
using System.Collections.Generic;
using System.Linq;

namespace ImpresionPOS58.DAOs
{
    public class DetallesVentasProductoDAO
    {
        public List<DetalleVentaProducto> ObtenerTodos()
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = "SELECT * FROM detalles_ventas_productos";
                return conn.Query<DetalleVentaProducto>(query).ToList();
            }
        }

        public DetalleVentaProducto ObtenerPorId(int productoId, int ventasId)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = "SELECT * FROM detalles_ventas_productos WHERE Producto_idProducto = @ProductoId AND Ventas_idVentas = @VentasId";
                return conn.QueryFirstOrDefault<DetalleVentaProducto>(query, new { ProductoId = productoId, VentasId = ventasId });
            }
        }

        public void Insertar(DetalleVentaProducto d)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = @"INSERT INTO detalles_ventas_productos (Producto_idProducto, Ventas_idVentas) 
                                 VALUES (@ProductoId, @VentasId)";
                conn.Execute(query, d);
            }
        }

        public void Eliminar(int productoId, int ventasId)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = "DELETE FROM detalles_ventas_productos WHERE Producto_idProducto = @ProductoId AND Ventas_idVentas = @VentasId";
                conn.Execute(query, new { ProductoId = productoId, VentasId = ventasId });
            }
        }
        public void InsertarDetallesDeVenta(List<Producto> productos, int idVenta)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = @"INSERT INTO detalles_ventas_productos 
                         (Producto_idProducto, Ventas_idVentas, cantidad) 
                         VALUES (@ProductoId, @VentasId, @Cantidad)";

                foreach (var producto in productos)
                {
                    try
                    {
                        conn.Execute(query, new
                        {

                            ProductoId = producto.IdProducto,
                            VentasId = idVenta,
                            Cantidad = producto.CantidadEnTicket,
                        });
                    }
                    catch
                    {
                        MessageBox.Show("Error en: " + producto.IdProducto + " Con venta " + idVenta);
                    }

                }
            }
        }

    }
}
