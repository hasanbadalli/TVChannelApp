using TVChannelMain.concretes;


namespace TVChannelMain.abstracts
{
    public interface ISubscription
    {
        void Subscribe(UserProfile user);
        void Unsubscribe(UserProfile user);
    }

}