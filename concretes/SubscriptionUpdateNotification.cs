namespace TVChannelMain.concretes
{
    public class SubscriptionUpdateNotification : Notification
    {
        public string PlanName { get; set; }

        public override void DisplayNotification()
        {
            Console.WriteLine($"Subscription Update: {PlanName}. {Message}");
        }
    }

}