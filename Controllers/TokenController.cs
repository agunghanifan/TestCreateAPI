using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using TestCreateAPI.DTO;
using TestCreateAPI.DTO.Commons;

namespace TestCreateAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("[action]")]
        public Task<JsonResult> CreateToken()
        {
            try
            {
                int expMinutes = Convert.ToInt32(_configuration["Token:ExpiredMinutes"]);
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("Token:Secret").Value ?? throw new InvalidOperationException()));
                var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expiresToken = DateTime.Now.AddMinutes(expMinutes);
                var jwtToken = new JwtSecurityToken
                                (
                                    issuer: _configuration["Token:ValidIssuer"],
                                    audience: _configuration["Token:ValidAudience"],
                                    expires: expiresToken,
                                    signingCredentials: credential
                                );

                var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

                TokenDTO newToken = new()
                {
                    TokenAuth = token,
                    StartSession = DateTime.Now,
                    EndSession = expiresToken,
                    DateCreated = DateTime.Now,
                };

                return Task.FromResult(new JsonResult(new BaseResponse{
                    SingleData = newToken
                }));
            }
            catch (Exception)
            {
                return Task.FromResult(new JsonResult(new BaseResponse()
                {
                    StatusCode = 500,
                    Message = "Internal service error"
                }));
            }
        }
    }
}
