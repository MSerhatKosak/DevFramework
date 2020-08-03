using NHibernate.Classic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace DevFramework.Core.CrossCuttingConcerns.Validation.Fluent
{
  public  class ValidatorTool
    {

        public static void FluentValidate(IValidator validator ,object Entity)
        {
            var result = validator.Validate((IValidationContext)Entity);

            if (result.Errors.Count>0)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
