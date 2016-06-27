using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodingCraft01.Models
{
    public class Purchase
    {
        [Key]
        public Guid PurchaseId { get; set; }
        [Required]
        public decimal Total { get; set; }
        [Required]
        public DateTime DatePurchase { get; set; }
        [Required]
        public DateTime PayDay { get; set; }

        public virtual ICollection<PurchaseProduct> PurchaseProducts { get; set; }



    }
}