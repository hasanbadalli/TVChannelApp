using TVChannelMain.abstracts;

namespace TVChannelMain.concretes
{
    public class Movie : VideoContent
    {
        public string Director { get; set; }

        public override void GetVideoDetails()
        {
            Console.WriteLine($"Movie: {Title}, Directed by {Director}, Duration: {Duration} minutes.");
        }
    }

}