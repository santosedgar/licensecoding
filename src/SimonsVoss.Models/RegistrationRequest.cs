using System;

namespace SimonsVoss.Models
{
    public class RegistrationRequest
    {
        public string CompanyName { get; set; }

        public string ContactPerson { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string LicenseKey { get; set; }
    }
}
