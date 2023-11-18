using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using noo.api.Work.Aggregations.WorkTask.DataAbstraction;
using noo.api.Work.Aggregations.WorkTask.Services;
using noo.api.Core.Request;
using noo.api.Core.Security.Permissions;

namespace noo.api.Work;

[ApiController]
[Route("course")]
public class WorkTaskController : ControllerBase
{
    private readonly Core.Log.ILogger logger;
    private readonly WorkValidator validator;
    private readonly IWorkTaskService workTaskService;

    private readonly IRequestContext requestContext;

    public WorkTaskController(Core.Log.ILogger logger, WorkValidator validator, IWorkTaskService workTaskService, IRequestContext requestContext)
    {
        this.logger = logger;
        this.validator = validator;
        this.workTaskService = workTaskService;
        this.requestContext = requestContext;
    }

    [Authorize]
    [HttpPost]
    
    public async Task<IActionResult> CreateWorkTask(WorkTaskModel workTask)
    {
        this.requestContext.PermissionResolver.HasPermission(Permissions.CreateWorks);
        try
        {
            await this.workTaskService.CreateAsync(workTask);
            return Ok();
        }
        catch (Exception e)
        {
            logger.Log(e);
            return BadRequest(e.Message);
        }
    }

    public async Task<IActionResult> UpdateWorkTask(WorkTaskModel workTask)
    {
        this.requestContext.PermissionResolver.HasPermission(Permissions.CreateWorks);
        try
        {
            await this.workTaskService.UpdateAsync(workTask);
            return Ok();
        }
        catch (Exception e)
        {
            logger.Log(e);
            return BadRequest(e.Message);
        }
    }

    public async Task<IActionResult> DeleteWorkTask(Ulid id)
    {
        this.requestContext.PermissionResolver.HasPermission(Permissions.CreateWorks);
        try
        {
            await this.workTaskService.DeleteAsync(id);
            return Ok();
        }
        catch (Exception e)
        {
            logger.Log(e);
            return BadRequest(e.Message);
        }
    }

        public async Task<IActionResult> CheckWorkTask(WorkTaskModel workTask)
    {
        this.requestContext.PermissionResolver.HasPermission(Permissions.CheckWorks);
        try
        {
            await this.workTaskService.UpdateAsync(workTask);
            return Ok();
        }
        catch (Exception e)
        {
            logger.Log(e);
            return BadRequest(e.Message);
        }
    }

        public async Task<IActionResult> SolveWorkTask(WorkTaskModel workTask)
    {
        this.requestContext.PermissionResolver.HasPermission(Permissions.SolveWorks);
        try
        {
            await this.workTaskService.UpdateAsync(workTask);
            return Ok();
        }
        catch (Exception e)
        {
            logger.Log(e);
            return BadRequest(e.Message);
        }
    }
}