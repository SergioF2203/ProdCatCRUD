using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProductCategoryCRUD.Startup))]
namespace ProductCategoryCRUD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
