using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfRestAuthentication.Services
{
    /// <summary>
    /// The reference to the object of any custom authorization provider.
    /// </summary>
    /// <returns></returns>
    public delegate IAuthorizationProvider CustomAuthorizationProvider();

    public static class AuthContext
    {
        private static CustomAuthorizationProvider currentProvider;

        /// <summary>
        /// The current ambient container.
        /// </summary>
        public static IAuthorizationProvider Current
        {
            get
            {
                if (!IsCustomAuthorizationProviderSet) throw new InvalidOperationException("No authorization strategy found!");

                return currentProvider();
            }
        }

        /// <summary>
        /// Set the delegate that is used to retrieve the current provider.
        /// </summary>
        /// <param name="newProvider">Delegate that, when called, will return
        /// the current ambient container.</param>
        public static void SetAuthorizationProvider(CustomAuthorizationProvider newProvider)
        {
            currentProvider = newProvider;
        }

        public static bool IsCustomAuthorizationProviderSet
        {
            get
            {
                return currentProvider != null;
            }
        }
    }
}