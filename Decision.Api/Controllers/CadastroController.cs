using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Decision.Api.Models;
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

        //private static RecognizeTextHeaders analysis = null;

        // Specify the features to return
        private static readonly List<VisualFeatureTypes> features =
            new List<VisualFeatureTypes>()
        {
            VisualFeatureTypes.Categories, VisualFeatureTypes.Description,
            VisualFeatureTypes.Faces, VisualFeatureTypes.ImageType,
            VisualFeatureTypes.Tags
        };

        public async Task<IHttpActionResult> Post()
        {
            HttpRequestMessage request = this.Request;

            ComputerVisionClient computerVision = new ComputerVisionClient(
                new ApiKeyServiceClientCredentials(subscriptionKey),
                new System.Net.Http.DelegatingHandler[] { });

            // Specify the Azure region
            computerVision.Endpoint = "https://eastus2.api.cognitive.microsoft.com";

            RecognizeTextInStreamHeaders analysis = null;
            using (Stream imageStream = await request.Content.ReadAsStreamAsync())
            {
                analysis = await computerVision.RecognizeTextInStreamAsync(imageStream, TextRecognitionMode.Printed);
            }

            string operation = analysis.OperationLocation.Split('/').GetValue(analysis.OperationLocation.Split('/').Length - 1).ToString();

            Thread.Sleep(5000);

            TextOperationResult result = await computerVision.GetTextOperationResultAsync(operation);

            Cadastro cadastro = new Cadastro();

            cadastro.Nome = result.RecognitionResult.Lines[5].Text;
            cadastro.RG = result.RecognitionResult.Lines[7].Text;
            cadastro.CPF = result.RecognitionResult.Lines[11].Text;

            {
                DateTime resultado;

                if (DateTime.TryParse(result.RecognitionResult.Lines[12].Text, out resultado))
                {
                    cadastro.DtNascimento = resultado;
                }
            }

            cadastro.NomeMae = result.RecognitionResult.Lines[19].Text;

            {
                DateTime resultado;

                if (DateTime.TryParse(result.RecognitionResult.Lines[29].Text, out resultado))
                {
                    cadastro.Validade = resultado;
                }


            }

            return Ok(cadastro);
        }
    }
}
