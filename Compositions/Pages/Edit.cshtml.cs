using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Compositions.Pages
{
    public class EditModel : PageModel
    {
        private readonly Composition _music;

        [BindProperty]
        public Music Music { get; set; }

        public EditModel(Composition music)
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
