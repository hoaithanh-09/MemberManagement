using MemberManagement.Data.Entities;
using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.PostViewModels;
using MemberManagerment.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MemberManagement.Services.Posts
{
    public class PostSV : IPostSV
    {

        private readonly MemberManagementContext _context;
        public PostSV(MemberManagementContext context)
        {
            _context = context;
        }
        public async Task<int> Create(PostCreatRequest request)
        {
            var post = new Post()
            {
                AuthorId = request.UserId,
                Longitude = request.Longitude,
                Latitude = request.Latitude,
                CreatedDate = request.CreatedDate,
                ModifiedDate = request.ModifiedDate,
                Text = request.Text,

            };
            await _context.Postes.AddAsync(post);
            await _context.SaveChangesAsync();
            return post.Id;
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PostVM>> getAll()
        {
            var query = from f in _context.Postes select f;
            var post = await query.Select(x => new PostVM()
            {
                UserId = x.AuthorId,
                Longitude = x.Longitude,
                Latitude = x.Latitude,
                CreatedDate = x.CreatedDate,
                ModifiedDate = x.ModifiedDate,
                Text = x.Text,
            }).ToListAsync();

            return post;
        }

        public Task<PostVM> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<PostVM>> GetPagedResult(GetPostPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Post> Update(int id, PostEditRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
