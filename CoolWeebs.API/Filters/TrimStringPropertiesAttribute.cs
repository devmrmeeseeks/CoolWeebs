using Microsoft.AspNetCore.Mvc.Filters;

namespace CoolWeebs.API.Filters
{
    public class TrimStringPropertiesAttribute : ActionFilterAttribute 
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            foreach (var argument in context.ActionArguments.Values)
            {
                foreach (var property in argument!.GetType().GetProperties())
                {
                    if (property.PropertyType == typeof(string))
                    {
                        var value = (string)property.GetValue(argument)!;
                        if (value != null)
                        {
                            property.SetValue(argument, value.Trim());
                        }
                    }
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
