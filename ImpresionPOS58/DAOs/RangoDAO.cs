using Dapper;
using ImpresionPOS58.OBJETOS;
using System.Collections.Generic;
using System.Linq;

namespace ImpresionPOS58.DAOs
{
    public class RangoDAO
    {
        public List<Rango> ObtenerTodos()
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = "SELECT * FROM Rango";
                return conn.Query<Rango>(query).ToList();
            }
        }

        public Rango ObtenerPorId(int id)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = "SELECT * FROM Rango WHERE idRango = @Id";
                return conn.QueryFirstOrDefault<Rango>(query, new { Id = id });
            }
        }

        public void Insertar(Rango r)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = @"INSERT INTO Rango (idRango, Nombre, Descripción) 
                                 VALUES (@IdRango, @Nombre, @Descripción)";
                conn.Execute(query, r);
            }
        }

        public void Actualizar(Rango r)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = @"UPDATE Rango SET 
                                 Nombre = @Nombre, 
                                 Descripción = @Descripción
                                 WHERE idRango = @IdRango";
                conn.Execute(query, r);
            }
        }

        public void Eliminar(int id)
        {
            using (var conn = ConnectionBD.GetConnection())
            {
                string query = "DELETE FROM Rango WHERE idRango = @Id";
                conn.Execute(query, new { Id = id });
            }
        }
    }
}

