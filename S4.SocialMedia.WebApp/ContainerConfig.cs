using Autofac;

using S4.SocialMedia.WebApp.Controllers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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