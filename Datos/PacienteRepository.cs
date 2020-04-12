using System.Collections.Generic;
using System.Data.SqlClient;
using Entity;

namespace Datos
{
    public class PacienteRepository
    {
        private readonly SqlConnection _connection;
        private readonly List<Paciente> _pacientes = new List<Paciente>();
        public PacienteRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        public void Guardar(Paciente paciente)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Paciente (Identificacion,ValorServicio,Salario,Copago) 
                                        values (@Identificacion,@ValorServicio,@Salario,@Copago)";
                command.Parameters.AddWithValue("@Identificacion", paciente.Identificacion);
                command.Parameters.AddWithValue("@ValorServicio", paciente.ValorServicio);
                command.Parameters.AddWithValue("@Salario", paciente.Salario);
                command.Parameters.AddWithValue("@Copago",paciente.Copago);
                var filas = command.ExecuteNonQuery();
            }
        }
        public void Eliminar( Paciente paciente)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from paciente where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", paciente.Identificacion);
                command.ExecuteNonQuery();
            }
        }
        public List<Paciente> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Paciente> pacientes = new List<Paciente>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from Paciente ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Paciente paciente = DataReaderMapToPerson(dataReader);
                        pacientes.Add(paciente);
                    }
                }
            }
            return pacientes;
        }
        public Paciente BuscarPorIdentificacion(string identificacion)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from paciente where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", identificacion);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToPerson(dataReader);
            }
        }
        private Paciente DataReaderMapToPerson(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Paciente paciente = new Paciente();
            paciente.Identificacion = (string)dataReader["Identificacion"];
            paciente.ValorServicio = (decimal)dataReader["ValorServicio"];
            paciente.Salario = (decimal)dataReader["Salario"];
            paciente.Copago = (decimal)dataReader["Copago"];
            return paciente;
        }
        
    }
}