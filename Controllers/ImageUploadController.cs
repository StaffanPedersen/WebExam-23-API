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
    public IActionResult PostImage(IFormFile formFile) // formFile-navnet bruker vi senere i MediaService.js
    {
        string webRootPath = environment.WebRootPath; // danner filstien til Web APIet frem til wwwroot-mappen
        string absolutePath = Path.Combine($"{webRootPath}/images/drivers/{formFile.FileName}"); // kombinerer filstien i webRootPath med images + bildenavn

        using (var fileStream = new FileStream(absolutePath, FileMode.Create))
        {
            formFile.CopyTo(fileStream); // bildet lagres til hvor absolutePath er satt
        }

        return Ok();
    }

    [HttpGet]
    public string Get()
    {
        return "Test OK!";
    }
}