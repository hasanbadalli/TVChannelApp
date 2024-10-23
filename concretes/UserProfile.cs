using TVChannelMain.abstracts;

namespace TVChannelMain.concretes
{

    public class UserProfile
    {
        private int userID;
        private string username;
        private string email;
        private string password;

        public int UserID { get => userID; set => userID = value; }
        public string Username { get => username; set => username = value; }
        public string Email
        {
            get => email;
            set => email = value;
        }
        public string Password { get => password; set => password = value; }
        public List<Notification> Notifications { get; private set; }

        public SubscriptionPlan SubscribedPlan { get; set; } 

        private List<VideoContent> watchedVideos = new List<VideoContent>();

        public UserProfile(int userID, string username, string email, string password)
        {
            UserID = userID;
            Username = username;
            Email = email;
            Password = password;
            Notifications = new List<Notification>();
        }

        public void AddWatchedVideo(VideoContent video)
        {
            watchedVideos.Add(video);
            Console.WriteLine($"Added {video.Title} to watched videos.");
        }

        public void DisplayWatchedVideos()
        {
            if (watchedVideos.Count == 0)
            {
                Console.WriteLine("You have not watched any videos yet.");
                return;
            }

            Console.WriteLine($"{Username}'s Watched Videos:");
            foreach (var video in watchedVideos)
            {
                video.GetVideoDetails();
            }
        }

        public void DisplayUserInfo()
        {
            Console.WriteLine($"User: {Username}, Email: {Email}, SubscribedPlan: {SubscribedPlan}");
        }
    }

}