using Microsoft.AspNetCore.Mvc;

namespace ControllersProjecy.Controllers
{
    public class FileController : Controller
    {
        [Route("file-download")]
        public IActionResult FileDownLoad()
        {
            return File("/dummy.pdf", "application/pdf");
        }

        [Route("file-download1")]
        public VirtualFileResult FileDownLoad1()
        {
            return new VirtualFileResult("/dummy.pdf", "application/pdf");
        }

        [Route("file-download2")]
        public PhysicalFileResult FileDownLoad2()
        {
            //return new PhysicalFileResult(@"D:\Windows\source\repos\NetCore8\ControllersProjecy\wwwroot\dummy.pdf", "application/pdf");
            return PhysicalFile(@"D:\Windows\source\repos\NetCore8\ControllersProjecy\wwwroot\dummy.pdf", "application/pdf");
        }

        [Route("file-download3")]
        public FileContentResult FileDownLoad3()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"D:\Windows\source\repos\NetCore8\ControllersProjecy\wwwroot\dummy.pdf");

            //return new FileContentResult(bytes, "application/pdf");
            return File(bytes, "application/pdf");
        }
    }
}
