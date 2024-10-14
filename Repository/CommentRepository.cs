using Api.Models;
using Api.Data;
using Api.Dtos.Comment;
using Api.Interfaces;
using Api.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Comment?> CreateAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.Include(c => c.AppUser).ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            var commentModel = await _context.Comments.Include(a => a.AppUser).FirstOrDefaultAsync(f => f.Id == id);
            if (commentModel == null)
            {
                return null;
            }
            return commentModel;
        }
        public async Task<Comment?> DeleteAsync(int id)
        {
            var commentModel = await _context.Comments.FirstOrDefaultAsync(f => f.Id == id);
            if (commentModel == null)
            {
                return null;
            }
            _context.Comments.Remove(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<Comment?> UpdateAsync(int id, Comment comment)
        {
            var commentModel = await _context.Comments.FirstOrDefaultAsync(f => f.Id == id);
            if(commentModel == null) return null;
            commentModel.Title = comment.Title;
            commentModel.Content = comment.Content;
            await _context.SaveChangesAsync();
            return commentModel;

        }
    }
}
