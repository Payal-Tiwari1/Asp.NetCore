namespace Asp.net_core_middelware
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            //app.MapGet("/", () => "Hello World!");

            //app.Run(async (content) =>
            //{
            //    await content.Response.WriteAsync("Welcome to middleware topic...");
            //});

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("With 'next' parameter...\n");  //Use method execute the next meddleware so that always pass the use method init.
                await next(context);
            });

            app.Run(async (content) =>
            {
                await content.Response.WriteAsync("After Use method Run method is executed...");  // After Run method the next middleware can't be executed 
            });

            app.Run();
        }
    }
}
