﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ResourceMessages.Resources.Tokens {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class RefreshTokensStatusMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal RefreshTokensStatusMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ResourceMessages.Resources.Tokens.RefreshTokensStatusMessages", typeof(RefreshTokensStatusMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This refresh token is Empty..
        /// </summary>
        public static string EmptyToken {
            get {
                return ResourceManager.GetString("EmptyToken", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This refresh token has expired..
        /// </summary>
        public static string ExpiredToken {
            get {
                return ResourceManager.GetString("ExpiredToken", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This refresh token has been invalidated..
        /// </summary>
        public static string InvalidatedToken {
            get {
                return ResourceManager.GetString("InvalidatedToken", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This refresh token does not exist..
        /// </summary>
        public static string NotExist {
            get {
                return ResourceManager.GetString("NotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This refresh token does not match this JWT..
        /// </summary>
        public static string NotMatchJWT {
            get {
                return ResourceManager.GetString("NotMatchJWT", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This refresh token has been used..
        /// </summary>
        public static string UsedToken {
            get {
                return ResourceManager.GetString("UsedToken", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This refresh token is Valid..
        /// </summary>
        public static string ValidToken {
            get {
                return ResourceManager.GetString("ValidToken", resourceCulture);
            }
        }
    }
}