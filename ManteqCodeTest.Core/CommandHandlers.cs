﻿using ManteqCodeTest.Core;

namespace ManteqCodeTest.Core
{
    public class CommandHandlers
    {
        private readonly IRepository<MedicalApprovalProcedure> _repository;

        public CommandHandlers(IRepository<MedicalApprovalProcedure> repository)
        {
            _repository = repository;
        }

        public void Handle(CreateMedicalProcedureApprovalRequest message)
        {
            var item = new MedicalApprovalProcedure(message.Id, message.PatientId, message.PatientName, message.DateOfBirth);
          
            _repository.Save(item, -1);
        }


    }
}
