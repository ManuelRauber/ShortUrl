﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using ShortUrl.Common;
using ShortUrl.DataAccessLayer;

namespace ShortUrl
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			WebApiConfig.Register(GlobalConfiguration.Configuration);
			Bootstrap.Run(GlobalConfiguration.Configuration);
		}
	}
}