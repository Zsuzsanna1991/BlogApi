namespace BlogApi.Models.Dtos
{
    public class UpdateBloggerDto
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime ModDate { get; set; } = DateTime.Now;

    }
}
