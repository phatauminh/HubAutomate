using Hub.Retailer.Common.Enums;
using Hub.Retailer.Common.Models.Activities;
using System.Linq;

namespace Hub.Retailer.Common.Extensions
{
    public static class EnergyOfferWizardExtensions
    {
        private static string SIGN_UP_ELEC = "Sign-Up Electricity Only";
        private static string SIGN_UP_GAS = "Sign-Up Gas Only";

        public static EnergyOfferWizard DecorateSampleData(this EnergyOfferWizard energyOfferWizard)
        {
            var connectionType = SIGN_UP_ELEC;

            if(energyOfferWizard.UtilityType.Equals(UtilityTypeEnum.G))
                connectionType = SIGN_UP_GAS;

            var state = energyOfferWizard.ServiceAddress.State;
            var customerType = energyOfferWizard.CustomerType;

            var stateCode =  state.GetStateCodeBy();
            var offerDocumentNumber = $"{state.First()}{customerType.ToString().First()}";

            energyOfferWizard.OfferDocumentNumber = offerDocumentNumber;
            energyOfferWizard.TrackingNumber = StringExtensions.GenerateStringWithPrefix(15, $"AUTO-");
            energyOfferWizard.ConnectionType = connectionType;
            energyOfferWizard.EnergyRepresentativeId = "Web Sale";

            return energyOfferWizard;
        }

    }
}
