using System;

namespace Hub.Retailer.Data.Entities
{
    public partial class EventExceptionDetail
    {
        public long ExceptionDetailId { get; set; }
        public long ExceptionId { get; set; }
        public string Source { get; set; }
        public string ExceptionEntity { get; set; }
        public string ErrorAttribute { get; set; }
        public string Severity { get; set; }
        public string ShortDescription { get; set; }
        public string DetailDescription { get; set; }
        public DateTime ExceptionTimestamp { get; set; }
        public DateTime CreatedDate { get; set; }
        public string RowVersion { get; set; }

        public virtual EventException Exception { get; set; }
    }
}
