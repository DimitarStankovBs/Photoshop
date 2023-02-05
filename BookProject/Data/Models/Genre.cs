using Photoshop.Data.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Photoshop.Data.Models
{
    public class Genre : BaseModel
    {
        public Genre()
        {
            this.Photo = new HashSet<Photo>();
        }
        [Required]
        
        public string Title { get; set; }
        
        public ICollection<Photo> Photo { get; set; }

    }
}
