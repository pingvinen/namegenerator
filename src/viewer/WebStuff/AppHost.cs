using System;
using ServiceStack.WebHost.Endpoints;
using ServiceStack.Razor;
using ServiceStack.CacheAccess.Providers;
using ServiceStack.CacheAccess;
using ServiceStack.ServiceHost;
using daslib;

namespace viewer.WebStuff
{
	public class AppHost : AppHostHttpListenerBase
	{
		public AppHost () : base("Namegenerator viewer", typeof(AppHost).Assembly)
		{
		}

		public override void Configure (Funq.Container container)
		{
			ServiceStack.Text.JsConfig.DateHandler = ServiceStack.Text.JsonDateHandler.ISO8601;

			this.Config.DebugMode = true;

			this.SetConfig (new EndpointHostConfig {
				DefaultRedirectPath = "/default"
			});

			this.Plugins.Add(new RazorFormat());

			container.Register<ICacheClient>(new MemoryCacheClient());
			container.Register<MySqlConnectionFactory> (new MySqlConnectionFactory ());
			container.RegisterAutoWired<NameRepository> ();
			container.RegisterAutoWired<ValidatorFactory> ();

			this.ServiceExceptionHandler = (IHttpRequest httpReq, object request, Exception exception) => {
				Console.Error.WriteLine("{0}\n\n-----\n\n{1}", request, exception);
				return ServiceStack.ServiceHost.DtoUtils.HandleException(this, request, exception);
			};
		}
	}
}

