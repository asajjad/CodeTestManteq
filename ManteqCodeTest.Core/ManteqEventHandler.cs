using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManteqCodeTest.Core.Domain;

namespace ManteqCodeTest.Core
{
    public class ManteqEventHandler : Handles<ApprovalCreated>
    {
        public void Handle(ApprovalCreated message)
        {
            using (var dataStoreContext = new SqlDataStoreContext())
            {
                var manteqApprovalRequest = new ManteqApprovalRequest();
                manteqApprovalRequest.ApprovalRequestId = message.Id;
                manteqApprovalRequest.PatientName = message.PatientName;
                manteqApprovalRequest.PatientId = message.PatientId;
                manteqApprovalRequest.DateOfBirth = message.DateOfBirth;
                dataStoreContext.ManteqApprovalRequests.Add(manteqApprovalRequest);
                dataStoreContext.SaveChanges();
            }
        }
    }
}
