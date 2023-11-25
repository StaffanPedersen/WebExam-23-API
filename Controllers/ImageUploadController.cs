namespace API.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ImageUploadController : ControllerBase
{

    private readonly IWebHostEnvironment environment; 

    public ImageUploadController(IWebHostEnvironment _environment)
    {
        environment = _environment;
    }

    [HttpPost]
    public IActionResult PostImage(IFormFile formFile)
    {

        string webRootPath = environment.WebRootPath;
        string absolutePath = Path.Combine($"{webRootPath}/images/drivers/{formFile.FileName}");

        using (var fileStream = new FileStream(absolutePath, FileMode.Create))
        {
            formFile.CopyTo(fileStream);
        }

        return Ok();
    }

    [HttpGet]
    public string Get()
    {
        return "Test OK!";
    }
}