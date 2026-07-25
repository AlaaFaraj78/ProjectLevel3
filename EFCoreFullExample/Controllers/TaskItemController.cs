using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pioneersacademy.Domains.Entities;
using Pioneersacademy.Domains.Interfaces;
using Pioneersacademy.Infrastacture;

namespace Pioneersacademy.Web.Controllers;

public class TaskItemController : Controller
{
    private readonly IUser _userService;
    private readonly ITaskItem _taskItemService;
    private readonly TaskManagmentSystemDbContext _dbContext;

    public TaskItemController(IUser userService, ITaskItem taskItemService, TaskManagmentSystemDbContext dbContext)
    {
        _userService = userService;
        _taskItemService = taskItemService;
        _dbContext = dbContext;
    }
    public async Task<IActionResult> Index(int userId)
    {
        // var generalResponse = new GeneralResponse();
        // var userService = new UserService();

        var result = await _userService.GetById(userId);

        // load status and priority lookup data from database for the form selects
        var statuses = await _dbContext.TaskStatuses.AsNoTracking().ToListAsync();
        var priorities = await _dbContext.TaskPriorities.AsNoTracking().ToListAsync();
        var tasks = await _taskItemService.GetAll(userId);

        var model = new Pioneersacademy.Domains.DTOs.TaskItemIndexViewModel
        {
            UserInfo = result,
            Statuses = statuses,
            Priorities = priorities,
            Tasks = tasks
        };

        return View(model);

    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(TaskItem request)
    {
        if (request is null)
        {
            return BadRequest();
        }

        await _taskItemService.Create(request);
        // redirect back to the user's task list
        return RedirectToAction("Index", new { userId = request.AssignedUserId });
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {

        await _taskItemService.Delete(id);
        return RedirectToAction("Index");

    }
}
