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
                        //return Request.CreateResponse(HttpStatusCode.OK, new { message = "Email_Not_Confirmed" });
                    }

                     //https://onthecode.co.uk/decode-json-web-tokens-jwt-angular/
                    switch (user.role_id)
                    {
                        case 2:
                            var medic = dbContext.medics.FirstOrDefault(x => x.id== user.id);
                                //id = mUser.id,
                                //role = mUser.roleId,
                                //docNumber = mUser.documentNumber,
                                //name = $"{mUser.firstName} {mUser.lastNameFather} {mUser.lastNameMother}",
                                //permissions = permissions,
                                //IsApproved = medic.IsApproved,
                                //IsFreezed = medic.IsFreezed,
                                //cmp = medic.cmp,
                                //rne = medic.rne


                            break;
                        default:
                            break;
                    }


                }
                    

                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            if (context.UserName == "admin" && context.Password == "admin")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                identity.AddClaim(new Claim("username", "admin"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Sourav Mondal"));
                context.Validated(identity);
            }
            else if (context.UserName == "user" && context.Password == "user")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
                identity.AddClaim(new Claim("username", "user"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Suresh Sha"));
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
