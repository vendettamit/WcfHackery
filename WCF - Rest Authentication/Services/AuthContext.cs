using System;

namespace WcfRestAuthentication.Services
{
    public static class AuthContext
    {
        private static Func<IAuthorizationProvider> _currentProvider;

        /// <summary>
        /// The current ambient container.
        /// </summary>
        public static IAuthorizationProvider Current
        {
            get
            {
                if (!IsCustomAuthorizationProviderSet) throw new InvalidOperationException("No authorization strategy found!");

                return _currentProvider();
            }
        }

        /// <summary>
        /// Set the delegate that is used to retrieve the current provider.
        /// </summary>
        /// <param name="newProvider">Delegate that, when called, will return
        /// the current ambient container.</param>
        public static void SetAuthorizationProvider(Func<IAuthorizationProvider> newProvider)
        {
            _currentProvider = newProvider;
        }

        public static bool IsCustomAuthorizationProviderSet
        {
            get
            {
                return _currentProvider != null;
            }
        }
    }
}