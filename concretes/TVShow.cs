using TVChannelMain.abstracts;

namespace TVChannelMain.concretes
{
    public class TVShow : VideoContent
    {
        public int Season { get; set; }
        public int Episode { get; set; }

        public override void GetVideoDetails()
        {
            Console.WriteLine($"TV Show: {Title}, Season {Season}, Episode {Episode}, Duration: {Duration} minutes.");
        }
    }

}