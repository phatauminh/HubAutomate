using System.ComponentModel;

namespace Hub.Retailer.Common.Enums
{
    public enum FunctionGroupEnum
    {
        [Description("Activation Call")]
        ActivationCall,

        [Description("Contract Renewal")]
        ContractRenewal,

        [Description("Inbound Telesales - In-Situ")]
        InboundTelesalesInSitu,

        [Description("Inbound Telesales - Move-In")]
        InboundTelesalesMoveIn,
    }
}
