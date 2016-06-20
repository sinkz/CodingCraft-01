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
        public int IDPurchase { get; set; }
    }
}