using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace OpenDataSite.Controllers
{
    public class TestController : BaseApiController
    {
        private readonly IMediator _mediator;

        public TestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]   //api/test
        public async Task<ActionResult<List<Activity>>> GetTest()
        {
            //return await _context.Activity.ToListAsync();
            //return await _mediator.Send(new DanhSach.Query());
            return await Mediator.Send(new DanhSach.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetDetail(Guid id)
        {
            //return await _context.Activity.FindAsync(id);
            //return Ok();
            return await Mediator.Send(new ChiTiet.Query { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> CreateTest([FromBody] Activity activity)
        {
            return Ok(await Mediator.Send(new ThemMoi.Command { Entity = activity }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditTest(Guid id, Activity activity)
        {
            activity.Id = id;
            return Ok(await Mediator.Send(new CapNhat.Command { Entity = activity }));
        }
    }
}
