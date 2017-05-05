using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace LearnToCook
{
    class ContentManager
    {
        public static async Task<InfoPage> GetInfoPageJSON(string pageType)
        {
            // URI for JSON
            var uri = "ms-appx:///Assets/Pages/" + pageType + ".json";
            var pageUri = new Uri(uri);

            // get the file
            var pageFile = await StorageFile.GetFileFromApplicationUriAsync(pageUri);

            // read the contents
            var pageJSON = await FileIO.ReadTextAsync(pageFile);

            var pageObject = JsonObject.Parse(pageJSON);

            var page = new InfoPage();
            page.Content = new List<Content>();

            page.PageTitle = pageObject["PageTitle"].GetString();
            page.Subtitle = pageObject["Subtitle"].GetString();
            page.MainImage = pageObject["MainImage"].GetString();

            foreach (JsonValue item in pageObject["Content"].GetArray())
            {
                JsonObject aItem = item.GetObject();

                Content content = new Content {
                    Title = aItem["Title"].GetString(),
                    Text = aItem["Text"].GetString(),
                    Image = aItem["Image"].GetString()
                };

                page.Content.Add(content);
            }

            return page;
        }

        public static async Task<RecipeInfoPage> GetRecipesJSON()
        {
            // URI for JSON
            var uri = "ms-appx:///Assets/Pages/recipes.json";
            var pageUri = new Uri(uri);

            // get the file
            var pageFile = await StorageFile.GetFileFromApplicationUriAsync(pageUri);

            // read the contents
            var pageJSON = await FileIO.ReadTextAsync(pageFile);

            var pageObject = JsonObject.Parse(pageJSON);

            var page = new RecipeInfoPage();
            page.Recipes = new List<Recipe>();

            page.PageTitle = pageObject["PageTitle"].GetString();
            page.Subtitle = pageObject["Subtitle"].GetString();
            page.MainImage = pageObject["MainImage"].GetString();

            foreach (JsonValue item in pageObject["Content"].GetArray())
            {
                JsonObject aItem = item.GetObject();

                Recipe content = new Recipe
                {
                    Title = aItem["Title"].GetString(),
                    Text = aItem["Text"].GetString(),
                    Image = aItem["Image"].GetString(),
                    Serves = aItem["Serves"].GetString(),
                    PrepTime = aItem["PrepTime"].GetString(),
                    CookingTime = aItem["CookingTime"].GetString(),
                    Ingredients = aItem["Ingredients"].GetString(),
                    Method = aItem["Method"].GetString()
                };

                page.Recipes.Add(content);
            }

            return page;
        }

        public static async Task<JsonObject> GetCookeryTermsPageJSON()
        {
            var uri = "ms-appx:///Assets/Pages/CookeryTerms.json";
            var pageUri = new Uri(uri);

            // get the file
            var pageFile = await StorageFile.GetFileFromApplicationUriAsync(pageUri);

            // read the contents
            var pageJSON = await FileIO.ReadTextAsync(pageFile);

            return JsonObject.Parse(pageJSON);
        }

        public static async Task<JsonObject> GetQuizJSON()
        {
            // URI for JSON
            var uri = "ms-appx:///Assets/Pages/Quiz.json";
            var pageUri = new Uri(uri);

            // get the file
            var pageFile = await StorageFile.GetFileFromApplicationUriAsync(pageUri);

            // read the contents
            var pageJSON = await FileIO.ReadTextAsync(pageFile);

            return JsonObject.Parse(pageJSON);
        }
    }
}
