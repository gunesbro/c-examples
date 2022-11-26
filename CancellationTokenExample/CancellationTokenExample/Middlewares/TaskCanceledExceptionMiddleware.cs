using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CancellationTokenExample.Middlewares
{
    public class TaskCanceledExceptionMiddleware
    {
        private readonly RequestDelegate next;
        public TaskCanceledExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (TaskCanceledException ex)
            {
                HandleExceptionAsync(context, ex);
            }
        }

        private void HandleExceptionAsync(HttpContext context, TaskCanceledException ex)
        {
            string message = $"Request Canceled: {context.Request.Path}";
            Debug.WriteLine(message);
        }
    }
}
