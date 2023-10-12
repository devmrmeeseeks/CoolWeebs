﻿using CoolWebs.Model.TitleLIst;
using CoolWeebs.API.Modules.TitleList.Validators;
using FluentValidation;

namespace CoolWeebs.API.Modules.TitleList.Providers
{
    public static partial class ValidatorProvider
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<TitleRequest>, TitleValidator>();

            return services;
        }
    }
}
