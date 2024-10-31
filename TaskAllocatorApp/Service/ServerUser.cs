using CoreWCF;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServerUser
    {
        public User User { get; set; } = null!;
        public OperationContext OperationContext { get; set; } = null!;
    }
}
