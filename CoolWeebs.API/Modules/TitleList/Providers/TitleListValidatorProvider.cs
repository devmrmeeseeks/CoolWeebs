﻿using CoolWebs.Model.TitleLIst;
using CoolWeebs.API.Modules.TitleList.Validators;
using FluentValidation;

namespace CoolWeebs.API.Modules.TitleList.Providers
{
    public static class TitleListValidatorProvider
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<TitleRequest>, TitleValidator>();
            services.AddScoped<IValidator<ListRequest>, ListValidator>();
            services.AddScoped<IValidator<ItemRequest>, ItemValidator>();

            return services;
        }
    }
}
