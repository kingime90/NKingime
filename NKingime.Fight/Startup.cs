using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NKingime.Fight.Startup))]
namespace NKingime.Fight
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
