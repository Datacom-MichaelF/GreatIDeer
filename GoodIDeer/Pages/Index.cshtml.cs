﻿using GoodIDeer.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GoodIDeer.Pages
{
    public class IndexModel : PageModel
    {

        public string Response { get; set; }

        public async Task OnGet()
        {
            string imageFilePath = @"C:\Work\Other\GoodDeer\GoodIDeer\images\deer01.jpg";

            VisionApiService MakeAnalysis = new VisionApiService();
            /*var respose =*/
            var response = await MakeAnalysis.MakeAnalysisRequest(imageFilePath);

            var content = await response.Content.ReadAsStringAsync();
            var thing = JsonConvert.DeserializeObject<Model.RootObject>(content);
            Response = thing;
        }

        public void processImage()
        {

        }
    }
}
