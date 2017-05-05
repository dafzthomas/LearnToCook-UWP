using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnToCook
{
    class RecipeInfoPage
    {
        public string PageTitle { get; set; }
        public string Subtitle { get; set; }
        public string MainImage { get; set; }
        public List<Recipe> Recipes { get; set; }
    }
}
