using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StokTakibiBusiness.Abstract;
using StokTakibiEntities.Concrete;

namespace StokTakibiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirimlerController : ControllerBase
    {
        private IBirimService _birimService;

        public BirimlerController(IBirimService birimService)
        {
            _birimService = birimService;
        }


        [HttpGet]
        public List<Birimler> Get()
        {
            return _birimService.GetAllBirimler();
        }
        [HttpGet("{id}")]
        public Birimler Get(int id)
        {
            return _birimService.GetBirimById(id);
        }

        [HttpPost]

        public void Post([FromBody] Birimler birim)
        {
            _birimService.CreateBirim(birim);
        }

        [HttpPut]

        public void Put([FromBody] Birimler birim)
        {
            _birimService.UpdateBirim(birim);
        }

        [HttpDelete("{id}")]

        public void Detete([FromBody] Birimler birim)
        {
            _birimService.DeleteBirim(birim);
        }
    }
}
