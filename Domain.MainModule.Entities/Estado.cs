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
    [KnownType(typeof(Ciudad))]
    [KnownType(typeof(Pais))]
    [KnownType(typeof(Municipio))]
    [System.CodeDom.Compiler.GeneratedCode("STE-EF",".NET 4.0")]
    #if !SILVERLIGHT
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage()]
    #endif
    public partial class Estado: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int EstadoID
        {
            get { return _estadoID; }
            set
            {
                if (_estadoID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'EstadoID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _estadoID = value;
                    OnPropertyChanged("EstadoID");
                }
            }
        }
        private int _estadoID;
    
        [DataMember]
        public Nullable<int> PaisID
        {
            get { return _paisID; }
            set
            {
                if (_paisID != value)
                {
                    ChangeTracker.RecordOriginalValue("PaisID", _paisID);
                    if (!IsDeserializing)
                    {
                        if (bk_tc_Pais != null && bk_tc_Pais.PaisID != value)
                        {
                            bk_tc_Pais = null;
                        }
                    }
                    _paisID = value;
                    OnPropertyChanged("PaisID");
                }
            }
        }
        private Nullable<int> _paisID;
    
        [DataMember]
        public Nullable<int> SISEcod_dpto
        {
            get { return _sISEcod_dpto; }
            set
            {
                if (_sISEcod_dpto != value)
                {
                    _sISEcod_dpto = value;
                    OnPropertyChanged("SISEcod_dpto");
                }
            }
        }
        private Nullable<int> _sISEcod_dpto;
    
        [DataMember]
        public string Descripcion
        {
            get { return _descripcion; }
            set
            {
                if (_descripcion != value)
                {
                    _descripcion = value;
                    OnPropertyChanged("Descripcion");
                }
            }
        }
        private string _descripcion;
    
        [DataMember]
        public string Desc_reduc
        {
            get { return _desc_reduc; }
            set
            {
                if (_desc_reduc != value)
                {
                    _desc_reduc = value;
                    OnPropertyChanged("Desc_reduc");
                }
            }
        }
        private string _desc_reduc;
    
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
        public TrackableCollection<Ciudad> bk_tc_Ciudad
        {
            get
            {
                if (_bk_tc_Ciudad == null)
                {
                    _bk_tc_Ciudad = new TrackableCollection<Ciudad>();
                    _bk_tc_Ciudad.CollectionChanged += Fixupbk_tc_Ciudad;
                }
                return _bk_tc_Ciudad;
            }
            set
            {
                if (!ReferenceEquals(_bk_tc_Ciudad, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_bk_tc_Ciudad != null)
                    {
                        _bk_tc_Ciudad.CollectionChanged -= Fixupbk_tc_Ciudad;
                    }
                    _bk_tc_Ciudad = value;
                    if (_bk_tc_Ciudad != null)
                    {
                        _bk_tc_Ciudad.CollectionChanged += Fixupbk_tc_Ciudad;
                    }
                    OnNavigationPropertyChanged("bk_tc_Ciudad");
                }
            }
        }
        private TrackableCollection<Ciudad> _bk_tc_Ciudad;
    
        [DataMember]
        public Pais bk_tc_Pais
        {
            get { return _bk_tc_Pais; }
            set
            {
                if (!ReferenceEquals(_bk_tc_Pais, value))
                {
                    var previousValue = _bk_tc_Pais;
                    _bk_tc_Pais = value;
                    Fixupbk_tc_Pais(previousValue);
                    OnNavigationPropertyChanged("bk_tc_Pais");
                }
            }
        }
        private Pais _bk_tc_Pais;
    
        [DataMember]
        public TrackableCollection<Municipio> bk_tc_Municipio
        {
            get
            {
                if (_bk_tc_Municipio == null)
                {
                    _bk_tc_Municipio = new TrackableCollection<Municipio>();
                    _bk_tc_Municipio.CollectionChanged += Fixupbk_tc_Municipio;
                }
                return _bk_tc_Municipio;
            }
            set
            {
                if (!ReferenceEquals(_bk_tc_Municipio, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_bk_tc_Municipio != null)
                    {
                        _bk_tc_Municipio.CollectionChanged -= Fixupbk_tc_Municipio;
                    }
                    _bk_tc_Municipio = value;
                    if (_bk_tc_Municipio != null)
                    {
                        _bk_tc_Municipio.CollectionChanged += Fixupbk_tc_Municipio;
                    }
                    OnNavigationPropertyChanged("bk_tc_Municipio");
                }
            }
        }
        private TrackableCollection<Municipio> _bk_tc_Municipio;

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
            bk_tc_Ciudad.Clear();
            bk_tc_Pais = null;
            bk_tc_Municipio.Clear();
        }

        #endregion

        #region Association Fixup
    
        private void Fixupbk_tc_Pais(Pais previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.bk_tc_Estado.Contains(this))
            {
                previousValue.bk_tc_Estado.Remove(this);
            }
    
            if (bk_tc_Pais != null)
            {
                if (!bk_tc_Pais.bk_tc_Estado.Contains(this))
                {
                    bk_tc_Pais.bk_tc_Estado.Add(this);
                }
    
                PaisID = bk_tc_Pais.PaisID;
            }
            else if (!skipKeys)
            {
                PaisID = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("bk_tc_Pais")
                    && (ChangeTracker.OriginalValues["bk_tc_Pais"] == bk_tc_Pais))
                {
                    ChangeTracker.OriginalValues.Remove("bk_tc_Pais");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("bk_tc_Pais", previousValue);
                }
                if (bk_tc_Pais != null && !bk_tc_Pais.ChangeTracker.ChangeTrackingEnabled)
                {
                    bk_tc_Pais.StartTracking();
                }
            }
        }
    
        private void Fixupbk_tc_Ciudad(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (Ciudad item in e.NewItems)
                {
                    item.bk_tc_Estado = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("bk_tc_Ciudad", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Ciudad item in e.OldItems)
                {
                    if (ReferenceEquals(item.bk_tc_Estado, this))
                    {
                        item.bk_tc_Estado = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("bk_tc_Ciudad", item);
                    }
                }
            }
        }
    
        private void Fixupbk_tc_Municipio(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (Municipio item in e.NewItems)
                {
                    item.bk_tc_Estado = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("bk_tc_Municipio", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Municipio item in e.OldItems)
                {
                    if (ReferenceEquals(item.bk_tc_Estado, this))
                    {
                        item.bk_tc_Estado = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("bk_tc_Municipio", item);
                    }
                }
            }
        }

        #endregion

    }
}
