using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ManteqCodeTest.Core;
using ManteqCodeTest.Core.Domain;

namespace ManteqCodeTest.Controllers.Api
{
    public class ProcedureApprovalRequestController : ApiController
    {

        private FakeBus _bus;
      
        public ProcedureApprovalRequestController()
        {
            _bus = ServiceLocator.Bus;
        }

        [HttpGet]
        [Route("api/medicalprocedureapproval/getAll")]
        public List<ManteqApprovalRequest> GetAll()
        {
            using (var dataStoreContext = new SqlDataStoreContext())
            {
                return dataStoreContext.ManteqApprovalRequests.ToList();
            }
        }

        [Route("api/medicalprocedureapproval/createrequest")]
        [HttpPost]
        public IHttpActionResult Post()
        {
            var createMedicalProcedureApprovalRequest = new CreateMedicalProcedureApprovalRequest(Guid.NewGuid(), 1, "1", "Henry", DateTime.UtcNow);
            _bus.Send(createMedicalProcedureApprovalRequest);
            return this.Ok("Request Created");
        }

    }
}