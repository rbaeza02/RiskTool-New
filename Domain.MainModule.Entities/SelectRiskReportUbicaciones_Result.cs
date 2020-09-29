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
    public partial class SelectRiskReportUbicaciones_Result : INotifyComplexPropertyChanging, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int nroUbicacion
        {
            get { return _nroUbicacion; }
            set
            {
                if (_nroUbicacion != value)
                {
                    OnComplexPropertyChanging();
                    _nroUbicacion = value;
                    OnPropertyChanged("nroUbicacion");
                }
            }
        }
        private int _nroUbicacion;
    
        [DataMember]
        public string CodigoPostal
        {
            get { return _codigoPostal; }
            set
            {
                if (_codigoPostal != value)
                {
                    OnComplexPropertyChanging();
                    _codigoPostal = value;
                    OnPropertyChanged("CodigoPostal");
                }
            }
        }
        private string _codigoPostal;
    
        [DataMember]
        public string Domicilio_Calle
        {
            get { return _domicilio_Calle; }
            set
            {
                if (_domicilio_Calle != value)
                {
                    OnComplexPropertyChanging();
                    _domicilio_Calle = value;
                    OnPropertyChanged("Domicilio_Calle");
                }
            }
        }
        private string _domicilio_Calle;
    
        [DataMember]
        public string Domicilio_NroExterior
        {
            get { return _domicilio_NroExterior; }
            set
            {
                if (_domicilio_NroExterior != value)
                {
                    OnComplexPropertyChanging();
                    _domicilio_NroExterior = value;
                    OnPropertyChanged("Domicilio_NroExterior");
                }
            }
        }
        private string _domicilio_NroExterior;
    
        [DataMember]
        public string Domicilio_NroInterior
        {
            get { return _domicilio_NroInterior; }
            set
            {
                if (_domicilio_NroInterior != value)
                {
                    OnComplexPropertyChanging();
                    _domicilio_NroInterior = value;
                    OnPropertyChanged("Domicilio_NroInterior");
                }
            }
        }
        private string _domicilio_NroInterior;
    
        [DataMember]
        public string colonia
        {
            get { return _colonia; }
            set
            {
                if (_colonia != value)
                {
                    OnComplexPropertyChanging();
                    _colonia = value;
                    OnPropertyChanged("colonia");
                }
            }
        }
        private string _colonia;
    
        [DataMember]
        public string ciudad
        {
            get { return _ciudad; }
            set
            {
                if (_ciudad != value)
                {
                    OnComplexPropertyChanging();
                    _ciudad = value;
                    OnPropertyChanged("ciudad");
                }
            }
        }
        private string _ciudad;
    
        [DataMember]
        public string estado
        {
            get { return _estado; }
            set
            {
                if (_estado != value)
                {
                    OnComplexPropertyChanging();
                    _estado = value;
                    OnPropertyChanged("estado");
                }
            }
        }
        private string _estado;
    
        [DataMember]
        public string municipio
        {
            get { return _municipio; }
            set
            {
                if (_municipio != value)
                {
                    OnComplexPropertyChanging();
                    _municipio = value;
                    OnPropertyChanged("municipio");
                }
            }
        }
        private string _municipio;
    
        [DataMember]
        public string Descripcion
        {
            get { return _descripcion; }
            set
            {
                if (_descripcion != value)
                {
                    OnComplexPropertyChanging();
                    _descripcion = value;
                    OnPropertyChanged("Descripcion");
                }
            }
        }
        private string _descripcion;
    
        [DataMember]
        public Nullable<double> Latitud
        {
            get { return _latitud; }
            set
            {
                if (_latitud != value)
                {
                    OnComplexPropertyChanging();
                    _latitud = value;
                    OnPropertyChanged("Latitud");
                }
            }
        }
        private Nullable<double> _latitud;
    
        [DataMember]
        public Nullable<double> Longitud
        {
            get { return _longitud; }
            set
            {
                if (_longitud != value)
                {
                    OnComplexPropertyChanging();
                    _longitud = value;
                    OnPropertyChanged("Longitud");
                }
            }
        }
        private Nullable<double> _longitud;
    
        [DataMember]
        public string TipoConstructivoIncendio
        {
            get { return _tipoConstructivoIncendio; }
            set
            {
                if (_tipoConstructivoIncendio != value)
                {
                    OnComplexPropertyChanging();
                    _tipoConstructivoIncendio = value;
                    OnPropertyChanged("TipoConstructivoIncendio");
                }
            }
        }
        private string _tipoConstructivoIncendio;
    
        [DataMember]
        public string TipoConstructivoTerremoto
        {
            get { return _tipoConstructivoTerremoto; }
            set
            {
                if (_tipoConstructivoTerremoto != value)
                {
                    OnComplexPropertyChanging();
                    _tipoConstructivoTerremoto = value;
                    OnPropertyChanged("TipoConstructivoTerremoto");
                }
            }
        }
        private string _tipoConstructivoTerremoto;
    
        [DataMember]
        public string SIC
        {
            get { return _sIC; }
            set
            {
                if (_sIC != value)
                {
                    OnComplexPropertyChanging();
                    _sIC = value;
                    OnPropertyChanged("SIC");
                }
            }
        }
        private string _sIC;
    
        [DataMember]
        public Nullable<int> añoConstruccion
        {
            get { return _añoConstruccion; }
            set
            {
                if (_añoConstruccion != value)
                {
                    OnComplexPropertyChanging();
                    _añoConstruccion = value;
                    OnPropertyChanged("añoConstruccion");
                }
            }
        }
        private Nullable<int> _añoConstruccion;
    
        [DataMember]
        public int nroPiso
        {
            get { return _nroPiso; }
            set
            {
                if (_nroPiso != value)
                {
                    OnComplexPropertyChanging();
                    _nroPiso = value;
                    OnPropertyChanged("nroPiso");
                }
            }
        }
        private int _nroPiso;
    
        [DataMember]
        public int nroSotano
        {
            get { return _nroSotano; }
            set
            {
                if (_nroSotano != value)
                {
                    OnComplexPropertyChanging();
                    _nroSotano = value;
                    OnPropertyChanged("nroSotano");
                }
            }
        }
        private int _nroSotano;
    
        [DataMember]
        public string zonaTev
        {
            get { return _zonaTev; }
            set
            {
                if (_zonaTev != value)
                {
                    OnComplexPropertyChanging();
                    _zonaTev = value;
                    OnPropertyChanged("zonaTev");
                }
            }
        }
        private string _zonaTev;
    
        [DataMember]
        public string zonHidro
        {
            get { return _zonHidro; }
            set
            {
                if (_zonHidro != value)
                {
                    OnComplexPropertyChanging();
                    _zonHidro = value;
                    OnPropertyChanged("zonHidro");
                }
            }
        }
        private string _zonHidro;
    
        [DataMember]
        public bool UbicacionCosta
        {
            get { return _ubicacionCosta; }
            set
            {
                if (_ubicacionCosta != value)
                {
                    OnComplexPropertyChanging();
                    _ubicacionCosta = value;
                    OnPropertyChanged("UbicacionCosta");
                }
            }
        }
        private bool _ubicacionCosta;
    
        [DataMember]
        public bool AnalisisFire
        {
            get { return _analisisFire; }
            set
            {
                if (_analisisFire != value)
                {
                    OnComplexPropertyChanging();
                    _analisisFire = value;
                    OnPropertyChanged("AnalisisFire");
                }
            }
        }
        private bool _analisisFire;

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
    
        public static void RecordComplexOriginalValues(String parentPropertyName, SelectRiskReportUbicaciones_Result complexObject, ObjectChangeTracker changeTracker)
        {
            if (String.IsNullOrEmpty(parentPropertyName))
            {
                throw new ArgumentException("String parameter cannot be null or empty.", "parentPropertyName");
            }
    
            if (changeTracker == null)
            {
                throw new ArgumentNullException("changeTracker");
            }
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.nroUbicacion", parentPropertyName), complexObject == null ? null : (object)complexObject.nroUbicacion);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.CodigoPostal", parentPropertyName), complexObject == null ? null : (object)complexObject.CodigoPostal);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.Domicilio_Calle", parentPropertyName), complexObject == null ? null : (object)complexObject.Domicilio_Calle);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.Domicilio_NroExterior", parentPropertyName), complexObject == null ? null : (object)complexObject.Domicilio_NroExterior);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.Domicilio_NroInterior", parentPropertyName), complexObject == null ? null : (object)complexObject.Domicilio_NroInterior);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.colonia", parentPropertyName), complexObject == null ? null : (object)complexObject.colonia);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.ciudad", parentPropertyName), complexObject == null ? null : (object)complexObject.ciudad);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.estado", parentPropertyName), complexObject == null ? null : (object)complexObject.estado);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.municipio", parentPropertyName), complexObject == null ? null : (object)complexObject.municipio);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.Descripcion", parentPropertyName), complexObject == null ? null : (object)complexObject.Descripcion);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.Latitud", parentPropertyName), complexObject == null ? null : (object)complexObject.Latitud);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.Longitud", parentPropertyName), complexObject == null ? null : (object)complexObject.Longitud);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.TipoConstructivoIncendio", parentPropertyName), complexObject == null ? null : (object)complexObject.TipoConstructivoIncendio);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.TipoConstructivoTerremoto", parentPropertyName), complexObject == null ? null : (object)complexObject.TipoConstructivoTerremoto);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.SIC", parentPropertyName), complexObject == null ? null : (object)complexObject.SIC);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.añoConstruccion", parentPropertyName), complexObject == null ? null : (object)complexObject.añoConstruccion);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.nroPiso", parentPropertyName), complexObject == null ? null : (object)complexObject.nroPiso);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.nroSotano", parentPropertyName), complexObject == null ? null : (object)complexObject.nroSotano);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.zonaTev", parentPropertyName), complexObject == null ? null : (object)complexObject.zonaTev);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.zonHidro", parentPropertyName), complexObject == null ? null : (object)complexObject.zonHidro);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.UbicacionCosta", parentPropertyName), complexObject == null ? null : (object)complexObject.UbicacionCosta);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.AnalisisFire", parentPropertyName), complexObject == null ? null : (object)complexObject.AnalisisFire);
        }

        #endregion

    }
}
