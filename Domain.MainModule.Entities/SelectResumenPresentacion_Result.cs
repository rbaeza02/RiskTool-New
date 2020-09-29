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
    public partial class SelectResumenPresentacion_Result : INotifyComplexPropertyChanging, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public Nullable<double> primaTotal
        {
            get { return _primaTotal; }
            set
            {
                if (_primaTotal != value)
                {
                    OnComplexPropertyChanging();
                    _primaTotal = value;
                    OnPropertyChanged("primaTotal");
                }
            }
        }
        private Nullable<double> _primaTotal;
    
        [DataMember]
        public Nullable<double> PrimaNeta
        {
            get { return _primaNeta; }
            set
            {
                if (_primaNeta != value)
                {
                    OnComplexPropertyChanging();
                    _primaNeta = value;
                    OnPropertyChanged("PrimaNeta");
                }
            }
        }
        private Nullable<double> _primaNeta;
    
        [DataMember]
        public Nullable<double> recargo
        {
            get { return _recargo; }
            set
            {
                if (_recargo != value)
                {
                    OnComplexPropertyChanging();
                    _recargo = value;
                    OnPropertyChanged("recargo");
                }
            }
        }
        private Nullable<double> _recargo;
    
        [DataMember]
        public string formaPago
        {
            get { return _formaPago; }
            set
            {
                if (_formaPago != value)
                {
                    OnComplexPropertyChanging();
                    _formaPago = value;
                    OnPropertyChanged("formaPago");
                }
            }
        }
        private string _formaPago;
    
        [DataMember]
        public string usuario
        {
            get { return _usuario; }
            set
            {
                if (_usuario != value)
                {
                    OnComplexPropertyChanging();
                    _usuario = value;
                    OnPropertyChanged("usuario");
                }
            }
        }
        private string _usuario;
    
        [DataMember]
        public string moneda
        {
            get { return _moneda; }
            set
            {
                if (_moneda != value)
                {
                    OnComplexPropertyChanging();
                    _moneda = value;
                    OnPropertyChanged("moneda");
                }
            }
        }
        private string _moneda;
    
        [DataMember]
        public Nullable<double> Derecho
        {
            get { return _derecho; }
            set
            {
                if (_derecho != value)
                {
                    OnComplexPropertyChanging();
                    _derecho = value;
                    OnPropertyChanged("Derecho");
                }
            }
        }
        private Nullable<double> _derecho;
    
        [DataMember]
        public Nullable<double> IVA
        {
            get { return _iVA; }
            set
            {
                if (_iVA != value)
                {
                    OnComplexPropertyChanging();
                    _iVA = value;
                    OnPropertyChanged("IVA");
                }
            }
        }
        private Nullable<double> _iVA;
    
        [DataMember]
        public Nullable<double> primaNetaAnual
        {
            get { return _primaNetaAnual; }
            set
            {
                if (_primaNetaAnual != value)
                {
                    OnComplexPropertyChanging();
                    _primaNetaAnual = value;
                    OnPropertyChanged("primaNetaAnual");
                }
            }
        }
        private Nullable<double> _primaNetaAnual;

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
    
        public static void RecordComplexOriginalValues(String parentPropertyName, SelectResumenPresentacion_Result complexObject, ObjectChangeTracker changeTracker)
        {
            if (String.IsNullOrEmpty(parentPropertyName))
            {
                throw new ArgumentException("String parameter cannot be null or empty.", "parentPropertyName");
            }
    
            if (changeTracker == null)
            {
                throw new ArgumentNullException("changeTracker");
            }
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.primaTotal", parentPropertyName), complexObject == null ? null : (object)complexObject.primaTotal);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.PrimaNeta", parentPropertyName), complexObject == null ? null : (object)complexObject.PrimaNeta);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.recargo", parentPropertyName), complexObject == null ? null : (object)complexObject.recargo);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.formaPago", parentPropertyName), complexObject == null ? null : (object)complexObject.formaPago);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.usuario", parentPropertyName), complexObject == null ? null : (object)complexObject.usuario);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.moneda", parentPropertyName), complexObject == null ? null : (object)complexObject.moneda);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.Derecho", parentPropertyName), complexObject == null ? null : (object)complexObject.Derecho);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.IVA", parentPropertyName), complexObject == null ? null : (object)complexObject.IVA);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.primaNetaAnual", parentPropertyName), complexObject == null ? null : (object)complexObject.primaNetaAnual);
        }

        #endregion

    }
}