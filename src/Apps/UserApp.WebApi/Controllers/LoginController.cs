using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using UserApp.Application.ApplicationUser.Queries.GetToken;
using UserApp.Application.Common.Models;

namespace UserApp.WebApi.Controllers
{
    /// <summary>
    /// Login
    /// </summary>
    public class LoginController : BaseApiController
    {
        /// <summary>
        /// Login with credentials: khoa@test.com / P@ssw0rd
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResult<LoginResponse>>> Login(GetTokenQuery query, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(query, cancellationToken));
        }
    }
}
