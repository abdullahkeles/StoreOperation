using System;
using FluentValidation;
using StoreOperation.WebApi.CustomEntities.Request.UserRequest;

namespace StoreOperation.WebApi.CustomEntities.FluentValidation
{
    public class UserValidation:AbstractValidator<RegisterUserRequest>
    {
        public UserValidation()
        {
            Console.WriteLine("UserValidation:AbstractValidator<User>");
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.MobilePhone).NotEmpty().Length(10);
            RuleFor(x => x.OfficePhone).Length(10);
        }
    }
}