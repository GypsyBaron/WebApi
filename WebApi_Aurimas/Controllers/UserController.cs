using System;
using DB;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApi_Aurimas.Models;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using HugDb.Repositoties;
using HugDb.Entities;

namespace WebApi_Aurimas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
       UserRepository _repository;
        public UserController(UserRepository repository)
        {
            _repository = repository;
        }

        private DbManager _dbManeger;

        [HttpGet]
        public List<UserModel> Get()
        {
            var users = _repository.GetAllUsers();
            var result = users.Select(x => new UserModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Created = x.Created,
                Id = x.Id,
                Email = x.Email
            }).ToList();

            return result;
        }

        [HttpPost]
        public string Post([FromBody]UserModel model)
        {
            var user = _repository.GetAllUsers();
            int exist = user.Where(x => x.Id == model.Id).Count();
            if (exist == 0)
            {
                User newUser = new User();

                newUser.FirstName = model.FirstName;
                newUser.LastName = model.LastName;
                newUser.Email = model.Email;
                newUser.Created = model.Created;

                _repository.AddUser(newUser);
                return "User Added";
            }
            else return "User not added";
        }
    }
}


