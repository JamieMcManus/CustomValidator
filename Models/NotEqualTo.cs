using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


namespace CustomValidator.Models
{
    public class NotEqualto : ValidationAttribute
    {
        private readonly string _other;
        public NotEqualto(string other)
        {
            // This is the name of the property to compare to 
            _other = other;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherProperty = validationContext.ObjectType.GetProperty(_other);
            if (otherProperty == null)
            {
                return new ValidationResult(string.Format("Property {0} not found", _other));
            }
            var otherValue = otherProperty.GetValue(validationContext.ObjectInstance, null);

            if (object.Equals(value, otherValue))
            {
                var otherDisplayAttribute = otherProperty.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
                string otherName = "";
                if (otherDisplayAttribute != null)
                {
                    otherName = otherDisplayAttribute.Name;
                }
                else
                {
                    otherName = otherProperty.Name;
                }
                this.ErrorMessage = $"{validationContext.DisplayName} cannot be the same as {otherName}";
                return new ValidationResult(this.ErrorMessage);
            }
            return null;
        }
    }
}
    
