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
    public class KategorilerController : ControllerBase
    {
        private IKategoriService _kategoriService;

        public KategorilerController(IKategoriService kategoriService)
        {
            _kategoriService = kategoriService;
        }


        [HttpGet]
        public List<Kategoriler> Get()
        {
            return _kategoriService.GetAllKategoriler();
        }
        [HttpGet("{id}")]
        public Kategoriler Get(int id)
        {
            return _kategoriService.GetKategoriById(id);
        }

        [HttpPost]

        public void Post([FromBody] Kategoriler kategori)
        {
            _kategoriService.CreateKategori(kategori);
        }

        [HttpPut]

        public void Put([FromBody] Kategoriler kategori)
        {
            _kategoriService.UpdateKategori(kategori);
        }

        [HttpDelete("{id}")]

        public void Detete([FromBody] Kategoriler kategori)
        {
            _kategoriService.DeleteKategori(kategori);
        }
    }
}
