using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePostToAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            WebRequest request = WebRequest.Create("http://localhost:53172/api/values/post");
            request.Method = "POST";
            // Create POST data and convert it to a byte array.
            string postData = "=This is a test that posts this string to a Web server.";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();
             */

            using (WebClient client = new WebClient())
            {
                Console.WriteLine("========== STARTING GET VERB ==========");
                client.Headers["Content-Type"] = "application/x-www-form-urlencoded; charset=UTF-8";
                var result = client.DownloadString("http://localhost:53172/api/values/get");
                Console.WriteLine("GET NO PARAM = {0}", result);
                Console.WriteLine("========== END GET VERB ==========");
            }

            using (WebClient client = new WebClient())
            {
                Console.WriteLine("========== STARTING GET VERB W/ PARAM ==========");
                client.Headers["Content-Type"] = "application/x-www-form-urlencoded; charset=UTF-8";
                var result = client.DownloadString("http://localhost:53172/api/values/get/5");
                Console.WriteLine("GET WITH PARAM = {0}", result);
                Console.WriteLine("========== END GET VERB W/ PARAM ==========");
            }

            using (WebClient client = new WebClient())
            {
                Console.WriteLine("========== STARTING POST VERB ==========");
                client.Headers["Content-Type"] = "application/x-www-form-urlencoded; charset=UTF-8";
                var result = client.UploadString("http://localhost:53172/api/values/post", "=test test test");
                Console.WriteLine("POST = {0}", result);
                Console.WriteLine("========== END POST VERB ==========");
            }
            

            
            using (WebClient client = new WebClient())
            {
                Console.WriteLine("========== STARTING PUT VERB ==========");
                client.Headers["Content-Type"] = "application/x-www-form-urlencoded; charset=UTF-8";
                var result = client.UploadString("http://localhost:53172/api/values/put", "PUT", "=aaaa");
                Console.WriteLine("PUT = {0}", result);
                Console.WriteLine("========== END PUT VERB ==========");
            }

            using (WebClient client = new WebClient())
            {
                Console.WriteLine("========== STARTING DELETE VERB ==========");
                client.Headers["Content-Type"] = "application/x-www-form-urlencoded; charset=UTF-8";
                var result = client.UploadString("http://localhost:53172/api/values/delete", "DELETE", "=12");
                Console.WriteLine("DELETE = {0}", result);
                Console.WriteLine("========== END DELETE VERB ==========");
            }


            Console.ReadLine();
            
        }
    }
}
