using Microsoft.AspNetCore.Mvc;
using S2pDAO;
using System;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListTransactionController : ControllerBase
    {
        private readonly IRepository _repo;
        public ListTransactionController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("identity={identity}")]
        public IActionResult GetByIdentity(string identity)
        {
            try
            {
                return Ok(_repo.GetByIdentity(identity));
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
