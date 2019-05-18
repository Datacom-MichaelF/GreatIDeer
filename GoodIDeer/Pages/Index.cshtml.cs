using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoodIDeer.Model;
using GoodIDeer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace GoodIDeer.Pages
{
    public class IndexModel : PageModel
    {

        public string Response { get; set; }

        public void OnGet()
        {
            string imageFilePath = @"C:\Users\MichaelFo\Downloads\Deer.jpg";

            VisionApiService MakeAnalysis = new VisionApiService();
            /*var respose =*/
            var response = MakeAnalysis.MakeAnalysisRequest(imageFilePath);

            var content = response.Result.Content.ReadAsStringAsync();
            //var thing = JsonConvert.DeserializeObject(content.ToString());

            Response = content.Result.ToString();
        }

        public void btnclick_Click()
        {

        }
    }
}
