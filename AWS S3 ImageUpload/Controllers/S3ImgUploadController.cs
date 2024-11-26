using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using System.Net.Http.Headers;

namespace AWS_S3_ImageUpload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class S3ImgUploadController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> CreateIntentsPayment()
        {
            string[] ss = { "x2-10-services-s.png" };
            var s3Client = GetS3Client();
            foreach (var item in ss)
            {
                //Generate the pre - signed URL      
                var artifactBucketName = "stage-broller-artifacts";
                //var artifactBucketName = "dev-broller-artifacts";
                var url = GeneratePreSignedURL(s3Client, artifactBucketName, item);
                //Upload File      
                var sourceFileNameWithPath = Path.Combine(@"D:\", item);
                await UploadFile(url, sourceFileNameWithPath);
            }
            return Ok();
        }

        static string GeneratePreSignedURL(AmazonS3Client client, string bucketName, string objectKey)
        {
            // Create the request for the pre-signed URL
            var request = new GetPreSignedUrlRequest
            {
                BucketName = bucketName,
                Key = objectKey,
                Verb = HttpVerb.PUT,
                //ContentType = "image/jpeg",               
                Expires = DateTime.UtcNow.AddHours(1) // Max URL expiration time is 1 hour     
            };
            // Generate the URL           
            string url = client.GetPreSignedURL(request);
            return url;
        }

        static async Task UploadFile(string preSignedUrl, string filePath)
        {
            using (var httpClient = new HttpClient())
            {
                using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    var content = new StreamContent(fileStream);
                    content.Headers.ContentType = new MediaTypeHeaderValue("image/png"); // Set your desired content type here  
                    var response = await httpClient.PutAsync(preSignedUrl, content);
                    if (!response.IsSuccessStatusCode)
                        throw new Exception($"Failed to upload file {filePath}. Status code: {response.StatusCode}");
                }
            }
        }

        static AmazonS3Client GetS3Client()
        {
            // Replace these with your actual AWS credentials and bucket details            
            var accessKey = "XXXXXXXXXXXXXXX";
            var secretKey = "XXXXXXXXXXXXXXXXXXXXXXX";
            var region = "us-east-2";
            return new AmazonS3Client(accessKey, secretKey, RegionEndpoint.GetBySystemName(region));
        }
    }
}
