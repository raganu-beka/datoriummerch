using datoriummerch.Models;
using Microsoft.AspNetCore.Mvc;

namespace datoriummerch.Controllers
{
    [Route("api/datorium-merch")]
    [ApiController]
    public class MerchController
    {
        private readonly MerchContext _dbContext;

        public MerchController(MerchContext context)
        {
            _dbContext = context;
        }

        [HttpGet("ok")]
        public ActionResult<string> GetMerch()
        {
            return "OK";
        }
    }
}
