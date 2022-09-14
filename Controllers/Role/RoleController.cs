using JobPortal.Service.Roles;
using Jobportel.Api.Controllers;
using Jobportel.Data.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JobPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService role)
        {
            _roleService = role;
        }
        [HttpGet("Roles")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _roleService.GetAll();
            return OkResponse("Success", roles);
        }

        [HttpPost("Role/{id}")]
        public async Task<IActionResult> GetRoleById(int Id)
        {
            Role role = await _roleService.GetById(Id);
            return OkResponse("Sucess", role);
        }

        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole(Role role)
        {
            await _roleService.Add(role);
            return OkResponse("Sucess", role);
        }

        [HttpPut("UpdateRole")]
        public async Task<IActionResult> UpdateRole(Role role)
        {
            await _roleService.Update(role);
            return OkResponse("Sucess", role);
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteRole(int Id)
        {
            await _roleService.Delete(Id);
            return OkResponse("Sucess", Id);
        }



    }
}
