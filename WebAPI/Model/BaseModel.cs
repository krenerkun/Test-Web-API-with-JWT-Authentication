using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public class BaseModel
    {
        public long ID { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}
