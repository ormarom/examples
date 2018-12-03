using Autofac;
using Books.Domain.AggregatedModel.AggragatedAutor;
using Books.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Infrastructure.AutofacModules
{
    public class ApplicationModule
       : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthorRepository>()
                .As<IAuthorRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
