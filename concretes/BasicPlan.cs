using TVChannelMain.abstracts;

namespace TVChannelMain.concretes
{

    public class BasicPlan : SubscriptionPlan
    {
        public BasicPlan()
        {
            PlanID = 1;
            PlanName = "Basic Plan";
        }

        public override string GetPlanDetails()
        {
            return $"Basic Plan: Access to standard video content.";
        }
    }

}