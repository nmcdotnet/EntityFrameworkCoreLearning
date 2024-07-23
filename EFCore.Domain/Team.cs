using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain
{
    public class Team :BaseDomainModel
    {
        public int TeamId { get; set; } 
        public string? Name { get; set; }
    }
    public class Coach : BaseDomainModel
    {
        public int CoachId { get; set; }
        public string? Name { get; set; }
    }

    public abstract class BaseDomainModel
    {
        public DateTime CreatedDate { get; set; }
    }
}
