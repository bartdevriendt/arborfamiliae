using System;

namespace ArborFamiliae.Domain.Events
{
    public class EventListModel
    {
        public Guid Id { get; set; }
        public string ArborId { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }
        public string Place { get; set; }
        public string Participant { get; set; }
        public bool IsPrivate { get; set; }
        public string Role { get; set; }
        public string Age { get; set; }
        public string Category { get; set; }
    }
}
