using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Develop.DataValidation
{
    public interface IValidation
    {
        /// <summary>
        /// validate
        /// </summary>
        /// <param name="obj">validate object</param>
        /// <returns></returns>
        VerifyResult Validate(dynamic obj);

        /// <summary>
        /// create validation attribute
        /// </summary>
        /// <returns></returns>
        ValidationAttribute CreateValidationAttribute();
    }
}
