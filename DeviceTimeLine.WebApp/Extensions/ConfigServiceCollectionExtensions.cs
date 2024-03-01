using DataProvider.Abstractions;
using DataProvider.Engine;
using DeviceTimeLine.Abstractions;
using DeviceTimeLine.Engine;

namespace DeviceTimeLine.WebApp.Extensions
{
    public static class ConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyGroup(this IServiceCollection services)
        {
            services.AddSingleton<IDeviceRepositoryService, DeviceRepositoryService>();
            services.AddSingleton<IDeviceTimeStatusRepositoryService, DeviceTimeStatusRepositoryService>();
            services.AddSingleton<IDeviceService, DeviceService>();
            services.AddSingleton<ITimeLineService, TimeLineService> ();

            return services;
        }
    }
}
