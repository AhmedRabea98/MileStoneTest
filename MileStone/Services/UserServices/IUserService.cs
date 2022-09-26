using MileStone.Models;
using System;
using System.Collections.Generic;

namespace MileStone.Services.UserServices
{
    public interface IUserService
    {
        public List<User> GetUser();
        public User GetUser(Guid Id);
        public User AddUser(User user);
        public User Login(User user); 
        public User UpdateUser(Guid Id, User user);
        public void DeleteUser(Guid Id);
    }
}
