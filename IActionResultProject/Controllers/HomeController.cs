using IActionResultProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace IActionResultProject.Controllers
{
    public class HomeController : Controller
    {
        [Route("bookstore/{bookid?}/{isloggedin?}")]
        //URL: /bookstore?bookid=10&isloggedin=true
        public IActionResult Index(int? bookid, [FromRoute] bool? isloggedin,Book book)
        {
            //Book id should be applied
            if (!bookid.HasValue)
            {
                //return new BadRequestResult();
                return BadRequest("Book id is not supplied or empty");
            }

            //Book id should be between 1 to 1000
            if (bookid <= 0)
            {
                return BadRequest("Book id can't be less then or equal to zero");
            }

            if (bookid > 1000)
            {
                return NotFound("Book id can't be greater than 1000");
            }

            if (!isloggedin.HasValue || !isloggedin.Value)
            {
                //return StatusCode(401);
                return Unauthorized("User must be authenticated");
            }

            string url = $"store/books/{bookid}";

            return Content($"Book id: {bookid}, Book:{book}", "text/plain");

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
