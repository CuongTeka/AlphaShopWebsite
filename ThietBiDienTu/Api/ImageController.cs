using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ThietBiDienTu.Areas.Admin.Models;

namespace ThietBiDienTu.Api
{
    public class ImageController : ApiController
    {
        private ThietBiDienTuEntities1 db = new ThietBiDienTuEntities1();

        // GET: api/image/getimage?imageName=yourimage.jpg
        [HttpGet]
        [Route("api/image/getimage")]
        public HttpResponseMessage GetImage(string imageName)
        {
            if (string.IsNullOrEmpty(imageName))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Image name is required.");
            }

            // Attempt to retrieve the image record from the database
            var image = db.HinhAnhs.FirstOrDefault(i => i.LinkHinhAnhChinh == imageName);
            if (image == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Image not found.");
            }

            // Construct the image file path
            var imagePath = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Assets/img"), image.LinkHinhAnhChinh);
            if (!File.Exists(imagePath))
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Image file not found.");
            }

            // Serve the image file
            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            };
            result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(GetMimeType(imagePath));
            return result;
        }

        // Method to determine the MIME type based on the file extension
        private string GetMimeType(string filePath)
        {
            var extension = Path.GetExtension(filePath).ToLowerInvariant();
            switch (extension)
            {
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                case ".webp":
                    return "image/webp";
                case ".jfif":
                    return "image/jfif";
                default:
                    return "application/octet-stream";
            }
        }
    }
}
