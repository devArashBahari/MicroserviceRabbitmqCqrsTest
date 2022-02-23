using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class SaleEntity
    {
        [Key]
        public int Id { get; set; }
        public string Product { get; set; }
        public int Count { get; set; }
    }
}
