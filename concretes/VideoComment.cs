using TVChannelMain.abstracts;

namespace TVChannelMain.concretes
{
    public class VideoComment : Comment
    {
        public string VideoReplyURL { get; set; }

        public override void DisplayComment()
        {
            Console.WriteLine($"Video Comment by {User.Username}: {Text}");
            Console.WriteLine($"Watch reply: {VideoReplyURL}");
        }
    }

}