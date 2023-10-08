using Crop_Dealer.Model;

namespace Crop_Dealer.Repository.AdminUser
{
    public class AllDealer:IAllDealer
    {
        CropDealContext _context;
        public AllDealer(CropDealContext context)
        {
            _context = context;
        }

        public List<Dealer> GetAllDealers()
        {
            try
            {
                return _context.Dealers.ToList();
            }
            catch
            {
                return new List<Dealer>();
            }
        }
    }
}
