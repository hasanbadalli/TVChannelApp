using TVChannelMain.abstracts;

namespace TVChannelMain.concretes
{
    public class TextComment : Comment
    {
        public override void DisplayComment()
        {
            Console.WriteLine($"Text Comment by {User.Username}: {Text}");
        }
    }

}