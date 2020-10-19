using Autofac;
using S4.SocialMedia.WebApp.Controllers;

namespace S4.SocialMedia.WebApp
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<PostsController>();

            return builder.Build();
        }
    }
}