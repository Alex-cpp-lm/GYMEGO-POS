using Dapper;
using ImpresionPOS58.OBJETOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ImpresionPOS58.DAOs
{
    public class ClienteDAO
    {
        public List<Cliente> ObtenerTodos()
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = "SELECT * FROM Cliente";
                return conn.Query<Cliente>(query).ToList();
            }
        }
        public List<Cliente> ObtenerClientesInactivadosHoy()
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = @"
            SELECT * FROM Cliente
            WHERE activo = 0
            AND DATE(fecha_inactivacion) = CURDATE();";

                return conn.Query<Cliente>(query).ToList();
            }
        }
        public List<Cliente> ObtenerClientesInactivadosUltimos30Dias()
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = @"
            SELECT * FROM Cliente
            WHERE activo = 0
            AND fecha_inactivacion BETWEEN DATE_SUB(CURDATE(), INTERVAL 30 DAY) AND NOW();";

                return conn.Query<Cliente>(query).ToList();
            }
        }

        public List<Cliente> ObtenerClientesInactivadosUltimos7Dias()
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = @"
            SELECT * FROM Cliente
            WHERE activo = 0
            AND fecha_inactivacion BETWEEN DATE_SUB(CURDATE(), INTERVAL 7 DAY) AND NOW();";

                return conn.Query<Cliente>(query).ToList();
            }
        }

        public Cliente ObtenerPorId(int id)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = "SELECT * FROM Cliente WHERE idCliente = @Id";
                return conn.QueryFirstOrDefault<Cliente>(query, new { Id = id });
            }
        }

        public int Insertar(Cliente cliente)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = @"
            INSERT INTO Cliente (Nombre, Apellidos, direccion, celular, correo, activo, foto) 
            VALUES (@Nombre, @Apellidos, @Direccion, @Celular, @Correo, @Activo, @Foto);
            SELECT LAST_INSERT_ID();"; // 🧠 ESTA PARTE ES CLAVE

                return conn.ExecuteScalar<int>(query, cliente); // 🔥 DEVUELVE EL ID INSERTADO
            }
        }


        public void Actualizar(Cliente cliente)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = @"UPDATE Cliente SET 
                                 Nombre = @Nombre, 
                                 Apellidos = @Apellidos, 
                                 direccion = @Direccion, 
                                 celular = @Celular, 
                                 correo = @Correo, 
                                 activo = @Activo, 
                                 foto = @Foto
                                 WHERE idCliente = @IdCliente";
                conn.Execute(query, cliente);
            }
        }
        public List<Cliente> ObtenerConMembresiaPorActividad(bool act)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = @"
            SELECT 
                c.idCliente,
                c.Nombre,
                c.Apellidos,
                c.direccion,
                c.celular,
                c.correo,
                c.activo,
                c.foto,
                m.Nombre AS NombreMembresia,
                vm.fecha AS FechaRenovacion
            FROM Cliente c
            LEFT JOIN (
                SELECT Cliente_idCliente, MAX(fecha) AS fecha
                FROM ventas_membresia
                GROUP BY Cliente_idCliente
            ) ultimaVenta ON ultimaVenta.Cliente_idCliente = c.idCliente
            LEFT JOIN ventas_membresia vm ON vm.Cliente_idCliente = c.idCliente AND vm.fecha = ultimaVenta.fecha
            LEFT JOIN Membresia m ON m.idMembresia = vm.Membresia_idMembresia
Where c.activo = @Act"
                ;

                return conn.Query<Cliente>(query, new { Act = act}).ToList();
            }
        }
        public List<Cliente> ObtenerConMembresia()
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = @"
            SELECT 
                c.idCliente,
                c.Nombre,
                c.Apellidos,
                c.direccion,
                c.celular,
                c.correo,
                c.activo,
                c.foto,
                m.Nombre AS NombreMembresia,
                vm.fecha AS FechaRenovacion
            FROM Cliente c
            LEFT JOIN (
                SELECT Cliente_idCliente, MAX(fecha) AS fecha
                FROM ventas_membresia
                GROUP BY Cliente_idCliente
            ) ultimaVenta ON ultimaVenta.Cliente_idCliente = c.idCliente
            LEFT JOIN ventas_membresia vm ON vm.Cliente_idCliente = c.idCliente AND vm.fecha = ultimaVenta.fecha
            LEFT JOIN Membresia m ON m.idMembresia = vm.Membresia_idMembresia";

                return conn.Query<Cliente>(query).ToList();
            }
        }


        public void Eliminar(int id)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = "DELETE FROM Cliente WHERE idCliente = @Id";
                conn.Execute(query, new { Id = id });
            }
        }
        public void Desactivar(int id)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = @"UPDATE Cliente SET 
                                 activo = false , fecha_inactivacion = NOW()
                                 WHERE idCliente = @Id";
                conn.Execute(query, new { Id = id });
            }
        }
        public List<Cliente> ObtenerConMembresiaPorNombre(string filtro, bool activo)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = @"
        SELECT 
            c.idCliente,
            c.Nombre,
            c.Apellidos,
            c.direccion,
            c.celular,
            c.correo,
            c.activo,
            c.foto,
            m.Nombre AS NombreMembresia,
            vm.fecha AS FechaRenovacion
        FROM Cliente c
        LEFT JOIN (
            SELECT Cliente_idCliente, MAX(fecha) AS fecha
            FROM ventas_membresia
            GROUP BY Cliente_idCliente
        ) ultimaVenta ON ultimaVenta.Cliente_idCliente = c.idCliente
        LEFT JOIN ventas_membresia vm ON vm.Cliente_idCliente = c.idCliente AND vm.fecha = ultimaVenta.fecha
        LEFT JOIN Membresia m ON m.idMembresia = vm.Membresia_idMembresia
        WHERE CONCAT(c.Nombre,c.Apellidos) LIKE @Filtro
        AND c.activo = @Activo";

                return conn.Query<Cliente>(query, new { Filtro = $"%{filtro}%", Activo = activo }).ToList();
            }
        }



        public void Activar(int id)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = @"UPDATE Cliente SET 
                                 activo = true 
                                 WHERE idCliente = @Id";
                conn.Execute(query, new { Id = id });
            }
        }
    }
}
