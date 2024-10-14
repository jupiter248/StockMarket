using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;

namespace api.Models
{
    [Table("Portfolios")]
    public class Portfolio
    {
        public required string AppUserId { get; set; }
        public required int StockId { get; set; }
        public AppUser? AppUser { get; set; }
        public Stock? Stock { get; set; }
    }
}