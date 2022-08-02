using System.ComponentModel;

namespace Hub.Retailer.Common.Enums
{
    public enum UtilityTypeEnum
    {
        [Description("Electricity")]
        E,
        [Description("Gas")]
        G,
        [Description("Dual Fuel")]
        DF
    }
}
