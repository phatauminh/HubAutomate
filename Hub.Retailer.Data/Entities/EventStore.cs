using System;
using System.Collections.Generic;

namespace Hub.Retailer.Data.Entities
{
    public partial class EventStore
    {
        public EventStore()
        {
            EventException = new HashSet<EventException>();
        }

        public long EventId { get; set; }
        public string ExternalEventId { get; set; }
        public string EntityType { get; set; }
        public decimal? EntityId { get; set; }
        public string Action { get; set; }
        public string EventSource { get; set; }
        public string Status { get; set; }
        public DateTime EventTimestamp { get; set; }
        public string EventPayload { get; set; }
        public string RowVersion { get; set; }
        public string MessageHeader { get; set; }
        public long? ParentEventId { get; set; }

        public virtual ICollection<EventException> EventException { get; set; }
    }
}
