using datoriummerch.Models;
using Microsoft.AspNetCore.Mvc;

namespace datoriummerch.Controllers
{
    [Route("api/datorium-merch")]
    [ApiController]
    public class MerchController : ControllerBase
    {
        private readonly MerchContext _dbContext;

        public MerchController(MerchContext context)
        {
            _dbContext = context;
        }

        [HttpGet("ok")]
        public ActionResult<string> GetOk()
        {
            return "OK";
        }

        [HttpGet]
        public ActionResult<IEnumerable<Merch>> GetMerch()
        {
            return _dbContext.Merches.ToList();
        }

        [HttpPost]
        public ActionResult PostMerch(Merch merch)
        {
            _dbContext.Merches.Add(merch);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
