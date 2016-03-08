using System;
using System.Collections.Generic;
using GameStoreMVC.Domain.Abstract;
using GameStoreMVC.Domain.Entities;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Moq;

namespace GameStoreMVC.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            Mock<IGameRepository> mock = new Mock<IGameRepository>();
            mock.Setup(m => m.Games).Returns(new List<Game>
            {
                new Game { Name = "Don't Starve", Price = 349 },
                new Game { Name = "Don't Starve Together", Price = 419 },
                new Game { Name = "Portal", Price = 249 }
            });
                kernel.Bind<IGameRepository>().ToConstant(mock.Object);
        }
    }
}