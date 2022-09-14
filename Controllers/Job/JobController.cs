using JobPortal.Service.Jobs;
using JobPortal.Service.Roles;
using Jobportel.Api.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobportel.Data.Model;

namespace JobPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : BaseController
    {
        private readonly IJobService _jobService;
        public JobController(IJobService job)
        {
            _jobService = job;
        }

        [HttpGet("Jobs")]
        public async Task<IActionResult> GetRoles()
        {
            var Jobs = await _jobService.GetAll();
            return OkResponse("Success", Jobs);
        }

        [HttpPost("Job/{id}")]
        public async Task<IActionResult> GetRoleById(int Id)
        {
            Job job  = await _jobService.GetById(Id);
            return OkResponse("Sucess", job);
        }

        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole(Job job)
        {
            await _jobService.Add(job);
            return OkResponse("Sucess", job);
        }

        [HttpPut("UpdateRole")]
        public async Task<IActionResult> UpdateRole(Job job)
        {
            await _jobService.Update(job);
            return OkResponse("Sucess", job);
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteRole(int Id)
        {
            await _jobService.Delete(Id);
            return OkResponse("Sucess", Id);
        }

    }
}
