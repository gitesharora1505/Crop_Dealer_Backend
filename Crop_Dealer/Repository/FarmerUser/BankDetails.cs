using Crop_Dealer.Model;

namespace Crop_Dealer.Repository.FarmerUser
{
    public class BankDetails : IBankDetails
    {
        CropDealContext _context;
        public BankDetails(CropDealContext context)
        {
            _context = context;
        }

        public string AddDetails(BankDetail bankDetail)
        {
            try
            {
                _context.BankDetails.Add(bankDetail);
                _context.SaveChanges();
                return "Bank Details Added Successfully";
            }catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string EditDetails(BankDetail bankDetail)
        {
            try
            {
                if(_context.BankDetails.Any(b=>b.FarmerEmail.Equals(bankDetail.FarmerEmail)))
                {
                    _context.BankDetails.Update(bankDetail);
                    _context.SaveChanges();
                    return "Bank Details Updated Successfully";
                }
                return "Bank Details Not Found With This Mail Id";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
