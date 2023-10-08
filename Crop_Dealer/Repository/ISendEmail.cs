using Crop_Dealer.Model;

namespace Crop_Dealer.Repository
{
    public interface ISendEmail
    {
        void CropNotify(string email,string subject, string message);
        void InvoiceMail(string email,string subject,Invoice invoice,double quantity,BankDetail bankDetail);
    }
}
