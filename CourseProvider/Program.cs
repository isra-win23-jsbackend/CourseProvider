using CourseProviderInfrastructure.Data.Contexts;
using CourseProviderInfrastructure.GraphQL;
using CourseProviderInfrastructure.GraphQL.Mutation;
using CourseProviderInfrastructure.GraphQL.ObjectTypes;
using CourseProviderInfrastructure.Services;
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

        services.AddPooledDbContextFactory<DataContext>(x => 
        {
            x.UseCosmos(Environment.GetEnvironmentVariable("COSMOS_URI")!, Environment.GetEnvironmentVariable("COSMOS_DB")!)
            .UseLazyLoadingProxies(true);
        });

        services.AddScoped<ICourseService, CourseService>();

        services.AddGraphQLFunction()
                .AddQueryType<CourseQuery>()
                .AddMutationType<CourseMutation>()
                .AddType<CourseType>();

        var sp = services.BuildServiceProvider();
        using var scope = sp.CreateScope();
        var dbcontextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<DataContext>>();
        using var context = dbcontextFactory.CreateDbContext();
        context.Database.EnsureCreated();


    })
    .Build();

host.Run();
