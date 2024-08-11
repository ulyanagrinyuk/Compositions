using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Compositions;

namespace Compositions.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Composition _music;

        [BindProperty]
        public Music Music { get; set; }

        public CreateModel(Composition music)
        {
            _music = music;
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var music = _music.GetFilms();
            music.Add(Music);
            _music.SaveFilms(music);

            return RedirectToPage("./Index");
        }
        public void OnGet()
        {
        }
    }
}
