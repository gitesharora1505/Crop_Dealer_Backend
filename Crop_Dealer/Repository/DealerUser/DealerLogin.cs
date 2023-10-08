using Crop_Dealer.Model;
using Microsoft.EntityFrameworkCore;

namespace Crop_Dealer.Repository.DealerUser
{
    public class DealerLogin : IDealerLogin
    {
        CropDealContext _context;
        public DealerLogin(CropDealContext context)
        {
            this._context = context;
        }
        public Dealer Login(string email, string password)
        {
            return _context.Dealers.FirstOrDefault(l => l.DealerEmail == email && l.Password == password);
        }
    }
}
