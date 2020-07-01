using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimonsVoss.Models;
using SimonsVoss.Services.Interfaces;

namespace PortalApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly ILogger<RegistrationController> _logger;
        private readonly IRegistrationService _registrationService;

        public RegistrationController(ILogger<RegistrationController> logger, IRegistrationService registrationService)
        {
            _logger = logger;
            _registrationService = registrationService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegistrationRequest request)
        {
            try
            {
                var result = await _registrationService.Register(request);
                if (!result.Valid)
                {
                    return StatusCode(500);
                }
                return Accepted(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500, e.Message);
            }
        }

    }
}
