namespace EFCore.Domain
{
    public class Coach : BaseDomainModel
    {
        public int CoachId { get; set; }
        public string? Name { get; set; }
    }
}
