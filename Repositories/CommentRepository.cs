using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
          return await _context.Comments.FindAsync();
        }
       public async Task<Comment>CreateAsync(Comment commentModel){
        await _context.Comments.AddAsync(commentModel);
        await _context.SaveChangesAsync();
        return commentModel;
       }
    }
}