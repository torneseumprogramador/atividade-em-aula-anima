using Microsoft.Extensions.Configuration;
using Npgsql;

namespace AtividadeAula.Api.Data
{
    public interface IDatabaseConfig
    {
        NpgsqlConnection CreateConnection();
    }

    public class DatabaseConfig : IDatabaseConfig
    {
        private readonly IConfiguration _configuration;

        public DatabaseConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public NpgsqlConnection CreateConnection()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            return new NpgsqlConnection(connectionString);
        }
    }
}