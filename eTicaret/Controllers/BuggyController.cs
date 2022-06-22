using eTicaret.Errors;
using eTicaret.Infrastructure.DataContext;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicaret.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _context;
        public BuggyController(StoreContext context)
        {
            _context = context;
        }
        
        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var product = _context.Products.Find(5);
            if (product==null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }


        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var product = _context.Products.Find(21);

            var productToString = product.ToString();
            return Ok();
        }

        

        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return BadRequest();
        }
    }
}
