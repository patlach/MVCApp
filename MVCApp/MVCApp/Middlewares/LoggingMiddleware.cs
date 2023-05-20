using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MVCApp.Models;
using MVCApp.Repository;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CoreApp.Midllewares
{
    public class LoggingMidlleware
    {
        private readonly RequestDelegate _next;
        private readonly IRequestRepository _request;

        public LoggingMidlleware(RequestDelegate next, IRequestRepository request)
        {
            _next = next;
            _request = request;
        }

        public async Task InvokeAsync(HttpContext context, IWebHostEnvironment env)
        {
            string logMessage = $"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}{Environment.NewLine}";

            string logFilePath = Path.Combine(env.ContentRootPath, "Logs", "RequestsLog.txt");

            string logUrlAdress = $"http://{context.Request.Host.Value + context.Request.Path}";

            var newLogUrl = new Request()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Url = logUrlAdress
            };

            await _request.AddRequest(newLogUrl);

            await File.AppendAllTextAsync(logFilePath, logMessage);

            Console.WriteLine(logMessage);

            await _next.Invoke(context);
        }
    }
}
