﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using ModelValidations.Models;

namespace ModelValidations.CustomModelBinders
{
    public class PersonModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(Person))
                return new BinderTypeModelBinder(typeof(PersonModelBinder));

            return null;
        }
    }
}
