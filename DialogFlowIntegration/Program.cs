using System;
using Google.Cloud.Dialogflow.V2;

namespace DialogFlowIntegration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string[] queryText = { "What are the insurance benefits provided to employees?" };

            DetectIntentFromTexts(queryText);
        }

        public static int DetectIntentFromTexts(string[] texts, string projectId = "myhr-johjri",
                                        string sessionId = "04ab1a17-f0d1-e7af-e0b1-4e9945b749f7",
                                        string languageCode = "en-US")
        {




            var client = SessionsClient.Create();

            foreach (var text in texts)
            {
                var response = client.DetectIntent(
                    session: SessionName.FromProjectSession(projectId,sessionId),
                    queryInput: new QueryInput()
                    {
                        Text = new TextInput()
                        {
                            Text = text,
                            LanguageCode = languageCode
                        }
                    }
                );

                var queryResult = response.QueryResult;

                Console.WriteLine($"Query text: {queryResult.QueryText}");
                if (queryResult.Intent != null)
                {
                    Console.WriteLine($"Intent detected: {queryResult.Intent.DisplayName}");
                }
                Console.WriteLine($"Intent confidence: {queryResult.IntentDetectionConfidence}");
                Console.WriteLine($"Fulfillment text: {queryResult.FulfillmentText}");
                Console.WriteLine();
            }

            return 0;
        }
    }
}
