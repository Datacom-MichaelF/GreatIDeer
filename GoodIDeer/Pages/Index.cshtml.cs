using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoodIDeer.Model;
using GoodIDeer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GoodIDeer.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            string imageFilePath = @"C:\Work\Other\GoodDeer\GoodIDeer\images\deer01.jpg";

            VisionApiService MakeAnalysis = new VisionApiService();
            var respose = MakeAnalysis.MakeAnalysisRequest(imageFilePath);
        }

        public void btnclick_Click()
        {

        }
    }
}
