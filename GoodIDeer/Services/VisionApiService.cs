using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GoodIDeer.Services
{
    public class Rectangle
    {
        public int x { get; set; }
        public int y { get; set; }
        public int w { get; set; }
        public int h { get; set; }
    }

    public class Parent2
    {
        public string @object { get; set; }
        public double confidence { get; set; }
    }

    public class Parent
    {
        public string @object { get; set; }
        public double confidence { get; set; }
        public Parent2 parent { get; set; }
    }

    public class Object
    {
        public Rectangle rectangle { get; set; }
        public string @object { get; set; }
        public double confidence { get; set; }
        public Parent parent { get; set; }
    }

    public class Metadata
    {
        public int width { get; set; }
        public int height { get; set; }
        public string format { get; set; }
    }

    public class RootObject
    {
        public List<Object> objects { get; set; }
        public string requestId { get; set; }
        public Metadata metadata { get; set; }
    }


    public class VisionApiService
    {
        const string subscriptionKey = "544f820e8f9f4c64b9d223feea3eba3a";
        const string endPoint = "https://westcentralus.api.cognitive.microsoft.com/vision/v2.0/detect";
        public async Task<HttpResponseMessage> MakeAnalysisRequest(string imageFilePath)
        {
            var errors = new List<string>();
            var response = new HttpResponseMessage();
            try
            {
                HttpClient client = new HttpClient();
                // Request headers.    
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
                // Request parameters. A third optional parameter is "details".    
                string requestParameters = "visualFeatures=Categories,Description,Color";
                // Assemble the URI for the REST API Call.    
                string uri = endPoint + "?" + requestParameters;
                //HttpResponseMessage response;
                // Request body. Posts a locally stored JPEG image.    
                byte[] byteData = GetImageAsByteArray(imageFilePath);
                using (ByteArrayContent content = new ByteArrayContent(byteData))
                {
                    // This example uses content type "application/octet-stream".    
                    // The other content types you can use are "application/json"    
                    // and "multipart/form-data".    
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    // Make the REST API call.    
                    response = await client.PostAsync(uri, content);
                    
                }
                // Get the JSON response.    
                //result = await response.Content.ReadAsStringAsync();
                //if (response.IsSuccessStatusCode)
                //{
                //    responeData = JsonConvert.DeserializeObject<Parent>(result, new JsonSerializerSettings
                //    {
                //        NullValueHandling = NullValueHandling.Include,
                //        Error = delegate (object sender, Newtonsoft.Json.Serialization.ErrorEventArgs earg) {
                //            errors.Add(earg.ErrorContext.Member.ToString());
                //            earg.ErrorContext.Handled = true;
                //        }
                //    });
                //}
            }
            catch (Exception e)
            {
                Console.WriteLine("\n" + e.Message);
            }
            return response;
        }
        static byte[] GetImageAsByteArray(string imageFilePath)
        {
            using (FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read))
            {
                BinaryReader binaryReader = new BinaryReader(fileStream);
                return binaryReader.ReadBytes((int)fileStream.Length);
            }
        }
    }
}  
