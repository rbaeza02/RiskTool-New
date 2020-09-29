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
    [KnownType(typeof(CotizacionDeducible))]
    [KnownType(typeof(SubLineaNegocio))]
    [System.CodeDom.Compiler.GeneratedCode("STE-EF",".NET 4.0")]
    #if !SILVERLIGHT
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage()]
    #endif
    public partial class Tarifa: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int tarifaID
        {
            get { return _tarifaID; }
            set
            {
                if (_tarifaID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'tarifaID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _tarifaID = value;
                    OnPropertyChanged("tarifaID");
                }
            }
        }
        private int _tarifaID;
    
        [DataMember]
        public Nullable<int> SubLineaNegocioID
        {
            get { return _subLineaNegocioID; }
            set
            {
                if (_subLineaNegocioID != value)
                {
                    ChangeTracker.RecordOriginalValue("SubLineaNegocioID", _subLineaNegocioID);
                    if (!IsDeserializing)
                    {
                        if (bk_tc_SubLineaNegocio != null && bk_tc_SubLineaNegocio.SubLineaNegocioID != value)
                        {
                            bk_tc_SubLineaNegocio = null;
                        }
                    }
                    _subLineaNegocioID = value;
                    OnPropertyChanged("SubLineaNegocioID");
                }
            }
        }
        private Nullable<int> _subLineaNegocioID;
    
        [DataMember]
        public string nombre
        {
            get { return _nombre; }
            set
            {
                if (_nombre != value)
                {
                    _nombre = value;
                    OnPropertyChanged("nombre");
                }
            }
        }
        private string _nombre;
    
        [DataMember]
        public Nullable<int> SISEcod_tarifa
        {
            get { return _sISEcod_tarifa; }
            set
            {
                if (_sISEcod_tarifa != value)
                {
                    _sISEcod_tarifa = value;
                    OnPropertyChanged("SISEcod_tarifa");
                }
            }
        }
        private Nullable<int> _sISEcod_tarifa;
    
        [DataMember]
        public Nullable<int> Sn_acum_prima_total
        {
            get { return _sn_acum_prima_total; }
            set
            {
                if (_sn_acum_prima_total != value)
                {
                    _sn_acum_prima_total = value;
                    OnPropertyChanged("Sn_acum_prima_total");
                }
            }
        }
        private Nullable<int> _sn_acum_prima_total;
    
        [DataMember]
        public Nullable<int> Sn_acum_suma_total
        {
            get { return _sn_acum_suma_total; }
            set
            {
                if (_sn_acum_suma_total != value)
                {
                    _sn_acum_suma_total = value;
                    OnPropertyChanged("Sn_acum_suma_total");
                }
            }
        }
        private Nullable<int> _sn_acum_suma_total;
    
        [DataMember]
        public string NombreDeducible
        {
            get { return _nombreDeducible; }
            set
            {
                if (_nombreDeducible != value)
                {
                    _nombreDeducible = value;
                    OnPropertyChanged("NombreDeducible");
                }
            }
        }
        private string _nombreDeducible;
    
        [DataMember]
        public Nullable<int> orden
        {
            get { return _orden; }
            set
            {
                if (_orden != value)
                {
                    _orden = value;
                    OnPropertyChanged("orden");
                }
            }
        }
        private Nullable<int> _orden;
    
        [DataMember]
        public bool isActivo
        {
            get { return _isActivo; }
            set
            {
                if (_isActivo != value)
                {
                    _isActivo = value;
                    OnPropertyChanged("isActivo");
                }
            }
        }
        private bool _isActivo;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public TrackableCollection<CotizacionDeducible> bk_te_CotizacionDeducible
        {
            get
            {
                if (_bk_te_CotizacionDeducible == null)
                {
                    _bk_te_CotizacionDeducible = new TrackableCollection<CotizacionDeducible>();
                    _bk_te_CotizacionDeducible.CollectionChanged += Fixupbk_te_CotizacionDeducible;
                }
                return _bk_te_CotizacionDeducible;
            }
            set
            {
                if (!ReferenceEquals(_bk_te_CotizacionDeducible, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_bk_te_CotizacionDeducible != null)
                    {
                        _bk_te_CotizacionDeducible.CollectionChanged -= Fixupbk_te_CotizacionDeducible;
                        // This is the principal end in an association that performs cascade deletes.
                        // Remove the cascade delete event handler for any entities in the current collection.
                        foreach (CotizacionDeducible item in _bk_te_CotizacionDeducible)
                        {
                            ChangeTracker.ObjectStateChanging -= item.HandleCascadeDelete;
                        }
                    }
                    _bk_te_CotizacionDeducible = value;
                    if (_bk_te_CotizacionDeducible != null)
                    {
                        _bk_te_CotizacionDeducible.CollectionChanged += Fixupbk_te_CotizacionDeducible;
                        // This is the principal end in an association that performs cascade deletes.
                        // Add the cascade delete event handler for any entities that are already in the new collection.
                        foreach (CotizacionDeducible item in _bk_te_CotizacionDeducible)
                        {
                            ChangeTracker.ObjectStateChanging += item.HandleCascadeDelete;
                        }
                    }
                    OnNavigationPropertyChanged("bk_te_CotizacionDeducible");
                }
            }
        }
        private TrackableCollection<CotizacionDeducible> _bk_te_CotizacionDeducible;
    
        [DataMember]
        public SubLineaNegocio bk_tc_SubLineaNegocio
        {
            get { return _bk_tc_SubLineaNegocio; }
            set
            {
                if (!ReferenceEquals(_bk_tc_SubLineaNegocio, value))
                {
                    var previousValue = _bk_tc_SubLineaNegocio;
                    _bk_tc_SubLineaNegocio = value;
                    Fixupbk_tc_SubLineaNegocio(previousValue);
                    OnNavigationPropertyChanged("bk_tc_SubLineaNegocio");
                }
            }
        }
        private SubLineaNegocio _bk_tc_SubLineaNegocio;

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
            bk_te_CotizacionDeducible.Clear();
            bk_tc_SubLineaNegocio = null;
        }

        #endregion

        #region Association Fixup
    
        private void Fixupbk_tc_SubLineaNegocio(SubLineaNegocio previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.bk_tc_Tarifa.Contains(this))
            {
                previousValue.bk_tc_Tarifa.Remove(this);
            }
    
            if (bk_tc_SubLineaNegocio != null)
            {
                if (!bk_tc_SubLineaNegocio.bk_tc_Tarifa.Contains(this))
                {
                    bk_tc_SubLineaNegocio.bk_tc_Tarifa.Add(this);
                }
    
                SubLineaNegocioID = bk_tc_SubLineaNegocio.SubLineaNegocioID;
            }
            else if (!skipKeys)
            {
                SubLineaNegocioID = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("bk_tc_SubLineaNegocio")
                    && (ChangeTracker.OriginalValues["bk_tc_SubLineaNegocio"] == bk_tc_SubLineaNegocio))
                {
                    ChangeTracker.OriginalValues.Remove("bk_tc_SubLineaNegocio");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("bk_tc_SubLineaNegocio", previousValue);
                }
                if (bk_tc_SubLineaNegocio != null && !bk_tc_SubLineaNegocio.ChangeTracker.ChangeTrackingEnabled)
                {
                    bk_tc_SubLineaNegocio.StartTracking();
                }
            }
        }
    
        private void Fixupbk_te_CotizacionDeducible(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (CotizacionDeducible item in e.NewItems)
                {
                    item.bk_tc_Tarifa = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("bk_te_CotizacionDeducible", item);
                    }
                    // This is the principal end in an association that performs cascade deletes.
                    // Update the event listener to refer to the new dependent.
                    ChangeTracker.ObjectStateChanging += item.HandleCascadeDelete;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (CotizacionDeducible item in e.OldItems)
                {
                    if (ReferenceEquals(item.bk_tc_Tarifa, this))
                    {
                        item.bk_tc_Tarifa = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("bk_te_CotizacionDeducible", item);
                        // Delete the dependent end of this identifying association. If the current state is Added,
                        // allow the relationship to be changed without causing the dependent to be deleted.
                        if (item.ChangeTracker.State != ObjectState.Added)
                        {
                            item.MarkAsDeleted();
                        }
                    }
                    // This is the principal end in an association that performs cascade deletes.
                    // Remove the previous dependent from the event listener.
                    ChangeTracker.ObjectStateChanging -= item.HandleCascadeDelete;
                }
            }
        }

        #endregion

    }
}