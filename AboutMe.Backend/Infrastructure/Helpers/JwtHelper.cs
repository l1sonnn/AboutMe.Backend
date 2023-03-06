using AboutMe.Backend.Infrastructure.Extensions;
using AboutMe.Backend.Infrastructure.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AboutMe.Backend.Infrastructure.Helpers
{
    internal static class JwtHelper
    {
        internal static void GenerateConfig(ref JwtBearerOptions options, in ValidationParameter validationParameter)
        {
            options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = validationParameter.Issuer,
                ValidAudience = validationParameter.Audienece,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(validationParameter.Key))
            };
        }

        internal static ValidationParameter GetValidationParameter(this IConfiguration configuration) =>
                                                                 new ValidationParameter
                                                                 {
                                                                     Key = configuration.GetKey(),
                                                                     Audienece = configuration.GetAudience(),
                                                                     Issuer = configuration.GetIssuer()
                                                                 };

        private static string GetKey(this IConfiguration configuration) => configuration["Jwt:Key"].Decrypt(AesConfiguration.Key, AesConfiguration.IV);
        private static string GetIssuer(this IConfiguration configuration) => configuration["Jwt:Issuer"].Decrypt(AesConfiguration.Key, AesConfiguration.IV);
        private static string GetAudience(this IConfiguration configuration) => configuration["Jwt:Audience"].Decrypt(AesConfiguration.Key, AesConfiguration.IV);
    }
}
