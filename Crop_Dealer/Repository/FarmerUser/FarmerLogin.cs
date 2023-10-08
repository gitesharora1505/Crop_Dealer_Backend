using Crop_Dealer.Model;
using Microsoft.EntityFrameworkCore;

namespace Crop_Dealer.Repository.FarmerUser
{
    public class FarmerLogin : IFarmerLogin
    {
        CropDealContext _context;
        public FarmerLogin(CropDealContext context)
        {
            this._context = context;
        }
        public Farmer Login(string email, string password)
        {
            return _context.Farmers.Where(l => l.FarmerEmail.Equals(email) && l.Password.Equals(password)).FirstOrDefault();

        }
    }
}
