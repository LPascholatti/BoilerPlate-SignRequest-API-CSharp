using System;
using System.Collections.Generic;
using System.Diagnostics;
using SignRequest.Api;
using SignRequest.Client;
using SignRequest.Model;

namespace csClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configure API key authorization: Token
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_HERE");
            Configuration.Default.AddApiKeyPrefix("Authorization", "Token");

            var documentsApi = new DocumentsApi();
            var document = new Document();
            document.FileFromUrl = "URL";

            Document documentResult = documentsApi.DocumentsCreate(document);

            var apiInstance = new SignrequestsApi();
            var data = new SignRequest.Model.SignRequest(
                signers: new List<Signer>
                {
                    new Signer("name+1@provider.com")
                },
                fromEmail: "name@provider.com",
                document: documentResult.Url
            );

            SignRequest.Model.SignRequest result = apiInstance.SignrequestsCreate(data);

            Console.WriteLine(result);
            
        }
    }
}