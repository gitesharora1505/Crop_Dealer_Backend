using Crop_Dealer.Model;
using Microsoft.EntityFrameworkCore;

namespace Crop_Dealer.Repository.AdminUser
{
    public class AdminLogin : IAdminLogin
    {
        CropDealContext _context;
        public AdminLogin(CropDealContext context)
        {
            _context = context;
        }
        public Admin Login(string email, string password)
        {
            return _context.Admins.FirstOrDefault(l => l.Email == email && l.Password == password);
        }
    }
}
