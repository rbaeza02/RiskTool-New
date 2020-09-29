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
    [KnownType(typeof(Cobertura))]
    [KnownType(typeof(Ubicacion))]
    [KnownType(typeof(Cotizacion))]
    [System.CodeDom.Compiler.GeneratedCode("STE-EF",".NET 4.0")]
    #if !SILVERLIGHT
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage()]
    #endif
    public partial class CotizacionCoberturaUbi: IObjectWithChangeTracker, INotifyPropertyChanged
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
        public int CoberturaID
        {
            get { return _coberturaID; }
            set
            {
                if (_coberturaID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'CoberturaID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    if (!IsDeserializing)
                    {
                        if (bk_tc_Cobertura != null && bk_tc_Cobertura.CoberturaID != value)
                        {
                            bk_tc_Cobertura = null;
                        }
                    }
                    _coberturaID = value;
                    OnPropertyChanged("CoberturaID");
                }
            }
        }
        private int _coberturaID;
    
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
        public Nullable<double> ValorAsegurable
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
        private Nullable<double> _valorAsegurable;
    
        [DataMember]
        public Nullable<int> valorAdicional
        {
            get { return _valorAdicional; }
            set
            {
                if (_valorAdicional != value)
                {
                    _valorAdicional = value;
                    OnPropertyChanged("valorAdicional");
                }
            }
        }
        private Nullable<int> _valorAdicional;
    
        [DataMember]
        public Nullable<double> SumaAsegurada
        {
            get { return _sumaAsegurada; }
            set
            {
                if (_sumaAsegurada != value)
                {
                    _sumaAsegurada = value;
                    OnPropertyChanged("SumaAsegurada");
                }
            }
        }
        private Nullable<double> _sumaAsegurada;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public Cobertura bk_tc_Cobertura
        {
            get { return _bk_tc_Cobertura; }
            set
            {
                if (!ReferenceEquals(_bk_tc_Cobertura, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added && value != null)
                    {
                        // This the dependent end of an identifying relationship, so the principal end cannot be changed if it is already set,
                        // otherwise it can only be set to an entity with a primary key that is the same value as the dependent's foreign key.
                        if (CoberturaID != value.CoberturaID)
                        {
                            throw new InvalidOperationException("The principal end of an identifying relationship can only be changed when the dependent end is in the Added state.");
                        }
                    }
                    var previousValue = _bk_tc_Cobertura;
                    _bk_tc_Cobertura = value;
                    Fixupbk_tc_Cobertura(previousValue);
                    OnNavigationPropertyChanged("bk_tc_Cobertura");
                }
            }
        }
        private Cobertura _bk_tc_Cobertura;
    
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
            bk_tc_Cobertura = null;
            bk_tc_Ubicacion = null;
            bk_te_Cotizacion = null;
        }

        #endregion

        #region Association Fixup
    
        private void Fixupbk_tc_Cobertura(Cobertura previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.bk_tr_CotizacionCoberturaUbi.Contains(this))
            {
                previousValue.bk_tr_CotizacionCoberturaUbi.Remove(this);
            }
    
            if (bk_tc_Cobertura != null)
            {
                if (!bk_tc_Cobertura.bk_tr_CotizacionCoberturaUbi.Contains(this))
                {
                    bk_tc_Cobertura.bk_tr_CotizacionCoberturaUbi.Add(this);
                }
    
                CoberturaID = bk_tc_Cobertura.CoberturaID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("bk_tc_Cobertura")
                    && (ChangeTracker.OriginalValues["bk_tc_Cobertura"] == bk_tc_Cobertura))
                {
                    ChangeTracker.OriginalValues.Remove("bk_tc_Cobertura");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("bk_tc_Cobertura", previousValue);
                }
                if (bk_tc_Cobertura != null && !bk_tc_Cobertura.ChangeTracker.ChangeTrackingEnabled)
                {
                    bk_tc_Cobertura.StartTracking();
                }
            }
        }
    
        private void Fixupbk_tc_Ubicacion(Ubicacion previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.bk_tr_CotizacionCoberturaUbi.Contains(this))
            {
                previousValue.bk_tr_CotizacionCoberturaUbi.Remove(this);
            }
    
            if (bk_tc_Ubicacion != null)
            {
                if (!bk_tc_Ubicacion.bk_tr_CotizacionCoberturaUbi.Contains(this))
                {
                    bk_tc_Ubicacion.bk_tr_CotizacionCoberturaUbi.Add(this);
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
    
            if (previousValue != null && previousValue.bk_tr_CotizacionCoberturaUbi.Contains(this))
            {
                previousValue.bk_tr_CotizacionCoberturaUbi.Remove(this);
            }
    
            if (bk_te_Cotizacion != null)
            {
                if (!bk_te_Cotizacion.bk_tr_CotizacionCoberturaUbi.Contains(this))
                {
                    bk_te_Cotizacion.bk_tr_CotizacionCoberturaUbi.Add(this);
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
