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
    public class SatislarController : ControllerBase
    {
        private ISatisService _satisService;

        public SatislarController(ISatisService satisService)
        {
            _satisService = satisService;
        }


        [HttpGet]
        public List<Satislar> Get()
        {
            return _satisService.GetAllSatislar();
        }
        [HttpGet("{id}")]
        public Satislar Get(int id)
        {
            return _satisService.GetSatisById(id);
        }

        [HttpPost]

        public void Post([FromBody] Satislar satis)
        {
            _satisService.CreateSatis(satis);
        }

        [HttpPut]

        public void Put([FromBody] Satislar satis)
        {
            _satisService.UpdateSatis(satis);
        }

        [HttpDelete("{id}")]

        public void Detete([FromBody] Satislar satis)
        {
            _satisService.DeleteSatis(satis);
        }
    }
}
