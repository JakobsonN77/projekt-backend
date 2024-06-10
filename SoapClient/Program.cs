using SoapCore;
using WebApi.Service;

namespace SoapClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSoapCore();
            builder.Services.AddSingleton<IUserService, UserService>();
            var app = builder.Build();

            app.UseSoapEndpoint<IUserService>("/UserService.asmx", new SoapEncoderOptions());

            app.Run();
        }
    }
}