using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WorkSpace.Behaviors.Interface;
using DataAnnotationValidator = System.ComponentModel.DataAnnotations.Validator;

namespace WorkSpace.Behaviors
{
    public class Validation: IValidation
    {
        public void CheckObjectForValid(object instance)
        {
            ValidationContext validationContext = new ValidationContext(instance);
            DataAnnotationValidator.ValidateObject(instance, validationContext, true);
        }

        public void CheckId(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id isn't valid");
            }
        }

        public void CheckObjectForNull(object instance)
        {
            if (instance == null)
            {
                throw new Exception("The object wasn't found");
            }
        }
    }
}
