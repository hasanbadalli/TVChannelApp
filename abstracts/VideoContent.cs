namespace TVChannelMain.abstracts
{

    public abstract class VideoContent
    {
        public int VideoID { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; } // in minutes

        public abstract void GetVideoDetails();
    }

}