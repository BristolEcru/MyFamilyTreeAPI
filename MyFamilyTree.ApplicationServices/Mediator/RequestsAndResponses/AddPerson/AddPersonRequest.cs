
using MediatR;
using MyFamilyTree.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.AddPerson
{
    public class AddPersonRequest : IRequest<AddPersonResponse>
    {
        public string FirstName { get; set; }

        public string? SurnameAtBirth { get; set; }

        public string? SecondSurname { get; set; }
        public string? Description { get; set; }
        public EnumGender? PersonGender { get; set; }
        public short? LifespanInYears { get; set; }

        public string? PlaceOfBirth { get; set; }
        public string? PlaceOfLiving { get; set; }
        public string? PlaceOfDeath { get; set; }

        private DateTime? _dateOfBirth;
        private DateTime? _dateOfDeath;

        public DateTime? DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value;
                RefreshLifespan();
            }
        }

        public DateTime? DateOfDeath
        {
            get { return _dateOfDeath; }
            set
            {
                _dateOfDeath = value;
                RefreshLifespan();
            }
        }

        private void RefreshLifespan()
        {
            if (DateOfBirth.HasValue && DateOfDeath.HasValue)
            {
                LifespanInYears = (short)(DateOfDeath.Value.Year - DateOfBirth.Value.Year);
            }
            else
            {
                LifespanInYears = null;
            }
        }

    }
}
