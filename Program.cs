namespace AspApiesApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.Environment.EnvironmentName = "Production";


            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler(appBuild => appBuild.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsync("Error 500");
                }));
            }

            app.UseStatusCodePages("text/plain; charset=utf-8", "Ошибка! Ресурс не найден. Код ошибки {0}");

            app.Map("/", () => "Home page");


            //if(!app.Environment.IsDevelopment())
            //{
            //    app.UseExceptionHandler("/error");
            //}

            //app.Map("/error", appBuild => appBuild.Run(async context =>
            //{
            //    context.Response.StatusCode = 500;
            //    await context.Response.WriteAsync("Error 500");
            //}));

            //app.Run(async context => 
            //{
            //    int a = 5;
            //    int b = 0;
            //    int c = a / b;
            //    await context.Response.WriteAsync($"c = {c}");
            //});

            app.Run();
        }
    }
}