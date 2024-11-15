using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using System.IO;
using System.Threading.Tasks;

namespace HospitalIMSServices
{
    internal class AWSServices
    {
        public bool uploadFile(string filePath)
        {
            var accessKey = "ENTER-ACCESSKEY"; 
            var secretKey = "ENTER-SECRETKEY";
            var bucketName = "ENTER-BUCKETNAME"; // TODO: Change this dynamically.

            var client = new AmazonS3Client(accessKey, secretKey, Amazon.RegionEndpoint.USEast1);

            var fileTransferUtility = new TransferUtility(client);

            try
            {
                FileInfo file = new FileInfo(filePath);
                string destPath = "emails/" + filePath; // Is assuming that filePath is just a filename for now.
                PutObjectRequest request = new PutObjectRequest()
                {
                    InputStream = file.OpenRead(),
                    BucketName = bucketName,
                    Key = destPath // <-- in S3 key represents a path  
                };

                // fileTransferUtility.Upload(filePath, bucketName); // Default code.

                // Use a different code to make this upload to a specific folder.
                // And no, this isn't an AI's doing, this is taken from:
                // https://stackoverflow.com/questions/25814972/how-to-upload-a-file-to-amazon-s3-super-easy-using-c-sharp
                // https://stackoverflow.com/questions/53479680/s3-and-net-amazon-sdk-getobject-is-inaccessible-due-to-protection-level
                Task<PutObjectResponse> response = client.PutObjectAsync(request);
                response.Wait();
                return true;
            }
            catch (AmazonS3Exception e)
            {
                return false;
            }
        }
        
    }
}
