using Identity.Country;
using Identity.Gender;
using Identity.Generation;
using Identity.Services.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private IIdentityService _identityService;
        private readonly ILogger<IdentityController> _logger;

        public IdentityController(IIdentityService identitiyService, ILogger<IdentityController> logger)
        {
            _identityService = identitiyService;
            _logger = logger;
        }

        /// <summary>
        /// Gets an identity of a person including gender, country, age and generation type.
        /// </summary>
        /// <param name="name">A string name.</param>
        /// <returns>Returns a person's identity.</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/Identity?name=Jhon
        ///     
        /// </remarks>
        /// <response code="200">Identity found</response>
        /// <response code="400">Invalid Name</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ClientResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ClientResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ClientResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetIdentity(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    return BadRequest("Name is required");
                }
                
                var response = await _identityService.GetIdentity(name);
                return Ok(response);
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }          
        }
    }
}
