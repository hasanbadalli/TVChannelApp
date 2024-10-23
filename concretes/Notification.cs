namespace TVChannelMain.concretes
{

    public class Notification
    {
        public int NotificationID { get; set; }
        public string Message { get; set; }

        public virtual void DisplayNotification()
        {
            Console.WriteLine($"Notification: {Message}");
        }
    }

}