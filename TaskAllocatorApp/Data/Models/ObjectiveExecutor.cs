using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class ObjectiveExecutor
    {
        private ObjectiveExecutor() { }

        public bool IsReady { get; set; }

        public Guid ObjectiveId { get; set; }
        public Objective Objective { get; set; } = null!;

        public Guid ExecutorId { get; set; }
        public User Executor { get; set; } = null!;
    }
}
