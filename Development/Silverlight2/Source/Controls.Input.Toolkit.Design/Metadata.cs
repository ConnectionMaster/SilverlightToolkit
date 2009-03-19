﻿// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System.Reflection;
using System.Windows.Controls.Design.Common;
using Microsoft.Windows.Design;
using Microsoft.Windows.Design.Metadata;

namespace System.Windows.Controls.Input.Design
{
    /// <summary>
    /// MetadataRegistration class.
    /// </summary>
    public partial class MetadataRegistration : MetadataRegistrationBase, IRegisterMetadata
    {
        /// <summary>
        /// Design time metadata registration class.
        /// </summary>
        public MetadataRegistration()
            : base()
        {
            // Note:
            // The default constructor sets value of AssemblyFullName and 
            // XmlResourceName used by MetadataRegistrationBase.AddDescriptions().
            // The convention here is that the <RootNamespace> in .design.csproj
            // (or Default namespace in Project -> Properties -> Application tab)
            // must be the same as runtime assembly's main namespace (t.Namespace)
            // plus .Input.Design. This is to ease the move of controls from toolkit to sdk.

            Type t = typeof(NumericUpDown);
            AssemblyName an = t.Assembly.GetName();
            AssemblyFullName = ", " + an.FullName;
            XmlResourceName = t.Namespace + ".Input.Design." + an.Name + ".XML";
        }

        /// <summary>
        /// Borrowed from System.Windows.Controls.Toolbox.Design.MetadataRegistration:
        /// use a static flag to ensure metadata is registered only one.
        /// </summary>
        private static bool _initialized;

        /// <summary>
        /// Called by tools to register design time metadata.
        /// </summary>
        public void Register()
        {
            if (!_initialized)
            {
                MetadataStore.AddAttributeTable(BuildAttributeTable());
                _initialized = true;
            }
        }

        /// <summary>
        /// Provide a place to add custom attributes without creating a AttributeTableBuilder subclass.
        /// </summary>
        /// <param name="builder">The assembly attribute table builder.</param>
        protected override void AddAttributes(AttributeTableBuilder builder)
        {
        }
    }
}