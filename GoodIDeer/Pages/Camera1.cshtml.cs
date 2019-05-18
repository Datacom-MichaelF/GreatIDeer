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
        
        public async Task OnGet()
        {
            var imagePaths = new List<string>
            {
                @"C:\Users\MichaelFo\Downloads\Deer.jpg",
                @"C:\Users\MichaelFo\source\repos\GoodIDeer\GoodIDeer\wwwroot\images\deer01.jpg",
                @"C:\Users\MichaelFo\source\repos\GoodIDeer\GoodIDeer\wwwroot\images\deer02.jpg"
            };

            VisionApiService MakeAnalysis = new VisionApiService();

            foreach(var image in imagePaths)
            {
                var response = await MakeAnalysis.MakeAnalysisRequest(image);

                var content = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<Model.RootObject>(content);

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
