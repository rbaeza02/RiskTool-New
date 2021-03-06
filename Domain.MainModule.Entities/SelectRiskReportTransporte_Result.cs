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
    public partial class SelectRiskReportTransporte_Result : INotifyComplexPropertyChanging, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public string asegurado
        {
            get { return _asegurado; }
            set
            {
                if (_asegurado != value)
                {
                    OnComplexPropertyChanging();
                    _asegurado = value;
                    OnPropertyChanged("asegurado");
                }
            }
        }
        private string _asegurado;
    
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
        public string tipoBien
        {
            get { return _tipoBien; }
            set
            {
                if (_tipoBien != value)
                {
                    OnComplexPropertyChanging();
                    _tipoBien = value;
                    OnPropertyChanged("tipoBien");
                }
            }
        }
        private string _tipoBien;
    
        [DataMember]
        public string com
        {
            get { return _com; }
            set
            {
                if (_com != value)
                {
                    OnComplexPropertyChanging();
                    _com = value;
                    OnPropertyChanged("com");
                }
            }
        }
        private string _com;
    
        [DataMember]
        public string Class
        {
            get { return _class; }
            set
            {
                if (_class != value)
                {
                    OnComplexPropertyChanging();
                    _class = value;
                    OnPropertyChanged("Class");
                }
            }
        }
        private string _class;
    
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
        public Nullable<int> code
        {
            get { return _code; }
            set
            {
                if (_code != value)
                {
                    OnComplexPropertyChanging();
                    _code = value;
                    OnPropertyChanged("code");
                }
            }
        }
        private Nullable<int> _code;
    
        [DataMember]
        public string GeographicPattern
        {
            get { return _geographicPattern; }
            set
            {
                if (_geographicPattern != value)
                {
                    OnComplexPropertyChanging();
                    _geographicPattern = value;
                    OnPropertyChanged("GeographicPattern");
                }
            }
        }
        private string _geographicPattern;
    
        [DataMember]
        public Nullable<double> CuotaAnterior
        {
            get { return _cuotaAnterior; }
            set
            {
                if (_cuotaAnterior != value)
                {
                    OnComplexPropertyChanging();
                    _cuotaAnterior = value;
                    OnPropertyChanged("CuotaAnterior");
                }
            }
        }
        private Nullable<double> _cuotaAnterior;
    
        [DataMember]
        public string modalidad
        {
            get { return _modalidad; }
            set
            {
                if (_modalidad != value)
                {
                    OnComplexPropertyChanging();
                    _modalidad = value;
                    OnPropertyChanged("modalidad");
                }
            }
        }
        private string _modalidad;
    
        [DataMember]
        public string cobertura
        {
            get { return _cobertura; }
            set
            {
                if (_cobertura != value)
                {
                    OnComplexPropertyChanging();
                    _cobertura = value;
                    OnPropertyChanged("cobertura");
                }
            }
        }
        private string _cobertura;
    
        [DataMember]
        public string TextoMonto1
        {
            get { return _textoMonto1; }
            set
            {
                if (_textoMonto1 != value)
                {
                    OnComplexPropertyChanging();
                    _textoMonto1 = value;
                    OnPropertyChanged("TextoMonto1");
                }
            }
        }
        private string _textoMonto1;
    
        [DataMember]
        public string TextoMonto2
        {
            get { return _textoMonto2; }
            set
            {
                if (_textoMonto2 != value)
                {
                    OnComplexPropertyChanging();
                    _textoMonto2 = value;
                    OnPropertyChanged("TextoMonto2");
                }
            }
        }
        private string _textoMonto2;
    
        [DataMember]
        public string TextoMonto3
        {
            get { return _textoMonto3; }
            set
            {
                if (_textoMonto3 != value)
                {
                    OnComplexPropertyChanging();
                    _textoMonto3 = value;
                    OnPropertyChanged("TextoMonto3");
                }
            }
        }
        private string _textoMonto3;
    
        [DataMember]
        public Nullable<decimal> DeducRobo
        {
            get { return _deducRobo; }
            set
            {
                if (_deducRobo != value)
                {
                    OnComplexPropertyChanging();
                    _deducRobo = value;
                    OnPropertyChanged("DeducRobo");
                }
            }
        }
        private Nullable<decimal> _deducRobo;
    
        [DataMember]
        public Nullable<decimal> DeducOtros
        {
            get { return _deducOtros; }
            set
            {
                if (_deducOtros != value)
                {
                    OnComplexPropertyChanging();
                    _deducOtros = value;
                    OnPropertyChanged("DeducOtros");
                }
            }
        }
        private Nullable<decimal> _deducOtros;
    
        [DataMember]
        public string DeducEspecial
        {
            get { return _deducEspecial; }
            set
            {
                if (_deducEspecial != value)
                {
                    OnComplexPropertyChanging();
                    _deducEspecial = value;
                    OnPropertyChanged("DeducEspecial");
                }
            }
        }
        private string _deducEspecial;
    
        [DataMember]
        public Nullable<double> EstimadoAnual
        {
            get { return _estimadoAnual; }
            set
            {
                if (_estimadoAnual != value)
                {
                    OnComplexPropertyChanging();
                    _estimadoAnual = value;
                    OnPropertyChanged("EstimadoAnual");
                }
            }
        }
        private Nullable<double> _estimadoAnual;
    
        [DataMember]
        public double limite
        {
            get { return _limite; }
            set
            {
                if (_limite != value)
                {
                    OnComplexPropertyChanging();
                    _limite = value;
                    OnPropertyChanged("limite");
                }
            }
        }
        private double _limite;
    
        [DataMember]
        public string TipoPronostico
        {
            get { return _tipoPronostico; }
            set
            {
                if (_tipoPronostico != value)
                {
                    OnComplexPropertyChanging();
                    _tipoPronostico = value;
                    OnPropertyChanged("TipoPronostico");
                }
            }
        }
        private string _tipoPronostico;
    
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
        public Nullable<double> FPA
        {
            get { return _fPA; }
            set
            {
                if (_fPA != value)
                {
                    OnComplexPropertyChanging();
                    _fPA = value;
                    OnPropertyChanged("FPA");
                }
            }
        }
        private Nullable<double> _fPA;
    
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
        public Nullable<double> Agua
        {
            get { return _agua; }
            set
            {
                if (_agua != value)
                {
                    OnComplexPropertyChanging();
                    _agua = value;
                    OnPropertyChanged("Agua");
                }
            }
        }
        private Nullable<double> _agua;
    
        [DataMember]
        public Nullable<double> Rotura
        {
            get { return _rotura; }
            set
            {
                if (_rotura != value)
                {
                    OnComplexPropertyChanging();
                    _rotura = value;
                    OnPropertyChanged("Rotura");
                }
            }
        }
        private Nullable<double> _rotura;
    
        [DataMember]
        public Nullable<double> deterioro
        {
            get { return _deterioro; }
            set
            {
                if (_deterioro != value)
                {
                    OnComplexPropertyChanging();
                    _deterioro = value;
                    OnPropertyChanged("deterioro");
                }
            }
        }
        private Nullable<double> _deterioro;
    
        [DataMember]
        public Nullable<double> hurto
        {
            get { return _hurto; }
            set
            {
                if (_hurto != value)
                {
                    OnComplexPropertyChanging();
                    _hurto = value;
                    OnPropertyChanged("hurto");
                }
            }
        }
        private Nullable<double> _hurto;
    
        [DataMember]
        public Nullable<double> robo
        {
            get { return _robo; }
            set
            {
                if (_robo != value)
                {
                    OnComplexPropertyChanging();
                    _robo = value;
                    OnPropertyChanged("robo");
                }
            }
        }
        private Nullable<double> _robo;
    
        [DataMember]
        public string GuerraHuelga
        {
            get { return _guerraHuelga; }
            set
            {
                if (_guerraHuelga != value)
                {
                    OnComplexPropertyChanging();
                    _guerraHuelga = value;
                    OnPropertyChanged("GuerraHuelga");
                }
            }
        }
        private string _guerraHuelga;
    
        [DataMember]
        public Nullable<decimal> GuerraHuelgaVal
        {
            get { return _guerraHuelgaVal; }
            set
            {
                if (_guerraHuelgaVal != value)
                {
                    OnComplexPropertyChanging();
                    _guerraHuelgaVal = value;
                    OnPropertyChanged("GuerraHuelgaVal");
                }
            }
        }
        private Nullable<decimal> _guerraHuelgaVal;
    
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
        public Nullable<double> PrimaPolAnterior
        {
            get { return _primaPolAnterior; }
            set
            {
                if (_primaPolAnterior != value)
                {
                    OnComplexPropertyChanging();
                    _primaPolAnterior = value;
                    OnPropertyChanged("PrimaPolAnterior");
                }
            }
        }
        private Nullable<double> _primaPolAnterior;
    
        [DataMember]
        public Nullable<double> SinUltimo
        {
            get { return _sinUltimo; }
            set
            {
                if (_sinUltimo != value)
                {
                    OnComplexPropertyChanging();
                    _sinUltimo = value;
                    OnPropertyChanged("SinUltimo");
                }
            }
        }
        private Nullable<double> _sinUltimo;
    
        [DataMember]
        public Nullable<double> SinPenultimo
        {
            get { return _sinPenultimo; }
            set
            {
                if (_sinPenultimo != value)
                {
                    OnComplexPropertyChanging();
                    _sinPenultimo = value;
                    OnPropertyChanged("SinPenultimo");
                }
            }
        }
        private Nullable<double> _sinPenultimo;
    
        [DataMember]
        public Nullable<double> SinAntepenultimo
        {
            get { return _sinAntepenultimo; }
            set
            {
                if (_sinAntepenultimo != value)
                {
                    OnComplexPropertyChanging();
                    _sinAntepenultimo = value;
                    OnPropertyChanged("SinAntepenultimo");
                }
            }
        }
        private Nullable<double> _sinAntepenultimo;

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
    
        public static void RecordComplexOriginalValues(String parentPropertyName, SelectRiskReportTransporte_Result complexObject, ObjectChangeTracker changeTracker)
        {
            if (String.IsNullOrEmpty(parentPropertyName))
            {
                throw new ArgumentException("String parameter cannot be null or empty.", "parentPropertyName");
            }
    
            if (changeTracker == null)
            {
                throw new ArgumentNullException("changeTracker");
            }
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.asegurado", parentPropertyName), complexObject == null ? null : (object)complexObject.asegurado);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.contacto", parentPropertyName), complexObject == null ? null : (object)complexObject.contacto);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.agente", parentPropertyName), complexObject == null ? null : (object)complexObject.agente);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.sucursal", parentPropertyName), complexObject == null ? null : (object)complexObject.sucursal);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.Fecha", parentPropertyName), complexObject == null ? null : (object)complexObject.Fecha);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.tipoOperacion", parentPropertyName), complexObject == null ? null : (object)complexObject.tipoOperacion);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.Participacion", parentPropertyName), complexObject == null ? null : (object)complexObject.Participacion);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.tipoBien", parentPropertyName), complexObject == null ? null : (object)complexObject.tipoBien);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.com", parentPropertyName), complexObject == null ? null : (object)complexObject.com);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.Class", parentPropertyName), complexObject == null ? null : (object)complexObject.Class);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.SIC", parentPropertyName), complexObject == null ? null : (object)complexObject.SIC);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.code", parentPropertyName), complexObject == null ? null : (object)complexObject.code);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.GeographicPattern", parentPropertyName), complexObject == null ? null : (object)complexObject.GeographicPattern);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.CuotaAnterior", parentPropertyName), complexObject == null ? null : (object)complexObject.CuotaAnterior);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.modalidad", parentPropertyName), complexObject == null ? null : (object)complexObject.modalidad);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.cobertura", parentPropertyName), complexObject == null ? null : (object)complexObject.cobertura);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.TextoMonto1", parentPropertyName), complexObject == null ? null : (object)complexObject.TextoMonto1);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.TextoMonto2", parentPropertyName), complexObject == null ? null : (object)complexObject.TextoMonto2);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.TextoMonto3", parentPropertyName), complexObject == null ? null : (object)complexObject.TextoMonto3);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.DeducRobo", parentPropertyName), complexObject == null ? null : (object)complexObject.DeducRobo);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.DeducOtros", parentPropertyName), complexObject == null ? null : (object)complexObject.DeducOtros);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.DeducEspecial", parentPropertyName), complexObject == null ? null : (object)complexObject.DeducEspecial);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.EstimadoAnual", parentPropertyName), complexObject == null ? null : (object)complexObject.EstimadoAnual);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.limite", parentPropertyName), complexObject == null ? null : (object)complexObject.limite);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.TipoPronostico", parentPropertyName), complexObject == null ? null : (object)complexObject.TipoPronostico);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.moneda", parentPropertyName), complexObject == null ? null : (object)complexObject.moneda);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.FPA", parentPropertyName), complexObject == null ? null : (object)complexObject.FPA);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.isNew", parentPropertyName), complexObject == null ? null : (object)complexObject.isNew);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.Agua", parentPropertyName), complexObject == null ? null : (object)complexObject.Agua);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.Rotura", parentPropertyName), complexObject == null ? null : (object)complexObject.Rotura);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.deterioro", parentPropertyName), complexObject == null ? null : (object)complexObject.deterioro);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.hurto", parentPropertyName), complexObject == null ? null : (object)complexObject.hurto);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.robo", parentPropertyName), complexObject == null ? null : (object)complexObject.robo);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.GuerraHuelga", parentPropertyName), complexObject == null ? null : (object)complexObject.GuerraHuelga);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.GuerraHuelgaVal", parentPropertyName), complexObject == null ? null : (object)complexObject.GuerraHuelgaVal);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.formaPago", parentPropertyName), complexObject == null ? null : (object)complexObject.formaPago);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.PrimaPolAnterior", parentPropertyName), complexObject == null ? null : (object)complexObject.PrimaPolAnterior);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.SinUltimo", parentPropertyName), complexObject == null ? null : (object)complexObject.SinUltimo);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.SinPenultimo", parentPropertyName), complexObject == null ? null : (object)complexObject.SinPenultimo);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.SinAntepenultimo", parentPropertyName), complexObject == null ? null : (object)complexObject.SinAntepenultimo);
        }

        #endregion

    }
}
