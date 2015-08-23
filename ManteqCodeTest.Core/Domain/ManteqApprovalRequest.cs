using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteqCodeTest.Core.Domain
{
    public class ManteqApprovalRequest
    {
        public int Id { get; set; }
        public Guid ApprovalRequestId { get; set; }
        public int OriginalVersion { get; set; }
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
