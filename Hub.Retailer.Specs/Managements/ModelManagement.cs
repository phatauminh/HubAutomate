using Hub.Retailer.Common.Models.Activities;

namespace Hub.Retailer.Specs.Managements
{
    public class ModelManagement
    {
        public EnergyOfferWizard EnergyOffer { get; set; }
        public ModelManagement(EnergyOfferWizard energyOfferWizard)
        {
            EnergyOffer = energyOfferWizard;
        }
    }
}
