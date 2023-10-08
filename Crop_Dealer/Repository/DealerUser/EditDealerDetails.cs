using Crop_Dealer.Model;

namespace Crop_Dealer.Repository.DealerUser
{
    public class EditDealerDetails:IEditDealerDetails
    {
        CropDealContext _context;
        public EditDealerDetails(CropDealContext context)
        {
            _context = context;
        }

        public string NewDetails(Dealer details)
        {
            try
            {
                if (_context.Dealers.Any(f => f.DealerId.Equals(details.DealerId)))
                {
                    _context.Dealers.Update(details);
                    _context.SaveChanges();
                    return "Dealer Updated Successfully";
                }
                return "Dealer Id Not Found";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
