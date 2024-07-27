namespace EFCore.Domain
{
    public class Team :BaseDomainModel
    {
        public int TeamId { get; set; } 
        public string? Name { get; set; }
        public string? Level { get; set; }  
    }
}
