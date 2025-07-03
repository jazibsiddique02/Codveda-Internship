using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3__Exception_Handling_and_Debugging_
{
    class InvalidAmountException : Exception
    {
        public InvalidAmountException(string message):base(message)
        {
            
        }
    }
}
