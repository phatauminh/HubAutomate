using Hub.Retailer.Common.Enums;
using Hub.Retailer.Common.Models;
using Hub.Retailer.Data.Services;

namespace Hub.Retailer.Common.Services
{
    public class EnergyOfferService
    {
        public ServiceAddress GetAvailableServiceAddress(string state, UtilityTypeEnum utilityType)
        {
            if (UtilityTypeEnum.E.Equals(utilityType))
            {
                var listNMIEntity = QueryHelper.Generate_List_NMI(state, 100);
            }

            return new ServiceAddress();
        }
    }
}
