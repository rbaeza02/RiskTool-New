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
    [KnownType(typeof(CotizacionTransConceptoEvaluacion))]
    [System.CodeDom.Compiler.GeneratedCode("STE-EF",".NET 4.0")]
    #if !SILVERLIGHT
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage()]
    #endif
    public partial class TransConceptoEval: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int TransConceptoEvalID
        {
            get { return _transConceptoEvalID; }
            set
            {
                if (_transConceptoEvalID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'TransConceptoEvalID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _transConceptoEvalID = value;
                    OnPropertyChanged("TransConceptoEvalID");
                }
            }
        }
        private int _transConceptoEvalID;
    
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
        public Nullable<decimal> pct
        {
            get { return _pct; }
            set
            {
                if (_pct != value)
                {
                    _pct = value;
                    OnPropertyChanged("pct");
                }
            }
        }
        private Nullable<decimal> _pct;
    
        [DataMember]
        public Nullable<bool> isActivo
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
        private Nullable<bool> _isActivo;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public TrackableCollection<CotizacionTransConceptoEvaluacion> bk_te_CotizacionTransConceptoEvaluacion
        {
            get
            {
                if (_bk_te_CotizacionTransConceptoEvaluacion == null)
                {
                    _bk_te_CotizacionTransConceptoEvaluacion = new TrackableCollection<CotizacionTransConceptoEvaluacion>();
                    _bk_te_CotizacionTransConceptoEvaluacion.CollectionChanged += Fixupbk_te_CotizacionTransConceptoEvaluacion;
                }
                return _bk_te_CotizacionTransConceptoEvaluacion;
            }
            set
            {
                if (!ReferenceEquals(_bk_te_CotizacionTransConceptoEvaluacion, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_bk_te_CotizacionTransConceptoEvaluacion != null)
                    {
                        _bk_te_CotizacionTransConceptoEvaluacion.CollectionChanged -= Fixupbk_te_CotizacionTransConceptoEvaluacion;
                        // This is the principal end in an association that performs cascade deletes.
                        // Remove the cascade delete event handler for any entities in the current collection.
                        foreach (CotizacionTransConceptoEvaluacion item in _bk_te_CotizacionTransConceptoEvaluacion)
                        {
                            ChangeTracker.ObjectStateChanging -= item.HandleCascadeDelete;
                        }
                    }
                    _bk_te_CotizacionTransConceptoEvaluacion = value;
                    if (_bk_te_CotizacionTransConceptoEvaluacion != null)
                    {
                        _bk_te_CotizacionTransConceptoEvaluacion.CollectionChanged += Fixupbk_te_CotizacionTransConceptoEvaluacion;
                        // This is the principal end in an association that performs cascade deletes.
                        // Add the cascade delete event handler for any entities that are already in the new collection.
                        foreach (CotizacionTransConceptoEvaluacion item in _bk_te_CotizacionTransConceptoEvaluacion)
                        {
                            ChangeTracker.ObjectStateChanging += item.HandleCascadeDelete;
                        }
                    }
                    OnNavigationPropertyChanged("bk_te_CotizacionTransConceptoEvaluacion");
                }
            }
        }
        private TrackableCollection<CotizacionTransConceptoEvaluacion> _bk_te_CotizacionTransConceptoEvaluacion;

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
            bk_te_CotizacionTransConceptoEvaluacion.Clear();
        }

        #endregion

        #region Association Fixup
    
        private void Fixupbk_te_CotizacionTransConceptoEvaluacion(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (CotizacionTransConceptoEvaluacion item in e.NewItems)
                {
                    item.bk_tw_TransConceptoEval = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("bk_te_CotizacionTransConceptoEvaluacion", item);
                    }
                    // This is the principal end in an association that performs cascade deletes.
                    // Update the event listener to refer to the new dependent.
                    ChangeTracker.ObjectStateChanging += item.HandleCascadeDelete;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (CotizacionTransConceptoEvaluacion item in e.OldItems)
                {
                    if (ReferenceEquals(item.bk_tw_TransConceptoEval, this))
                    {
                        item.bk_tw_TransConceptoEval = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("bk_te_CotizacionTransConceptoEvaluacion", item);
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
