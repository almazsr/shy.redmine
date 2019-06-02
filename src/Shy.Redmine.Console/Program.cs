using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using Refit;
using ReadLine = System.ReadLine;

namespace Shy.Redmine.Console
{
	using Console = System.Console;
	using CommandLineParser = CommandLine.Parser;

	class Program
	{
		public class AutoCompletionHandler : IAutoCompleteHandler
		{
			public string[] GetSuggestions(string text, int index)
			{
				if(text.StartsWith("Category"))
				{
					return new[] { "T", "Y", "X" };
				}
				if(text.StartsWith("Test"))
				{
					return new[] { "YYY" };
				}
				return new string[] { };
			}

			public char[] Separators { get; set; } = { ' ', '.', '/' };
		}

		public class ProjectSelectOptions
		{
			[Value(0, HelpText = "Project identificator", Required = true)]
			public int ProjectId { get; set; }
		}

		public class SetApiKeyOptions
		{

		}

		public const string ApiKeyPath = "Shy_Redmine_ApiKey";
		public const string ProjectIdPath = "Shy_Redmine_ProjectId";
		public const string BaseUriPath = "Shy_Redmine_BaseUri";

		static void Main(string[] args)
		{
			ReadLine.AutoCompletionHandler = new AutoCompletionHandler();
			var apiKey = Environment.GetEnvironmentVariable(ApiKeyPath);
			if(string.IsNullOrEmpty(apiKey))
			{
				apiKey = ReadLine.Read("Redmine API key is not set yet, please input it and press enter: ");
				Environment.SetEnvironmentVariable(ApiKeyPath, apiKey);
			}
			var baseUri = Environment.GetEnvironmentVariable(BaseUriPath);
			if(string.IsNullOrEmpty(baseUri))
			{
				baseUri = ReadLine.Read("Redmine base uri is not set yet, please input it and press enter: ");
				Environment.SetEnvironmentVariable(BaseUriPath, baseUri);
			}
			var projectIdString = Environment.GetEnvironmentVariable(ProjectIdPath);
			if(string.IsNullOrEmpty(projectIdString))
			{
				projectIdString = ReadLine.Read("Redmine project id is not set yet, please input it and press enter: ");
				Environment.SetEnvironmentVariable(ProjectIdPath, projectIdString);
			}
			var projectId = int.Parse(projectIdString);

			var apiClient = RestService.For<IRedmineApiClient>(new HttpClient(new RedmineHttpClientHandler(apiKey))
			{
				BaseAddress = new Uri(baseUri)
			});

			var projectCache = new RedmineProjectCache(apiClient, projectId);
			projectCache.InitializeAsync().Wait();
			Console.WriteLine("Redmine project cache initializing...");

			if(args.Length == 0)
			{
				string command = null;
				do
				{
					command = ReadLine.Read();
					args = command.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
				} while(command != "q");
			}
			Console.ReadLine();
		}
	}
}
