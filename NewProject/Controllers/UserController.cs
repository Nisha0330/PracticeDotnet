using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewProject.Model;
using NewProject.Repo;

namespace NewProject.Controllers
{

    [Route("[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _dbcontext;

        public UserController(AppDbContext dbContext)
        {
           _dbcontext = dbContext; 
        }

        [HttpPost]
        public List<User> AddUser(User user)
        {
            _dbcontext.Users.Add(user);
            _dbcontext.SaveChanges();
            return GetAll();
        }
        [HttpGet]
        [Route("GetAll")]
        public List<User> GetAll()
        {
            var user =_dbcontext.Users.ToList();
            return user;
        }
    }
}
