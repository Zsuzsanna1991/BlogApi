namespace BlogApi.Models
{
    public class Blogger
    {
        public int Id { get; set; }
        public string Name { get; set; }  //A string? lehet null. A string nem lehet null.
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime RegTime { get; set; } = DateTime.Now;
    }
}
