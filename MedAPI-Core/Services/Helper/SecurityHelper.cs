using Microsoft.AspNetCore.Http;
using Repository.DTOs;
using System;
using System.Net.Http;
using System.Web;

namespace Services.Helpers
{
    public class SecurityHelper
    {
        public static string GetEmailConfirmatioLink(User mUser, HttpRequest Request)
        {
            var tokenHash = HttpUtility.UrlEncode(HashPasswordHelper.HashToken(mUser.token).ToString());
            return $"{GetBaseUrl(Request)}/account-confirm?id={mUser.id}&code={tokenHash}";
        }

        public static string GetPasswordResetLink(User mUser, HttpRequest Request)
        {
            var tokenHash = HttpUtility.UrlEncode(HashPasswordHelper.HashToken(mUser.reset_token));
            return $"{GetBaseUrl(Request)}/reset-password?id={mUser.id}&code={tokenHash}";
        }

        public static string GetLabNotificationLink(User user, HttpRequest Request)
        {
            return $"{GetBaseUrl(Request)}/records/{user.documentNumber}";

        }

        
        public static string GetAccountSettingLink(HttpRequest Request)
        {
            return $"{GetBaseUrl(Request)}/account-setting";

        }

        public static string GetBaseUrl(HttpRequest request) => $"{request.Scheme}://{request.Host.Value}";
        

    }
}
