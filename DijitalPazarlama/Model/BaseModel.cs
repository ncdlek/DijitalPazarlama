using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijitalPazarlama.Model
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public DateTime AddedDate { get; set; }
    }
}
