using Dapper;
using ImpresionPOS58.OBJETOS;
using System.Collections.Generic;
using System.Linq;

namespace ImpresionPOS58.DAOs
{
    public class MembresiaDAO
    {
        public List<Membresia> ObtenerTodas()
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = "SELECT * FROM Membresia";
                return conn.Query<Membresia>(query).ToList();
            }
        }

        public Membresia ObtenerPorId(int id)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = "SELECT * FROM Membresia WHERE idMembresia = @Id";
                return conn.QueryFirstOrDefault<Membresia>(query, new { Id = id });
            }
        }

        public void Insertar(Membresia m)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string insertQuery = @"INSERT INTO Membresia (Nombre, descripcion, precio, duracion)
                               VALUES (@Nombre, @Descripcion, @Precio, @Duracion);
                               SELECT LAST_INSERT_ID();";

                int idMembresia = conn.ExecuteScalar<int>(insertQuery, m);

                string eventName = $"desactivar_clientes_membresia_{idMembresia}";

                string crearEvento = $@"
        DROP EVENT IF EXISTS {eventName};

        CREATE EVENT {eventName}
        ON SCHEDULE EVERY 1 DAY
        STARTS CURRENT_TIMESTAMP
        DO
        BEGIN
            UPDATE Cliente c
            JOIN (
                SELECT vm.Cliente_idCliente, MAX(vm.fecha) AS fecha, me.duracion
                FROM ventas_membresia vm
                JOIN Membresia me ON me.idMembresia = vm.Membresia_idMembresia
                WHERE vm.Membresia_idMembresia = {idMembresia}
                GROUP BY vm.Cliente_idCliente
            ) t ON c.idCliente = t.Cliente_idCliente
            SET 
                c.activo = 0,
                c.fecha_inactivacion = NOW()
            WHERE DATEDIFF(NOW(), t.fecha) > t.duracion AND c.activo = 1;
        END;
        ";

                conn.Execute(crearEvento);
            }
        }


       







        public void Actualizar(Membresia m)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = @"UPDATE Membresia SET 
                                 Nombre = @Nombre, 
                                 descripcion = @Descripcion, 
                                 precio = @Precio
                                 WHERE idMembresia = @IdMembresia";
                conn.Execute(query, m);
            }
        }

        public void Eliminar(int id)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = "DELETE FROM Membresia WHERE idMembresia = @Id";
                conn.Execute(query, new { Id = id });
            }
        }
    }
}

