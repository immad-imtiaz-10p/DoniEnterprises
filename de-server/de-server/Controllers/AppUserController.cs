using de_server.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using de_server.Security;
using de_server.Providers;
using de_server.App_Config;
using System.Threading.Tasks;
using de_server.Models;
using Newtonsoft.Json.Linq;
using de_server.Filters;

namespace de_server.Controllers
{
    [DoniApiExceptionFilter]   
    public class AppUserController : ApiController
    {
        [Route("changePassword")]
        [HttpPost]
        public IHttpActionResult changePassword([FromBody] JObject passDetails)
        {
            using (var context = new DhoniEnterprisesEntities())
            {
                
                var passwordDetails = passDetails["passwordDetails"];
                var oldPass = passwordDetails["oldPassword"];
                var newPass = passwordDetails["newPassword"];
                var confirmPass = passwordDetails["confirmPassword"];
                if (Convert.ToString(newPass) != Convert.ToString(confirmPass))
                {
                    return Ok(new {success = false, message = "Passwords do not match"});
                }
                
                
                int userID = BasicAuthHttpModule.getCurrentUserId();
                
                var userDetails = (from user in context.AppUsers where user.UserID.Equals(userID) select user).FirstOrDefault();
                string hashedPassword = Security.Security.HashSHA1(Convert.ToString(oldPass) + Convert.ToString(userDetails.UserGuid) );
                if (hashedPassword != userDetails.UserPass)
                {
                    return Ok(new {success = false, message = "Passwords is not correct!"});
                }
                else
                {
                    Guid userGuid = System.Guid.NewGuid();
                    string newHashedPass = Security.Security.HashSHA1(Convert.ToString(newPass) + userGuid );
                    context.AppUserChangePasword(userID, newHashedPass, userGuid);
                    return Ok(new { success = true, message = "Your Password has been Changed!" });
                }
               

                
                
                

                
                
            }   
        }

        [Route("login")]
        [HttpPost]
        public async Task<IHttpActionResult> PostuserLogin(AuthenticateViewModel viewModel)
        {
            using(var context = new DhoniEnterprisesEntities())
            {
               
                    int userId = BasicAuthHttpModule.AuthenticateUser(viewModel.Username, viewModel.Password);
                    if (userId == -1)
                    {
                        return Ok(new { success = false, message = "Invalid Password/email" });
                        
                    }
                    else if (userId == -2)
                    {
                        return Ok(new { success = false, message = "Your account has been deactivated by Administrator" });
                    }
                    else
                    {
                        return Ok(new { success = true, userId = userId });
                    }           

            }

        }

        [Authorize]
        [Route("getUserDetails")]
        [HttpGet]
        public IHttpActionResult getUserDetails(string email)
        {
            
                using (var context = new DhoniEnterprisesEntities())
                {
                    var curUser = DataTableSerializer.LINQToDataTable(context.uspGetAppUserByEmail(email));
                    return Ok(new { success = true, user = curUser});                    
                }
          
        }


        [Authorize]
        [Route("activateUser")]
        [HttpPost]
        public IHttpActionResult ActivateUser([FromBody] JObject userDetails)
        {
            using (var context = new DhoniEnterprisesEntities())
            {
                var userId = Convert.ToInt32(userDetails["userId"]);               
                context.activateUser(userId);
                return Ok(new { success = true, message = "User has been activated." });
            }
        }

        [Authorize]
        [Route("deactivateUser")]
        [HttpPost]
        public IHttpActionResult DeActivateUser([FromBody] JObject userDetails)
        {
            using (var context = new DhoniEnterprisesEntities())
            {
                var userId = Convert.ToInt32(userDetails["userId"]);
                if (userId == 1)
                {
                    return Ok(new { success = false, message = "This user is a master admin and can not be deactivated." });
                }
                context.deactivateUser(userId);
                return Ok(new { success = true, message="User has been deactivated." });
            }
        }


        [Authorize]
        [Route("getAppUsers")]
        [HttpGet]
        public IHttpActionResult GetAppUsers()
        {
            
                using (var context = new DhoniEnterprisesEntities())
                {
                    var allUsers = DataTableSerializer.LINQToDataTable(context.getAllUsers());
                    return Ok(new { success = true, user = allUsers });
                }
         
            
        }

        [Authorize]
        [Route("addNewUser")]
        [HttpPost]
        public HttpResponseMessage addNewUser([FromBody] JObject newUser)
        {
            var nUser = newUser["newUser"];
            var email = Convert.ToString(nUser["email"]);
            var fname = Convert.ToString(nUser["firstName"]);
            var lname = Convert.ToString(nUser["lastName"]);
            var pass = Convert.ToString(nUser["password"]);
            var title = Convert.ToString(nUser["initials"]);
            var des = Convert.ToString(nUser["designation"]);
            var isAdmin = Convert.ToBoolean(nUser["isAdmin"]);

            Guid userGuid = System.Guid.NewGuid();
            string hashedPassword = Security.Security.HashSHA1(pass + userGuid.ToString());
            using (var context = new DhoniEnterprisesEntities())
            {
                int a = (from user in context.AppUsers where user.UserEmail.Equals(email) select user).Count();
                if (a > 0)
               {
                    var resp = new HttpResponseMessage(HttpStatusCode.OK);
                    resp.Content = new StringContent("AlreadyExist", System.Text.Encoding.UTF8, "text/plain");
                    return resp;
                }
                else
                {
                    try
                    {

                        //string body = emailManager.populateEmailBody(title + ". " + fname + lname, "Doni Managment Account Created",
                                        //"An account for Doni Managment has been created.</br>"+ 
                                        //"Please Access your acount with your email and password given below </br>"
                                        //+pass);
                        //emailManager.SendHtmlFormattedEmail(email, "Doni Managment Account Created", body);
                        var x = context.addNewAppUser(title, fname, lname, hashedPassword, email, userGuid, des, isAdmin);
                        var resp = new HttpResponseMessage(HttpStatusCode.OK);
                        resp.Content = new StringContent("Saved", System.Text.Encoding.UTF8, "text/plain");
                        return resp;
                    }
                    catch
                    {
                          var resp = new HttpResponseMessage(HttpStatusCode.OK);
                          resp.Content = new StringContent("Error", System.Text.Encoding.UTF8, "text/plain");
                          return resp;
                    }
                }


            }
        }
    }
}
