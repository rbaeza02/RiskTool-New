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
    public partial class LazCasualty: IObjectWithChangeTracker, INotifyPropertyChanged
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
        public Nullable<bool> isReferral
        {
            get { return _isReferral; }
            set
            {
                if (_isReferral != value)
                {
                    _isReferral = value;
                    OnPropertyChanged("isReferral");
                }
            }
        }
        private Nullable<bool> _isReferral;
    
        [DataMember]
        public Nullable<int> RetroactiveId
        {
            get { return _retroactiveId; }
            set
            {
                if (_retroactiveId != value)
                {
                    _retroactiveId = value;
                    OnPropertyChanged("RetroactiveId");
                }
            }
        }
        private Nullable<int> _retroactiveId;
    
        [DataMember]
        public Nullable<int> TriggerId
        {
            get { return _triggerId; }
            set
            {
                if (_triggerId != value)
                {
                    _triggerId = value;
                    OnPropertyChanged("TriggerId");
                }
            }
        }
        private Nullable<int> _triggerId;
    
        [DataMember]
        public Nullable<int> TypeOcurrencyIdPremises
        {
            get { return _typeOcurrencyIdPremises; }
            set
            {
                if (_typeOcurrencyIdPremises != value)
                {
                    _typeOcurrencyIdPremises = value;
                    OnPropertyChanged("TypeOcurrencyIdPremises");
                }
            }
        }
        private Nullable<int> _typeOcurrencyIdPremises;
    
        [DataMember]
        public Nullable<int> TypeOcurrencyIdProducts
        {
            get { return _typeOcurrencyIdProducts; }
            set
            {
                if (_typeOcurrencyIdProducts != value)
                {
                    _typeOcurrencyIdProducts = value;
                    OnPropertyChanged("TypeOcurrencyIdProducts");
                }
            }
        }
        private Nullable<int> _typeOcurrencyIdProducts;
    
        [DataMember]
        public Nullable<int> TypeOcurrencyIdLiability
        {
            get { return _typeOcurrencyIdLiability; }
            set
            {
                if (_typeOcurrencyIdLiability != value)
                {
                    _typeOcurrencyIdLiability = value;
                    OnPropertyChanged("TypeOcurrencyIdLiability");
                }
            }
        }
        private Nullable<int> _typeOcurrencyIdLiability;
    
        [DataMember]
        public Nullable<int> TypeOcurrencyIdAuto
        {
            get { return _typeOcurrencyIdAuto; }
            set
            {
                if (_typeOcurrencyIdAuto != value)
                {
                    _typeOcurrencyIdAuto = value;
                    OnPropertyChanged("TypeOcurrencyIdAuto");
                }
            }
        }
        private Nullable<int> _typeOcurrencyIdAuto;
    
        [DataMember]
        public Nullable<int> TypeOcurrencyIdConstruction
        {
            get { return _typeOcurrencyIdConstruction; }
            set
            {
                if (_typeOcurrencyIdConstruction != value)
                {
                    _typeOcurrencyIdConstruction = value;
                    OnPropertyChanged("TypeOcurrencyIdConstruction");
                }
            }
        }
        private Nullable<int> _typeOcurrencyIdConstruction;
    
        [DataMember]
        public Nullable<decimal> pctPremises
        {
            get { return _pctPremises; }
            set
            {
                if (_pctPremises != value)
                {
                    _pctPremises = value;
                    OnPropertyChanged("pctPremises");
                }
            }
        }
        private Nullable<decimal> _pctPremises;
    
        [DataMember]
        public Nullable<decimal> pctProducts
        {
            get { return _pctProducts; }
            set
            {
                if (_pctProducts != value)
                {
                    _pctProducts = value;
                    OnPropertyChanged("pctProducts");
                }
            }
        }
        private Nullable<decimal> _pctProducts;
    
        [DataMember]
        public Nullable<decimal> pctLiability
        {
            get { return _pctLiability; }
            set
            {
                if (_pctLiability != value)
                {
                    _pctLiability = value;
                    OnPropertyChanged("pctLiability");
                }
            }
        }
        private Nullable<decimal> _pctLiability;
    
        [DataMember]
        public Nullable<decimal> pctAuto
        {
            get { return _pctAuto; }
            set
            {
                if (_pctAuto != value)
                {
                    _pctAuto = value;
                    OnPropertyChanged("pctAuto");
                }
            }
        }
        private Nullable<decimal> _pctAuto;
    
        [DataMember]
        public Nullable<decimal> pctConstruction
        {
            get { return _pctConstruction; }
            set
            {
                if (_pctConstruction != value)
                {
                    _pctConstruction = value;
                    OnPropertyChanged("pctConstruction");
                }
            }
        }
        private Nullable<decimal> _pctConstruction;
    
        [DataMember]
        public string Comments1
        {
            get { return _comments1; }
            set
            {
                if (_comments1 != value)
                {
                    _comments1 = value;
                    OnPropertyChanged("Comments1");
                }
            }
        }
        private string _comments1;
    
        [DataMember]
        public string Comments2
        {
            get { return _comments2; }
            set
            {
                if (_comments2 != value)
                {
                    _comments2 = value;
                    OnPropertyChanged("Comments2");
                }
            }
        }
        private string _comments2;
    
        [DataMember]
        public string Comments3
        {
            get { return _comments3; }
            set
            {
                if (_comments3 != value)
                {
                    _comments3 = value;
                    OnPropertyChanged("Comments3");
                }
            }
        }
        private string _comments3;
    
        [DataMember]
        public string Authority
        {
            get { return _authority; }
            set
            {
                if (_authority != value)
                {
                    _authority = value;
                    OnPropertyChanged("Authority");
                }
            }
        }
        private string _authority;

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
    
            if (previousValue != null && ReferenceEquals(previousValue.bk_te_LazCasualty, this))
            {
                previousValue.bk_te_LazCasualty = null;
            }
    
            if (bk_te_Cotizacion != null)
            {
                bk_te_Cotizacion.bk_te_LazCasualty = this;
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
