using api.Extensions;
using api.Models;
using Api.Dtos.Comment;
using Api.Interfaces;
using Api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IStockRepository _stockRepository;

        private readonly UserManager<AppUser> _userManager;

        public CommentController(ICommentRepository commentRepository, IStockRepository stockRepository, UserManager<AppUser> userManager)
        {
            _commentRepository = commentRepository;
            _stockRepository = stockRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepository.GetAllAsync();
            var commentDto = comments.Select(s => s.ToCommentDto());
            return Ok(commentDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var commentModel = await _commentRepository.GetByIdAsync(id);
            if (commentModel == null)
                return NotFound();
            return Ok(commentModel.ToCommentDto());
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var commentModel = await _commentRepository.DeleteAsync(id);
            if (commentModel == null) return NotFound();
            return Ok(commentModel.ToCommentDto());
        }
        [HttpPost("{stockId:int}")]
        [Authorize]
        public async Task<IActionResult> Create([FromRoute] int stockId, [FromBody] CreateCommentRequestDto createCommentDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var username = User.GetUsername();

            var appUser = await _userManager.FindByNameAsync(username);

            var commentModel = createCommentDto.ToCommentFromCreate(stockId);
            commentModel.AppUserId = appUser.Id;
            if (appUser == null) return BadRequest("User does not exist");

            bool stockExists = await _stockRepository.StockExists(stockId);

            if (!stockExists) BadRequest("the Stock does not exist");

            await _commentRepository.CreateAsync(commentModel);

            return CreatedAtAction(nameof(GetById), new { id = commentModel.Id }, commentModel.ToCommentDto());
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequsetDto updateCommentDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var comment = await _commentRepository.UpdateAsync(id, updateCommentDto.ToCommentFromUpdate());
            if (comment == null) return NotFound();
            return Ok(comment.ToCommentDto());
        }

    }
}
