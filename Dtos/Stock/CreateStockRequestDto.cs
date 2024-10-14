using System.ComponentModel.DataAnnotations;

namespace Api.Dtos.Stock
{
    public class CreateStockRequestDto
    {
        [Required]
        [MaxLength(15, ErrorMessage = "Symbol cannot be over 15 characters")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MaxLength(15, ErrorMessage = "Company Name cannot be over 15 characters")]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        [Range(1, 1000000000)]
        public decimal Purchase { get; set; }
        [Required]
        [Range(0.001, 100)]
        public decimal LastDiv { get; set; }
        [Required]
        [MaxLength(15, ErrorMessage = "industry Name cannot be over 15 characters")]
        public string Industry { get; set; } = string.Empty;
        [Required]
        [Range(1, 50000000000)]
        public long MarketCap { get; set; }
    }
}
