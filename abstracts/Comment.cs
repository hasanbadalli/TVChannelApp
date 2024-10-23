using TVChannelMain.concretes;

namespace TVChannelMain.abstracts
{

    public abstract class Comment
    {
        public int CommentID { get; set; }
        public UserProfile User { get; set; }
        public string Text { get; set; }

        public abstract void DisplayComment();
    }

}