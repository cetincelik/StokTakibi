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
    public class MusterilerController : ControllerBase
    {
        private IMusteriService _musteriService;

        public MusterilerController(IMusteriService musteriService)
        {
            _musteriService = musteriService;
        }


        [HttpGet]
        public List<Musteriler> Get()
        {
            return _musteriService.GetAllMusteriler();
        }

        [HttpGet("{id}")]
        public Musteriler Get(int id)
        {
            return _musteriService.GetMusteriById(id);
        }

        [HttpPost]

        public void Post([FromBody] Musteriler musteri)
        {
            _musteriService.CreateMusteri(musteri);
        }

        [HttpPut]

        public void Put([FromBody] Musteriler musteri)
        {
            _musteriService.UpdateMusteri(musteri);
        }

        [HttpDelete("{id}")]

        public void Detete([FromBody] Musteriler musteri)
        {
            _musteriService.DeleteMusteri(musteri);
        }
    }
}
