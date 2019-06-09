using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;

namespace Decision.Api.Controllers
{
    public class CadastroController : ApiController
    {
        // subscriptionKey = "0123456789abcdef0123456789ABCDEF"
        private const string subscriptionKey = "1df9a911fd2844d5a75db1026761bcd2";

        // localImagePath = @"C:\Documents\LocalImage.jpg"
        private const string localImagePath = @"<LocalImage>";

        private const string remoteImageUrl =
           "https://amazonasatual.com.br/wp-content/uploads/2018/08/CNH-falsa-Manaus.jpeg";

        private static RecognizeTextHeaders analysis = null;

        // Specify the features to return
        private static readonly List<VisualFeatureTypes> features =
            new List<VisualFeatureTypes>()
        {
            VisualFeatureTypes.Categories, VisualFeatureTypes.Description,
            VisualFeatureTypes.Faces, VisualFeatureTypes.ImageType,
            VisualFeatureTypes.Tags
        };

        public string Get()
        {
            return "teste 123";
        }

        public void Post()
        {
            ComputerVisionClient computerVision = new ComputerVisionClient(
                new ApiKeyServiceClientCredentials(subscriptionKey),
                new System.Net.Http.DelegatingHandler[] { });

            // Specify the Azure region
            computerVision.Endpoint = "https://eastus2.api.cognitive.microsoft.com";


            Console.WriteLine("Images being analyzed ...");
            var t1 = AnalyzeRemoteAsync(computerVision);
            //var t2 = AnalyzeLocalAsync(computerVision, localImagePath);

            //Task.WhenAll(t1).Wait(50000);

            //var result = DisplayResults(analysis, computerVision);

            Task.WhenAll(t1).Wait(5000);
        }

        // Analyze a remote image
        private static async Task AnalyzeRemoteAsync(ComputerVisionClient computerVision)
        {
            analysis = await computerVision.RecognizeTextAsync(remoteImageUrl, TextRecognitionMode.Printed);
            var result = DisplayResults(analysis, computerVision);

            Task.WhenAll(result).Wait(5000);
        }

        // Display the most relevant caption for the image
        private static async Task DisplayResults(RecognizeTextHeaders analysis, ComputerVisionClient computerVision)
        {
            string operation = analysis.OperationLocation.Split('/').GetValue(analysis.OperationLocation.Split('/').Length - 1).ToString();

            TextOperationResult result = await computerVision.GetTextOperationResultAsync(operation);
        }
    }
}
