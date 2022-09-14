using JobPortal.Service.Applicants;
using Jobportel.Api.Controllers;
using Jobportel.Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Api.Controllers.Applicants
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : BaseController
    {
        private readonly IApplicantService _applicantService;
        public ApplicantController(IApplicantService applicant)
        {
            _applicantService = applicant;
        }

        [HttpGet("Applicant")]
        public async Task<IActionResult> GetRoles()
        {
            var Jobs = await _applicantService.GetAll();
            return OkResponse("Success", Jobs);
        }

        [HttpPost("Applicant/{id}")]
        public async Task<IActionResult> GetApplicantById(int Id)
        {
            Applicant applicant = await _applicantService.GetById(Id);
            return OkResponse("Sucess", applicant);
        }

        [HttpPost("Addapplicant")]
        public async Task<IActionResult> AddRole(Applicant applicant)
        {
            Applicant applicants= await _applicantService.Add(applicant);
            return OkResponse("Sucess", applicants);
        }

        [HttpPut("UpdateRole")]
        public async Task<IActionResult> UpdateRole(Applicant applicant)
        {
           var applicants= await _applicantService.Update(applicant);
            return OkResponse("Sucess", applicants);
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteRole(int Id)
        {
            await _applicantService.Delete(Id);
            return OkResponse("Sucess", Id);
        }

    }
}

