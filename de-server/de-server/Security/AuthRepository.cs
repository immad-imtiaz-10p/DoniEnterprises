using de_server.Entity_Framework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace de_server.Security
{
    public class AuthRepository : IDisposable
    {
        public DhoniEnterprisesEntities _ctx;

        private UserManager<IdentityUser> _userManager;

        public AuthRepository()
        {
            _ctx = new DhoniEnterprisesEntities();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(AppUser userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.UserEmail
            };

            var result = await _userManager.CreateAsync(user, userModel.UserPass);

            return result;
        }

      

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}