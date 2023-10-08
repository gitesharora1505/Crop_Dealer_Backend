using Crop_Dealer.Model;

namespace Crop_Dealer.Repository.DealerUser
{
    public class DealerReg : IDealerReg
    {
        CropDealContext _context;
        public DealerReg(CropDealContext context)
        {
            this._context = context;
        }
        public string AddDealer(Dealer dealer)
        {
            try
            {
                string email = dealer.DealerEmail;
                if (_context.Dealers.Any(a => a.DealerEmail == email))
                {
                    string error = "Dealer already exist";
                    return error;
                }
                _context.Dealers.Add(dealer);
                _context.SaveChanges();
                return "Dealer Added Successfully";
            }
            catch (Exception ex)
            {
                return "Not Able To Add Dealer Retry";
            }
        }
    }
}
