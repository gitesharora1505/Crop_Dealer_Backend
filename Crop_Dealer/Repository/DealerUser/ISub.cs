namespace Crop_Dealer.Repository.DealerUser
{
    public interface ISub
    {
        string AddSubscription(string cropname, int dealerId);
        string deleteSubscription(string cropname, string dealermail);
    }
}
