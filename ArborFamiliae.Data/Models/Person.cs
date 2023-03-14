using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArborFamiliae.Shared;
using ArborFamiliae.Shared.Interfaces;

namespace ArborFamiliae.Data.Models
{
    public class Person : BaseModel, IAggregateRoot, IHasSequence
    {
        public virtual string ArborId { get; set; }
        public virtual Guid GenderId { get; set; }
        public virtual Gender Gender { get; set; }

        public virtual Name? PrimaryName
        {
            get => Names.FirstOrDefault(p => p.IsPrimary) ?? null;
        }

        public virtual List<Name> Names { get; set; } = new();
        public virtual List<PersonEvent> Events { get; set; } = new();

        public virtual bool IsPrivate { get; set; }
        public string SequenceType
        {
            get => "person";
        }

        public void SetSequence(int sequence)
        {
            ArborId = $"I{sequence:0000}";
        }

        public bool NeedsSequence => String.IsNullOrEmpty(ArborId);

        public string DisplayName =>
            $"{PrimaryName?.PrimarySurname?.SurnameValue}, {PrimaryName?.FirstName}";

        public string BirthDate
        {
            get
            {
                var birth = Events.FirstOrDefault(e => e.Event.EventType == 12);
                if (birth != null)
                {
                    return birth.Event.EventDate?.Text ?? "";
                }

                return "";
            }
        }

        public string DeathDate
        {
            get
            {
                var death = Events.FirstOrDefault(e => e.Event.EventType == 13);
                if (death != null)
                {
                    return death.Event.EventDate?.Text ?? "";
                }

                return "";
            }
        }
    }
}
