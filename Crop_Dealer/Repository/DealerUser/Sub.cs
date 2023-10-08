using Crop_Dealer.Model;

namespace Crop_Dealer.Repository.DealerUser
{
    public class Sub : ISub
    {
        CropDealContext context;
        public Sub(CropDealContext context)
        {
            this.context = context;
        }
        public string AddSubscription(string cropname, int dealerId)
        {
            try
            {
                var tempdealer=context.Dealers.FirstOrDefault(d=>d.DealerId==dealerId);
                Subscribe subscribe = new Subscribe();
                subscribe.CropName = cropname;
                subscribe.DealerEmail = tempdealer.DealerEmail;
                subscribe.Subscribed = "Subscribed";
                context.Subscribes.Add(subscribe);
                context.SaveChanges();
                return "Subscribed to " + cropname;
            }catch (Exception ex)
            {
                return ex.Message;
            }
           
        }

        public string deleteSubscription(string cropname, string dealermail)
        {
            try
            {

                var tempsub = context.Subscribes.FirstOrDefault(s => s.CropName.Equals(cropname) && s.DealerEmail.Equals(dealermail));
                if (tempsub!=null)
                {
                    
                    context.Subscribes.Remove(tempsub);
                    context.SaveChanges();
                    return "Unsubscribed " + cropname;
                }
                return "Subscription Not Found";
            }catch(Exception ex) { return ex.Message;}
        }
    }
}
