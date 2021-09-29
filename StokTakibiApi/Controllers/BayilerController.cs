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
    public class BayilerController : ControllerBase
    {
        private IBayiService _bayiService;

        public BayilerController(IBayiService bayiService)
        {
            _bayiService = bayiService;
        }


        [HttpGet]
        public List<Bayiler> Get()
        {
            return _bayiService.GetAllBayiler();
        }
        [HttpGet("{id}")]
        public Bayiler Get(int id)
        {
            return _bayiService.GetBayiById(id);
        }

        [HttpPost]

        public void Post([FromBody] Bayiler bayi)
        {
            _bayiService.CreateBayi(bayi);
        }

        [HttpPut]

        public void Put([FromBody] Bayiler bayi)
        {
            _bayiService.UpdateBayi(bayi);
        }

        [HttpDelete("{id}")]

        public void Detete([FromBody] Bayiler bayi)
        {
            _bayiService.DeleteBayi(bayi);
        }
    }
}
