namespace WebApplication1.Models
{
    public class SpecialLink
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    public class SpecialLinkRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
