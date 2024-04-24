using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Errors;
using Talabat.Repository;

namespace Talabat.APIs.Controllers
{
    public class buggyController : BaseAPIController
    {
        private readonly StoreContext _storeContext;

        public buggyController(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        [HttpGet("notfound")] //   GET: api/buggy/notfound
        public ActionResult GetNotFoundRequest()
        {
            var product = _storeContext.Products.Find(100); // Not Found

            if(product == null)
            {
                return NotFound(new ApiResponse(404)); 
            }

            return Ok(product);
        }

        [HttpGet("servererror")] // GET : api/buggy/servererror
        public ActionResult GetServerError(int id)
        {
            var Product = _storeContext.Products.Find(100);
            var ProductToReturn = Product.ToString(); // Will Throw Exception [NullReferenceException]

            return Ok(ProductToReturn);
        }

        [HttpGet("badrequest")] //  GET : api/buggy/badrequest
        public ActionResult BadRequest()
        { 
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")] // GET : api/buggy/five
        public ActionResult ValidationError(int id) // five => Named Validation Error
        {
            // اصلا end point مش هيخش في ال 
            var Product = _storeContext.Products.Find(id);
            
            return Ok();
        }

        [HttpGet("unauthorized")]
        public ActionResult GetUnauthorizedError(int id)
        {
            return Unauthorized(new ApiResponse(401));
        }

    }
}
