using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArborFamiliae.Desktop.Messages
{
    public class ReloadDataMessage {
        public readonly static ReloadDataMessage AllData = new ReloadDataMessage();
        ReloadDataMessage() { }
    }
}
