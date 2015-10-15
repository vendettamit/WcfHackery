﻿using System;
using WcfRestAuthentication.Model;
using WcfRestAuthentication.Services.Api.Endpoints.User;

namespace WcfRestAuthentication.Services.Api
{
    public partial class ApiService : IUserService
    {
        private User CreateTestUser(Guid userId)
        {
            return User.Create(userId, "TestUser", "Test", "User");
        }

        public User Get(Guid userId)
        {
            return CreateTestUser(userId);
        }

        public User Post(User user)
        {
            return user;
        }

        public User Put(User user)
        {
            return user;
        }

        public void Delete(Guid userId)
        {
        }
    }

}