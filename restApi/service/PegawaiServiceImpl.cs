using Dapper;
using Microsoft.Data.SqlClient;
using restApi.model;
using System.Data;

namespace restApi.service
{
    public class PegawaiServiceImpl : PegawaiService
    {

        private readonly IConfiguration _configuration;

        public PegawaiServiceImpl(IConfiguration configuration)
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

        public async Task<BaseResponse<IEnumerable<dynamic>>> GetPegawaiCari2(PegawaiRequest request)
        {
            using var conn = new SqlConnection(
                _configuration.GetConnectionString("DefaultConnection"));

            var data = await conn.QueryAsync(
                "sp_GetPegawai_Lihat",
               new { idPegawai = request.Id_Pegawai, nip = request.Nip }, commandType: CommandType.StoredProcedure

                );

            return BaseResponse<IEnumerable<dynamic>>.Ok(data);
        }
    }
}
