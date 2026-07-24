using CrmClientsManager.Infrastructure.Factories;
using CrmClientsManager.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CrmClientsManager.Infrastructure.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
    {
        protected string EntityName => typeof(T).Name;
        protected abstract IDataMap<T> Mapper { get; set; }
        protected abstract IDbConnectionFactory ConnectionFactory { get; set; }

        protected BaseRepository(IDbConnectionFactory connectionFactory)
        {
            ConnectionFactory = connectionFactory;
        }

        public void Delete(int id)
        {
            using var connection = ConnectionFactory.CreateConnection();

            using var command = CreateCommand(
                connection,
                $"{EntityName}_Delete");

            command.Parameters.AddWithValue(
                $"@{EntityName}Id",
                id);

            connection.Open();

            command.ExecuteNonQuery();
        }

        public IList<T> GetAll()
        {
            using var connection = ConnectionFactory.CreateConnection();

            using var command = CreateCommand(
                connection,
                $"{EntityName}_GetAll");

            connection.Open();

            using var reader = command.ExecuteReader();

            return Mapper.Map(reader);
        }

        public T? GetById(int id)
        {
            using var connection = ConnectionFactory.CreateConnection();

            using var command = CreateCommand(
                connection,
                $"{EntityName}_GetById");

            command.Parameters.AddWithValue(
                $"@{EntityName}Id",
                id);

            connection.Open();

            using var reader = command.ExecuteReader();

            return Mapper.Map(reader)
                          .FirstOrDefault();
        }

        protected SqlCommand CreateCommand(
                SqlConnection connection,
                string procedureName
            ) => 
            new SqlCommand(
                procedureName,
                connection)
            {
                CommandType = CommandType.StoredProcedure
            };

        protected int ExecuteScalar(
           SqlCommand command)
        {
            command.Connection.Open();

            return (int)command.ExecuteScalar();
        }


        protected void ExecuteNonQuery(
            SqlCommand command)
        {
            command.Connection.Open();

            command.ExecuteNonQuery();
        }


        protected IList<T> ExecuteReader(
            SqlCommand command)
        {
            command.Connection.Open();

            using var reader =
                command.ExecuteReader();

            return Mapper.Map(reader);
        }
    }
}
