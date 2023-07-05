using FluentValidation;
using Students.Domain.DTOs.Requests;
using Students.Domain.Entities;
using Students.Domain.Enums;
using System;

namespace StudentsApi.Validators
{
    public class AddTeacherDtoValidator : AbstractValidator<AddTeacherDto>
    {
        public AddTeacherDtoValidator()
        {
            RuleFor(t => t.NationalId)
                .NotEmpty().WithMessage("National ID number is required.");

            RuleFor(t => t.Name)
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(t => t.Title)
                .NotEmpty().WithMessage("Title is required.")
                .Must(title => Enum.IsDefined(typeof(Title), title))
                    .WithMessage("Invalid title.");

            RuleFor(t => t.Surname)
                .NotEmpty().WithMessage("Surname is required.");

            RuleFor(t => t.DateOfBirth)
                .NotEmpty().WithMessage("Date of birth is required.")
            .Must(dob => dob <= DateTime.Now.AddYears(-21))
            .WithMessage("Teacher must be at least 21 years old.");
            RuleFor(t => t.TeacherNumber)
            .NotEmpty().WithMessage("Teacher number is required.");
            RuleFor(t => t.Salary)
                .GreaterThanOrEqualTo(0).WithMessage("Salary cannot be negative.");
        }
    }

    
}
