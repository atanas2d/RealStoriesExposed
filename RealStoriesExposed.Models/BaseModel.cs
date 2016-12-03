using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStoriesExposed.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }

        public DateTime? CreatedOn { get; set; }

        public bool isDelated { get; set; }
    }
}
