using System;
using System.Collections.Generic;

namespace ManteqCodeTest.Core
{
    public class MedicalApprovalProcedure : AggregateRoot
    {
        public MedicalApprovalProcedure()
        {
        }
        public MedicalApprovalProcedure(Guid id, string patientId, string patientName, DateTime? dateOfBirth)
        {
            _id = id;
            ApplyChange(new ApprovalCreated(id, patientId, patientName, dateOfBirth));
        }
        private Guid _id;

        public override Guid Id
        {
            get { return _id; }
        }

    }

}
