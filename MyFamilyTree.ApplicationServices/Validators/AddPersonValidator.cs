using FluentValidation;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.AddPerson;
using MyFamilyTree.Domain.Entities.Enums;

namespace MyFamilyTree.ApplicationServices.Validators
{
    public class AddPersonValidator : AbstractValidator<AddPersonRequest>
    {
        public AddPersonValidator()
        {
            RuleFor(x => x.LifespanInYears).InclusiveBetween((short)0, (short)150);
            RuleFor(x => x.DateOfBirth)
                .Must(date => BeAValidDate(date))
                .WithMessage("Nieprawidłowy format daty urodzenia.");
            RuleFor(x => x.PersonGender).IsInEnum().Must(gender => gender is >= 0 and <= (EnumGender)2);
        }

        private bool BeAValidDate(DateTime? date)
        {
            return date > DateTime.MinValue;
        }
    }
}
