using CourseProvider.Data.Contexts;
using CourseProvider.GraphQl.Mutations;
using CourseProvider.GraphQl.Queries;
using CourseProvider.Infrastructure.GraphQL.ObjectTypes;
using CourseProvider.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddPooledDbContextFactory<DataContext>(options =>
        {
            options.UseCosmos(
                Environment.GetEnvironmentVariable("COSMOS_URI")!,
                Environment.GetEnvironmentVariable("COSMOS_DB")!
            );
            options.UseLazyLoadingProxies(); // Moved here from OnConfiguring
        });
        services.AddScoped<ICourseService, CourseService>();
        services.AddGraphQLFunction()
                .AddQueryType<Query>()
                .AddMutationType<CourseMutation>()
                .AddType<CourseType>();
    })
    .Build();

// Ensure the database is created
EnsureDatabaseCreated(host);

host.Run();

static void EnsureDatabaseCreated(IHost host)
{
    using var scope = host.Services.CreateScope();
    var dbContextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<DataContext>>();
    using var context = dbContextFactory.CreateDbContext();
    context.Database.EnsureCreated();
}

