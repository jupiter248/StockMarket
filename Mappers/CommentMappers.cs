using api.Models;
using Api.Dtos.Comment;
using Api.Models;

namespace Api.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto()
            {
                Id = commentModel.Id,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                Title = commentModel.Title,
                StockId = commentModel.StockId,
                CreatedBy = commentModel.AppUser.UserName

            };
        }
        public static Comment ToCommentFromCreate(this CreateCommentRequestDto createCommentDto, int stockId)
        {
            return new Comment()
            {
                Title = createCommentDto.Title,
                Content = createCommentDto.Content,
                StockId = stockId,
            };
        }
        public static Comment ToCommentFromUpdate(this UpdateCommentRequsetDto updateDto)
        {
            return new Comment()
            {
                Title = updateDto.Title,
                Content = updateDto.Content,
            };
        }
    }
}
