using System;
using System.Collections.Generic;
using TVChannelMain.abstracts;
using TVChannelMain.concretes;

namespace TVChannelMain
{
    public class Program
    {
        static List<UserProfile> users = new List<UserProfile>() { };
        static List<Notification> notifications = new List<Notification>();

        public static void Main(string[] args)
        {
            int choice;
            UserProfile loggedInUser = null;
            CreateSampleUsersAndNotifications();

            while (true)
            {
                try
                {
                    if (loggedInUser == null)
                    {
                        Console.WriteLine("\n--- Main Menu ---");
                        Console.WriteLine("1. Login");
                        Console.WriteLine("2. Register");
                        Console.WriteLine("3. Exit");
                        Console.Write("Select an option: ");
                        choice = int.Parse(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                loggedInUser = Login();
                                break;
                            case 2:
                                Register();
                                break;
                            case 3:
                                return;
                            default:
                                Console.WriteLine("Invalid option. Try again.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"\n--- Welcome {loggedInUser.Username} ---");
                        Console.WriteLine("1. View Watched Videos");
                        Console.WriteLine("2. Add Watched Video");
                        Console.WriteLine("3. View Notifications");
                        Console.WriteLine("4. Add Comment");
                        Console.WriteLine("5. Subscribe");
                        Console.WriteLine("6. Unsubscribe");
                        Console.WriteLine("7. Logout");
                        Console.Write("Select an option: ");
                        choice = int.Parse(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                loggedInUser.DisplayWatchedVideos();
                                break;
                            case 2:
                                AddWatchedVideo(loggedInUser);
                                break;
                            case 3:
                                ViewNotifications(loggedInUser);
                                break;
                            case 4:
                                AddComment(loggedInUser);
                                break;
                            case 5:
                                SubscribeToPlan(loggedInUser);
                                break;
                            case 6:
                                UnsubscribeFromPlan(loggedInUser);
                                break;
                            case 7:
                                loggedInUser = null;
                                Console.WriteLine("Logged out.");
                                break;
                            default:
                                Console.WriteLine("Invalid option. Try again.");
                                break;
                        }
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input format is invalid. Please enter a valid number.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                }
            }
        }

        static void CreateSampleUsersAndNotifications()
        {
            UserProfile user1 = new UserProfile(1, "user1", "user1@example.com", "12345");
            user1.Notifications.Add(new Notification { NotificationID = 1, Message = "Welcome to the platform!" });
            user1.Notifications.Add(new NewReleaseNotification { NotificationID = 2, VideoTitle = "Action Movie", Message = "New movie is available!" });

            UserProfile user2 = new UserProfile(2, "user2", "user2@example.com", "12345");
            user2.Notifications.Add(new Notification { NotificationID = 3, Message = "Your subscription has been updated." });
            user2.Notifications.Add(new SubscriptionUpdateNotification { NotificationID = 4, PlanName = "Premium Plan", Message = "Your premium plan is now active." });

            UserProfile user3 = new UserProfile(3, "user3", "user3@example.com", "12345");
            user3.Notifications.Add(new Notification { NotificationID = 5, Message = "New comment on your post." });
            user3.Notifications.Add(new NewReleaseNotification { NotificationID = 6, VideoTitle = "Comedy Show", Message = "New episode available!" });

            users.Add(user1);
            users.Add(user2);
            users.Add(user3);
        }

        static UserProfile Login()
        {
            try
            {
                Console.Write("Enter username: ");
                string username = Console.ReadLine();
                Console.WriteLine("Enter Password");
                string password = Console.ReadLine();

                foreach (var user in users)
                {
                    if (user.Username == username && user.Password == password)
                    {
                        Console.WriteLine("Login successful.");
                        return user;
                    }
                }

                Console.WriteLine("Invalid username or password.");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during login: {ex.Message}");
                return null;
            }
        }

        static void Register()
        {
            try
            {
                Console.Write("Enter username: ");
                string username = Console.ReadLine();
                Console.Write("Enter email: ");
                string email = Console.ReadLine();
                if (!email.Contains("@"))
                {
                    throw new FormatException("Invalid email format.");
                }

                Console.Write("Enter password: ");
                string password = Console.ReadLine();

                UserProfile newUser = new UserProfile(users.Count + 1, username, email, password);
                users.Add(newUser);
                Console.WriteLine("Registration successful.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during registration: {ex.Message}");
            }
        }

        static void AddWatchedVideo(UserProfile user)
        {
            try
            {
                Console.WriteLine("1. Add Movie");
                Console.WriteLine("2. Add TV Show");
                Console.Write("Select an option: ");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.Write("Enter movie title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter director: ");
                    string director = Console.ReadLine();
                    Console.Write("Enter duration: ");
                    int duration = int.Parse(Console.ReadLine());

                    if (title == null || director == null)
                    {
                        throw new ArgumentException("Movie details are incomplete.");
                    }

                    Movie movie = new Movie { VideoID = 1, Title = title, Director = director, Duration = duration };
                    user.AddWatchedVideo(movie);
                }
                else if (choice == 2)
                {
                    Console.Write("Enter show title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter season: ");
                    int season = int.Parse(Console.ReadLine());
                    Console.Write("Enter episode: ");
                    int episode = int.Parse(Console.ReadLine());
                    Console.Write("Enter duration: ");
                    int duration = int.Parse(Console.ReadLine());

                    TVShow show = new TVShow { VideoID = 2, Title = title, Season = season, Episode = episode, Duration = duration };
                    user.AddWatchedVideo(show);
                }
                else
                {
                    Console.WriteLine("Invalid option.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding watched video: {ex.Message}");
            }
        }

        static void ViewNotifications(UserProfile user)
        {
            try
            {
                if (user.Notifications.Count == 0)
                {
                    throw new InvalidOperationException("No notifications available.");
                }

                Console.WriteLine("Notifications:");
                foreach (var notification in user.Notifications)
                {
                    notification.DisplayNotification();
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error viewing notifications: {ex.Message}");
            }
        }

        static void AddComment(UserProfile user)
        {
            try
            {
                Console.WriteLine("1. Add Text Comment");
                Console.WriteLine("2. Add Video Comment");
                Console.Write("Select an option: ");
                int choice = int.Parse(Console.ReadLine());

                Console.Write("Enter comment text: ");
                string text = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(text))
                {
                    throw new ArgumentException("Comment text cannot be empty.");
                }

                if (choice == 1)
                {
                    TextComment comment = new TextComment { CommentID = 1, User = user, Text = text };
                    comment.DisplayComment();
                }
                else if (choice == 2)
                {
                    Console.Write("Enter video reply URL: ");
                    string videoReplyURL = Console.ReadLine();
                    VideoComment comment = new VideoComment { CommentID = 2, User = user, Text = text, VideoReplyURL = videoReplyURL };
                    comment.DisplayComment();
                }
                else
                {
                    throw new ArgumentException("Invalid option selected.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding comment: {ex.Message}");
            }
        }

        static void SubscribeToPlan(UserProfile user)
        {
            try
            {
                Console.WriteLine("1. Basic Plan");
                Console.WriteLine("2. Premium Plan");
                Console.Write("Select a plan: ");
                int choice = int.Parse(Console.ReadLine());

                SubscriptionPlan selectedPlan = null;

                if (choice == 1)
                {
                    selectedPlan = new BasicPlan();
                }
                else if (choice == 2)
                {
                    selectedPlan = new PremiumPlan();
                }
                else
                {
                    throw new ArgumentException("Invalid plan selected.");
                }

                selectedPlan.Subscribe(user);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error subscribing to plan: {ex.Message}");
            }
        }

        static void UnsubscribeFromPlan(UserProfile user)
        {
            try
            {
                if (user.SubscribedPlan == null)
                {
                    throw new InvalidOperationException("You are not subscribed to any plan.");
                }
                else
                {
                    user.SubscribedPlan.Unsubscribe(user);
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error unsubscribing from plan: {ex.Message}");
            }
        }
    }
}
