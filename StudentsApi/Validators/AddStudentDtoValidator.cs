using FluentValidation;
using Students.Domain.DTOs.Requests;

namespace StudentsApi.Validators
{
    

    public class AddStudentDtoValidator : AbstractValidator<AddStudentDto>
    {
        public AddStudentDtoValidator()
        {
            RuleFor(x => x.NationalId).NotEmpty().WithMessage("National ID Number is required.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is required.");
            RuleFor(x => x.DateOfBirth).Must(BeUnder22YearsOld).WithMessage("Age cannot be more than 22.");
            RuleFor(x => x.StudentNumber).NotEmpty().WithMessage("Student Number is required.");
        }

        private bool BeUnder22YearsOld(DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;
            if (dateOfBirth > today.AddYears(-age)) age--;
            return age <= 22;
        }
    }
}
