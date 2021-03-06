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
    [KnownType(typeof(CotizacionTipoCobertura))]
    [KnownType(typeof(Cobertura))]
    [System.CodeDom.Compiler.GeneratedCode("STE-EF",".NET 4.0")]
    #if !SILVERLIGHT
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage()]
    #endif
    public partial class TipoCobertura: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int TipoCoberturaID
        {
            get { return _tipoCoberturaID; }
            set
            {
                if (_tipoCoberturaID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'TipoCoberturaID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _tipoCoberturaID = value;
                    OnPropertyChanged("TipoCoberturaID");
                }
            }
        }
        private int _tipoCoberturaID;
    
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
        public bool isPrimerRiesgo
        {
            get { return _isPrimerRiesgo; }
            set
            {
                if (_isPrimerRiesgo != value)
                {
                    _isPrimerRiesgo = value;
                    OnPropertyChanged("isPrimerRiesgo");
                }
            }
        }
        private bool _isPrimerRiesgo;
    
        [DataMember]
        public string nombrePrimerRiesgo
        {
            get { return _nombrePrimerRiesgo; }
            set
            {
                if (_nombrePrimerRiesgo != value)
                {
                    _nombrePrimerRiesgo = value;
                    OnPropertyChanged("nombrePrimerRiesgo");
                }
            }
        }
        private string _nombrePrimerRiesgo;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public TrackableCollection<CotizacionTipoCobertura> bk_tr_CotizacionTipoCobertura
        {
            get
            {
                if (_bk_tr_CotizacionTipoCobertura == null)
                {
                    _bk_tr_CotizacionTipoCobertura = new TrackableCollection<CotizacionTipoCobertura>();
                    _bk_tr_CotizacionTipoCobertura.CollectionChanged += Fixupbk_tr_CotizacionTipoCobertura;
                }
                return _bk_tr_CotizacionTipoCobertura;
            }
            set
            {
                if (!ReferenceEquals(_bk_tr_CotizacionTipoCobertura, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_bk_tr_CotizacionTipoCobertura != null)
                    {
                        _bk_tr_CotizacionTipoCobertura.CollectionChanged -= Fixupbk_tr_CotizacionTipoCobertura;
                        // This is the principal end in an association that performs cascade deletes.
                        // Remove the cascade delete event handler for any entities in the current collection.
                        foreach (CotizacionTipoCobertura item in _bk_tr_CotizacionTipoCobertura)
                        {
                            ChangeTracker.ObjectStateChanging -= item.HandleCascadeDelete;
                        }
                    }
                    _bk_tr_CotizacionTipoCobertura = value;
                    if (_bk_tr_CotizacionTipoCobertura != null)
                    {
                        _bk_tr_CotizacionTipoCobertura.CollectionChanged += Fixupbk_tr_CotizacionTipoCobertura;
                        // This is the principal end in an association that performs cascade deletes.
                        // Add the cascade delete event handler for any entities that are already in the new collection.
                        foreach (CotizacionTipoCobertura item in _bk_tr_CotizacionTipoCobertura)
                        {
                            ChangeTracker.ObjectStateChanging += item.HandleCascadeDelete;
                        }
                    }
                    OnNavigationPropertyChanged("bk_tr_CotizacionTipoCobertura");
                }
            }
        }
        private TrackableCollection<CotizacionTipoCobertura> _bk_tr_CotizacionTipoCobertura;
    
        [DataMember]
        public TrackableCollection<Cobertura> bk_tc_Cobertura
        {
            get
            {
                if (_bk_tc_Cobertura == null)
                {
                    _bk_tc_Cobertura = new TrackableCollection<Cobertura>();
                    _bk_tc_Cobertura.CollectionChanged += Fixupbk_tc_Cobertura;
                }
                return _bk_tc_Cobertura;
            }
            set
            {
                if (!ReferenceEquals(_bk_tc_Cobertura, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_bk_tc_Cobertura != null)
                    {
                        _bk_tc_Cobertura.CollectionChanged -= Fixupbk_tc_Cobertura;
                    }
                    _bk_tc_Cobertura = value;
                    if (_bk_tc_Cobertura != null)
                    {
                        _bk_tc_Cobertura.CollectionChanged += Fixupbk_tc_Cobertura;
                    }
                    OnNavigationPropertyChanged("bk_tc_Cobertura");
                }
            }
        }
        private TrackableCollection<Cobertura> _bk_tc_Cobertura;

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
            bk_tr_CotizacionTipoCobertura.Clear();
            bk_tc_Cobertura.Clear();
        }

        #endregion

        #region Association Fixup
    
        private void Fixupbk_tr_CotizacionTipoCobertura(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (CotizacionTipoCobertura item in e.NewItems)
                {
                    item.bk_tc_TipoCobertura = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("bk_tr_CotizacionTipoCobertura", item);
                    }
                    // This is the principal end in an association that performs cascade deletes.
                    // Update the event listener to refer to the new dependent.
                    ChangeTracker.ObjectStateChanging += item.HandleCascadeDelete;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (CotizacionTipoCobertura item in e.OldItems)
                {
                    if (ReferenceEquals(item.bk_tc_TipoCobertura, this))
                    {
                        item.bk_tc_TipoCobertura = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("bk_tr_CotizacionTipoCobertura", item);
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
    
        private void Fixupbk_tc_Cobertura(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (Cobertura item in e.NewItems)
                {
                    item.bk_tc_TipoCobertura = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("bk_tc_Cobertura", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Cobertura item in e.OldItems)
                {
                    if (ReferenceEquals(item.bk_tc_TipoCobertura, this))
                    {
                        item.bk_tc_TipoCobertura = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("bk_tc_Cobertura", item);
                    }
                }
            }
        }

        #endregion

    }
}
