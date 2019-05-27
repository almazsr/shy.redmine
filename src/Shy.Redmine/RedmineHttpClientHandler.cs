using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Shy.Redmine
{
	public class RedmineHttpClientHandler : HttpClientHandler
	{
		public string ApiKey { get; set; }

		private void InsertApiKey(HttpRequestMessage request)
		{
			var uriBuilder = new UriBuilder(request.RequestUri);
			var query = HttpUtility.ParseQueryString(uriBuilder.Query);
			query["key"] = ApiKey;
			uriBuilder.Query = query.ToString();
			request.RequestUri = uriBuilder.Uri;
		}

		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			InsertApiKey(request);
			return base.SendAsync(request, cancellationToken);
		}
	}
}