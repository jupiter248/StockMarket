using Api.Dtos.Stock;
using Api.Models;

namespace Api.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stock stockModel)
        {
            return new StockDto()
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                MarketCap = stockModel.MarketCap,
                Industry = stockModel.Industry,
                Comments = stockModel.Comments.Select(s => s.ToCommentDto()).ToList(),
            };
        }
        public static Stock ToStockFromCreateDto(this CreateStockRequestDto createStockRequestDto)
        {
            return new Stock()
            {
                Symbol = createStockRequestDto.Symbol,
                CompanyName = createStockRequestDto.CompanyName,
                Purchase = createStockRequestDto.Purchase,
                LastDiv = createStockRequestDto.LastDiv,
                Industry = createStockRequestDto.Industry,
                MarketCap = createStockRequestDto.MarketCap,
            };
        }
        public static Stock ToStockFromUpdateDto(this UpdateStockRequestDto updateStockRequestDto)
        {
            return new Stock()
            {
                Symbol = updateStockRequestDto.Symbol,
                CompanyName = updateStockRequestDto.CompanyName,
                Purchase = updateStockRequestDto.Purchase,
                LastDiv = updateStockRequestDto.LastDiv,
                Industry =updateStockRequestDto.Industry,
                MarketCap = updateStockRequestDto.MarketCap,
            };
        }
    }
}
