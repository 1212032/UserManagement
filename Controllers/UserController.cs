namespace Controllers;

using Domain.User;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class UserController : ControllerBase{
    [HttpGet]
    public IActionResult Get() => Ok("Gae Found");

    [HttpPost]
    public IActionResult Post([FromBody] LoginModel request)
    {
        
        return Ok("Gae found");
    }
}