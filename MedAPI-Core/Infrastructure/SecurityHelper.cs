
using AutoMapper;
using Data.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Repository.DTOs;
using System;
using System.Net.Http;
using System.Web;

namespace Infrastructure
{
    public class SecurityHelper
    {
        
        public static string GetEmailConfirmatioLink(Repository.DTOs.User mUser, HttpRequest request, UserManager<user> userManager, IMapper mapper)
        {
            try
            {
                var user = mapper.Map<user>(mUser);
                var token = userManager.GenerateEmailConfirmationTokenAsync(user).Result;
                var baseUrl = $"{request.Scheme}://{request.Host}";
                return $"{baseUrl}/account-confirm?email={user.Email}&token={token}";
            }
            catch (Exception ex)
            {
                var a = ex.InnerException;
                var b = ex.Message;
                throw;
            }
            
           
        }

        public static string GetLabNotificationLink(User user, HttpRequest request, UserManager<user> userManager, IMapper mapper)
        {
            return string.Empty;
        }

        //public static string GetPasswordResetLink(User mUser, HttpRequestMessage Request)
        //{
        //    return string.Empty;
        //    //var tokenHash = HttpUtility.UrlEncode(Infrastructure.HashPasswordHelper.HashToken(mUser.reset_token));
        //    //var baseUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority);

        //    //return $"{baseUrl}/reset-password?id={mUser.id}&code={tokenHash}";
        //}

        //public static string GetLabNotificationLink(User user, HttpRequestMessage Request)
        //{
        //    var baseUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority);

        //    return $"{baseUrl}/records/{user.documentNumber}";

        //}


        //public static string GetAccountSettingLink(HttpRequestMessage Request)
        //{
        //    var baseUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority);

        //    return $"{baseUrl}/account-setting";

        //}

    }
}
