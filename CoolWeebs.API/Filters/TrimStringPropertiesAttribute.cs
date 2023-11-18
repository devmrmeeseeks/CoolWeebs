using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace CoolWeebs.API.Filters
{
    public class TrimStringPropertiesAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            object argument = context.ActionArguments.Values.First()!;
            foreach (PropertyInfo property in argument.GetType().GetProperties())
            {
                if (property.PropertyType != typeof(string)) continue;

                string? value = (string?)property.GetValue(argument);
                if (value != null)
                {
                    property.SetValue(argument, value.Trim());
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
