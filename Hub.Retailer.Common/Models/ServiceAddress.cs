namespace Hub.Retailer.Common.Models
{
    public class ServiceAddress
    {
        public string MIRN { get; set; }
        public string NMI { get; set; }
        public string CheckDigit { get; set; }
        public string HouseNumber { get; set; }
        public string HouseNumber2 { get; set; }
        public string HouseNumberSfx { get; set; }
        public string HouseNumberSfx2 { get; set; }
        public string FlatUnitType { get; set; }
        public string FlatUnitNum { get; set; }
        public string StreetName { get; set; }
        public string StreetNameSfx { get; set; }
        public string StreetType { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public string FloorLevelType { get; set; }
        public string FloorLevelNumber { get; set; }
        public string LotNumber { get; set; }
        public string BuildingPropertyName { get; set; }
        public string BuildingPropertyName2 { get; set; }
        public string DeliveryType { get; set; }
        public string DeliveryNumber { get; set; }
        public string PostalType { get; set; }
        public string PostalNumber { get; set; }
        public string FullAddress { get; set; }
        public string FullAddress1 { get; set; }
        public string Address { get; set; }
        public bool IsManualOverride { get; set; }
    }
}
