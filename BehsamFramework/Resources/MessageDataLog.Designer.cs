﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BehsamFramework.Resources {
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
    public class MessageDataLog {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal MessageDataLog() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BehsamFramework.Resources.MessageDataLog", typeof(MessageDataLog).Assembly);
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
        ///   Looks up a localized string similar to عملیات تغییر وضعیت.
        /// </summary>
        public static string OperationChangeStatus {
            get {
                return ResourceManager.GetString("OperationChangeStatus", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to عملیات حذف اطلاعات.
        /// </summary>
        public static string OperationDelete {
            get {
                return ResourceManager.GetString("OperationDelete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to عملیات ثبت اطلاعات.
        /// </summary>
        public static string OperationRegister {
            get {
                return ResourceManager.GetString("OperationRegister", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to عملیات بروزرسانی اطلاعات.
        /// </summary>
        public static string OperationUpdate {
            get {
                return ResourceManager.GetString("OperationUpdate", resourceCulture);
            }
        }
    }
}
