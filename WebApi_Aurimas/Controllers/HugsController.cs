using System;
using DB;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApi_Aurimas.Models;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using HugDb.Repositoties;

namespace WebApi_Aurimas.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HugsController : ControllerBase
    {
        //private readonly ILogger _logger;
        // private readonly IMyTime _time;
        private UserRepository _repository;

        public HugsController(UserRepository repository)
        {
            // IMyTime myTime = new MyTime();
            // _logger = new FileLogger();
            //????????????_dbManeger = new DbManager();
            _repository = repository;
        }

        private DbManager _dbManeger;

        [HttpGet]
        public List<HugModel> Get()
        {
         //   var hugs = _dbManeger.GetHugs();

            /* var mappedHugs = hugs.Select(h => new HugModel
             {
                 From = h.From,
                 To = h.To,
                 Reason = h.Reason,
                 Created = h.Created,
                 Id = h.Id
             })
             .ToList();*/

            //   return mappedHugs;
            return null;
        }

        [HttpGet("{id}")]
        public HugModel Get(int id)
        {
            //var dbManeger = new DbManager();
            var hugs = _dbManeger.GetHugs();

            var mappedHugs = hugs.Select(h => new HugModel
            {
                From = h.From,
                To = h.To,
                Reason = h.Reason,
                Created = h.Created,
                Id = h.Id
            })
            .First(h => h.Id == id);

            return mappedHugs;
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            if (_dbManeger.DeleteById(id) == true) return true;
            else return false;
        }

        [HttpPost]
        public void Post([FromBody]HugModel model)
        {
            var newHug = new Hug
            {
                From = model.From,
                To = model.To,
                Reason = model.Reason,
                Created = model.Created,
                Id = model.Id
            };
            _dbManeger.AddNewModel(newHug);
        }

        [HttpPut]
        public void Put([FromBody]HugModel model)
        {
            var newHug = new Hug
            {
                From = model.From,
                To = model.To,
                Reason = model.Reason,
                Created = model.Created,
                Id = model.Id
            };
            _dbManeger.PutHug(newHug);
        }

        [HttpPatch]
        public void Patch([FromBody]HugModel model)
        {
            var newHug = new Hug
            {
                From = model.From,
                To = model.To,
                Reason = model.Reason,
                Created = model.Created,
                Id = model.Id
            };
            _dbManeger.PatchHug(newHug);
        }
    }
}


