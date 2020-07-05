using FluentValidation;
using SimonsVoss.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimonsVoss.Services.Validators
{
    public class RegistrationValidator : AbstractValidator<RegistrationRequest>
    {
        public RegistrationValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty();
            RuleFor(x => x.ContactPerson).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.LicenseKey).NotEmpty();
        }
    }
}
