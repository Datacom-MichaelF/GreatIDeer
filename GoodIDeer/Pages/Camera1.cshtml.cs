using GoodIDeer.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace GoodIDeer.Pages
{
    public class Camera1Model : PageModel
    {
        public async Task OnGet()
        {
            string imageFilePath = @"C:\Work\Other\GoodDeer\GoodIDeer\wwwroot\images\deer01.jpg";

            VisionApiService MakeAnalysis = new VisionApiService();
            /*var respose =*/
            var response = await MakeAnalysis.MakeAnalysisRequest(imageFilePath);

            var content = await response.Content.ReadAsStringAsync();
            var thing = JsonConvert.DeserializeObject<Model.RootObject>(content);
        }
    }
}
