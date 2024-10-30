using Data.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Objective
    {
        private Objective() { }
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Priority Priority { get; set; }
        public bool IsDeleted { get; set; }

        public Guid CreatorId { get; set; }
        public User Creator { get; set; } = null!;

        public ICollection<ObjectiveExecutor> Executors { get; set; } = null!;
    }
}
