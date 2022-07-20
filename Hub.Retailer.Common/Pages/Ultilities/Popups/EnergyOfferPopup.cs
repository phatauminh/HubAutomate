using Hub.Core.Controls;
using Hub.Core.Decorators;
using Hub.Core.Ultilities;
using Hub.Retailer.Common.Models.Activities;
using System.Threading.Tasks;

namespace Hub.Retailer.Common.Pages.Ultilities.Popups
{
    public class EnergyOfferPopup : BasePopup
    {
        #region Energy Offer Label
        private const string LblFunctionGroup = "Function Group";
        private const string LblCustomerNumber = "Customer Number";
        private const string LblUseCustomer = "Use Customer";
        private const string LblCustomerName = "Customer Name";
        private const string LblOfferDocumentNumber = "Offer Document Number";
        private const string LblNMI = "NMI";
        private const string LblMIRN = "MIRN";
        private const string LblServiceAddress = "Service Address";
        private const string LblSupplyAddress = "Supply Address";
        private const string LblTrackingNumber = "Tracking Number";
        private const string LblConfirmExistingHUBCustomer = "Confirm Existing HUB Customer";
        private const string LblSalesChannel = "Sales Channel";
        private const string LblContractReceived = "Contract Received";
        private const string LblContractVerified = "Contract Verified";
        private const string LblSignedDate = "Signed Date";
        private const string LblAppointmentDate = "Appointment Date";
        private const string LblEnergyRepresentativeID = "Energy Representative ID";
        private const string LblConnectionType = "Connection Type";
        private const string LblMoveInDate = "Move-In Date";
        private const string LblMoveOutDate = "Move-Out Date";
        private const string LblElecOfferCode = "Electricity Offer Code";
        private const string LblGasOfferCode = "Gas Offer Code";
        private const string LblCompanyName = "Company Name";
        private const string LblBusinessType = "Business Type";
        private const string LblTradingName = "Trading Name";
        private const string LblAustralianBusinessNumber = "Australian Business Number";
        private const string LblCompanyPositionheld = "Company Position held";
        private const string LblTitle = "Title";
        private const string LblFirstName = "First Name";
        private const string LblLastName = "Last Name";
        private const string LblCompanyPhoneNumber = "Company Phone Number";
        private const string LblAfterHoursContactNumber = "After Hours Contact Number";
        private const string LblMobileNumber = "Mobile Number";
        private const string LblEmailAddress = "Email Address";
        private const string LblDateOfBirth = "Date of Birth";
        private const string LblPINNumber = "PIN Number";
        private const string LblDriversLicenceNumber = "Drivers Licence Number";
        private const string LblLifeSupport = "Life Support Electricity";
        private const string LblLifeSupportGas = "Life Support Gas";
        private const string LblOwnPremises = "Own Premises";
        private const string LblElecMeterSN = "Elec Meter SN";
        private const string LblGasMeterSN = "Gas Meter SN";
        private const string LblEstimatedAnnualUsagekWh = "Estimated Annual Usage (kWh)";
        private const string LblEstimatedAnnualUsageMJ = "Estimated Annual Usage (MJ)";
        private const string LblElectricityProductCode = "Electricity Product Code";
        private const string LblOffPeakElectricityProductCode = "Off Peak Electricity Product Code";
        private const string LblFeedInType = "Feed-in Type";
        private const string LblGasProductCode = "Gas Product Code";
        private const string LblTeamPreference = "Team Preference";
        private const string LblEnergyUsageProfileCode = "Energy Usage Profile Code";
        private const string LblPensionNumber = "Pension Number";
        private const string LblPensionStartDate = "Pension Start Date";
        private const string LblCardFirstName = "Card First Name";
        private const string LblCardOtherNames = "Card Other Names";
        private const string LblCardSurname = "Card Surname";
        private const string LblPensionType = "Pension Type";
        private const string LblRewardPlanCardID = "Reward Plan Card ID";
        private const string LblSurnameOnRewardCard = "Surname on Reward Card";
        private const string LblNameInitialOnRewardCard = "Name Initial on Reward Card";
        private const string LblPostalAddress = "Postal Address";
        private const string LblBillMedia = "Bill Media";
        private const string LblMarketingMedia = "Marketing Media";
        private const string LblExemptNoInternetAccess = "Exempt due to No Internet Access";
        private const string LblVisuallyImpairedCustomer = "Visually Impaired Customer";
        private const string LblPaperBillFee = "Paper Bill Fee";
        private const string LblWelcomePackDeliveryMethod = "Welcome Pack Delivery Method";
        private const string LblSignatory = "Signatory";
        private const string LblCustomerReportsNoHazard = "Customer Reports No Hazard";
        private const string LblDog = "Dog";
        private const string LblElectricFence = "Electric Fence";
        private const string LblCustomerCaution = "Customer Caution";
        private const string LblElectricalSafetyIssue = "Electrical Safety Issue";
        private const string LblAsbestosFuse = "Asbestos Fuse";
        private const string LblAsbestosBoard = "Asbestos Board";
        private const string LblNotKnownToInitiator = "Not Known To Initiator";
        private const string LblOtherHazard1 = "Other Hazard 1";
        private const string LblOtherHazard2 = "Other Hazard 2";
        private const string LblSiteAccessInformation = "Site Access Information";
        private const string LblResidentialAddress = "Residential Address";
        private const string LblNaturalGas = "Natural Gas";
        private const string LblPaymentMethod = "Payment Method";
        private const string LblRequestPaymentCard = "Request Payment Card";
        private const string LblBankName = "Bank Name";
        private const string LblBankBrancNumber = "Bank Branch Number";
        private const string LblBankAccountNumber = "Bank Account Number";
        private const string LblBankAccountHolderName = "Bank Account Holder Name";
        private const string LblCreditCardType = "Credit Card Type";
        private const string LblCreditCardNumber = "Credit Card Number";
        private const string LblCreditCardExpiry = "Credit Card Expiry (MMYY)";
        private const string LblCreditCardHolderName = "Credit Card Holder Name";
        private const string LblAutoConfirmContractDatesCheck = "Auto-Confirm Contract Dates Check";
        private const string LblCustomerUnderstoodandSignedContract = "Customer Understood and Signed (verbal or written) Contract";
        private const string LblVerificationnumber = "Verification number";
        private const string LblCustomerhistoryandfeedback = "Customer history and feedback";
        private const string LblServiceOrderSubType = "Service Order Sub Type";
        private const string LblReconnectionLocation = "Reconnection Location";
        private const string LblScheduledDate = "Scheduled Date";
        private const string LblScheduleDate = "Schedule Date";
        private const string LblServiceTime = "Service Time";
        private const string LblCustomerConsultationRequired = "Customer Consultation Required?";
        private const string LblSpecialInstructions = "Special Instructions";
        private const string LblSOFeeWaived = "SO Fee Waived?";
        private const string LblSOFeeWaiverReason = "SO Fee Waiver Reason";
        private const string LblAdminFeeWaived = "Admin Fee Waived?";
        private const string LblAdminFeeWaiverReason = "Admin Fee Waiver Reason";
        private const string LblAppointmentReference = "Appointment Reference";
        private const string LblCustomersPreferredDate = "Customers Preferred Date";
        private const string LblPreferredTransferDate = "Preferred Transfer Date";
        private const string LblCustomersPreferredTime = "Customers Preferred Time";
        private const string LblSafetyCertificateID = "Safety Certificate ID";
        private const string LblSafetyCertificateSendMethod = "Safety Certificate Send Method";
        private const string LblSendFinalBillviaEmail = "Send Final Bill via Email ";
        private const string LblProposedTariff1 = "Proposed Tariff #1";
        private const string LblProposedTariff2 = "Proposed Tariff #2";
        private const string LblProposedTariff3 = "Proposed Tariff #3";
        private const string LblCustomerPreferredTransferType = "Customer";
        private const string LblPreferredReadType = "Preferred Read Type";
        private const string LblMismatchAddress = "Mismatch between Supply Address and Electricity Address";
        private const string LblMeterDataProvider = "Meter Data Provider ";
        private const string LblMeterProvider = "Meter Provider ";
        private const string LblMeterProviderCollector = "Meter Provider Collector ";
        private const string LblMeteringCoordinatorRP = "Metering Coordinator (RP) ";
        #endregion

       
        public override string Title => "Energy Offer - Customer Find / New";

        public TextBox CustomerNameTextBox => GetTextBoxByLabel(LblCustomerName);
        public TextBox OfferDocumentNumberTextBox => GetTextBoxByLabel(LblOfferDocumentNumber);
        public TextBox TrackingNumberTextBox => GetTextBoxByLabel(LblTrackingNumber);

        public SelectList FunctionGroupSelectList => GetSelectListByLabel(LblFunctionGroup);

        public EnergyOfferPopup(IPageDecorator page) : base(page)
        {
        }

        public async Task Create(EnergyOffer model)
        {
            await InputCustomerFindNew(model);
            await ClickNext();
            await InputDocumentSupplyAddress(model);
            await ClickNext();
        }


        private async Task InputCustomerFindNew(EnergyOffer model)
        {
            await FunctionGroupSelectList.Select(model.FunctionGroup);
        }

        private async Task InputDocumentSupplyAddress(EnergyOffer model)
        {
            await OfferDocumentNumberTextBox.SetText(model.OfferDocumentNumber);
            await TrackingNumberTextBox.SetText(model.TrackingNumber);
        }
    }
}
