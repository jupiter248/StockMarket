using System.ComponentModel.DataAnnotations;

namespace Api.Dtos.Comment
{
    public class UpdateCommentRequsetDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Title should has atlest 3 characters")]
        [MaxLength(250, ErrorMessage = "Title connot be over 250 characters")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MinLength(3, ErrorMessage = "Content should has atlest 3 characters")]
        [MaxLength(250, ErrorMessage = "Content connot be over 250 characters")]
        public string Content { get; set; } = string.Empty;
    }
}
