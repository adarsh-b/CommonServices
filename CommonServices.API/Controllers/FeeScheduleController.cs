using CommonServices.Business.Entities.Common;
using CommonServices.Business.Entities.FeeSchedule;
using CommonServices.Business.Services.FeeSchedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CommonServices.API.Controllers
{
    public class FeeScheduleController : ApiController
    {
        private readonly string MSG_SUCCESS = "Operation executed successfully.";

        [HttpPost]
        [Authorize]
        public ResponseData GetFeeSchedule([FromBody] FeeScheduleParameter parameters)
        {
            ResponseData response = new ResponseData();
            try
            {
                FeeScheduleService service = new FeeScheduleService();
                FeeScheduleData data = service.GetFeeSchedule(parameters);

                response.MessageCode = MessageCodes.REQUEST_SUCCESS;
                response.MessageText = MSG_SUCCESS;
                response.MessageType = EnumMessageType.OPERATION_SUCCESS;
                response.Add(data);
                response.HasException = false;
            }
            catch (Exception ex)
            {
                response.MessageCode = MessageCodes.REQUEST_ERROR;
                response.HasException = true;
                response.MessageText = ex.Message;
                response.MessageType = EnumMessageType.OPERATION_APPLICATION_ERROR;
                response.Exception = ex.ToString();
            }

            return response;
        }

        [HttpPost]
        [Authorize]
        public ResponseData AddFeeSchedule([FromBody] FeeScheduleData parameters)
        {
            ResponseData response = new ResponseData();
            try
            {
                FeeScheduleService service = new FeeScheduleService();
                service.AddFeeSchedule(parameters);

                response.MessageCode = MessageCodes.REQUEST_SUCCESS;
                response.MessageText = MSG_SUCCESS;
                response.MessageType = EnumMessageType.OPERATION_SUCCESS;
                response.HasException = false;
            }
            catch (Exception ex)
            {
                response.MessageCode = MessageCodes.REQUEST_ERROR;
                response.HasException = true;
                response.MessageText = ex.Message;
                response.MessageType = EnumMessageType.OPERATION_APPLICATION_ERROR;
                response.Exception = ex.ToString();
            }

            return response;
        }
    }
}
