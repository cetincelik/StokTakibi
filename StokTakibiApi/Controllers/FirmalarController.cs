using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StokTakibiBusiness.Abstract;
using StokTakibiBusiness.Concrete;
using StokTakibiEntities.Concrete;

namespace StokTakibiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmalarController : ControllerBase
    {
        private IFirmaService _firmaService;

        public FirmalarController(IFirmaService firmaService)
        {
            _firmaService = firmaService;
        }


        [HttpGet]
        public List<Firmalar> Get()
        {
            return _firmaService.GetAllFirmalar();
        }
        [HttpGet("{id}")]
        public Firmalar Get(int id)
        {
            return _firmaService.GetFirmaById(id);
        }

        [HttpPost]

        public void Post([FromBody] Firmalar firma)
        {
             _firmaService.CreateFirma(firma);
        }

        [HttpPut]

        public void Put([FromBody] Firmalar firma)
        {
            _firmaService.UpdateFirma(firma);
        }

        [HttpDelete("{id}")]

        public void Detete([FromBody] Firmalar firma)
        {
            
            _firmaService.DeleteFirma(firma);
        }

    }
}
