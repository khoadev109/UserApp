using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UserApp.Application.Common.Models;
using UserApp.Application.Dto;
using UserApp.Application.Users.Commands.Save;
using UserApp.Application.Users.Queries;

namespace UserApp.WebApi.Controllers
{
    [Authorize]
    public class UserController : BaseApiController
    {
        /// <summary>
        /// Get all users
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ServiceResult<List<UserDto>>>> GetAllUsers(CancellationToken cancellationToken)
        {
            //Cancellation token example.
            return Ok(await Mediator.Send(new GetAllUsersQuery(), cancellationToken));
        }

        /// <summary>
        /// Save user
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResult<UserDto>>> Save(SaveUserCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }
    }
}
