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
    public partial class IncAS: IObjectWithChangeTracker, INotifyPropertyChanged
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
        public string Reinsurance
        {
            get { return _reinsurance; }
            set
            {
                if (_reinsurance != value)
                {
                    _reinsurance = value;
                    OnPropertyChanged("Reinsurance");
                }
            }
        }
        private string _reinsurance;
    
        [DataMember]
        public string Carrier
        {
            get { return _carrier; }
            set
            {
                if (_carrier != value)
                {
                    _carrier = value;
                    OnPropertyChanged("Carrier");
                }
            }
        }
        private string _carrier;
    
        [DataMember]
        public Nullable<double> CostNetGross
        {
            get { return _costNetGross; }
            set
            {
                if (_costNetGross != value)
                {
                    _costNetGross = value;
                    OnPropertyChanged("CostNetGross");
                }
            }
        }
        private Nullable<double> _costNetGross;
    
        [DataMember]
        public string Terms
        {
            get { return _terms; }
            set
            {
                if (_terms != value)
                {
                    _terms = value;
                    OnPropertyChanged("Terms");
                }
            }
        }
        private string _terms;
    
        [DataMember]
        public string Explanation
        {
            get { return _explanation; }
            set
            {
                if (_explanation != value)
                {
                    _explanation = value;
                    OnPropertyChanged("Explanation");
                }
            }
        }
        private string _explanation;
    
        [DataMember]
        public string LossControlReport
        {
            get { return _lossControlReport; }
            set
            {
                if (_lossControlReport != value)
                {
                    _lossControlReport = value;
                    OnPropertyChanged("LossControlReport");
                }
            }
        }
        private string _lossControlReport;
    
        [DataMember]
        public string LossControlService
        {
            get { return _lossControlService; }
            set
            {
                if (_lossControlService != value)
                {
                    _lossControlService = value;
                    OnPropertyChanged("LossControlService");
                }
            }
        }
        private string _lossControlService;
    
        [DataMember]
        public string Recommendations
        {
            get { return _recommendations; }
            set
            {
                if (_recommendations != value)
                {
                    _recommendations = value;
                    OnPropertyChanged("Recommendations");
                }
            }
        }
        private string _recommendations;

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
    
            if (previousValue != null && ReferenceEquals(previousValue.bk_te_IncAS, this))
            {
                previousValue.bk_te_IncAS = null;
            }
    
            if (bk_te_Cotizacion != null)
            {
                bk_te_Cotizacion.bk_te_IncAS = this;
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
