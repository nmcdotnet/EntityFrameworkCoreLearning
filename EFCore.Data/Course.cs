namespace EFCore.Data
{
    public class Course
    {
        public int CourseId { get; set; }
        public string? Title { get; set; }
        public int DifficultyLevel { get; set; }
        public string? Language { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string? AuthorId { get; set; }
    }
}
