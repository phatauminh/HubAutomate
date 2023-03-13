using Hub.Retailer.Common.Services;

namespace Hub.Retailer.Specs.Managements
{
    public class ServiceManagement
    {
        public EnergyOfferService EnergyOfferService { get; set; }
        public ServiceManagement(EnergyOfferService energyOfferService)
        {
            EnergyOfferService = energyOfferService;
        }
    }
}