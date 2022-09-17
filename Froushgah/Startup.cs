using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Froushgah.Startup))]
namespace Froushgah
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
