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
    public class MarkalarController : ControllerBase
    {
        private IMarkaService _markaService;

        public MarkalarController(IMarkaService markaService)
        {
            _markaService = markaService;
        }


        [HttpGet]
        public List<Markalar> Get()
        {
            return _markaService.GetAllMarkalar();
        }


        [HttpGet("{id}")]
        public Markalar Get(int id)
        {
            return _markaService.GetMarkaById(id);
        }

        [HttpPost]

        public void Post([FromBody] Markalar marka)
        { 
            _markaService.CreateMarka(marka);
        }

        [HttpPut]

        public void Put([FromBody] Markalar marka)
        {
            _markaService.UpdateMarka(marka);
        }

        [HttpDelete("{id}")]

        public void Detete([FromBody] Markalar marka)
        {
            _markaService.DeleteMarka(marka);
        }
    }
}
