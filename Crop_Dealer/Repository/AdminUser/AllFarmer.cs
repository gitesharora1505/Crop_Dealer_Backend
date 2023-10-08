using Crop_Dealer.Model;

namespace Crop_Dealer.Repository.AdminUser
{
    public class AllFarmer : IAllFarmer
    {
        CropDealContext _context;
        public AllFarmer(CropDealContext context)
        {
            _context = context;
        }

        public List<Farmer> GetAllFarmers()
        {
            try
            {
                return _context.Farmers.ToList();
            }
            catch
            {
                return new List<Farmer>();
            }
        }
    }
}
