using restApi.model;

namespace restApi.service
{
    public interface PegawaiService
    {
        Task<IEnumerable<dynamic>> GetPegawai();
        Task<IEnumerable<dynamic>> GetPegawaiCari(int id);
        Task<BaseResponse<IEnumerable<dynamic>>> GetPegawaiCari2(PegawaiRequest request);
    }
}
