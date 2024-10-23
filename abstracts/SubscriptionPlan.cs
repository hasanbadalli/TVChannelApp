using TVChannelMain.concretes;


namespace TVChannelMain.abstracts
{
    public abstract class SubscriptionPlan : ISubscription
    {
        public int PlanID { get; set; }
        public string PlanName { get; set; }

        public abstract string GetPlanDetails();

        public virtual void Subscribe(UserProfile user)
        {
            user.SubscribedPlan = this;
            Console.WriteLine($"{user.Username} has subscribed to {PlanName}.");
        }

        public virtual void Unsubscribe(UserProfile user)
        {
            if (user.SubscribedPlan == this)
            {
                user.SubscribedPlan = null;
                Console.WriteLine($"{user.Username} has unsubscribed from {PlanName}.");
            }
            else
            {
                Console.WriteLine($"{user.Username} is not subscribed to {PlanName}.");
            }
        }
    }

}