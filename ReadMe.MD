## Solution Files

#### Kert Kullerkann

Create database

```
dotnet ef migrations add InitialDbCreation --project DAL.App.EF --startup-project WebApp  //Create migration
dotnet ef database update --project DAL.App.EF --startup-project WebApp
dotnet ef database drop --project DAL.App.EF --startup-project WebApp
```

Generate Identity UI run in Webapp folder

```
dotnet aspnet-codegenerator identity -dc DAL.App.EF.AppDbContext -f
dotnet aspnet-codegenerator identity --help
```

API Controllers

```BASH
 dotnet aspnet-codegenerator controller -name ImagesController              -actions -m Image                       -dc AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
 dotnet aspnet-codegenerator controller -name ImagesController              -actions -m Image                       -dc AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
 dotnet aspnet-codegenerator controller -name ImageTypesController          -actions -m ImageType                   -dc AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
 dotnet aspnet-codegenerator controller -name PartsController               -actions -m Part                        -dc AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
 dotnet aspnet-codegenerator controller -name PartInPartsStocksController   -actions -m PartInPartsStock             -dc AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
 dotnet aspnet-codegenerator controller -name PartManufacturersController   -actions -m PartManufacturer            -dc AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
 dotnet aspnet-codegenerator controller -name PartsStocksController         -actions -m PartsStock                   -dc AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
 dotnet aspnet-codegenerator controller -name ProductionLinesController     -actions -m ProductionLine              -dc AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
 dotnet aspnet-codegenerator controller -name ProductionLineSectionsController -actions -m ProductionLineSection         -dc AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
 dotnet aspnet-codegenerator controller -name UserAssignedToWorkOrdersController -actions -m UserAssignedToWorkOrder         -dc AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
 dotnet aspnet-codegenerator controller -name WorkAssignments              -actions -m WorkAssignment             -dc AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
 dotnet aspnet-codegenerator controller -name WorkRequests                  -actions -m WorkRequest                 -dc AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
```

run in WebApp folder

```BASH
 dotnet aspnet-codegenerator controller -name ImagesController              -actions -m Image                       -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
 dotnet aspnet-codegenerator controller -name ImageTypesController          -actions -m ImageType                   -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
 dotnet aspnet-codegenerator controller -name PartsController               -actions -m Part                        -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
 dotnet aspnet-codegenerator controller -name PartInPartsStocksController   -actions -m PartInPartsStock             -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
 dotnet aspnet-codegenerator controller -name PartManufacturersController   -actions -m PartManufacturer            -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
 dotnet aspnet-codegenerator controller -name PartsStocksController         -actions -m PartsStock                   -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
 dotnet aspnet-codegenerator controller -name ProductionLinesController     -actions -m ProductionLine              -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
 dotnet aspnet-codegenerator controller -name ProductionLineSectionsController -actions -m ProductionLineSection         -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
 dotnet aspnet-codegenerator controller -name UserAssignedToWorkOrdersController -actions -m UserAssignedToWorkOrder         -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
 dotnet aspnet-codegenerator controller -name WorkAssignments              -actions -m WorkAssignment             -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
 dotnet aspnet-codegenerator controller -name WorkRequests                  -actions -m WorkRequest                 -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

```

Scaffold to Areas

```
 dotnet aspnet-codegenerator controller -name RolesController              -actions -m AppRole                      -dc AppDbContext -outDir Areas/Admin/Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
```

Create Database migrations in App start

```
1:50 In Soft Delete, EF migrations video FEB 28:
```

Code Generator Python documentation

```
https://pypi.org/project/dotnet-generate/
```

Problem solver with asp-net codegenerator

```
Solution commands
On project folder execute

mkdir Templates && mkdir Templates/ControllerGenerator && mkdir Templates/ViewGenerator

cp -r /home/$USER/.nuget/packages/microsoft.visualstudio.web.codegenerators.mvc/5.0.0/Templates/ControllerGenerator/* ./Templates/ControllerGenerator

cp -r /home/$USER/.nuget/packages/microsoft.visualstudio.web.codegenerators.mvc/5.0.0/Templates/ViewGenerator/* ./Templates/ViewGenerator/
```

Build and run the Docker image

~~~
docker build -t aspnetapp .
docker run -d -p 8080:80 --name myapp aspnetapp
~~~

Show migration script(options -from, to )

~~~BASH
 dotnet ef migrations script
~~~

Apply migrations on runtime

~~~
myDBContext.Database.Migrate()
~~~

Seed Database and how to get service from dependency injection factory

~~~c#
 private static void SetupAppData(IApplicationBuilder app, IConfiguration configuration)
        {
            using var serviceScope =
                app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var ctx = serviceScope.ServiceProvider.GetService<AppDbContext>();
            
            if (ctx != null)
            {
                if (configuration.GetValue<bool>("AppData:DropDatabase"))
                {
                    DataInit.DropDatabase(ctx);
                }

                if (configuration.GetValue<bool>("AppData:Migrate"))
                {
                    DataInit.MigrateDatabase(ctx);
                }

                if (configuration.GetValue<bool>("AppData:SeedIdentity"))
                {
                    // TODO
                }

                if (configuration.GetValue<bool>("AppData:SeedData"))
                {
                    DataInit.SeedAppData(ctx);
                }

                
            }
            
            //C# will dispose all the usings here
        }
~~~

Javascript date picker

~~~
https://flatpickr.js.org/
~~~
