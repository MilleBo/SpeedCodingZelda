using Microsoft.Practices.Unity;
using Zelda.Server.Extensions;

namespace Zelda.Server
{
    public class Bootstrapper
    {
        public static IUnityContainer GetContainer()
        {
            var unityContainer = new UnityContainer();
            unityContainer.RegisterMediator(new HierarchicalLifetimeManager());
            return unityContainer;
        }
    }
}
