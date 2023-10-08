using Crop_Dealer.Model;

namespace Crop_Dealer.Repository.CropRepo
{
    public class AddCrops : IAddCrops
    {
        CropDealContext context;
        ISendEmail _SendEmail { get; set; }
        public AddCrops(CropDealContext context, ISendEmail sendEmail)
        {
            this.context = context;
            _SendEmail = sendEmail;
        }
        public string AddCrop(Crop crop,int farmerid)
        {
            try
            {
                var tempfarmer=context.Farmers.FirstOrDefault(f => f.FarmerId == farmerid);
                crop.FarmerEmail = tempfarmer.FarmerEmail;
                context.Crops.Add(crop);
                context.SaveChanges();
                var mails = context.Subscribes.Where(a => a.CropName.Equals(crop.CropName)).ToList();
                if(mails!=null)
                {
                    string message = crop.CropName + " Available";
                    foreach (var mail in mails)
                    {
                        _SendEmail.CropNotify(mail.DealerEmail, "New Crop", message);
                    }
                }
                return "Crop Added Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

       

    }
}
