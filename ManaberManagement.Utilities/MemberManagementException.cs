﻿using System;

namespace ManaberManagement.Utilities
{
    public class MemberManagementException : Exception
    {
        public MemberManagementException()
        {

        }
        public MemberManagementException(string message) : base (message)
        {

        }
        public MemberManagementException(string message, Exception exception) : base(message , exception)
        {

        }
    }
}
