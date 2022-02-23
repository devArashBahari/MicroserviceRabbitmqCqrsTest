using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellar.Domain
{
    public class CellarEntity
    {
        [Key]
        public int Id { get; set; }
        public string product { get; set; }
        public int Count { get; set; }
    }
}
