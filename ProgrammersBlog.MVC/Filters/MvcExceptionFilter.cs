using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProgrammersBlog.Shared.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.MVC.Filters
{
    public class MvcExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment _environment;
        private readonly IModelMetadataProvider _metadataProvider;
        private readonly ILogger _logger;
        public MvcExceptionFilter(IHostEnvironment environment, IModelMetadataProvider metadataProvider, ILogger<MvcExceptionFilter> logger)
        {
            _environment = environment;
            _metadataProvider = metadataProvider;
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            if (_environment.IsDevelopment())
            {
                context.ExceptionHandled = true;
                var mvcErrorModel = new MvcErrorModel();
                ViewResult result;
                switch (context.Exception)
                {
                    case SqlNullValueException:
                        mvcErrorModel.Message = "Üzrlü sayın, gözlənilməz bir verilənlər bazası xətası yarandı. Ən qısa zamanda həll ediləcək.";
                        mvcErrorModel.Detail = context.Exception.Message;
                        result = new ViewResult { ViewName = "Error" };
                        _logger.LogError(context.Exception, context.Exception.Message);
                        result.StatusCode = 500;
                        break;
                    case NullReferenceException:
                        mvcErrorModel.Message = "Üzrlü sayın, gözlənilməz bir null dəyərə rastlandı. Ən qısa zamanda həll ediləcək.";
                        mvcErrorModel.Detail = context.Exception.Message;
                        result = new ViewResult { ViewName = "Error" };
                        _logger.LogError(context.Exception, context.Exception.Message);
                        result.StatusCode = 501;
                        break;
                    default:
                        mvcErrorModel.Message = "Üzrlü sayın, gözlənilməz bir xəta yarandı. Ən qısa zamanda həll ediləcək.";
                        result = new ViewResult { ViewName = "Error" };
                        _logger.LogError(context.Exception, context.Exception.Message);
                        result.StatusCode = 500;
                        break;
                }

                result.ViewData = new ViewDataDictionary(_metadataProvider, context.ModelState);
                result.ViewData.Add("MvcErrorModel", mvcErrorModel);
                context.Result = result;
            }
        }
    }
}
