using de_server.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;

namespace de_server.Security
{
    public class BasicAuthHttpModule : IHttpModule
    {
        private const string Realm = "AngularWebAPI";

        public void Init(HttpApplication context)
        {
            // Register event handlers
            context.AuthenticateRequest += OnApplicationAuthenticateRequest;
            context.EndRequest += OnApplicationEndRequest;
        }

        private static void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }

        public static bool AuthenticateUser(string credentials)
        {
            var encoding = Encoding.GetEncoding("iso-8859-1");
            credentials = encoding.GetString(Convert.FromBase64String(credentials));
            var credentialsArray = credentials.Split(':');
            var email = credentialsArray[0];
            var password = credentialsArray[1];

            
            /* REPLACE THIS WITH REAL AUTHENTICATION
            ----------------------------------------------*/
            using (var dbContext = new DhoniEnterprisesEntities())
            {
                var loggedUser = (from user in dbContext.AppUsers where user.UserEmail.Equals(email) select user).First();                 
                string hashedPassword = Security.HashSHA1(password + loggedUser.UserGuid);
                if (hashedPassword != loggedUser.UserPass)
                {
                    return false;
                }
            }

            var identity = new GenericIdentity(email);
            SetPrincipal(new GenericPrincipal(identity, null));

            return true;
        }

        public static int AuthenticateUser(string email, string password)
        {
            var encoding = Encoding.GetEncoding("iso-8859-1");
            //credentials = encoding.GetString(Convert.FromBase64String(credentials));
            //var credentialsArray = credentials.Split(':');
            //var email = credentialsArray[0];
            //var password = credentialsArray[1];
            int userId;

            /* REPLACE THIS WITH REAL AUTHENTICATION
            ----------------------------------------------*/
            using (var dbContext = new DhoniEnterprisesEntities())
            {
                var loggedUser = (from user in dbContext.AppUsers where user.UserEmail.Equals(email) select user).First();
                string hashedPassword = Security.HashSHA1(password + loggedUser.UserGuid);
                if (hashedPassword != loggedUser.UserPass)
                {
                    return -1;
                }
                userId = loggedUser.UserID;
            }

            var identity = new GenericIdentity(email);
            SetPrincipal(new GenericPrincipal(identity, null));

            return userId;
        }

        private static void OnApplicationAuthenticateRequest(object sender, EventArgs e)
        {
            var request = HttpContext.Current.Request;
            var authHeader = request.Headers["Authorization"];
            if (authHeader != null)
            {
                var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);

                // RFC 2617 sec 1.2, "scheme" name is case-insensitive
                if (authHeaderVal.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) && authHeaderVal.Parameter != null)
                {
                    AuthenticateUser(authHeaderVal.Parameter);
                }
            }
        }

        // If the request was unauthorized, add the WWW-Authenticate header
        // to the response.
        private static void OnApplicationEndRequest(object sender, EventArgs e)
        {
            var response = HttpContext.Current.Response;
            if (response.StatusCode == 401)
            {
                response.Headers.Add("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", Realm));
            }
        }

        public static int getCurrentUserId()
        {
            try
            {
                var request = HttpContext.Current.Request;
                var encoding = Encoding.GetEncoding("iso-8859-1");
                var userDetails = encoding.GetString(Convert.FromBase64String(request.Headers["userId"]));
                var userDetailsArray = userDetails.Split(':');
                var userId = userDetailsArray[0];
                var userEmail = userDetailsArray[1];
                return Convert.ToInt32(userId);
            }
            catch
            {
                return -1;
            }            
        }

        public void Dispose()
        {
        }
    }
}