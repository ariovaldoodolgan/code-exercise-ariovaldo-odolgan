using Microsoft.AspNetCore.Mvc;
using Palindrome.Api.Models;
using Palindrome.Api.Business;
using Palindrome.Api.Data.Repositories;

namespace Palindrome.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class PalindromeController : ControllerBase
{
    private readonly ILogger<PalindromeController> _logger;
    private readonly IPalindromeBusiness _palindromeBusiness;
    private readonly IPalindromeRepository _palindromeRepository;

    public PalindromeController(ILogger<PalindromeController> logger, 
        IPalindromeBusiness palindromeBusiness, 
        IPalindromeRepository palindromeRepository)
    {
        _logger = logger;
        _palindromeBusiness = palindromeBusiness;
        _palindromeRepository = palindromeRepository;
    }

    [HttpGet(Name = "This is a placeholder")]
    public ActionResult GetAll()
    {
        var result = _palindromeRepository.GetPalindromeList();
        
        if (result.Count > 0)
        {
            return Ok(result);
        }

        return NoContent();
    }

    [HttpPost]
    public ActionResult ValidateInputText(PalindromeInput inputText)
    {
        var result = _palindromeBusiness.Validate(inputText);
        
        return Ok(result);
    }
}
