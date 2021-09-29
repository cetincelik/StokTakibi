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
    public class UrunlerController : ControllerBase
    {
        private IUrunService _urunService;

        public UrunlerController(IUrunService urunService)
        {
            _urunService = urunService;
        }


        [HttpGet]
        public List<Urunler> Get()
        {
            return _urunService.GetAllUrunler();
        }

        [HttpGet("{id}")]
        public Urunler Get(int id)
        {
            return _urunService.GetUrunById(id);
        }

        [HttpPost]

        public void Post([FromBody] Urunler urun)
        {
            _urunService.CreateUrun(urun);
        }

        [HttpPut]

        public void Put([FromBody] Urunler urun)
        {
            _urunService.UpdateUrun(urun);
        }

        [HttpDelete("{id}")]

        public void Detete([FromBody] Urunler urun)
        {
            _urunService.DeleteUrun(urun);
        }
    }
}
