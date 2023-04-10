using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using ArborFamiliae.Domain.Attributes;
using ArborFamiliae.Domain.Citations;
using ArborFamiliae.Domain.Enums;
using ArborFamiliae.Domain.Events;
using ArborFamiliae.Domain.Notes;

namespace ArborFamiliae.Domain.Person
{
    public class PersonAddEditModel : BaseDomainModel
    {
        public NameType PreferredNameType { get; set; }
        public string PreferredTitle { get; set; }
        public string PreferredNick { get; set; }
        public string PreferredCall { get; set; }
        public string PreferredGivenName { get; set; }
        public string PreferredSuffix { get; set; }
        public string PreferredSurnamePrefix { get; set; }
        public string PreferredSurname { get; set; }
        public Guid Gender { get; set; }

        public string ArborId { get; set; }

        public BindingList<EventAddEditModel> Events { get; set; } = new();
        public BindingList<EventAddEditModel> DeletedEvents { get; set; } = new();
        public BindingList<NameListModel> Names { get; set; }
        public BindingList<CitationListModel> SourceCitations { get; set; }
        public BindingList<AttributeListModel> Attributes { get; set; }
        public BindingList<AddressListModel> Addresses { get; set; }
        public BindingList<NoteListModel> Notes { get; set; }

        public string DisplayName
        {
            get => $"{PreferredSurname}, {PreferredGivenName}";
        }
    }
}
