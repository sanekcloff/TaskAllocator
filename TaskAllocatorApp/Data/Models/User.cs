using Data.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class User
    {
        private User() { }
        public Guid Id { get; set; }
        public string Lastname { get; set; } = null!;
        public string Firstname { get; set; } = null!;
        public string Middlename { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public byte[]? ImageData { get; set; } = null!;
        public Status Status { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Objective> CreatedObjectives { get; set; } = null!;
        public ICollection<ObjectiveExecutor> ExecutingObjectives { get; set; } = null!;
    }
}

