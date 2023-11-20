using Microsoft.AspNetCore.Mvc.Filters;
using log4net;

[AttributeUsage(AttributeTargets.Class)]
public class CustomLogFilter : ActionFilterAttribute
{
    private readonly ILog _logger;

    public CustomLogFilter(string loggerName)
    {
        _logger = LogManager.GetLogger(loggerName);
    }

    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        //check for other kinds of IActionResult if any ...
        //...
        _logger.Info($"{context.ActionDescriptor.DisplayName}");

        await next();

    }

}
