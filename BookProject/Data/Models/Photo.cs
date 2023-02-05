using Photoshop.Data.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Photoshop.Data.Models
{
    public class Photo : BaseModel
    {
        [Required]
        public string Title { get; set; }
       
        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string BuyerName { get; set; }

        public string BuyerAddress { get; set; }

        public string BuyerPhone { get; set; }

        public DateTime PurchseDate { get; set; }

        public Genre Genre { get; set; }
        
        public Guid GenreId { get; set; }

        public Photo()
        {
            this.PurchseDate = DateTime.Now;
        }

    }
}
