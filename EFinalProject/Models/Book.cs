using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFinalProject.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CreatedDate { get; set; }
        public int? AuthorId { get; set; }
        public Author? Author { get; set; }
        public int? GenerId { get; set; }
        public Gener? Gener { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}
