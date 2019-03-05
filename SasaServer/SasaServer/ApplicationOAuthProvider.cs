
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using SasaServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using TestPro;
//using TestPro.Models;

namespace testpro
{
  public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
  {
    public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
    {
      context.Validated();
    }

    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
    {
      var user = AuthService.GetLoginUser(context.UserName, context.Password);

      if (user != null)
      {
        var identity = new ClaimsIdentity(context.Options.AuthenticationType);

        AuthenticationProperties data = CreateProperties(user);
        var ticket = new AuthenticationTicket(identity, data);

        context.Validated(ticket);
      }

    }

    public static AuthenticationProperties CreateProperties(Users user)
    {
      IDictionary<string, string> data = new Dictionary<string, string>
        {
            { "userName", user.Username },
            {"email", user.Email},
            {"role",user.RoleId.ToString()}
        };
      return new AuthenticationProperties(data);
    }
    public override Task TokenEndpoint(OAuthTokenEndpointContext context)
    {
      foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
      {
        context.AdditionalResponseParameters.Add(property.Key, property.Value);
      }

      return Task.FromResult<object>(null);
    }

  }

  internal class AuthService
  {

    public static Users GetLoginUser(string username, string password)
    {
      using (var db = new SaSaDBEntities())
      {
        var user = db.Users.FirstOrDefault(x => x.Username == username && x.Password == password);
        return user;

      }
    }
  }

}
