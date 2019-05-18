using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoodIDeer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace GoodIDeer.Pages
{
    public class Camera1Model : PageModel
    {
        public int DeerCount { get; set; }
        public int AnimalCount { get; set; }
        public int ImageCount { get; set; }
        
        public async Task OnGet()
        {
            var imagePaths = new List<string>
            {
                @"C:\Users\MichaelFo\Downloads\Understory.jpg"
                //@"C:\Users\MichaelFo\source\repos\GoodIDeer\GoodIDeer\wwwroot\images\Understory.jpg",
                //@"C:\Users\MichaelFo\source\repos\GoodIDeer\GoodIDeer\wwwroot\images\forest1.jpg",
                //@"C:\Users\MichaelFo\source\repos\GoodIDeer\GoodIDeer\wwwroot\images\deerInForest.jpg",
                //@"C:\Users\MichaelFo\source\repos\GoodIDeer\GoodIDeer\wwwroot\images\pigInForest.jpg"
            };

            ImageCount = imagePaths.Count();

            //string imageFilePath = @"C:\Users\MichaelFo\Downloads\Deer.jpg";

            VisionApiService MakeAnalysis = new VisionApiService();

            foreach(var image in imagePaths)
            {
                var response = await MakeAnalysis.MakeAnalysisRequest(image);

                var content = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<Model.RootObject>(content);

                if (json.objects[0] == null)
                {
                    return;
                }

                if (json.objects[0].@object == "Deer" && json.objects[0].confidence > 0.7)
                {
                    DeerCount++;
                }
                if (json.objects[0].@object == "mammal" || json.objects[0].parent.@object == "mammal" || json.objects[0].@object == "animal") {
                    AnimalCount++;
                }

            }
            

            //var content = await response.Content.ReadAsStringAsync();
            //var json = JsonConvert.DeserializeObject<Model.RootObject>(content);

            //if (json.objects[0].@object == "Deer" && json.objects[0].confidence > 0.7)
            //{
            //    DeerCount++;
            //}
        }
    }
}
