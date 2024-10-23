using TVChannelMain.abstracts;

namespace TVChannelMain.concretes
{
    public class PremiumPlan : SubscriptionPlan
    {
        public PremiumPlan()
        {
            PlanID = 2;
            PlanName = "Premium Plan";
        }

        public override string GetPlanDetails()
        {
            return $"Premium Plan: Access to exclusive content, including early releases and HD videos.";
        }
    }

}