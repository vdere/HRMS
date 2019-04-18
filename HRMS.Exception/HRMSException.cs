using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Exceptions
{
    public class HRMSException : ApplicationException
    {
        //Default constructor
        public HRMSException()
            : base()
        { }

        //Parameterized constructor with message parameter
        public HRMSException(string Message) : base(Message)
        { }
    }
}
