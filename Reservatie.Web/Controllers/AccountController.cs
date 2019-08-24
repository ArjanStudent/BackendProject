using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Reservatie.Core.Models;
using Reservatie.Models.Models;

namespace Reservatie.Web.Controllers
{
    [Authorize(Roles="Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;

        }
        // GET: Account
        public ActionResult Index()
        {

            var col_UserDTO = new List<ExpandedUserDTO>();
            var result = _userManager.Users
                .OrderBy(x => x.UserName)
                .ToList();
            foreach(var item in result)
            {
                ExpandedUserDTO objUserDTO = new ExpandedUserDTO();
                List<string> UserRoles = new List<string>();
                objUserDTO.UserName = item.UserName;
                objUserDTO.Email = item.Email;
                objUserDTO.Name = item.Name;
                var roles = _userManager.GetRolesAsync(item).Result.ToList();
                foreach(var role in roles)
                {
                    UserRoles.Add(role);
                }
                objUserDTO.Roles = UserRoles;
                col_UserDTO.Add(objUserDTO);
            }
            var users = col_UserDTO;
            return View(users);
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Account/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}