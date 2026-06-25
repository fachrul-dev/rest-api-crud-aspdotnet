using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace restApi.service
{
    public class PegawaiService : IPegawaiService
    {

        private readonly IConfiguration _configuration;

        public PegawaiService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IEnumerable<dynamic>> GetPegawai()
        {
            using var conn = new SqlConnection(
                _configuration.GetConnectionString("DefaultConnection"));

            return await conn.QueryAsync("sp_GetPegawai", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<dynamic>> GetPegawaiCari(int id)
        {
            using var conn = new SqlConnection(
                _configuration.GetConnectionString("DefaultConnection"));

            return await conn.QueryAsync(
                "sp_GetPegawai_Lihat",
                new { idPegawai = id },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
