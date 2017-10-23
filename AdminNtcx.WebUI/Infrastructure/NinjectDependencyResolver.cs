using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using System.Linq;
using AdminNtcx.Domain.Abstract;
using AdminNtcx.Domain.Concrete;
using AdminNtcx.Domain.Entities;
using AdminNtcx.WebUI.Infrastructure.Abstract;
using AdminNtcx.WebUI.Infrastructure.Concrete;


namespace AdminNtcx.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        //创建一个自定义的依赖项解析器，以便MVC框架用它创建整个应用程序的实例化对象
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

        //用于绑定实体类与虚接口类
        private void AddBindings()
        {
            //创建 EFUserInfoRepository 类的实例，对 IUserInfoRepository 接口的请求进行服务
            kernel.Bind<IUserInfoRepository>().To<EFUserInfoRepository>();
            //绑定Forms验证接口
            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}