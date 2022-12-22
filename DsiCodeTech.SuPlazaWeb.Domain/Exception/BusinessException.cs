using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodeTech.SuPlazaWeb.Domain.Exception
{

    [Serializable]
    public class BusinessException : System.Exception
    {
        public BusinessException(string message) : base(message)
        {

        }

        public BusinessException(string message, System.Exception exception) : base(message, exception)
        {

        }

        protected BusinessException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
