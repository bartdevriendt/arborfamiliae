﻿using System;
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

        public virtual Name PrimaryName { get; set; }

        public virtual List<Name> AlternateNames { get; set; } = new();
        public virtual List<ArborEvent> Events { get; set; } = new();

        public virtual bool IsPrivate { get; set; }
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
