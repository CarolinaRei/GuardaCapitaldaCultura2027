using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GuardaCapitaldaCultura2027.Areas.Identity.Pages.Account
{
    public class RegistarModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegistarModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegistarModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegistarModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Key]
            public int TuristaId { get; set; }

            [Required(ErrorMessage = "Por favor, insira o seu Nome")]
            [StringLength(20, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 20 caracteres")]
            [Display(Name = "Nome *", Prompt = "Nome")]
            public String Nome { get; set; }

            [Required(ErrorMessage = "Por favor, insira o seu Sobrenome")]
            [StringLength(20, MinimumLength = 2, ErrorMessage = "O sobrenome deve ter entre 2 e 20 caracteres")]
            [Display(Name = "Sobrenome *", Prompt = "Sobrenome")]
            public String Sobrenome { get; set; }

            [StringLength(20)]
            [Display(Name = "Contacto", Prompt = "Contacto")]
            public String Contacto { get; set; }

            [StringLength(10)]
            [Display(Name = "NIF", Prompt = "NIF")]
            public String NIF { get; set; }

            [Required(ErrorMessage = "Por favor, insira o seu Email")]
            [StringLength(50, MinimumLength = 12, ErrorMessage = "O seu Email deve ter entre 12 e 50 caracteres")]
            [EmailAddress(ErrorMessage = "Por favor, introduza o seu Email correto")]
            [Display(Name = "Email *", Prompt = "Email")]
            public String Email { get; set; }

            [Required]
            [StringLength(20, ErrorMessage = "A sua Password deve ter entre 8 e 20 caracteres", MinimumLength = 8)]
            [DataType(DataType.Password)]
            [Display(Name = "Password *")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirmar password *")]
            [Compare("Password", ErrorMessage = "A password e a password de confirmação não correspondem.")]
            public string ConfirmPassword { get; set; }
        }
        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        #region snippet
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("/");
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("O Turista foi criado com sucesso");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Por favor, confirma no seu email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
        #endregion
    }
}
