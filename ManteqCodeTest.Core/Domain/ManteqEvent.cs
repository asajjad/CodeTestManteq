using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteqCodeTest.Core.Domain
{
    public class ManteqEvent
    {
        public ManteqEvent()
        {
            TimeStamp = DateTime.UtcNow;
        }
        public long Id { get; set; }
        public int Version { get; set; }
        public Guid AggregateId { get; set; }
        public byte[] Data { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
