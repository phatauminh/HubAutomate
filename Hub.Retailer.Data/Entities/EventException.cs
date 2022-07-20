using System;
using System.Collections.Generic;

namespace Hub.Retailer.Data.Entities
{
    public partial class EventException
    {
        public EventException()
        {
            EventExceptionDetail = new HashSet<EventExceptionDetail>();
        }

        public long Exceptionid { get; set; }
        public string ExceptionExternalEventId { get; set; }
        public long Eventid { get; set; }
        public string ExceptionHeader { get; set; }
        public string ExceptionPayload { get; set; }
        public DateTime CreatedDate { get; set; }
        public string RowVersion { get; set; }

        public virtual EventStore Event { get; set; }
        public virtual ICollection<EventExceptionDetail> EventExceptionDetail { get; set; }
    }
}
