namespace Controllers;
using Microsoft.AspNetCore.Mvc;
using Domain.User;
using Utils;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class LogInController(IConfiguration configuration) : ControllerBase{
    private readonly IConfiguration _configuration = configuration;

    [HttpGet]
    public IActionResult Get() => Ok("Gae Found");

    [HttpPost]
    public IActionResult LogIn([FromBody]LoginModel request){
        string secretKey = _configuration["Jwt:Key"];

        User user = new User(request.UserName,request.UserEmail, request.Password);

        var token = JWTGenerator.GenerateToken(user.UserName, user.UserEmail, secretKey);

        return Ok(new { token });
    }
}