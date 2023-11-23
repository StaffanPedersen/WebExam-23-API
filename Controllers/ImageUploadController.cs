namespace API.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ImageUploadController : ControllerBase
{

    private readonly IWebHostEnvironment environment; // objekt vi bruker for å få tak i den korrekte filstien til hele Web APIet (ps! ikke det samme som endepunkt-url)

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

        return Ok(); // Return the file name or any relevant information
    }

    [HttpGet]
    public string Get()
    {
        return "Test OK!";
    }
}