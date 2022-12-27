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
        public string ArborId { get; set; }
        public virtual Guid GenderId { get; set; }
        public Gender Gender { get; set; }

        public Name PrimaryName { get; set; }

        public List<Name> AlternateNames { get; set; }

        public bool IsPrivate { get; set; }
        public string SequenceType
        {
            get => "person";
        }

        public void SetSequence(int sequence)
        {
            ArborId = $"I{sequence:0000}";
        }
    }
}
