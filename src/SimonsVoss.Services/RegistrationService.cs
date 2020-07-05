using SimonsVoss.Services.Interfaces;
using SimonsVoss.LicenseSignatureServer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SimonsVoss.Models;
using SimonsVoss.Shared;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

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
                Message = GenerateKey(request.LicenseKey),
                Valid = getResponse.IsSigned
            };
        }

        public string GenerateKey(string clientKey)
        {
            // Dummy method to generate a key
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: clientKey,
                salt: new byte[0],
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 1,
                numBytesRequested: 256 / 8));
        }
    }
}
