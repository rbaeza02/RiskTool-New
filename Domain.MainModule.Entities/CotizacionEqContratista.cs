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
    [DataContract(IsReference = true)]
    [KnownType(typeof(Cotizacion))]
    [System.CodeDom.Compiler.GeneratedCode("STE-EF",".NET 4.0")]
    #if !SILVERLIGHT
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage()]
    #endif
    public partial class CotizacionEqContratista: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int CotizacionID
        {
            get { return _cotizacionID; }
            set
            {
                if (_cotizacionID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'CotizacionID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    if (!IsDeserializing)
                    {
                        if (bk_te_Cotizacion != null && bk_te_Cotizacion.CotizacionID != value)
                        {
                            bk_te_Cotizacion = null;
                        }
                    }
                    _cotizacionID = value;
                    OnPropertyChanged("CotizacionID");
                }
            }
        }
        private int _cotizacionID;
    
        [DataMember]
        public decimal Comision
        {
            get { return _comision; }
            set
            {
                if (_comision != value)
                {
                    _comision = value;
                    OnPropertyChanged("Comision");
                }
            }
        }
        private decimal _comision;
    
        [DataMember]
        public double ValorAsegurable
        {
            get { return _valorAsegurable; }
            set
            {
                if (_valorAsegurable != value)
                {
                    _valorAsegurable = value;
                    OnPropertyChanged("ValorAsegurable");
                }
            }
        }
        private double _valorAsegurable;
    
        [DataMember]
        public double ValorAsegurableInflacion
        {
            get { return _valorAsegurableInflacion; }
            set
            {
                if (_valorAsegurableInflacion != value)
                {
                    _valorAsegurableInflacion = value;
                    OnPropertyChanged("ValorAsegurableInflacion");
                }
            }
        }
        private double _valorAsegurableInflacion;
    
        [DataMember]
        public decimal Siniestralidad
        {
            get { return _siniestralidad; }
            set
            {
                if (_siniestralidad != value)
                {
                    _siniestralidad = value;
                    OnPropertyChanged("Siniestralidad");
                }
            }
        }
        private decimal _siniestralidad;
    
        [DataMember]
        public Nullable<int> Edad
        {
            get { return _edad; }
            set
            {
                if (_edad != value)
                {
                    _edad = value;
                    OnPropertyChanged("Edad");
                }
            }
        }
        private Nullable<int> _edad;
    
        [DataMember]
        public int EqContratistaMantID
        {
            get { return _eqContratistaMantID; }
            set
            {
                if (_eqContratistaMantID != value)
                {
                    _eqContratistaMantID = value;
                    OnPropertyChanged("EqContratistaMantID");
                }
            }
        }
        private int _eqContratistaMantID;
    
        [DataMember]
        public int EqContratistaRiesgoID
        {
            get { return _eqContratistaRiesgoID; }
            set
            {
                if (_eqContratistaRiesgoID != value)
                {
                    _eqContratistaRiesgoID = value;
                    OnPropertyChanged("EqContratistaRiesgoID");
                }
            }
        }
        private int _eqContratistaRiesgoID;
    
        [DataMember]
        public int EqContratistaRastreoID
        {
            get { return _eqContratistaRastreoID; }
            set
            {
                if (_eqContratistaRastreoID != value)
                {
                    _eqContratistaRastreoID = value;
                    OnPropertyChanged("EqContratistaRastreoID");
                }
            }
        }
        private int _eqContratistaRastreoID;
    
        [DataMember]
        public int EqContratistaIncID
        {
            get { return _eqContratistaIncID; }
            set
            {
                if (_eqContratistaIncID != value)
                {
                    _eqContratistaIncID = value;
                    OnPropertyChanged("EqContratistaIncID");
                }
            }
        }
        private int _eqContratistaIncID;
    
        [DataMember]
        public int EqContratistaMovID
        {
            get { return _eqContratistaMovID; }
            set
            {
                if (_eqContratistaMovID != value)
                {
                    _eqContratistaMovID = value;
                    OnPropertyChanged("EqContratistaMovID");
                }
            }
        }
        private int _eqContratistaMovID;
    
        [DataMember]
        public Nullable<decimal> pctPrimerRiesgo
        {
            get { return _pctPrimerRiesgo; }
            set
            {
                if (_pctPrimerRiesgo != value)
                {
                    _pctPrimerRiesgo = value;
                    OnPropertyChanged("pctPrimerRiesgo");
                }
            }
        }
        private Nullable<decimal> _pctPrimerRiesgo;
    
        [DataMember]
        public Nullable<double> CuotaBase
        {
            get { return _cuotaBase; }
            set
            {
                if (_cuotaBase != value)
                {
                    _cuotaBase = value;
                    OnPropertyChanged("CuotaBase");
                }
            }
        }
        private Nullable<double> _cuotaBase;
    
        [DataMember]
        public Nullable<double> Cuota
        {
            get { return _cuota; }
            set
            {
                if (_cuota != value)
                {
                    _cuota = value;
                    OnPropertyChanged("Cuota");
                }
            }
        }
        private Nullable<double> _cuota;
    
        [DataMember]
        public Nullable<double> CuotaInflacion
        {
            get { return _cuotaInflacion; }
            set
            {
                if (_cuotaInflacion != value)
                {
                    _cuotaInflacion = value;
                    OnPropertyChanged("CuotaInflacion");
                }
            }
        }
        private Nullable<double> _cuotaInflacion;
    
        [DataMember]
        public Nullable<double> Prima
        {
            get { return _prima; }
            set
            {
                if (_prima != value)
                {
                    _prima = value;
                    OnPropertyChanged("Prima");
                }
            }
        }
        private Nullable<double> _prima;
    
        [DataMember]
        public Nullable<double> Huelga
        {
            get { return _huelga; }
            set
            {
                if (_huelga != value)
                {
                    _huelga = value;
                    OnPropertyChanged("Huelga");
                }
            }
        }
        private Nullable<double> _huelga;
    
        [DataMember]
        public Nullable<double> BienesBajoTierra
        {
            get { return _bienesBajoTierra; }
            set
            {
                if (_bienesBajoTierra != value)
                {
                    _bienesBajoTierra = value;
                    OnPropertyChanged("BienesBajoTierra");
                }
            }
        }
        private Nullable<double> _bienesBajoTierra;
    
        [DataMember]
        public Nullable<double> GastosExtra
        {
            get { return _gastosExtra; }
            set
            {
                if (_gastosExtra != value)
                {
                    _gastosExtra = value;
                    OnPropertyChanged("GastosExtra");
                }
            }
        }
        private Nullable<double> _gastosExtra;
    
        [DataMember]
        public Nullable<double> CausaExterna
        {
            get { return _causaExterna; }
            set
            {
                if (_causaExterna != value)
                {
                    _causaExterna = value;
                    OnPropertyChanged("CausaExterna");
                }
            }
        }
        private Nullable<double> _causaExterna;
    
        [DataMember]
        public Nullable<double> Terrorismo
        {
            get { return _terrorismo; }
            set
            {
                if (_terrorismo != value)
                {
                    _terrorismo = value;
                    OnPropertyChanged("Terrorismo");
                }
            }
        }
        private Nullable<double> _terrorismo;
    
        [DataMember]
        public bool isCMICDeduc
        {
            get { return _isCMICDeduc; }
            set
            {
                if (_isCMICDeduc != value)
                {
                    _isCMICDeduc = value;
                    OnPropertyChanged("isCMICDeduc");
                }
            }
        }
        private bool _isCMICDeduc;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public Cotizacion bk_te_Cotizacion
        {
            get { return _bk_te_Cotizacion; }
            set
            {
                if (!ReferenceEquals(_bk_te_Cotizacion, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added && value != null)
                    {
                        // This the dependent end of an identifying relationship, so the principal end cannot be changed if it is already set,
                        // otherwise it can only be set to an entity with a primary key that is the same value as the dependent's foreign key.
                        if (CotizacionID != value.CotizacionID)
                        {
                            throw new InvalidOperationException("The principal end of an identifying relationship can only be changed when the dependent end is in the Added state.");
                        }
                    }
                    var previousValue = _bk_te_Cotizacion;
                    _bk_te_Cotizacion = value;
                    Fixupbk_te_Cotizacion(previousValue);
                    OnNavigationPropertyChanged("bk_te_Cotizacion");
                }
            }
        }
        private Cotizacion _bk_te_Cotizacion;

        #endregion

        #region ChangeTracking
    
        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        protected virtual void OnNavigationPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged{ add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
        private ObjectChangeTracker _changeTracker;
    
        [DataMember]
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
                return _changeTracker;
            }
            set
            {
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging -= HandleObjectStateChanging;
                }
                _changeTracker = value;
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
            }
        }
    
        private void HandleObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                ClearNavigationProperties();
            }
        }
    
        // This entity type is the dependent end in at least one association that performs cascade deletes.
        // This event handler will process notifications that occur when the principal end is deleted.
        internal void HandleCascadeDelete(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                this.MarkAsDeleted();
            }
        }
    
        protected bool IsDeserializing { get; private set; }
    
        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            IsDeserializing = true;
        }
    
        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            IsDeserializing = false;
            ChangeTracker.ChangeTrackingEnabled = true;
        }
    
        protected virtual void ClearNavigationProperties()
        {
            bk_te_Cotizacion = null;
        }

        #endregion

        #region Association Fixup
    
        private void Fixupbk_te_Cotizacion(Cotizacion previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && ReferenceEquals(previousValue.bk_te_CotizacionEqContratista, this))
            {
                previousValue.bk_te_CotizacionEqContratista = null;
            }
    
            if (bk_te_Cotizacion != null)
            {
                bk_te_Cotizacion.bk_te_CotizacionEqContratista = this;
                CotizacionID = bk_te_Cotizacion.CotizacionID;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("bk_te_Cotizacion")
                    && (ChangeTracker.OriginalValues["bk_te_Cotizacion"] == bk_te_Cotizacion))
                {
                    ChangeTracker.OriginalValues.Remove("bk_te_Cotizacion");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("bk_te_Cotizacion", previousValue);
                }
                if (bk_te_Cotizacion != null && !bk_te_Cotizacion.ChangeTracker.ChangeTrackingEnabled)
                {
                    bk_te_Cotizacion.StartTracking();
                }
            }
        }

        #endregion

    }
}
