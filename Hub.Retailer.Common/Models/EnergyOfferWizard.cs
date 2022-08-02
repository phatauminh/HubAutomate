using Hub.Retailer.Common.Enums;

namespace Hub.Retailer.Common.Models.Activities
{
    public class EnergyOfferWizard
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
        public string EnergyRepresentativeId { get; set; }
        public string ConnectionType { get; set; }
        public string Tariff { get; set; }
        public string MeterType { get; set; }
        public UtilityTypeEnum UtilityType { get; set; }
        public CustomerTypeEnum CustomerType { get; set; }
        public string OfferCode { get; set; }

    }
}
