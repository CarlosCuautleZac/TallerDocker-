﻿using Models.Abstractions;
using Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetAllUsers(Guid id);
        Task<bool> AddUser(CreateOrUpdateUserRequest user);
        Task<bool> UpdateUser(Guid id, CreateOrUpdateUserRequest user);
    }
}
