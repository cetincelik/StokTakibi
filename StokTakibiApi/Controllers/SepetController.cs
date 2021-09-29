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
    public class SepetController : ControllerBase
    {
        private ISepetService _sepetService;

        public SepetController(ISepetService sepetService)
        {
            _sepetService = sepetService;
        }


        [HttpGet]
        public List<Sepet> Get()
        {
            return _sepetService.GetAllSepetler();
        }

        [HttpGet("{id}")]
        public Sepet Get(int id)
        {
            return _sepetService.GetSepetById(id);
        }

        [HttpPost]

        public void Post([FromBody] Sepet sepet)
        {
            _sepetService.CreateSepet(sepet);
        }

        [HttpPut]

        public void Put([FromBody] Sepet sepet)
        {
            _sepetService.UpdateSepet(sepet);
        }

        [HttpDelete("{id}")]

        public void Detete([FromBody] Sepet sepet)
        {
            _sepetService.DeleteSepet(sepet);
        }
    }
}
