using Microsoft.AspNetCore.Mvc;
using Pioneersacademy.Domains.DTOs;
using Pioneersacademy.Domains.Entities;
using Pioneersacademy.Domains.Interfaces;

namespace Pioneersacademy.Web.Controllers;

public class UserController : Controller
{
    private readonly IUser _userService;

    public UserController(IUser userService)
    {
        _userService = userService;
    }

    public async Task<IActionResult> Index()
    {
        var users = await _userService.GetAll();
        return View(users);
    }


    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(User request)
    {
        if (request is null)
        {
            return BadRequest();
        }

        await _userService.Create(request);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {

        await _userService.Delete(id);
        return RedirectToAction("Index");

    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var generalResponse = new GeneralResponse();
       // var userService = new UserService();

        var result = await _userService.GetById(id);
        generalResponse.UserInfo = result;

        return View(generalResponse);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(User request)
    {
        //var userService = new UserService();
        //var generalResponse = userService.Update(request);

        //return View("Edit", generalResponse);

        await _userService.Update(request);
        return RedirectToAction("Index");
    }
}
