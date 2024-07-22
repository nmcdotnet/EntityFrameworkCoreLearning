namespace EFCore.Domain
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public int CourseId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? VideoURL { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
