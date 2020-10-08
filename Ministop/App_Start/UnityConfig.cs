using Ministop.DI.Implements;
using Ministop.DI.Interfaces;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Ministop
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IKhachHangService, KhachHangService>();
            container.RegisterType<INhaCungCapService, NhaCungCapService>();
            container.RegisterType<INhanVienService, NhanVienService>();
            container.RegisterType<ISanPhamService, SanPhamService>();
            container.RegisterType<INhapHangService, NhapHangService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}