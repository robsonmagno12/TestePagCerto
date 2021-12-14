
using Eco.UmlRt.Impl;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NuGet.Packaging;
using System;
using System.Threading.Tasks;

namespace TestePagCerto.Filters
{
    public class ErrorHandlerAttribute : ExceptionFilterAttribute
    {
          private IHostingEnvironment _env;
          private IErrorLogger _logger;

          public ErrorHandlerAttribute(IHostingEnvironment env, IErrorLogger logger)
          {
              _env = env;
              _logger = logger;
          }

          public override async Task OnExceptionAsync(ExceptionContext context)
          {
              if (!_env.IsDevelopment())
              {
               await _logger.LogAsync(context.Exception);
              }

              context.Result = new StatusCodeResult(500);
          }
    }
}
