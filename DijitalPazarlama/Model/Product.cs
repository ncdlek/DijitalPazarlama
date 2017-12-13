using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijitalPazarlama.Model
{
    public class Product : BaseModel
    {
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public decimal price { get; set; }

        private string _pictureName;
        public string PictureName {
            get
            {
                return @"img\" + _pictureName;
            }
            set { _pictureName = value; }
        }

        public override string ToString()
        {
            return $"{Name} - {Description}";
        }
    }
}
