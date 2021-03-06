using Microsoft.AspNetCore.Mvc;
using SearchDuplicatesText.Services.PlagiarismCheckService;
using SearchDuplicatesText.Services.PlagiarismCheckService.AvramenkoMethod;
using SearchDuplicatesText.Services.PlagiarismCheckService.NgramMethod;
using SearchDuplicatesText.Services.PlagiarismCheckService.ShingleMethod;

namespace SearchDuplicatesText.Controllers;

[ApiController]
[Route("[controller]")]
public class CheckDuplicateController : ControllerBase
{
    private readonly PlagiarismCheckService _plagiarismCheck;
    private readonly ShingleMethod _shingleMethod;
    private readonly NgramMethod _ngramMethod;
    private readonly AvramenkoMethod _avramenkoMethod;

    public CheckDuplicateController(PlagiarismCheckService plagiarismCheck, ShingleMethod shingleMethod, AvramenkoMethod avramenkoMethod, NgramMethod ngramMethod)
    {
        _plagiarismCheck = plagiarismCheck;
        _shingleMethod = shingleMethod;
        _avramenkoMethod = avramenkoMethod;
        _ngramMethod = ngramMethod;
    }

    [HttpPost("shingle-check")]
    public async Task<IResult> ShingleCheck(IFormFile file)
    {
        var result = await _plagiarismCheck.CheckPlagiarism(file, _shingleMethod);
        return result;
    }
    [HttpPost("ngram-check")]
    public async Task<IResult> NgramCheck(IFormFile file)
    {
        var result = await _plagiarismCheck.CheckPlagiarism(file, _ngramMethod);
        return result;
    }
    [HttpPost("avramenko-check")]
    public async Task<IResult> AvramenkoCheck(IFormFile file)
    {
        var result = await _plagiarismCheck.CheckPlagiarism(file, _avramenkoMethod);
        return result;
    }
}