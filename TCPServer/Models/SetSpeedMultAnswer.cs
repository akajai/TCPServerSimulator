using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPServer.Models
{
    public struct SetSpeedMultAnswer
    {
        //Answer
        int Cmd= 0x2004;// SetSpeedMult
        int Error;// Error code(always Ok)

        public SetSpeedMultAnswer()
        {
            Cmd = 0x2004;
            Error = (int)Errors.Ok;
        }
    }
}
