using Backend.Models;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
namespace Backend.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;
        public UserService(IConfiguration config){
            var client = new MongoClient(config.GetConnectionString("DB"));
            var database = client.GetDatabase("MyDatabase");
            _users = database.GetCollection<User>("MyCollection");
        }
        public List<User> GetUsers()=>_users.Find(user=>true).ToList();
        public User GetUser(string id)=>_users.Find(User=>User.Id == id).FirstOrDefault();
        public User PostUser(User user){
            _users.InsertOne(user);
            return user;
        }
        public User PutUser(string id, User newUser){
            _users.ReplaceOne(user=>user.Id == id , newUser);
            return newUser;
        }
        public void DeleteUser(string id){
            _users.DeleteOne(user=>user.Id == id);
        }

    }
}
