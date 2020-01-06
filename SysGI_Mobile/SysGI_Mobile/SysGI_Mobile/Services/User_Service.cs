using SysGI_Mobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SysGI_Mobile.Services
{
    public class User_Service:Interface<User>
    {
        public static User user_logged;

        public static void Save_Login(User user)
        {

        }
        public static void Reset_Login()
        {
            
        }

        public async Task<bool> Add(User user)
        {
            await Network.Collection_users.InsertOneAsync(user);
            return true;
        }

        public async Task<bool> Delete(User user)
        {
            //await Network.Collection_users.DeleteOneAsync(u => u.Id == user.Id);
            return true;
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
