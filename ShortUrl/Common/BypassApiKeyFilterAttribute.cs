using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Autofac.Integration.WebApi;

namespace ShortUrl.Common
{
	// Don't do anything here :)
	public class BypassApiKeyFilterAttribute : IAutofacActionFilter
	{
		public void OnActionExecuting(HttpActionContext actionContext)
		{}

		public void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
		{}
	}
}