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
    public partial class SelectCodigoPostalDatos_Result : INotifyComplexPropertyChanging, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public Nullable<int> ZonaHidroID
        {
            get { return _zonaHidroID; }
            set
            {
                if (_zonaHidroID != value)
                {
                    OnComplexPropertyChanging();
                    _zonaHidroID = value;
                    OnPropertyChanged("ZonaHidroID");
                }
            }
        }
        private Nullable<int> _zonaHidroID;
    
        [DataMember]
        public Nullable<int> ZonaTEVID
        {
            get { return _zonaTEVID; }
            set
            {
                if (_zonaTEVID != value)
                {
                    OnComplexPropertyChanging();
                    _zonaTEVID = value;
                    OnPropertyChanged("ZonaTEVID");
                }
            }
        }
        private Nullable<int> _zonaTEVID;
    
        [DataMember]
        public Nullable<double> longitud
        {
            get { return _longitud; }
            set
            {
                if (_longitud != value)
                {
                    OnComplexPropertyChanging();
                    _longitud = value;
                    OnPropertyChanged("longitud");
                }
            }
        }
        private Nullable<double> _longitud;
    
        [DataMember]
        public Nullable<double> latitud
        {
            get { return _latitud; }
            set
            {
                if (_latitud != value)
                {
                    OnComplexPropertyChanging();
                    _latitud = value;
                    OnPropertyChanged("latitud");
                }
            }
        }
        private Nullable<double> _latitud;
    
        [DataMember]
        public Nullable<bool> esCosta
        {
            get { return _esCosta; }
            set
            {
                if (_esCosta != value)
                {
                    OnComplexPropertyChanging();
                    _esCosta = value;
                    OnPropertyChanged("esCosta");
                }
            }
        }
        private Nullable<bool> _esCosta;

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
    
        public static void RecordComplexOriginalValues(String parentPropertyName, SelectCodigoPostalDatos_Result complexObject, ObjectChangeTracker changeTracker)
        {
            if (String.IsNullOrEmpty(parentPropertyName))
            {
                throw new ArgumentException("String parameter cannot be null or empty.", "parentPropertyName");
            }
    
            if (changeTracker == null)
            {
                throw new ArgumentNullException("changeTracker");
            }
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.ZonaHidroID", parentPropertyName), complexObject == null ? null : (object)complexObject.ZonaHidroID);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.ZonaTEVID", parentPropertyName), complexObject == null ? null : (object)complexObject.ZonaTEVID);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.longitud", parentPropertyName), complexObject == null ? null : (object)complexObject.longitud);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.latitud", parentPropertyName), complexObject == null ? null : (object)complexObject.latitud);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.esCosta", parentPropertyName), complexObject == null ? null : (object)complexObject.esCosta);
        }

        #endregion

    }
}
