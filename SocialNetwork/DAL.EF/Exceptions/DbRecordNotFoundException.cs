using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF.Exceptions
{
    public class DbRecordNotFoundException : ArgumentException
    {
        public DbRecordNotFoundException()
        {
        }

        public DbRecordNotFoundException(string message, string paramName) : base(message, paramName)
        {
        }

    }
}
