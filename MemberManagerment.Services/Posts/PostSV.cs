using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemberManagerment.Data.EF;
using ManaberManagement.Utilities;
using MemberManagement.ViewModels.ImageInPostViewModels;
using MemberManagement.ViewModels.Common;
using MemberManagement.Data.Entities;
using MemberManagement.ViewModels.ImageViewModels;
using MemberManagement.ViewModels.PostViewModels;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;


namespace MemberManagement.Services.Posts
{
    public class PostSV : IPostSV
    {
        private readonly MemberManagementContext _context;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        public PostSV(MemberManagementContext context)
        {
            _context = context;
      
        }

        public async Task<string> Delete(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return "Không tìm thấy bài viết";
            }
            var images =  _context.Images.Where(x => x.PostID == id);
            foreach (var image in images)
            {
                _context.Images.Remove(image);
            }
            _context.Posts.Remove(post);
            var a = await _context.SaveChangesAsync();
            if (a >0)
            {
                return "Xóa thành công";
            }
            return "Xóa thất bại";
        }

        public async Task<List<PostVM>> GetAll()
        {
            var query = from f in _context.Posts select f;
            var post = await query.Select(x => new PostVM()
            {
                Id = x.Id,
                Title = x.Title,
                CreatedDate = x.CreatedDate,
                ModifiedDate = x.ModifiedDate,
                AuthorId = x.AuthorId,
                Content = x.Content,
            }).ToListAsync();

            return post;
        }

        public async Task<PostVM> GetById(int id)
        {
            var imageVM = new ImageVM();
            var post = await _context.Posts.
                Where(x => x.Id == id).FirstOrDefaultAsync();
            if (post == null)
                throw new MemberManagementException("Không tìm thấy bài viết");



            var imagePost = new ImageInPostVM()
            {
                Image = imageVM,
            };

            var postVM = new PostVM()
            {
                Id = post.Id,
                CreatedDate = post.CreatedDate,
                Title = post.Title,
                Content = post.Content,
                ModifiedDate = post.ModifiedDate,
                ImageInPosts = imagePost,


            };
            return postVM;
        }

        public async Task<PagedResult<PostVM>> GetPagedResult(GetPostPagingRequest request)
        {
            var query = from f in _context.Posts
                        select  f;
            if (request.IdMumber.HasValue)
                query = query.Where(x => x.AuthorId == request.IdMumber.Value);
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.Title.Contains(request.Keyword));
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                .Select(x => new PostVM()
                {
                    Id = x.Id,
                    Title = x.Title,
                    CreatedDate = x.CreatedDate,
                    ModifiedDate = x.ModifiedDate,
                    AuthorId = x.AuthorId,
                    Content = x.Content,
                    PathFile = _context.Images.FirstOrDefault(_=>_.PostID == x.Id).ImagePath,
                }).ToListAsync();

            var pagedResult = new PagedResult<PostVM>()
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = totalRow,
                Items = data
            };
            return pagedResult;
        }
        public async Task<Post> Update(int id, PostEditRequest request)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                throw new MemberManagementException("Không tìm thấy thông tin !");
            }

            post.Title = request.Title;
            post.CreatedDate = request.CreatedDate;
            post.ModifiedDate = request.ModifiedDate;
            post.AuthorId = request.AuthorId;
            post.Content = request.Content;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GetById(id) == null)
                {
                    throw new MemberManagementException("Không tìm thấy thông tin");
                }
                else
                {
                    throw;
                }
            }
            return post;
        }

        public async Task<int> AddImage(int postId, ImageInPostCreateRequest request)
        {
            var image = await _context.Images.FindAsync(request.ImageId);

            if (image == null)
            {
                throw new MemberManagementException("Thông tin không hợp lệ");
            }

            return image.Id;
        }


        public async Task<ApiResult<string>> Create(PostCreateRequest request)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x => x.Title == request.Title);
            if (post != null)
            {
                return new ApiErrorResult<string>("Bài viết đã tồn tại");
            }

            post = new Post()
            {
                Title = request.Title,
                CreatedDate = request.CreatedDate,
                ModifiedDate = request.ModifiedDate,
                AuthorId = request.AuthorId,
                Content = request.Content,
                
            };
            //Save image
            if (request.ThumbnailImage != null)
            {
                post.Images = new List<Image>()
                {
                   
                    new Image()
                    {
                        DateCreated = DateTime.Now,
                        FileSize = request.ThumbnailImage.Length,
                        ImagePath = request.ThumbnailImage.FileName,
                    }
                };
            }
            _context.Posts.Add(post);
            var a = await _context.SaveChangesAsync();
            if (a > 0)
            {
                return new ApiSuccessResult<string>("Tạo thành công");

            }
            return new ApiErrorResult<string>("Tạo mới thất bại");
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }
    }
}
        
    
