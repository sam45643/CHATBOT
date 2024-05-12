using Azure;
using Azure.AI.Language.QuestionAnswering;
using System;

namespace question_answering
{
    class Program
    {
        static void Main(string[] args)
        {
            // This example requires environment variables named "LANGUAGE_KEY" and "LANGUAGE_ENDPOINT"
            Uri endpoint = new Uri("https://questandanswer.cognitiveservices.azure.com/");
            AzureKeyCredential credential = new AzureKeyCredential("4bc7b54abc514285a7d44c4cbc7d5b8c");
            string projectName = "job";
            string deploymentName = "production";

            QuestionAnsweringClient client = new QuestionAnsweringClient(endpoint, credential);
            QuestionAnsweringProject project = new QuestionAnsweringProject(projectName, deploymentName);

            Console.WriteLine("Welcome to the Question Answering App!");
            Console.WriteLine("Type 'exit' to quit.");

            while (true)
            {
                Console.Write("Ask question about any Major: ");
                string question = Console.ReadLine();

                if (question.ToLower() == "exit")
                    break;

                Response<AnswersResult> response = client.GetAnswers(question, project);

                foreach (KnowledgeBaseAnswer answer in response.Value.Answers)
                {
                    Console.WriteLine($"Q: {question}");
                    Console.WriteLine($"A: {answer.Answer}");
                }

                Console.WriteLine();
            }

            Console.WriteLine("Goodbye!");
        }
    }
}