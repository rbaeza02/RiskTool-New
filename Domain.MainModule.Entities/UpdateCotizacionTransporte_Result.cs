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
    public partial class UpdateCotizacionTransporte_Result : INotifyComplexPropertyChanging, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public Nullable<double> primaTarifaMinRenovacion
        {
            get { return _primaTarifaMinRenovacion; }
            set
            {
                if (_primaTarifaMinRenovacion != value)
                {
                    OnComplexPropertyChanging();
                    _primaTarifaMinRenovacion = value;
                    OnPropertyChanged("primaTarifaMinRenovacion");
                }
            }
        }
        private Nullable<double> _primaTarifaMinRenovacion;
    
        [DataMember]
        public Nullable<double> primaTarifaMaxRenovacion
        {
            get { return _primaTarifaMaxRenovacion; }
            set
            {
                if (_primaTarifaMaxRenovacion != value)
                {
                    OnComplexPropertyChanging();
                    _primaTarifaMaxRenovacion = value;
                    OnPropertyChanged("primaTarifaMaxRenovacion");
                }
            }
        }
        private Nullable<double> _primaTarifaMaxRenovacion;
    
        [DataMember]
        public Nullable<double> primaNetaNuevo
        {
            get { return _primaNetaNuevo; }
            set
            {
                if (_primaNetaNuevo != value)
                {
                    OnComplexPropertyChanging();
                    _primaNetaNuevo = value;
                    OnPropertyChanged("primaNetaNuevo");
                }
            }
        }
        private Nullable<double> _primaNetaNuevo;
    
        [DataMember]
        public Nullable<double> primaNetaRenovacion
        {
            get { return _primaNetaRenovacion; }
            set
            {
                if (_primaNetaRenovacion != value)
                {
                    OnComplexPropertyChanging();
                    _primaNetaRenovacion = value;
                    OnPropertyChanged("primaNetaRenovacion");
                }
            }
        }
        private Nullable<double> _primaNetaRenovacion;
    
        [DataMember]
        public Nullable<double> CuotaRenovacion
        {
            get { return _cuotaRenovacion; }
            set
            {
                if (_cuotaRenovacion != value)
                {
                    OnComplexPropertyChanging();
                    _cuotaRenovacion = value;
                    OnPropertyChanged("CuotaRenovacion");
                }
            }
        }
        private Nullable<double> _cuotaRenovacion;
    
        [DataMember]
        public Nullable<double> CuotaNuevo
        {
            get { return _cuotaNuevo; }
            set
            {
                if (_cuotaNuevo != value)
                {
                    OnComplexPropertyChanging();
                    _cuotaNuevo = value;
                    OnPropertyChanged("CuotaNuevo");
                }
            }
        }
        private Nullable<double> _cuotaNuevo;
    
        [DataMember]
        public Nullable<double> PrimaNetaModificada
        {
            get { return _primaNetaModificada; }
            set
            {
                if (_primaNetaModificada != value)
                {
                    OnComplexPropertyChanging();
                    _primaNetaModificada = value;
                    OnPropertyChanged("PrimaNetaModificada");
                }
            }
        }
        private Nullable<double> _primaNetaModificada;

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
    
        public static void RecordComplexOriginalValues(String parentPropertyName, UpdateCotizacionTransporte_Result complexObject, ObjectChangeTracker changeTracker)
        {
            if (String.IsNullOrEmpty(parentPropertyName))
            {
                throw new ArgumentException("String parameter cannot be null or empty.", "parentPropertyName");
            }
    
            if (changeTracker == null)
            {
                throw new ArgumentNullException("changeTracker");
            }
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.primaTarifaMinRenovacion", parentPropertyName), complexObject == null ? null : (object)complexObject.primaTarifaMinRenovacion);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.primaTarifaMaxRenovacion", parentPropertyName), complexObject == null ? null : (object)complexObject.primaTarifaMaxRenovacion);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.primaNetaNuevo", parentPropertyName), complexObject == null ? null : (object)complexObject.primaNetaNuevo);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.primaNetaRenovacion", parentPropertyName), complexObject == null ? null : (object)complexObject.primaNetaRenovacion);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.CuotaRenovacion", parentPropertyName), complexObject == null ? null : (object)complexObject.CuotaRenovacion);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.CuotaNuevo", parentPropertyName), complexObject == null ? null : (object)complexObject.CuotaNuevo);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.PrimaNetaModificada", parentPropertyName), complexObject == null ? null : (object)complexObject.PrimaNetaModificada);
        }

        #endregion

    }
}
