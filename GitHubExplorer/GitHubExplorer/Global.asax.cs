using GitHubExplorer.Repository;
using GitHubExplorer.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GitHubExplorer
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            switch (dataSource)
            {
                case "GitHub":
                    {
                        Repository = new GitHubApi(gitHubApiAddress);
                        break;
                    }
                case "Mock":
                    {
                        Repository = new MockedRepository();
                        break;
                    }
                default:
                    {
                        throw new Exception("Wrong DataSource config - Application start fail");
                    }
            }
        }

        public static IUsersRepository Repository;
        private string gitHubApiAddress = WebConfigurationManager.AppSettings["GitHubApiAddress"];
        private string dataSource = WebConfigurationManager.AppSettings["DataSource"];
    }
}
