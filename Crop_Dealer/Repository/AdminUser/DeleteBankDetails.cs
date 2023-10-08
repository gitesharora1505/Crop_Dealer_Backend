using Crop_Dealer.Model;

namespace Crop_Dealer.Repository.AdminUser
{
    public class DeleteBankDetails : IDeleteBankDetails
    {
        CropDealContext context;
        public DeleteBankDetails(CropDealContext context)
        {
            this.context = context;
        }
        public string deleteBankdetail(int id)
        {
            try
            {
                var temp = context.BankDetails.Find(id);
                if (temp != null)
                {
                    context.BankDetails.Remove(temp);
                    context.SaveChanges();
                    return "Deleted Successfully";
                }
                return "Bank Details Not Found";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
