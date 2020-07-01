using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace SimonsVoss.LicenseSignatureServer
{
    public class LicenseSignatureService : LicenseSignature.LicenseSignatureBase
    {
        private static readonly string Authority = Guid.NewGuid().ToString("D");

        private readonly ILogger<LicenseSignatureService> _logger;

        public LicenseSignatureService(ILogger<LicenseSignatureService> logger)
        {
            _logger = logger;
        }

        public override Task<SignatureReply> Validate(SignatureRequest request, ServerCallContext context)
        {
            return Task.FromResult(new SignatureReply()
            {
                Message = new Guid().ToString(),
                IsSigned = true,
                Authority = Authority
            });
        }
    }
}
