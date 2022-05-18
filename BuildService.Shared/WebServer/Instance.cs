using BuildService.Shared.Configuration;

namespace BuildService.Shared.WebServer;

using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

public static class Instance
{
    public static HttpListener? listener;
    public static string url => $@"http://{ConfigManager.svAddress}:{ConfigManager.svhttpPort}/";

    public static string WebDataWithTemplatedStrings = @"";
    public static string WebData =>
        WebDataWithTemplatedStrings.Replace(@"$WEBSOCKET_URL", $@"ws://$HTTP_HOST:{ConfigManager.svwsPort}/");
    public static void WebServerThread(EventWaitHandle handle)
    {   
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = "BuildService.websocket.html";

        var names = assembly.GetManifestResourceNames();
        
        using (var stream = assembly.GetManifestResourceStream(resourceName))
        {
            using (var reader = new StreamReader(stream))
            {
                var content = reader.ReadToEnd();
                WebDataWithTemplatedStrings = content;
            }
        }
        
        // Create a Http server and start listening for incoming connections
        listener = new HttpListener();
        listener.Prefixes.Add(url);
        listener.Start();
        Console.WriteLine("Listening for connections on {0}", url);

        // Handle requests
        Task listenTask = HandleIncomingConnections();
        listenTask.GetAwaiter().GetResult();

        // Close the listener
        listener.Close();

        handle.Set();
    }
    
    public static async Task HandleIncomingConnections()
        {
            bool runServer = true;

            // While a user hasn't visited the `shutdown` url, keep on handling requests
            while (runServer)
            {
                // Will wait here until we hear from a connection
                HttpListenerContext ctx = await listener.GetContextAsync();

                // Peel out the requests and response objects
                HttpListenerRequest req = ctx.Request;
                HttpListenerResponse resp = ctx.Response;

                // Print out some info about the request
                if (req.Url != null) Console.WriteLine(req.Url.ToString());

                // Write the response info
                string disableSubmit = !runServer ? "disabled" : "";
                byte[] data = Encoding.UTF8.GetBytes(WebData.Replace(@"$HTTP_HOST", req.UserHostName.Split(@":")[0]));
                resp.ContentType = "text/html";
                resp.ContentEncoding = Encoding.UTF8;
                resp.ContentLength64 = data.LongLength;

                // Write out to the response stream (asynchronously), then close it
                await resp.OutputStream.WriteAsync(data, 0, data.Length);
                resp.Close();
            }
        }
}