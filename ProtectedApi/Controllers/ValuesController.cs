using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProtectedApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Requires authentication for all actions in this controller
    public class ValuesController : ControllerBase
    {
        [HttpGet("userinfo")]
        public IActionResult GetUserInfo()
        {
            // Get user information from claims
            var username = User.Identity.Name;

            // Return user information
            return Ok(new { Username = username, Section = "YourSection", Course = "YourCourse" });
        }

        [HttpGet("funfacts")]
        public IActionResult GetFunFacts()
        {
            // Return fun facts about the API creator
            string[] funFacts = {
                "Fun fact 1",
                "Fun fact 2",
                "Fun fact 3",
                "Fun fact 4",
                "Fun fact 5",
                "Fun fact 6",
                "Fun fact 7",
                "Fun fact 8",
                "Fun fact 9",
                "Fun fact 10"
                // Add more fun facts here
            };

            return Ok(funFacts);
        }
    }
}