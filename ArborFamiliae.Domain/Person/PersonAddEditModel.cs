using System;
using System.Collections.Generic;
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

        public List<EventListModel> Events { get; set; }
        public List<NameListModel> Names { get; set; }
        public List<CitationListModel> SourceCitations { get; set; }
        public List<AttributeListModel> Attributes { get; set; }
        public List<AddressListModel> Addresses { get; set; }
        public List<NoteListModel> Notes { get; set; }
    }
}
