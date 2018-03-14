using ShopOnline.Data.Infrastructure;
using ShopOnline.Data.Repositories;
using ShopOnline.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Service
{
    public interface IPostService
    {
        void AddPost(Post post);
        void Update(Post post);
        void Delete(Post post);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow);
        Post GetByID(int id);
        IEnumerable<Post> GetAllByTagPaging(string tag,int page, int pageSize, out int totalRow);
        void SaveChanges();

    }
    public class PostService : IPostService
    {
        IPostRepository _postRepository;
        IUnitOfWork _unitOfWork;

        public PostService(IPostRepository postRepository,IUnitOfWork unitOfWork)
        {
            this._postRepository = postRepository;
            this._unitOfWork = unitOfWork;
        }
        public void AddPost(Post post)
        {
            _postRepository.Add(post);
        }

        public void Delete(int id)
        {
            _postRepository.Delete(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll(new string[] { "Postcategory" });
        }

        public IEnumerable<Post> GetAllByTagPaging(string tag,int page, int pageSize, out int totalRow)
        {
            //TODO : select all post by tag
            return _postRepository.GetMultiPaging(x=>x.Status, out totalRow,page,pageSize);
        }

        public IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _postRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public Post GetByID(int id)
        {
            return _postRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
        }
    }
}
