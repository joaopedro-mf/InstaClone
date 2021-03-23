using InstaClone.Domain.SeedWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaClone.WebAPI.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected ActionResult CustomResponse(IResponse result)
        {
            if (!result.Sucesso)
            {
                return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
                {
                    { "Messages", result.GetErros() }
                }));
            }
            return Ok(result.GetResponse());
        }

        protected int GetJwtIdentifier()
        {
            try
            {
                return Int32.Parse(User.Claims.FirstOrDefault(c => c.Type.Contains("nameidentifier")).Value);
            }
            catch
            {
                return 0;
            }
        }

    }
}
