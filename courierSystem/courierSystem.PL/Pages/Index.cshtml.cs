using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using courierSystem.BLL.Services;
using courierSystem.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace courierSystem.PL.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AccountService _accountService;

        public IndexModel(AccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public AdminAccount LogIn { get; set; } = new AdminAccount();

        public void OnGet()
        {
            LogIn = new AdminAccount();
        }

        public async Task<IActionResult> OnPostLogInAsync()
        {
            if (ModelState.IsValid)
            {
                bool logSuccessful = await _accountService.LogInAsync(LogIn.Username, LogIn.Password);

                if (logSuccessful)
                {
                    return RedirectToPage("/Main");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid username or password");
                }
            }
            return Page();
        }
    }
}
