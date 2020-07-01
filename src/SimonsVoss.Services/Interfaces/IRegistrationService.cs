using SimonsVoss.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimonsVoss.Services.Interfaces
{
    public interface IRegistrationService
    {
        Task<RegistrationResult> Register(RegistrationRequest request);
    }
}
