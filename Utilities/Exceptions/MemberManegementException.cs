using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Exceptions
{
     public class MemberManegementException : Exception
    {
        public MemberManegementException()
        {

        }
        public MemberManegementException(string message) : base(message)
        {

        }
        public MemberManegementException(string message, Exception e) : base(message,e)
        {

        }
    }
}
