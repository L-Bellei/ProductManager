using ProductManager.Configuration.Profiles;

namespace ProductManager.Configuration;

public static class AutoMapperConfiguration
{
    public static void AddAutoMapperConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile<ProductProfile>();
        });
    }
}
