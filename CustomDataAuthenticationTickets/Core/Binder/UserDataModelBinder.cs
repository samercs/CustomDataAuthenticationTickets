using System;
using System.Web.Mvc;
using System.Web.Security;
using CustomDataAuthenticationTickets.Core.Model;
using Newtonsoft.Json;

namespace CustomDataAuthenticationTickets.Core.Binder
{
    public class UserDataModelBinder<T> : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            if (bindingContext.Model != null)
                throw new InvalidOperationException("Cannot update instances");
            if (controllerContext.RequestContext.HttpContext.Request.IsAuthenticated)
            {
                var cookie = controllerContext
                    .RequestContext
                    .HttpContext
                    .Request
                    .Cookies[FormsAuthentication.FormsCookieName];

                if (null == cookie)
                    return null;

                var decrypted = FormsAuthentication.Decrypt(cookie.Value);

                if (!string.IsNullOrEmpty(decrypted.UserData))
                    return  JsonConvert.DeserializeObject<UserData>(decrypted.UserData);
            }
            return null;
        }
    }
}