using FluentValidation;
using InterfaceAdapters.DTOs.Pets;

namespace Presentation_API.Validators
{
    public class PetUpdateValidator : AbstractValidator<PetUpdateRequestDTO>
    {
        public PetUpdateValidator()
        {
            RuleFor(dto => dto.Name).NotEmpty().WithMessage("The pet's name is required");
            RuleFor(dto => dto.Age).NotEmpty().WithMessage("The pet's age is required");
            RuleFor(dto => dto.Age).GreaterThan(0).WithMessage("The pet's age can not be less than 0");
        }
    }
}
