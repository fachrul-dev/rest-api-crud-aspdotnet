using Microsoft.AspNetCore.Mvc;
using restApi.model;
using restApi.service;

namespace restApi.Controllers
{

    //private readonly IConfiguration _configuration;

    [ApiController]
    [Route("api")]
    public class PegawaiController(PegawaiService pegawaiService) : ControllerBase
    {
        

        [HttpGet("pegawai")]
        public async Task<IActionResult> Get()
        {
            var data = await pegawaiService.GetPegawai();
            return Ok(data);
        }
 

        [HttpGet("pegawai/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await pegawaiService.GetPegawaiCari(id);
            return Ok(data);
        }

        [HttpPost("pegawai/cari")]
        public async Task<IActionResult> Get(PegawaiRequest request)
        {
            var data = await pegawaiService.GetPegawaiCari2(request);
            return Ok(data);
        }

    }
}
