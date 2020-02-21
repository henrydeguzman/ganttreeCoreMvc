using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using ganttreeCoreMvc.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace ganttreeCoreMvc.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<StoreUser> _signInManager;
        private readonly UserManager<StoreUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        [Obsolete]
        private readonly IHostingEnvironment hostingEnvironment;

        [Obsolete]
        public RegisterModel(
            UserManager<StoreUser> userManager,
            SignInManager<StoreUser> signInManager,
            ILogger<RegisterModel> logger,
            
            IHostingEnvironment hostingEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
           
            this.hostingEnvironment = hostingEnvironment;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]           
            [Display(Name = "Username")]
            public string UserName { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            [Required]
            [Display(Name = "Photo upload")]
            public IFormFile FormFile { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {

                string uniqueFilename = null;
                string filePath = null;
                if (Input.FormFile != null) {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images/uploads");
                    uniqueFilename = Guid.NewGuid().ToString() + "_" + Input.FormFile.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFilename);
                    Input.FormFile.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                var user = new StoreUser { 
                    UserName = Input.UserName,                     
                    LastName = Input.LastName,
                    FirstName = Input.FirstName,
                    photoUrl = uniqueFilename
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                   // var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                   // code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                     //   values: new { area = "Identity", userId = user.Id, code = code },
                     //   protocol: Request.Scheme);

                    // await _emailSender.SendEmailAsync(Input.UserName, "Confirm your email",
                        // $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                   // if (_userManager.Options.SignIn.RequireConfirmedAccount)
                  //  {
                        // return RedirectToPage("RegisterConfirmation", new { email = Input.Email });
                   // }
                  //  else
                  //  {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Userprof");
                    
                 //   }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
