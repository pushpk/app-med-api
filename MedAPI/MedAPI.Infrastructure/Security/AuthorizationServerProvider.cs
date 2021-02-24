using AutoMapper;
using MedAPI.DataAccess;
using MedAPI.Infrastructure.IService;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace MedAPI.Infrastructure.Security
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IUserService userService;
        public AuthorizationServerProvider()
        {

        }
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); // 
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
         

            using (var dbContext = new registroclinicoEntities())
            {
                var user = dbContext.users.FirstOrDefault(x => x.email == context.UserName && x.deleted == false);
                if (user != null && HashPasswordHelper.ValidatePassword(context.Password, user.password_hash))
                {
                    
                    if (!user.emailConfirmed)
                    {
                        context.SetError("email_not_confired", "Email_Not_Confirmed");
                        return;
                    }
                    
                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    identity.AddClaim(new Claim("userId", user.id.ToString()));

                    switch (user.role_id)
                    {
                        case 1:
                            identity.AddClaim(new Claim(ClaimTypes.Role,"admin"));
                            break;
                        case 2:
                            identity.AddClaim(new Claim(ClaimTypes.Role, "medic"));
                            break;
                        case 4:
                            identity.AddClaim(new Claim(ClaimTypes.Role, "patient"));
                            break;
                        case 5:
                            identity.AddClaim(new Claim(ClaimTypes.Role, "lab"));
                            break;
                        default:
                            identity.AddClaim(new Claim(ClaimTypes.Role, "patient"));
                            break;
                    }
                    context.Validated(identity);
                }
                else
                {
                    context.SetError("invalid_grant", "Provided username and password is incorrect");
                    return;
                }
            }
        }
    }
}
