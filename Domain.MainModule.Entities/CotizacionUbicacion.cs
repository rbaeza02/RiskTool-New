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
    [KnownType(typeof(Exposicion))]
    [KnownType(typeof(GradoExposicion))]
    [KnownType(typeof(GrupoIncendio))]
    [KnownType(typeof(ProteccionPublica))]
    [KnownType(typeof(ProteccionPrivada))]
    [KnownType(typeof(Ubicacion))]
    [KnownType(typeof(Cotizacion))]
    [System.CodeDom.Compiler.GeneratedCode("STE-EF",".NET 4.0")]
    #if !SILVERLIGHT
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage()]
    #endif
    public partial class CotizacionUbicacion: IObjectWithChangeTracker, INotifyPropertyChanged
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
        public int UbicacionID
        {
            get { return _ubicacionID; }
            set
            {
                if (_ubicacionID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'UbicacionID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    if (!IsDeserializing)
                    {
                        if (bk_tc_Ubicacion != null && bk_tc_Ubicacion.UbicacionID != value)
                        {
                            bk_tc_Ubicacion = null;
                        }
                    }
                    _ubicacionID = value;
                    OnPropertyChanged("UbicacionID");
                }
            }
        }
        private int _ubicacionID;
    
        [DataMember]
        public Nullable<int> GrupoIncendioID
        {
            get { return _grupoIncendioID; }
            set
            {
                if (_grupoIncendioID != value)
                {
                    ChangeTracker.RecordOriginalValue("GrupoIncendioID", _grupoIncendioID);
                    if (!IsDeserializing)
                    {
                        if (bk_tc_GrupoIncendio != null && bk_tc_GrupoIncendio.GrupoIncendioID != value)
                        {
                            bk_tc_GrupoIncendio = null;
                        }
                    }
                    _grupoIncendioID = value;
                    OnPropertyChanged("GrupoIncendioID");
                }
            }
        }
        private Nullable<int> _grupoIncendioID;
    
        [DataMember]
        public Nullable<int> GradoExposicionID
        {
            get { return _gradoExposicionID; }
            set
            {
                if (_gradoExposicionID != value)
                {
                    ChangeTracker.RecordOriginalValue("GradoExposicionID", _gradoExposicionID);
                    if (!IsDeserializing)
                    {
                        if (bk_tc_GradoExposicion != null && bk_tc_GradoExposicion.GradoExposicionID != value)
                        {
                            bk_tc_GradoExposicion = null;
                        }
                    }
                    _gradoExposicionID = value;
                    OnPropertyChanged("GradoExposicionID");
                }
            }
        }
        private Nullable<int> _gradoExposicionID;
    
        [DataMember]
        public Nullable<int> ProteccionPublicaID
        {
            get { return _proteccionPublicaID; }
            set
            {
                if (_proteccionPublicaID != value)
                {
                    ChangeTracker.RecordOriginalValue("ProteccionPublicaID", _proteccionPublicaID);
                    if (!IsDeserializing)
                    {
                        if (bk_tc_ProteccionPublica != null && bk_tc_ProteccionPublica.ProteccionPublicaID != value)
                        {
                            bk_tc_ProteccionPublica = null;
                        }
                    }
                    _proteccionPublicaID = value;
                    OnPropertyChanged("ProteccionPublicaID");
                }
            }
        }
        private Nullable<int> _proteccionPublicaID;
    
        [DataMember]
        public Nullable<int> ProteccionPrivadaID
        {
            get { return _proteccionPrivadaID; }
            set
            {
                if (_proteccionPrivadaID != value)
                {
                    ChangeTracker.RecordOriginalValue("ProteccionPrivadaID", _proteccionPrivadaID);
                    if (!IsDeserializing)
                    {
                        if (bk_tc_ProteccionPrivada != null && bk_tc_ProteccionPrivada.ProteccionPrivadaID != value)
                        {
                            bk_tc_ProteccionPrivada = null;
                        }
                    }
                    _proteccionPrivadaID = value;
                    OnPropertyChanged("ProteccionPrivadaID");
                }
            }
        }
        private Nullable<int> _proteccionPrivadaID;
    
        [DataMember]
        public Nullable<int> ExposicionIDInterna
        {
            get { return _exposicionIDInterna; }
            set
            {
                if (_exposicionIDInterna != value)
                {
                    ChangeTracker.RecordOriginalValue("ExposicionIDInterna", _exposicionIDInterna);
                    if (!IsDeserializing)
                    {
                        if (bk_tc_Exposicion != null && bk_tc_Exposicion.ExposicionID != value)
                        {
                            bk_tc_Exposicion = null;
                        }
                    }
                    _exposicionIDInterna = value;
                    OnPropertyChanged("ExposicionIDInterna");
                }
            }
        }
        private Nullable<int> _exposicionIDInterna;
    
        [DataMember]
        public Nullable<int> ExposicionIDExterna
        {
            get { return _exposicionIDExterna; }
            set
            {
                if (_exposicionIDExterna != value)
                {
                    ChangeTracker.RecordOriginalValue("ExposicionIDExterna", _exposicionIDExterna);
                    if (!IsDeserializing)
                    {
                        if (bk_tc_Exposicion1 != null && bk_tc_Exposicion1.ExposicionID != value)
                        {
                            bk_tc_Exposicion1 = null;
                        }
                    }
                    _exposicionIDExterna = value;
                    OnPropertyChanged("ExposicionIDExterna");
                }
            }
        }
        private Nullable<int> _exposicionIDExterna;
    
        [DataMember]
        public Nullable<int> ExposicionIDAgua
        {
            get { return _exposicionIDAgua; }
            set
            {
                if (_exposicionIDAgua != value)
                {
                    ChangeTracker.RecordOriginalValue("ExposicionIDAgua", _exposicionIDAgua);
                    if (!IsDeserializing)
                    {
                        if (bk_tc_Exposicion2 != null && bk_tc_Exposicion2.ExposicionID != value)
                        {
                            bk_tc_Exposicion2 = null;
                        }
                    }
                    _exposicionIDAgua = value;
                    OnPropertyChanged("ExposicionIDAgua");
                }
            }
        }
        private Nullable<int> _exposicionIDAgua;
    
        [DataMember]
        public Nullable<int> ExposicionIDHumo
        {
            get { return _exposicionIDHumo; }
            set
            {
                if (_exposicionIDHumo != value)
                {
                    ChangeTracker.RecordOriginalValue("ExposicionIDHumo", _exposicionIDHumo);
                    if (!IsDeserializing)
                    {
                        if (bk_tc_Exposicion3 != null && bk_tc_Exposicion3.ExposicionID != value)
                        {
                            bk_tc_Exposicion3 = null;
                        }
                    }
                    _exposicionIDHumo = value;
                    OnPropertyChanged("ExposicionIDHumo");
                }
            }
        }
        private Nullable<int> _exposicionIDHumo;
    
        [DataMember]
        public Nullable<double> ComisionIncendio
        {
            get { return _comisionIncendio; }
            set
            {
                if (_comisionIncendio != value)
                {
                    _comisionIncendio = value;
                    OnPropertyChanged("ComisionIncendio");
                }
            }
        }
        private Nullable<double> _comisionIncendio;
    
        [DataMember]
        public Nullable<double> DeducibleUSD
        {
            get { return _deducibleUSD; }
            set
            {
                if (_deducibleUSD != value)
                {
                    _deducibleUSD = value;
                    OnPropertyChanged("DeducibleUSD");
                }
            }
        }
        private Nullable<double> _deducibleUSD;
    
        [DataMember]
        public Nullable<double> CoaseguroTerremoto
        {
            get { return _coaseguroTerremoto; }
            set
            {
                if (_coaseguroTerremoto != value)
                {
                    _coaseguroTerremoto = value;
                    OnPropertyChanged("CoaseguroTerremoto");
                }
            }
        }
        private Nullable<double> _coaseguroTerremoto;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public Exposicion bk_tc_Exposicion
        {
            get { return _bk_tc_Exposicion; }
            set
            {
                if (!ReferenceEquals(_bk_tc_Exposicion, value))
                {
                    var previousValue = _bk_tc_Exposicion;
                    _bk_tc_Exposicion = value;
                    Fixupbk_tc_Exposicion(previousValue);
                    OnNavigationPropertyChanged("bk_tc_Exposicion");
                }
            }
        }
        private Exposicion _bk_tc_Exposicion;
    
        [DataMember]
        public Exposicion bk_tc_Exposicion1
        {
            get { return _bk_tc_Exposicion1; }
            set
            {
                if (!ReferenceEquals(_bk_tc_Exposicion1, value))
                {
                    var previousValue = _bk_tc_Exposicion1;
                    _bk_tc_Exposicion1 = value;
                    Fixupbk_tc_Exposicion1(previousValue);
                    OnNavigationPropertyChanged("bk_tc_Exposicion1");
                }
            }
        }
        private Exposicion _bk_tc_Exposicion1;
    
        [DataMember]
        public Exposicion bk_tc_Exposicion2
        {
            get { return _bk_tc_Exposicion2; }
            set
            {
                if (!ReferenceEquals(_bk_tc_Exposicion2, value))
                {
                    var previousValue = _bk_tc_Exposicion2;
                    _bk_tc_Exposicion2 = value;
                    Fixupbk_tc_Exposicion2(previousValue);
                    OnNavigationPropertyChanged("bk_tc_Exposicion2");
                }
            }
        }
        private Exposicion _bk_tc_Exposicion2;
    
        [DataMember]
        public Exposicion bk_tc_Exposicion3
        {
            get { return _bk_tc_Exposicion3; }
            set
            {
                if (!ReferenceEquals(_bk_tc_Exposicion3, value))
                {
                    var previousValue = _bk_tc_Exposicion3;
                    _bk_tc_Exposicion3 = value;
                    Fixupbk_tc_Exposicion3(previousValue);
                    OnNavigationPropertyChanged("bk_tc_Exposicion3");
                }
            }
        }
        private Exposicion _bk_tc_Exposicion3;
    
        [DataMember]
        public GradoExposicion bk_tc_GradoExposicion
        {
            get { return _bk_tc_GradoExposicion; }
            set
            {
                if (!ReferenceEquals(_bk_tc_GradoExposicion, value))
                {
                    var previousValue = _bk_tc_GradoExposicion;
                    _bk_tc_GradoExposicion = value;
                    Fixupbk_tc_GradoExposicion(previousValue);
                    OnNavigationPropertyChanged("bk_tc_GradoExposicion");
                }
            }
        }
        private GradoExposicion _bk_tc_GradoExposicion;
    
        [DataMember]
        public GrupoIncendio bk_tc_GrupoIncendio
        {
            get { return _bk_tc_GrupoIncendio; }
            set
            {
                if (!ReferenceEquals(_bk_tc_GrupoIncendio, value))
                {
                    var previousValue = _bk_tc_GrupoIncendio;
                    _bk_tc_GrupoIncendio = value;
                    Fixupbk_tc_GrupoIncendio(previousValue);
                    OnNavigationPropertyChanged("bk_tc_GrupoIncendio");
                }
            }
        }
        private GrupoIncendio _bk_tc_GrupoIncendio;
    
        [DataMember]
        public ProteccionPublica bk_tc_ProteccionPublica
        {
            get { return _bk_tc_ProteccionPublica; }
            set
            {
                if (!ReferenceEquals(_bk_tc_ProteccionPublica, value))
                {
                    var previousValue = _bk_tc_ProteccionPublica;
                    _bk_tc_ProteccionPublica = value;
                    Fixupbk_tc_ProteccionPublica(previousValue);
                    OnNavigationPropertyChanged("bk_tc_ProteccionPublica");
                }
            }
        }
        private ProteccionPublica _bk_tc_ProteccionPublica;
    
        [DataMember]
        public ProteccionPrivada bk_tc_ProteccionPrivada
        {
            get { return _bk_tc_ProteccionPrivada; }
            set
            {
                if (!ReferenceEquals(_bk_tc_ProteccionPrivada, value))
                {
                    var previousValue = _bk_tc_ProteccionPrivada;
                    _bk_tc_ProteccionPrivada = value;
                    Fixupbk_tc_ProteccionPrivada(previousValue);
                    OnNavigationPropertyChanged("bk_tc_ProteccionPrivada");
                }
            }
        }
        private ProteccionPrivada _bk_tc_ProteccionPrivada;
    
        [DataMember]
        public Ubicacion bk_tc_Ubicacion
        {
            get { return _bk_tc_Ubicacion; }
            set
            {
                if (!ReferenceEquals(_bk_tc_Ubicacion, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added && value != null)
                    {
                        // This the dependent end of an identifying relationship, so the principal end cannot be changed if it is already set,
                        // otherwise it can only be set to an entity with a primary key that is the same value as the dependent's foreign key.
                        if (UbicacionID != value.UbicacionID)
                        {
                            throw new InvalidOperationException("The principal end of an identifying relationship can only be changed when the dependent end is in the Added state.");
                        }
                    }
                    var previousValue = _bk_tc_Ubicacion;
                    _bk_tc_Ubicacion = value;
                    Fixupbk_tc_Ubicacion(previousValue);
                    OnNavigationPropertyChanged("bk_tc_Ubicacion");
                }
            }
        }
        private Ubicacion _bk_tc_Ubicacion;
    
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
            bk_tc_Exposicion = null;
            bk_tc_Exposicion1 = null;
            bk_tc_Exposicion2 = null;
            bk_tc_Exposicion3 = null;
            bk_tc_GradoExposicion = null;
            bk_tc_GrupoIncendio = null;
            bk_tc_ProteccionPublica = null;
            bk_tc_ProteccionPrivada = null;
            bk_tc_Ubicacion = null;
            bk_te_Cotizacion = null;
        }

        #endregion

        #region Association Fixup
    
        private void Fixupbk_tc_Exposicion(Exposicion previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.bk_te_CotizacionUbicacion.Contains(this))
            {
                previousValue.bk_te_CotizacionUbicacion.Remove(this);
            }
    
            if (bk_tc_Exposicion != null)
            {
                if (!bk_tc_Exposicion.bk_te_CotizacionUbicacion.Contains(this))
                {
                    bk_tc_Exposicion.bk_te_CotizacionUbicacion.Add(this);
                }
    
                ExposicionIDInterna = bk_tc_Exposicion.ExposicionID;
            }
            else if (!skipKeys)
            {
                ExposicionIDInterna = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("bk_tc_Exposicion")
                    && (ChangeTracker.OriginalValues["bk_tc_Exposicion"] == bk_tc_Exposicion))
                {
                    ChangeTracker.OriginalValues.Remove("bk_tc_Exposicion");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("bk_tc_Exposicion", previousValue);
                }
                if (bk_tc_Exposicion != null && !bk_tc_Exposicion.ChangeTracker.ChangeTrackingEnabled)
                {
                    bk_tc_Exposicion.StartTracking();
                }
            }
        }
    
        private void Fixupbk_tc_Exposicion1(Exposicion previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.bk_te_CotizacionUbicacion1.Contains(this))
            {
                previousValue.bk_te_CotizacionUbicacion1.Remove(this);
            }
    
            if (bk_tc_Exposicion1 != null)
            {
                if (!bk_tc_Exposicion1.bk_te_CotizacionUbicacion1.Contains(this))
                {
                    bk_tc_Exposicion1.bk_te_CotizacionUbicacion1.Add(this);
                }
    
                ExposicionIDExterna = bk_tc_Exposicion1.ExposicionID;
            }
            else if (!skipKeys)
            {
                ExposicionIDExterna = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("bk_tc_Exposicion1")
                    && (ChangeTracker.OriginalValues["bk_tc_Exposicion1"] == bk_tc_Exposicion1))
                {
                    ChangeTracker.OriginalValues.Remove("bk_tc_Exposicion1");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("bk_tc_Exposicion1", previousValue);
                }
                if (bk_tc_Exposicion1 != null && !bk_tc_Exposicion1.ChangeTracker.ChangeTrackingEnabled)
                {
                    bk_tc_Exposicion1.StartTracking();
                }
            }
        }
    
        private void Fixupbk_tc_Exposicion2(Exposicion previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.bk_te_CotizacionUbicacion2.Contains(this))
            {
                previousValue.bk_te_CotizacionUbicacion2.Remove(this);
            }
    
            if (bk_tc_Exposicion2 != null)
            {
                if (!bk_tc_Exposicion2.bk_te_CotizacionUbicacion2.Contains(this))
                {
                    bk_tc_Exposicion2.bk_te_CotizacionUbicacion2.Add(this);
                }
    
                ExposicionIDAgua = bk_tc_Exposicion2.ExposicionID;
            }
            else if (!skipKeys)
            {
                ExposicionIDAgua = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("bk_tc_Exposicion2")
                    && (ChangeTracker.OriginalValues["bk_tc_Exposicion2"] == bk_tc_Exposicion2))
                {
                    ChangeTracker.OriginalValues.Remove("bk_tc_Exposicion2");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("bk_tc_Exposicion2", previousValue);
                }
                if (bk_tc_Exposicion2 != null && !bk_tc_Exposicion2.ChangeTracker.ChangeTrackingEnabled)
                {
                    bk_tc_Exposicion2.StartTracking();
                }
            }
        }
    
        private void Fixupbk_tc_Exposicion3(Exposicion previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.bk_te_CotizacionUbicacion3.Contains(this))
            {
                previousValue.bk_te_CotizacionUbicacion3.Remove(this);
            }
    
            if (bk_tc_Exposicion3 != null)
            {
                if (!bk_tc_Exposicion3.bk_te_CotizacionUbicacion3.Contains(this))
                {
                    bk_tc_Exposicion3.bk_te_CotizacionUbicacion3.Add(this);
                }
    
                ExposicionIDHumo = bk_tc_Exposicion3.ExposicionID;
            }
            else if (!skipKeys)
            {
                ExposicionIDHumo = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("bk_tc_Exposicion3")
                    && (ChangeTracker.OriginalValues["bk_tc_Exposicion3"] == bk_tc_Exposicion3))
                {
                    ChangeTracker.OriginalValues.Remove("bk_tc_Exposicion3");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("bk_tc_Exposicion3", previousValue);
                }
                if (bk_tc_Exposicion3 != null && !bk_tc_Exposicion3.ChangeTracker.ChangeTrackingEnabled)
                {
                    bk_tc_Exposicion3.StartTracking();
                }
            }
        }
    
        private void Fixupbk_tc_GradoExposicion(GradoExposicion previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.bk_te_CotizacionUbicacion.Contains(this))
            {
                previousValue.bk_te_CotizacionUbicacion.Remove(this);
            }
    
            if (bk_tc_GradoExposicion != null)
            {
                if (!bk_tc_GradoExposicion.bk_te_CotizacionUbicacion.Contains(this))
                {
                    bk_tc_GradoExposicion.bk_te_CotizacionUbicacion.Add(this);
                }
    
                GradoExposicionID = bk_tc_GradoExposicion.GradoExposicionID;
            }
            else if (!skipKeys)
            {
                GradoExposicionID = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("bk_tc_GradoExposicion")
                    && (ChangeTracker.OriginalValues["bk_tc_GradoExposicion"] == bk_tc_GradoExposicion))
                {
                    ChangeTracker.OriginalValues.Remove("bk_tc_GradoExposicion");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("bk_tc_GradoExposicion", previousValue);
                }
                if (bk_tc_GradoExposicion != null && !bk_tc_GradoExposicion.ChangeTracker.ChangeTrackingEnabled)
                {
                    bk_tc_GradoExposicion.StartTracking();
                }
            }
        }
    
        private void Fixupbk_tc_GrupoIncendio(GrupoIncendio previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.bk_te_CotizacionUbicacion.Contains(this))
            {
                previousValue.bk_te_CotizacionUbicacion.Remove(this);
            }
    
            if (bk_tc_GrupoIncendio != null)
            {
                if (!bk_tc_GrupoIncendio.bk_te_CotizacionUbicacion.Contains(this))
                {
                    bk_tc_GrupoIncendio.bk_te_CotizacionUbicacion.Add(this);
                }
    
                GrupoIncendioID = bk_tc_GrupoIncendio.GrupoIncendioID;
            }
            else if (!skipKeys)
            {
                GrupoIncendioID = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("bk_tc_GrupoIncendio")
                    && (ChangeTracker.OriginalValues["bk_tc_GrupoIncendio"] == bk_tc_GrupoIncendio))
                {
                    ChangeTracker.OriginalValues.Remove("bk_tc_GrupoIncendio");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("bk_tc_GrupoIncendio", previousValue);
                }
                if (bk_tc_GrupoIncendio != null && !bk_tc_GrupoIncendio.ChangeTracker.ChangeTrackingEnabled)
                {
                    bk_tc_GrupoIncendio.StartTracking();
                }
            }
        }
    
        private void Fixupbk_tc_ProteccionPublica(ProteccionPublica previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.bk_te_CotizacionUbicacion.Contains(this))
            {
                previousValue.bk_te_CotizacionUbicacion.Remove(this);
            }
    
            if (bk_tc_ProteccionPublica != null)
            {
                if (!bk_tc_ProteccionPublica.bk_te_CotizacionUbicacion.Contains(this))
                {
                    bk_tc_ProteccionPublica.bk_te_CotizacionUbicacion.Add(this);
                }
    
                ProteccionPublicaID = bk_tc_ProteccionPublica.ProteccionPublicaID;
            }
            else if (!skipKeys)
            {
                ProteccionPublicaID = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("bk_tc_ProteccionPublica")
                    && (ChangeTracker.OriginalValues["bk_tc_ProteccionPublica"] == bk_tc_ProteccionPublica))
                {
                    ChangeTracker.OriginalValues.Remove("bk_tc_ProteccionPublica");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("bk_tc_ProteccionPublica", previousValue);
                }
                if (bk_tc_ProteccionPublica != null && !bk_tc_ProteccionPublica.ChangeTracker.ChangeTrackingEnabled)
                {
                    bk_tc_ProteccionPublica.StartTracking();
                }
            }
        }
    
        private void Fixupbk_tc_ProteccionPrivada(ProteccionPrivada previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.bk_te_CotizacionUbicacion.Contains(this))
            {
                previousValue.bk_te_CotizacionUbicacion.Remove(this);
            }
    
            if (bk_tc_ProteccionPrivada != null)
            {
                if (!bk_tc_ProteccionPrivada.bk_te_CotizacionUbicacion.Contains(this))
                {
                    bk_tc_ProteccionPrivada.bk_te_CotizacionUbicacion.Add(this);
                }
    
                ProteccionPrivadaID = bk_tc_ProteccionPrivada.ProteccionPrivadaID;
            }
            else if (!skipKeys)
            {
                ProteccionPrivadaID = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("bk_tc_ProteccionPrivada")
                    && (ChangeTracker.OriginalValues["bk_tc_ProteccionPrivada"] == bk_tc_ProteccionPrivada))
                {
                    ChangeTracker.OriginalValues.Remove("bk_tc_ProteccionPrivada");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("bk_tc_ProteccionPrivada", previousValue);
                }
                if (bk_tc_ProteccionPrivada != null && !bk_tc_ProteccionPrivada.ChangeTracker.ChangeTrackingEnabled)
                {
                    bk_tc_ProteccionPrivada.StartTracking();
                }
            }
        }
    
        private void Fixupbk_tc_Ubicacion(Ubicacion previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.bk_te_CotizacionUbicacion.Contains(this))
            {
                previousValue.bk_te_CotizacionUbicacion.Remove(this);
            }
    
            if (bk_tc_Ubicacion != null)
            {
                if (!bk_tc_Ubicacion.bk_te_CotizacionUbicacion.Contains(this))
                {
                    bk_tc_Ubicacion.bk_te_CotizacionUbicacion.Add(this);
                }
    
                UbicacionID = bk_tc_Ubicacion.UbicacionID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("bk_tc_Ubicacion")
                    && (ChangeTracker.OriginalValues["bk_tc_Ubicacion"] == bk_tc_Ubicacion))
                {
                    ChangeTracker.OriginalValues.Remove("bk_tc_Ubicacion");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("bk_tc_Ubicacion", previousValue);
                }
                if (bk_tc_Ubicacion != null && !bk_tc_Ubicacion.ChangeTracker.ChangeTrackingEnabled)
                {
                    bk_tc_Ubicacion.StartTracking();
                }
            }
        }
    
        private void Fixupbk_te_Cotizacion(Cotizacion previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.bk_te_CotizacionUbicacion.Contains(this))
            {
                previousValue.bk_te_CotizacionUbicacion.Remove(this);
            }
    
            if (bk_te_Cotizacion != null)
            {
                if (!bk_te_Cotizacion.bk_te_CotizacionUbicacion.Contains(this))
                {
                    bk_te_Cotizacion.bk_te_CotizacionUbicacion.Add(this);
                }
    
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
