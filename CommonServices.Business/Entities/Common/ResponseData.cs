using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonServices.Business.Entities.Common
{
    public class ResponseData
    {
        public string MessageCode { set; get; }
        public string MessageText { set; get; }
        public EnumMessageType MessageType { set; get; }
        public bool HasException { set; get; }
        public string Exception { set; get; }

        private List<Object> oData;
        public List<Object> Data
        {
            get
            {
                return oData;
            }
            set
            {
                oData = value;
            }
        }

        public void Add(Object p_Object)
        {
            if (oData == null)
            {
                oData = new List<Object>();
            }
            oData.Add(p_Object);
        }
    }

    public enum EnumMessageType
    {
        OPERATION_SUCCESS = 1, OPERATION_TECHNICAL_ERROR = 2, OPERATION_APPLICATION_ERROR = 3, INCOMPLETE_DATA = 4
    }

    public static class MessageCodes
    {
        public const string REQUEST_INCOMPLETE = "422";
        public const string REQUEST_ERROR = "500";
        public const string REQUEST_SUCCESS = "200";
    }
}
