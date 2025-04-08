using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayZone.DAL.Models
{
    public class Game : BaseEntity
    {
        public string Description { get; set; }
        public string Cover { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<GameDevice> Device { get; set; } = new List<GameDevice>();
    }
}
