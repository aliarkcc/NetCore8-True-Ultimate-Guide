using Microsoft.AspNetCore.Mvc;

namespace IActionResultProject.Controllers
{
    public class HomeController : Controller
    {
        [Route("book")]
        public IActionResult Index()
        {
            //Book id should be applied
            if (!Request.Query.ContainsKey("bookid"))
            {
                //return new BadRequestResult();
                return BadRequest("Book id is not supplied");
            }

            //Book id can not be empty
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                return BadRequest("Book id can't be null or empty");
            }

            //Book id should be between 1 to 1000
            int bookId = Convert.ToInt16(ControllerContext.HttpContext.Request.Query["bookid"]);

            if (bookId < 0)
            {
                return BadRequest("Book id can't be less then or equal to zero");
            }

            if (bookId > 1000)
            {
                return NotFound("Book id can't be greater than 1000");
            }

            if (Convert.ToBoolean(Request.Query["isloggedin"]) == false)
            {
                //return StatusCode(401);
                return Unauthorized("User must be authenticated");
            }

            string url = $"store/books/{bookId}";

            //302 - Found
            //return new RedirectToActionResult("Books", "Store", new { id = bookId });
            //return RedirectToAction("Books", "Store", new { id = bookId });

            //302 - Found - LocalRedirectResult
            //return new LocalRedirectResult(url);
            //return LocalRedirect(url);
            //return RedirectToAction("Books", "Store"); //302 - Found


            //301 - Moved Permanently - RedirectToActionResult
            //return new RedirectToActionResult("Books", "Store", new { id = bookId }, true); 
            //return RedirectToActionPermanent("Books", "Store", new { id = bookId });



            //301 - Moved Permanently - LocalRedirectResult
            //return new LocalRedirectResult(url, true);
            //return LocalRedirectPermanent(url);

            //return Redirect(url); // 302 Found
            return RedirectPermanent(url); //301 - Moved Permanently
        }
    }
}
