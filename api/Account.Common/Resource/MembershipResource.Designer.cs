﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Account.Common.Resource {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class MembershipResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal MembershipResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Account.Common.Resource.MembershipResource", typeof(MembershipResource).Assembly);
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
        ///   Looks up a localized string similar to نام کاربری ارسالی با کاربر جاری یکسان نمی باشد.
        /// </summary>
        public static string Error_CurrentUserMismatch {
            get {
                return ResourceManager.GetString("Error_CurrentUserMismatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ایمیل قبلا استفاده شده است.
        /// </summary>
        public static string Error_DuplicateEmail {
            get {
                return ResourceManager.GetString("Error_DuplicateEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to نام کاربری قبلا استفاده شده است.
        /// </summary>
        public static string Error_DuplicateUserName {
            get {
                return ResourceManager.GetString("Error_DuplicateUserName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to کلمه عبور باید شامل عدد باشد.
        /// </summary>
        public static string Error_PasswordRequiresDigit {
            get {
                return ResourceManager.GetString("Error_PasswordRequiresDigit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to کلمه عبور باید شامل حروف لاتین کوچک باشد.
        /// </summary>
        public static string Error_PasswordRequiresLower {
            get {
                return ResourceManager.GetString("Error_PasswordRequiresLower", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to کلمه عبور باید شامل حروف غیر عدد و حرف باشد.
        /// </summary>
        public static string Error_PasswordRequiresNonAlphanumeric {
            get {
                return ResourceManager.GetString("Error_PasswordRequiresNonAlphanumeric", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to کلمه عبور باید شامل حروف لاتین بزرگ باشد.
        /// </summary>
        public static string Error_PasswordRequiresUpper {
            get {
                return ResourceManager.GetString("Error_PasswordRequiresUpper", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to طول کلمه عبور باید حد اقل ۶ کاراکتر باشد.
        /// </summary>
        public static string Error_PasswordTooShort {
            get {
                return ResourceManager.GetString("Error_PasswordTooShort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to کاربر مسدود شده است.
        /// </summary>
        public static string Error_UserLockout {
            get {
                return ResourceManager.GetString("Error_UserLockout", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to نام کاربری و یا کلمه عبور معتبر نمی باشد.
        /// </summary>
        public static string Error_UsernameOrPasswordIsNotValid {
            get {
                return ResourceManager.GetString("Error_UsernameOrPasswordIsNotValid", resourceCulture);
            }
        }
    }
}