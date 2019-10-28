using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SISTEMA_CENSO_INSTRUCTORES.Startup))]
namespace SISTEMA_CENSO_INSTRUCTORES
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            // ConfigureAuth(app);

        }
    }
}
