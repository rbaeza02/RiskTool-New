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
    [KnownType(typeof(Ubicacion))]
    [KnownType(typeof(Cotizacion))]
    [System.CodeDom.Compiler.GeneratedCode("STE-EF",".NET 4.0")]
    #if !SILVERLIGHT
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage()]
    #endif
    public partial class IncCOPE: IObjectWithChangeTracker, INotifyPropertyChanged
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
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        private string _description;
    
        [DataMember]
        public Nullable<int> FireAreas
        {
            get { return _fireAreas; }
            set
            {
                if (_fireAreas != value)
                {
                    _fireAreas = value;
                    OnPropertyChanged("FireAreas");
                }
            }
        }
        private Nullable<int> _fireAreas;
    
        [DataMember]
        public string PublicProtection
        {
            get { return _publicProtection; }
            set
            {
                if (_publicProtection != value)
                {
                    _publicProtection = value;
                    OnPropertyChanged("PublicProtection");
                }
            }
        }
        private string _publicProtection;
    
        [DataMember]
        public Nullable<bool> isPaidFireDepartment
        {
            get { return _isPaidFireDepartment; }
            set
            {
                if (_isPaidFireDepartment != value)
                {
                    _isPaidFireDepartment = value;
                    OnPropertyChanged("isPaidFireDepartment");
                }
            }
        }
        private Nullable<bool> _isPaidFireDepartment;
    
        [DataMember]
        public Nullable<double> DistanceRisk
        {
            get { return _distanceRisk; }
            set
            {
                if (_distanceRisk != value)
                {
                    _distanceRisk = value;
                    OnPropertyChanged("DistanceRisk");
                }
            }
        }
        private Nullable<double> _distanceRisk;
    
        [DataMember]
        public string PrivateProtection
        {
            get { return _privateProtection; }
            set
            {
                if (_privateProtection != value)
                {
                    _privateProtection = value;
                    OnPropertyChanged("PrivateProtection");
                }
            }
        }
        private string _privateProtection;
    
        [DataMember]
        public Nullable<int> ISOid
        {
            get { return _iSOid; }
            set
            {
                if (_iSOid != value)
                {
                    _iSOid = value;
                    OnPropertyChanged("ISOid");
                }
            }
        }
        private Nullable<int> _iSOid;
    
        [DataMember]
        public Nullable<int> ExposicionIDHurricane
        {
            get { return _exposicionIDHurricane; }
            set
            {
                if (_exposicionIDHurricane != value)
                {
                    ChangeTracker.RecordOriginalValue("ExposicionIDHurricane", _exposicionIDHurricane);
                    if (!IsDeserializing)
                    {
                        if (bk_tc_Exposicion != null && bk_tc_Exposicion.ExposicionID != value)
                        {
                            bk_tc_Exposicion = null;
                        }
                    }
                    _exposicionIDHurricane = value;
                    OnPropertyChanged("ExposicionIDHurricane");
                }
            }
        }
        private Nullable<int> _exposicionIDHurricane;
    
        [DataMember]
        public Nullable<int> ExposicionIDFlood
        {
            get { return _exposicionIDFlood; }
            set
            {
                if (_exposicionIDFlood != value)
                {
                    ChangeTracker.RecordOriginalValue("ExposicionIDFlood", _exposicionIDFlood);
                    if (!IsDeserializing)
                    {
                        if (bk_tc_Exposicion1 != null && bk_tc_Exposicion1.ExposicionID != value)
                        {
                            bk_tc_Exposicion1 = null;
                        }
                    }
                    _exposicionIDFlood = value;
                    OnPropertyChanged("ExposicionIDFlood");
                }
            }
        }
        private Nullable<int> _exposicionIDFlood;
    
        [DataMember]
        public Nullable<int> ExposicionIDElectricStorm
        {
            get { return _exposicionIDElectricStorm; }
            set
            {
                if (_exposicionIDElectricStorm != value)
                {
                    ChangeTracker.RecordOriginalValue("ExposicionIDElectricStorm", _exposicionIDElectricStorm);
                    if (!IsDeserializing)
                    {
                        if (bk_tc_Exposicion2 != null && bk_tc_Exposicion2.ExposicionID != value)
                        {
                            bk_tc_Exposicion2 = null;
                        }
                    }
                    _exposicionIDElectricStorm = value;
                    OnPropertyChanged("ExposicionIDElectricStorm");
                }
            }
        }
        private Nullable<int> _exposicionIDElectricStorm;
    
        [DataMember]
        public Nullable<int> ExposicionIDHail
        {
            get { return _exposicionIDHail; }
            set
            {
                if (_exposicionIDHail != value)
                {
                    ChangeTracker.RecordOriginalValue("ExposicionIDHail", _exposicionIDHail);
                    if (!IsDeserializing)
                    {
                        if (bk_tc_Exposicion3 != null && bk_tc_Exposicion3.ExposicionID != value)
                        {
                            bk_tc_Exposicion3 = null;
                        }
                    }
                    _exposicionIDHail = value;
                    OnPropertyChanged("ExposicionIDHail");
                }
            }
        }
        private Nullable<int> _exposicionIDHail;

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
    
            if (previousValue != null && previousValue.bk_te_IncCOPE.Contains(this))
            {
                previousValue.bk_te_IncCOPE.Remove(this);
            }
    
            if (bk_tc_Exposicion != null)
            {
                if (!bk_tc_Exposicion.bk_te_IncCOPE.Contains(this))
                {
                    bk_tc_Exposicion.bk_te_IncCOPE.Add(this);
                }
    
                ExposicionIDHurricane = bk_tc_Exposicion.ExposicionID;
            }
            else if (!skipKeys)
            {
                ExposicionIDHurricane = null;
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
    
            if (previousValue != null && previousValue.bk_te_IncCOPE1.Contains(this))
            {
                previousValue.bk_te_IncCOPE1.Remove(this);
            }
    
            if (bk_tc_Exposicion1 != null)
            {
                if (!bk_tc_Exposicion1.bk_te_IncCOPE1.Contains(this))
                {
                    bk_tc_Exposicion1.bk_te_IncCOPE1.Add(this);
                }
    
                ExposicionIDFlood = bk_tc_Exposicion1.ExposicionID;
            }
            else if (!skipKeys)
            {
                ExposicionIDFlood = null;
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
    
            if (previousValue != null && previousValue.bk_te_IncCOPE2.Contains(this))
            {
                previousValue.bk_te_IncCOPE2.Remove(this);
            }
    
            if (bk_tc_Exposicion2 != null)
            {
                if (!bk_tc_Exposicion2.bk_te_IncCOPE2.Contains(this))
                {
                    bk_tc_Exposicion2.bk_te_IncCOPE2.Add(this);
                }
    
                ExposicionIDElectricStorm = bk_tc_Exposicion2.ExposicionID;
            }
            else if (!skipKeys)
            {
                ExposicionIDElectricStorm = null;
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
    
            if (previousValue != null && previousValue.bk_te_IncCOPE3.Contains(this))
            {
                previousValue.bk_te_IncCOPE3.Remove(this);
            }
    
            if (bk_tc_Exposicion3 != null)
            {
                if (!bk_tc_Exposicion3.bk_te_IncCOPE3.Contains(this))
                {
                    bk_tc_Exposicion3.bk_te_IncCOPE3.Add(this);
                }
    
                ExposicionIDHail = bk_tc_Exposicion3.ExposicionID;
            }
            else if (!skipKeys)
            {
                ExposicionIDHail = null;
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
    
        private void Fixupbk_tc_Ubicacion(Ubicacion previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.bk_te_IncCOPE.Contains(this))
            {
                previousValue.bk_te_IncCOPE.Remove(this);
            }
    
            if (bk_tc_Ubicacion != null)
            {
                if (!bk_tc_Ubicacion.bk_te_IncCOPE.Contains(this))
                {
                    bk_tc_Ubicacion.bk_te_IncCOPE.Add(this);
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
    
            if (previousValue != null && previousValue.bk_te_IncCOPE.Contains(this))
            {
                previousValue.bk_te_IncCOPE.Remove(this);
            }
    
            if (bk_te_Cotizacion != null)
            {
                if (!bk_te_Cotizacion.bk_te_IncCOPE.Contains(this))
                {
                    bk_te_Cotizacion.bk_te_IncCOPE.Add(this);
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