using SimonsVoss.Services.Interfaces;
using SimonsVoss.LicenseSignatureServer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SimonsVoss.Models;
using SimonsVoss.Shared;

namespace SimonsVoss.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly LicenseSignature.LicenseSignatureClient _licenseSignatureClient;

        public RegistrationService(LicenseSignature.LicenseSignatureClient licenseSignatureClient)
        {
            _licenseSignatureClient = licenseSignatureClient;
        }

        public async Task<RegistrationResult> Register(RegistrationRequest request)
        {
            var response = _licenseSignatureClient.ValidateAsync(new SignatureRequest()
            {
                LicenseKey = request.LicenseKey
            });

            var getResponse = await response.ResponseAsync;
            var headers = await response.ResponseHeadersAsync;

            return new RegistrationResult()
            {
                Authority = getResponse.Authority,
                Message = getResponse.Message,
                Valid = getResponse.IsSigned
            };
        }
    }
}
