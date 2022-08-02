namespace Hub.Retailer.Data.Entities
{
    public class ProductEntity
    {
        public string ProductCode { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string ProductType { get; set; }
        public string Dependent { get; set; }
        public string EndDate { get; set; }
        public string ProductClass { get; set; }
        public string ProductSubClass { get; set; }
        public string ChargeType { get; set; }
        public string InventoryType { get; set; }
        public string ReportKey { get; set; }
        public string GLAccountRevenueCode { get; set; }
        public string GLAccountDiscountCode { get; set; }
        public string TaxCode { get; set; }
        public string EnergyRelatedIndicator { get; set; }
        public string ProRateIndicator { get; set; }
        public string UtilityType { get; set; }
        public string EnergyChargeFlagForRewardPlans { get; set; }
        public string ConcessionTypeForAdminFee { get; set; }
        public string Rule { get; set; }
        public string State { get; set; }
        public string MarketSegment { get; set; }
        public string Distributor { get; set; }
        public string ProductGroup { get; set; }
        public string ProductLine { get; set; }
        public string RetailTariffCode { get; set; }
        public string Status { get; set; }
        public string InventoryStartDate { get; set; }
        public string InventoryEndDate { get; set; }
        public string RateReductionPlan { get; set; }
        public string RateReductionTier { get; set; }
        public string DemandInformationforRateSheet { get; set; }
        public string MeteringChargeInformationforRateSheet { get; set; }
        public string OfferCode { get; set; }
        public string UtilityOffer { get; set; }
        public string SaleChannel { get; set; }
        public string TeamPreference { get; set; }
        public string SaleAgent { get; set; }
        public string SaleAgents { get; set; }
        public bool HasReward { get; set; }
        public string FeedInType { get; set; }
    }
}
