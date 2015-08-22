using System;
namespace ManteqCodeTest.Core
{
    public class Command : Message
    {
    }

    public class CreateMedicalProcedureApprovalRequest : Command
    {
        public readonly Guid Id;
        public readonly int OriginalVersion;
        public string PatientId;
        public string PatientName;
        public DateTime? DateOfBirth;


        public CreateMedicalProcedureApprovalRequest(Guid id, int originalVersion, string patientId, string patientName, DateTime? dateOfBirth)
        {
            Id = id;
            OriginalVersion = originalVersion;
            PatientName = patientName;
            PatientId = patientId;
            DateOfBirth = dateOfBirth;
        }
    }

    public class UpdateMedicalProcedureApprovalRequest : Command
    {
        public readonly Guid Id;
        public readonly string PatientName;

        public UpdateMedicalProcedureApprovalRequest(Guid id, string patientName)
        {
            Id = id;
            PatientName = patientName;
        }
    }

}
