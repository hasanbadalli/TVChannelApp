namespace TVChannelMain.concretes
{
    public class NewReleaseNotification : Notification
    {
        public string VideoTitle { get; set; }

        public override void DisplayNotification()
        {
            Console.WriteLine($"New Release: {VideoTitle}. {Message}");
        }
    }

}