using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PathfinderManagement.Models
{
    public class PathfindersDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Group { get; set; }
        public Counsellors Counsellor { get; set; }
        }
    }

