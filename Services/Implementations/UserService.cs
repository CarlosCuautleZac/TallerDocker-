using Microsoft.EntityFrameworkCore;
using Models.Abstractions;
using Models.Db;
using Models.Requests;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class UserService:IUserService
    {
        private readonly DatabaseContext _dbContext;
        public UserService(DatabaseContext db)
        {
            _dbContext = db;
        }

        //Regresamos la lista de usuarios
        public async Task<List<User>> GetAllUsers()
        {
            var users = await _dbContext.Users.ToListAsync();
            return users;
        }

        //Regresamos un usuario
        public async Task<User> GetAllUsers(Guid id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }

        //Añadimos un usuario
        public async Task<bool> AddUser(CreateOrUpdateUserRequest user)
        {
            User model = new User()
            {
                Id = Guid.NewGuid(),
                Name = user.Name,
                Age = user.Age,
                LastName = user.LastName
            };

            await _dbContext.Users.AddAsync(model);
            int result = await _dbContext.SaveChangesAsync();
            return result != -1; ;
        }

        //Actualizamos un usuario
        public async Task<bool> UpdateUser(Guid id, CreateOrUpdateUserRequest user)
        {
            var model = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (model != null)
            {
                model.Name = user.Name;
                model.Age = user.Age;
                model.LastName = user.LastName;
                int result = await _dbContext.SaveChangesAsync();
                return result != -1;
            }

            return false;

        }

       
    }
}
