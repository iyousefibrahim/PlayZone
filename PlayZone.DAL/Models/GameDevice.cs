using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayZone.DAL.Models
{
    public class GameDevice
    {
        public Guid GameId { get; set; }
        public Game Game { get; set; }

        public Guid DeviceId { get; set; }
        public Device Device { get; set; }
    }
}
