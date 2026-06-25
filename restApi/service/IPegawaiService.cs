namespace restApi.service
{
    public interface IPegawaiService
    {
        Task<IEnumerable<dynamic>> GetPegawai();
        Task<IEnumerable<dynamic>> GetPegawaiCari(int id);
    }
}
