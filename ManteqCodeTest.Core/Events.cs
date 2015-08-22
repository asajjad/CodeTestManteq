using System;
namespace ManteqCodeTest.Core
{
    public class Event : Message
    {
        public int Version;
    }

    public class ApprovalCreated : Event
    {
        public readonly Guid Id;
        public readonly string PatientId;
        public readonly string PatientName;
        public readonly DateTime? DateOfBirth;
        public ApprovalCreated(Guid id, string patientId, string patientName, DateTime? dateOfBirth)
        {
            this.Id = id;
            this.PatientId = patientId;
            this.PatientName = patientName;
            this.DateOfBirth = dateOfBirth;
        }
    }

    public class ApprovalUpdated : Event
    {
        public readonly Guid Id;
        public readonly string PatientName;
        public readonly DateTime? DateOfBirth;
        public ApprovalUpdated(Guid id, string patientName, DateTime? dateOfBirth)
        {
            this.Id = id;
            this.PatientName = patientName;
            this.DateOfBirth = dateOfBirth;
        }
    }

}

