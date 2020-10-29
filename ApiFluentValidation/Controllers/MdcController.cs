using System;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ApiFluentValidation.Controllers
{
    /// <summary>
    /// A command for adding user file to the system
    /// </summary>
    public class AddFileCommand
    {
        /// <summary>
        /// Device id the file is added from
        /// </summary>
        public Guid DeviceId { get; set; }
    }

    public class AddFileCommandValidator : AbstractValidator<AddFileCommand>
    {
        /// <summary>
        /// Creates instance of the <see cref="AddFileCommandValidator"/>
        /// </summary>
        public AddFileCommandValidator()
        {
            RuleFor(m => m.DeviceId)
                .NotEmpty()
                .WithErrorCode("GetError(25002)");
        }
    }

    [Route("[controller]")]
    public class MdcController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(@"POST to /mdc with `{""DeviceId"":""xxxxx""}");
        }

        [HttpPost]
        public IActionResult Index([FromBody]AddFileCommand addFileCommand)
        {
            if (ModelState.IsValid)
            {
                return Ok("VALID!");
            }
            else
            {
                return BadRequest(ModelState.Values);
            }
        }
    }
}
