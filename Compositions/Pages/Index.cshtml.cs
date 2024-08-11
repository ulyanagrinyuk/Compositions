using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Compositions.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Composition _music;

        public List<Music> Music { get; set; }

        public IndexModel(Composition music)
        {
            _music = music;
        }

        public void OnGet()
        {
            Music = _music.GetFilms();
        }

        public IActionResult OnPostDelete(string name)
        {
            var music = _music.GetFilms();
            var filmToRemove = music.FirstOrDefault(l => l.Attributes == name);
            if (filmToRemove != null)
            {
                music.Remove(filmToRemove);
                _music.SaveFilms(music);
            }
            return RedirectToPage();
        }
    }
}
