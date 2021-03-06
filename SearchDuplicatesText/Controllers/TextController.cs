using Microsoft.AspNetCore.Mvc;
using SearchDuplicatesText.Services.FileService;

namespace SearchDuplicatesText.Controllers;

[ApiController]
[Route("[controller]")]
public class TextController
{
    private readonly UploadFileService _uploadFileService;

    public TextController(UploadFileService uploadFileService)
    {
        _uploadFileService = uploadFileService;
    }

    [HttpPost("upload-text")]
    public async Task<IResult> UploadText(IFormFile text)
    {
        var result = await _uploadFileService.SaveUploadFile(text);
        return result;
    }
}