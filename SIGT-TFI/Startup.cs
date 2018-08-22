using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SIGT_TFI.Startup))]
namespace SIGT_TFI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
