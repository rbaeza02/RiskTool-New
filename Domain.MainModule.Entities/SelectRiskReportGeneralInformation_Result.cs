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
    public partial class SelectRiskReportGeneralInformation_Result : INotifyComplexPropertyChanging, INotifyPropertyChanged
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
        public string tipoPersona
        {
            get { return _tipoPersona; }
            set
            {
                if (_tipoPersona != value)
                {
                    OnComplexPropertyChanging();
                    _tipoPersona = value;
                    OnPropertyChanged("tipoPersona");
                }
            }
        }
        private string _tipoPersona;
    
        [DataMember]
        public string FormaPago
        {
            get { return _formaPago; }
            set
            {
                if (_formaPago != value)
                {
                    OnComplexPropertyChanging();
                    _formaPago = value;
                    OnPropertyChanged("FormaPago");
                }
            }
        }
        private string _formaPago;
    
        [DataMember]
        public string rfc
        {
            get { return _rfc; }
            set
            {
                if (_rfc != value)
                {
                    OnComplexPropertyChanging();
                    _rfc = value;
                    OnPropertyChanged("rfc");
                }
            }
        }
        private string _rfc;
    
        [DataMember]
        public string RazonSocial
        {
            get { return _razonSocial; }
            set
            {
                if (_razonSocial != value)
                {
                    OnComplexPropertyChanging();
                    _razonSocial = value;
                    OnPropertyChanged("RazonSocial");
                }
            }
        }
        private string _razonSocial;
    
        [DataMember]
        public string Nombres
        {
            get { return _nombres; }
            set
            {
                if (_nombres != value)
                {
                    OnComplexPropertyChanging();
                    _nombres = value;
                    OnPropertyChanged("Nombres");
                }
            }
        }
        private string _nombres;
    
        [DataMember]
        public string Apellido1
        {
            get { return _apellido1; }
            set
            {
                if (_apellido1 != value)
                {
                    OnComplexPropertyChanging();
                    _apellido1 = value;
                    OnPropertyChanged("Apellido1");
                }
            }
        }
        private string _apellido1;
    
        [DataMember]
        public string Apellido2
        {
            get { return _apellido2; }
            set
            {
                if (_apellido2 != value)
                {
                    OnComplexPropertyChanging();
                    _apellido2 = value;
                    OnPropertyChanged("Apellido2");
                }
            }
        }
        private string _apellido2;
    
        [DataMember]
        public string webPage
        {
            get { return _webPage; }
            set
            {
                if (_webPage != value)
                {
                    OnComplexPropertyChanging();
                    _webPage = value;
                    OnPropertyChanged("webPage");
                }
            }
        }
        private string _webPage;
    
        [DataMember]
        public string sucursal
        {
            get { return _sucursal; }
            set
            {
                if (_sucursal != value)
                {
                    OnComplexPropertyChanging();
                    _sucursal = value;
                    OnPropertyChanged("sucursal");
                }
            }
        }
        private string _sucursal;
    
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
        public string contacto
        {
            get { return _contacto; }
            set
            {
                if (_contacto != value)
                {
                    OnComplexPropertyChanging();
                    _contacto = value;
                    OnPropertyChanged("contacto");
                }
            }
        }
        private string _contacto;
    
        [DataMember]
        public double comision
        {
            get { return _comision; }
            set
            {
                if (_comision != value)
                {
                    OnComplexPropertyChanging();
                    _comision = value;
                    OnPropertyChanged("comision");
                }
            }
        }
        private double _comision;
    
        [DataMember]
        public string nombreUsuario
        {
            get { return _nombreUsuario; }
            set
            {
                if (_nombreUsuario != value)
                {
                    OnComplexPropertyChanging();
                    _nombreUsuario = value;
                    OnPropertyChanged("nombreUsuario");
                }
            }
        }
        private string _nombreUsuario;
    
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
        public bool isNew
        {
            get { return _isNew; }
            set
            {
                if (_isNew != value)
                {
                    OnComplexPropertyChanging();
                    _isNew = value;
                    OnPropertyChanged("isNew");
                }
            }
        }
        private bool _isNew;
    
        [DataMember]
        public Nullable<int> nroPolizaAnt
        {
            get { return _nroPolizaAnt; }
            set
            {
                if (_nroPolizaAnt != value)
                {
                    OnComplexPropertyChanging();
                    _nroPolizaAnt = value;
                    OnPropertyChanged("nroPolizaAnt");
                }
            }
        }
        private Nullable<int> _nroPolizaAnt;
    
        [DataMember]
        public string tipoOperacion
        {
            get { return _tipoOperacion; }
            set
            {
                if (_tipoOperacion != value)
                {
                    OnComplexPropertyChanging();
                    _tipoOperacion = value;
                    OnPropertyChanged("tipoOperacion");
                }
            }
        }
        private string _tipoOperacion;
    
        [DataMember]
        public Nullable<double> Participacion
        {
            get { return _participacion; }
            set
            {
                if (_participacion != value)
                {
                    OnComplexPropertyChanging();
                    _participacion = value;
                    OnPropertyChanged("Participacion");
                }
            }
        }
        private Nullable<double> _participacion;
    
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
    
        [DataMember]
        public System.DateTime VigenciaFin
        {
            get { return _vigenciaFin; }
            set
            {
                if (_vigenciaFin != value)
                {
                    OnComplexPropertyChanging();
                    _vigenciaFin = value;
                    OnPropertyChanged("VigenciaFin");
                }
            }
        }
        private System.DateTime _vigenciaFin;
    
        [DataMember]
        public Nullable<int> dias
        {
            get { return _dias; }
            set
            {
                if (_dias != value)
                {
                    OnComplexPropertyChanging();
                    _dias = value;
                    OnPropertyChanged("dias");
                }
            }
        }
        private Nullable<int> _dias;
    
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
        public string nivelFire
        {
            get { return _nivelFire; }
            set
            {
                if (_nivelFire != value)
                {
                    OnComplexPropertyChanging();
                    _nivelFire = value;
                    OnPropertyChanged("nivelFire");
                }
            }
        }
        private string _nivelFire;
    
        [DataMember]
        public string nivelLiability
        {
            get { return _nivelLiability; }
            set
            {
                if (_nivelLiability != value)
                {
                    OnComplexPropertyChanging();
                    _nivelLiability = value;
                    OnPropertyChanged("nivelLiability");
                }
            }
        }
        private string _nivelLiability;
    
        [DataMember]
        public string nivelProduct
        {
            get { return _nivelProduct; }
            set
            {
                if (_nivelProduct != value)
                {
                    OnComplexPropertyChanging();
                    _nivelProduct = value;
                    OnPropertyChanged("nivelProduct");
                }
            }
        }
        private string _nivelProduct;
    
        [DataMember]
        public string Machinery
        {
            get { return _machinery; }
            set
            {
                if (_machinery != value)
                {
                    OnComplexPropertyChanging();
                    _machinery = value;
                    OnPropertyChanged("Machinery");
                }
            }
        }
        private string _machinery;
    
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
        public Nullable<double> TipoCambio
        {
            get { return _tipoCambio; }
            set
            {
                if (_tipoCambio != value)
                {
                    OnComplexPropertyChanging();
                    _tipoCambio = value;
                    OnPropertyChanged("TipoCambio");
                }
            }
        }
        private Nullable<double> _tipoCambio;
    
        [DataMember]
        public string Narrative
        {
            get { return _narrative; }
            set
            {
                if (_narrative != value)
                {
                    OnComplexPropertyChanging();
                    _narrative = value;
                    OnPropertyChanged("Narrative");
                }
            }
        }
        private string _narrative;

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
    
        public static void RecordComplexOriginalValues(String parentPropertyName, SelectRiskReportGeneralInformation_Result complexObject, ObjectChangeTracker changeTracker)
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
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.tipoPersona", parentPropertyName), complexObject == null ? null : (object)complexObject.tipoPersona);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.FormaPago", parentPropertyName), complexObject == null ? null : (object)complexObject.FormaPago);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.rfc", parentPropertyName), complexObject == null ? null : (object)complexObject.rfc);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.RazonSocial", parentPropertyName), complexObject == null ? null : (object)complexObject.RazonSocial);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.Nombres", parentPropertyName), complexObject == null ? null : (object)complexObject.Nombres);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.Apellido1", parentPropertyName), complexObject == null ? null : (object)complexObject.Apellido1);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.Apellido2", parentPropertyName), complexObject == null ? null : (object)complexObject.Apellido2);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.webPage", parentPropertyName), complexObject == null ? null : (object)complexObject.webPage);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.sucursal", parentPropertyName), complexObject == null ? null : (object)complexObject.sucursal);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.agente", parentPropertyName), complexObject == null ? null : (object)complexObject.agente);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.contacto", parentPropertyName), complexObject == null ? null : (object)complexObject.contacto);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.comision", parentPropertyName), complexObject == null ? null : (object)complexObject.comision);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.nombreUsuario", parentPropertyName), complexObject == null ? null : (object)complexObject.nombreUsuario);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.SIC", parentPropertyName), complexObject == null ? null : (object)complexObject.SIC);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.isNew", parentPropertyName), complexObject == null ? null : (object)complexObject.isNew);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.nroPolizaAnt", parentPropertyName), complexObject == null ? null : (object)complexObject.nroPolizaAnt);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.tipoOperacion", parentPropertyName), complexObject == null ? null : (object)complexObject.tipoOperacion);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.Participacion", parentPropertyName), complexObject == null ? null : (object)complexObject.Participacion);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.VigenciaInicio", parentPropertyName), complexObject == null ? null : (object)complexObject.VigenciaInicio);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.VigenciaFin", parentPropertyName), complexObject == null ? null : (object)complexObject.VigenciaFin);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.dias", parentPropertyName), complexObject == null ? null : (object)complexObject.dias);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.giro", parentPropertyName), complexObject == null ? null : (object)complexObject.giro);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.nivelFire", parentPropertyName), complexObject == null ? null : (object)complexObject.nivelFire);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.nivelLiability", parentPropertyName), complexObject == null ? null : (object)complexObject.nivelLiability);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.nivelProduct", parentPropertyName), complexObject == null ? null : (object)complexObject.nivelProduct);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.Machinery", parentPropertyName), complexObject == null ? null : (object)complexObject.Machinery);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.moneda", parentPropertyName), complexObject == null ? null : (object)complexObject.moneda);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.TipoCambio", parentPropertyName), complexObject == null ? null : (object)complexObject.TipoCambio);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.Narrative", parentPropertyName), complexObject == null ? null : (object)complexObject.Narrative);
        }

        #endregion

    }
}
