//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

#pragma warning disable 1591 // this is for supress no xml comments in public members warnings 

using Domain.Core.Entities;

namespace Domain.MainModule.Entities
{
    [System.CodeDom.Compiler.GeneratedCode("STE-EF",".NET 4.0")]
    #if !SILVERLIGHT
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage()]
    #endif
    public partial class SelectTextosPrimaPresentacion_Result : INotifyComplexPropertyChanging, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public Nullable<int> grupo
        {
            get { return _grupo; }
            set
            {
                if (_grupo != value)
                {
                    OnComplexPropertyChanging();
                    _grupo = value;
                    OnPropertyChanged("grupo");
                }
            }
        }
        private Nullable<int> _grupo;
    
        [DataMember]
        public string texto1
        {
            get { return _texto1; }
            set
            {
                if (_texto1 != value)
                {
                    OnComplexPropertyChanging();
                    _texto1 = value;
                    OnPropertyChanged("texto1");
                }
            }
        }
        private string _texto1;
    
        [DataMember]
        public string texto2
        {
            get { return _texto2; }
            set
            {
                if (_texto2 != value)
                {
                    OnComplexPropertyChanging();
                    _texto2 = value;
                    OnPropertyChanged("texto2");
                }
            }
        }
        private string _texto2;

        #endregion

        #region ChangeTracking
    
        private void OnComplexPropertyChanging()
        {
            if (_complexPropertyChanging != null)
            {
                _complexPropertyChanging(this, new EventArgs());
            }
        }
    
        event EventHandler INotifyComplexPropertyChanging.ComplexPropertyChanging { add { _complexPropertyChanging += value; } remove { _complexPropertyChanging -= value; } }
        private event EventHandler _complexPropertyChanging;
    
        private void OnPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged { add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
    
        public static void RecordComplexOriginalValues(String parentPropertyName, SelectTextosPrimaPresentacion_Result complexObject, ObjectChangeTracker changeTracker)
        {
            if (String.IsNullOrEmpty(parentPropertyName))
            {
                throw new ArgumentException("String parameter cannot be null or empty.", "parentPropertyName");
            }
    
            if (changeTracker == null)
            {
                throw new ArgumentNullException("changeTracker");
            }
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.grupo", parentPropertyName), complexObject == null ? null : (object)complexObject.grupo);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.texto1", parentPropertyName), complexObject == null ? null : (object)complexObject.texto1);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.texto2", parentPropertyName), complexObject == null ? null : (object)complexObject.texto2);
        }

        #endregion

    }
}
