using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelValidations.Models;

namespace ModelValidations.CustomModelBinders
{
    public class PersonModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            Person person = new Person();

            var asda = bindingContext.ValueProvider.GetValue("FirstName");

            if (bindingContext.ValueProvider.GetValue("FirstName").Count() > 0)
            {
                person.PersonName = bindingContext.ValueProvider.GetValue("FirstName").FirstValue;

                if (bindingContext.ValueProvider.GetValue("LastName").Count() > 0)
                {
                    person.PersonName += " " + bindingContext.ValueProvider.GetValue("LastName").FirstValue;
                }
            }

            //email
            if (bindingContext.ValueProvider.GetValue("Email").Count() > 0)
            {
                person.Email = bindingContext.ValueProvider.GetValue("Email").FirstValue;
            }

            //password
            if (bindingContext.ValueProvider.GetValue("Password").Count() > 0)
            {
                person.Password = bindingContext.ValueProvider.GetValue("Password").FirstValue;
            }

            //confirm-password
            if (bindingContext.ValueProvider.GetValue("ConfirmPassword").Count() > 0)
            {
                person.ConfirmPassword = bindingContext.ValueProvider.GetValue("ConfirmPassword").FirstValue;
            }

            //dateofbirth
            if (bindingContext.ValueProvider.GetValue("DateOfBirth").Count() > 0)
            {
                person.DateOfBirth = Convert.ToDateTime(bindingContext.ValueProvider.GetValue("DateOfBirth").FirstValue);
            }

            //phone
            if (bindingContext.ValueProvider.GetValue("Phone").Count() > 0)
            {
                person.Phone = bindingContext.ValueProvider.GetValue("Phone").FirstValue;
            }

            //fromDate
            if (bindingContext.ValueProvider.GetValue("FromDate").Count() > 0)
            {
                person.FromDate = Convert.ToDateTime(bindingContext.ValueProvider.GetValue("FromDate").FirstValue);
            }

            //toDate
            if (bindingContext.ValueProvider.GetValue("ToDate").Count() > 0)
            {
                person.ToDate = Convert.ToDateTime(bindingContext.ValueProvider.GetValue("ToDate").FirstValue);
            }

            //age
            if (bindingContext.ValueProvider.GetValue("Age").Count() > 0)
            {
                person.Age =Convert.ToInt16(bindingContext.ValueProvider.GetValue("Age").FirstValue);
            }

            //price
            if (bindingContext.ValueProvider.GetValue("Price").Count() > 0)
            {
                person.Price = Convert.ToDouble(bindingContext.ValueProvider.GetValue("Price").FirstValue);
            }

            bindingContext.Result = ModelBindingResult.Success(person);

            return Task.CompletedTask;
        }
    }
}
