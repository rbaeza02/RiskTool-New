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
    public partial class SelectCotizacionPresentacion_Result : INotifyComplexPropertyChanging, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public System.DateTime Fecha
        {
            get { return _fecha; }
            set
            {
                if (_fecha != value)
                {
                    OnComplexPropertyChanging();
                    _fecha = value;
                    OnPropertyChanged("Fecha");
                }
            }
        }
        private System.DateTime _fecha;
    
        [DataMember]
        public string Asegurado
        {
            get { return _asegurado; }
            set
            {
                if (_asegurado != value)
                {
                    OnComplexPropertyChanging();
                    _asegurado = value;
                    OnPropertyChanged("Asegurado");
                }
            }
        }
        private string _asegurado;
    
        [DataMember]
        public string giro
        {
            get { return _giro; }
            set
            {
                if (_giro != value)
                {
                    OnComplexPropertyChanging();
                    _giro = value;
                    OnPropertyChanged("giro");
                }
            }
        }
        private string _giro;
    
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
        public string vigencia
        {
            get { return _vigencia; }
            set
            {
                if (_vigencia != value)
                {
                    OnComplexPropertyChanging();
                    _vigencia = value;
                    OnPropertyChanged("vigencia");
                }
            }
        }
        private string _vigencia;
    
        [DataMember]
        public string agente
        {
            get { return _agente; }
            set
            {
                if (_agente != value)
                {
                    OnComplexPropertyChanging();
                    _agente = value;
                    OnPropertyChanged("agente");
                }
            }
        }
        private string _agente;
    
        [DataMember]
        public string ubi
        {
            get { return _ubi; }
            set
            {
                if (_ubi != value)
                {
                    OnComplexPropertyChanging();
                    _ubi = value;
                    OnPropertyChanged("ubi");
                }
            }
        }
        private string _ubi;
    
        [DataMember]
        public string RFC
        {
            get { return _rFC; }
            set
            {
                if (_rFC != value)
                {
                    OnComplexPropertyChanging();
                    _rFC = value;
                    OnPropertyChanged("RFC");
                }
            }
        }
        private string _rFC;
    
        [DataMember]
        public System.DateTime VigenciaInicio
        {
            get { return _vigenciaInicio; }
            set
            {
                if (_vigenciaInicio != value)
                {
                    OnComplexPropertyChanging();
                    _vigenciaInicio = value;
                    OnPropertyChanged("VigenciaInicio");
                }
            }
        }
        private System.DateTime _vigenciaInicio;

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
    
        public static void RecordComplexOriginalValues(String parentPropertyName, SelectCotizacionPresentacion_Result complexObject, ObjectChangeTracker changeTracker)
        {
            if (String.IsNullOrEmpty(parentPropertyName))
            {
                throw new ArgumentException("String parameter cannot be null or empty.", "parentPropertyName");
            }
    
            if (changeTracker == null)
            {
                throw new ArgumentNullException("changeTracker");
            }
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.Fecha", parentPropertyName), complexObject == null ? null : (object)complexObject.Fecha);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.Asegurado", parentPropertyName), complexObject == null ? null : (object)complexObject.Asegurado);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.giro", parentPropertyName), complexObject == null ? null : (object)complexObject.giro);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.moneda", parentPropertyName), complexObject == null ? null : (object)complexObject.moneda);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.vigencia", parentPropertyName), complexObject == null ? null : (object)complexObject.vigencia);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.agente", parentPropertyName), complexObject == null ? null : (object)complexObject.agente);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.ubi", parentPropertyName), complexObject == null ? null : (object)complexObject.ubi);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.RFC", parentPropertyName), complexObject == null ? null : (object)complexObject.RFC);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.VigenciaInicio", parentPropertyName), complexObject == null ? null : (object)complexObject.VigenciaInicio);
        }

        #endregion

    }
}
