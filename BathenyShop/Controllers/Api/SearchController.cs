using BathenyShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BathenyShop.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private IPieRepository _pieRepository;

        public SearchController(IPieRepository pieRepository)
        {
            _pieRepository  = pieRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_pieRepository.AllPies);
        }

        [HttpGet("{id}")]
        public IActionResult GetAll(int id)
        {
            if(!_pieRepository.AllPies.Any(p=>p.PieId == id))
            {
                return NotFound();
            }
            return Ok(_pieRepository.AllPies.Where(p=>p.PieId == id));  
        }

        [HttpPost]
        public IActionResult SearchPies([FromBody]string searchQuery)
        {
            IEnumerable<Pie> pies = new List<Pie>(); 
            if (!string.IsNullOrEmpty(searchQuery)) { 
                pies = _pieRepository.SearhcPies(searchQuery);
            }
            return new JsonResult(pies);
        }
    }
}
