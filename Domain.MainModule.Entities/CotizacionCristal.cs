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
    public partial class CotizacionCristal: IObjectWithChangeTracker, INotifyPropertyChanged
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
        public Nullable<double> Limite_100
        {
            get { return _limite_100; }
            set
            {
                if (_limite_100 != value)
                {
                    _limite_100 = value;
                    OnPropertyChanged("Limite_100");
                }
            }
        }
        private Nullable<double> _limite_100;
    
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
        public int nroUbicaciones
        {
            get { return _nroUbicaciones; }
            set
            {
                if (_nroUbicaciones != value)
                {
                    _nroUbicaciones = value;
                    OnPropertyChanged("nroUbicaciones");
                }
            }
        }
        private int _nroUbicaciones;
    
        [DataMember]
        public int CristalesExpID
        {
            get { return _cristalesExpID; }
            set
            {
                if (_cristalesExpID != value)
                {
                    _cristalesExpID = value;
                    OnPropertyChanged("CristalesExpID");
                }
            }
        }
        private int _cristalesExpID;
    
        [DataMember]
        public int nroPisos
        {
            get { return _nroPisos; }
            set
            {
                if (_nroPisos != value)
                {
                    _nroPisos = value;
                    OnPropertyChanged("nroPisos");
                }
            }
        }
        private int _nroPisos;
    
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
    
            if (previousValue != null && ReferenceEquals(previousValue.bk_te_CotizacionCristal, this))
            {
                previousValue.bk_te_CotizacionCristal = null;
            }
    
            if (bk_te_Cotizacion != null)
            {
                bk_te_Cotizacion.bk_te_CotizacionCristal = this;
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
