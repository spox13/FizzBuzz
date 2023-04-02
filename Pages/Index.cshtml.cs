using FizzBuzz.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FizzBuzz.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public FizzBuzzForm FizzBuzz { get; set; } = new FizzBuzzForm();
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                Name = "User";
            }
        }
        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                Name = "User";
            }
            /*if (!ModelState.IsValid)
            {
                return Page();
            }*/

            if (FizzBuzz.Number != null && (FizzBuzz.Number > 0 && FizzBuzz.Number < 1001))
            {
                if (FizzBuzz.Number % 3 == 0 && FizzBuzz.Number % 5 == 0)
                {
                    ViewData["Message"] = "FizzBuzz";
                }
                else if (FizzBuzz.Number % 3 == 0)
                {
                    ViewData["Message"] = "Fizz";
                }
                else if (FizzBuzz.Number % 5 == 0)
                {
                    ViewData["Message"] = "Buzz";
                }
                else
                {
                    ViewData["Message"] = $"Liczba: {FizzBuzz.Number} nie spełnia kryteriów FizzBuzz";
                }
            }

            return Page();
        }
    }
}