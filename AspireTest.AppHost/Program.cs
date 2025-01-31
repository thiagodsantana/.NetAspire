var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache").WithRedisInsight();

var sql = builder.AddSqlServer("sql")
                 .WithLifetime(ContainerLifetime.Persistent) //Recomend�vel utilizar uma vida �til persistente para evitar reinicializa��es desnecess�rias.
                 .WithDataVolume(); 
                // usado para armazenar permanentemente os dados de SQL Server
                // fora do ciclo de vida de seu cont�iner.

var db = sql.AddDatabase("database");


var apiService = builder.AddProject<Projects.AspireTest_ApiService>("apiservice")
                        .WithReference(cache)
                        .WithReference(db)
                        .WaitFor(db)
                        .WaitFor(cache);

builder.AddProject<Projects.AspireTest_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService)
    .WithReference(cache)
    .WaitFor(cache);

builder.Build().Run();
