﻿using FluentValidation;
using UdemyAuthService.Core.Dtos;

namespace UdemyAuthService.API.Validations
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Email is wrong");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required");

        }
    }
}
