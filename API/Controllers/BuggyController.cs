using Microsoft.AspNetCore.Mvc;

namespace API.Controllers{


    [ApiController]
    [Route("api/[controller]")]
    public class BuggyController : BaseApiController
    {
        public BuggyController()
        {
        }

        [HttpGet("not-found")]
        public ActionResult GetNotFound(){
            return NotFound();
        }

        [HttpGet("bad-request")]
        public ActionResult GetBadRequest(){
            return BadRequest(new ProblemDetails{Title = "this is a bad request"});
        }

        [HttpGet("unauthorized")]
        public ActionResult GetUnauthorized(){
            return Unauthorized();
        }

        [HttpGet("validation-error")]
        public ActionResult GetValidationError(){
            ModelState.AddModelError("Problem 1", "this is the first error");
            ModelState.AddModelError("Problem 2", "this is the second error");
            return ValidationProblem();
        }

        
        [HttpGet("server-error")]
        public ActionResult GetServerError(){
            throw new System.Exception("This is a server error");
        }
    }
}