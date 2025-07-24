namespace ApiTestsAutomation.TestData
{
    public class PostData
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public static PostData CreatePost(int userId, string title, string body)
        {
            return new PostData
            {
                UserId = userId,
                Title = title,
                Body = body
            };
        }
    }
}
    
