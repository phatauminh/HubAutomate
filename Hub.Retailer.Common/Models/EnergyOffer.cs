namespace Hub.Retailer.Common.Models.Activities
{
    public class EnergyOffer
    {
        public string FunctionGroup { get; set; }
        public string UserCustomer { get; set; }
        public string CustomerNumber { get; set; }
        public string CustomerName { get; set; }
        public string OfferDocumentNumber { get; set; }
        public string TrackingNumber { get; set; }
        public string NMI { get; set; }
        public string MIRN { get; set; }
        public ServiceAddress ServiceAddress { get; set; }
    }
}
