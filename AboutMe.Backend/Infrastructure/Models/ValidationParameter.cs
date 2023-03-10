using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace AboutMe.Backend.Infrastructure.Models
{
    public class ValidationParameter
    {
        public ValidationParameter() { }

        public ValidationParameter(IConfiguration configuration)
        {
            var properties = this.GetType().GetProperties();
            var jwtValidationParameter = configuration.GetValidationParameter();
            jwtValidationParameter.GetType()
                                  .GetProperties(BindingFlags.SetProperty)
                                  .ToList()
                                  .ForEach(property => properties.FirstOrDefault(c => c.Name == property.Name)
                                                                 .SetValue(this, property.GetValue(jwtValidationParameter)));
        }

        public required string Issuer { get; init; }
        public required string Audienece { get; init; }
        public required string Key { get; init; }
        public SecurityKey SymmetricSecurityKey => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
    }
}
