using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PathfinderManagement.Models
{
    public class Counsellors
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rank { get; set; }
        public string Group { get; set; }
        public int GroupSize { get; set; }
    }
}
