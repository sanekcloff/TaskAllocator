using Data.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string? Description { get; set; } = null!;
        public Priority Priority { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ExecuteDate { get; set; }

        public Guid CreatorId { get; set; }
        public User Creator { get; set; } = null!;

        public ICollection<ObjectiveExecutor> Executors { get; set; } = null!;

        public bool IsDeleted { get; set; }

        [NotMapped]
        public string ShortCreationDate => CreationDate.ToString("g");
        public string ShortExecuteDate => ExecuteDate?.ToString("g")!;
        public string PriorityText
        {
            get
            {
                var text = string.Empty;
                switch (Priority)
                {
                    case Priority.Low:
                        text = "Низкий";
                        break;
                    case Priority.Medium:
                        text = "Средний";
                        break;
                    case Priority.High:
                        text = "Высокий";
                        break;
                }
                return text;
            }
        }
        public string DescirptionText => Description == null ? "Описание отсутсвует" : Description ;
    }
}
