using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PathfinderManagement.Models
{
    public class Pathfinders
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Group { get; set; }
        public Counsellors Counsellor { get; set; }
        }
    }

