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

        public async Task OnGet()
        {
            string imageFilePath = @"C:\Users\MichaelFo\Downloads\Deer.jpg";

            VisionApiService MakeAnalysis = new VisionApiService();
            /*var respose =*/
            var response = await MakeAnalysis.MakeAnalysisRequest(imageFilePath);

            var content = await response.Content.ReadAsStringAsync();
            var thing = JsonConvert.DeserializeObject<Model.RootObject>(content);
            //Response = thing;

//            Response = "";// content.Result.ToString();
        }

        public void btnclick_Click()
        {

        }
    }
}
