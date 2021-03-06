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
    [KnownType(typeof(Rol))]
    [System.CodeDom.Compiler.GeneratedCode("STE-EF",".NET 4.0")]
    #if !SILVERLIGHT
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage()]
    #endif
    public partial class Accion: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int AccionID
        {
            get { return _accionID; }
            set
            {
                if (_accionID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'AccionID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _accionID = value;
                    OnPropertyChanged("AccionID");
                }
            }
        }
        private int _accionID;
    
        [DataMember]
        public string actionName
        {
            get { return _actionName; }
            set
            {
                if (_actionName != value)
                {
                    _actionName = value;
                    OnPropertyChanged("actionName");
                }
            }
        }
        private string _actionName;
    
        [DataMember]
        public string controllerName
        {
            get { return _controllerName; }
            set
            {
                if (_controllerName != value)
                {
                    _controllerName = value;
                    OnPropertyChanged("controllerName");
                }
            }
        }
        private string _controllerName;
    
        [DataMember]
        public string descripcion
        {
            get { return _descripcion; }
            set
            {
                if (_descripcion != value)
                {
                    _descripcion = value;
                    OnPropertyChanged("descripcion");
                }
            }
        }
        private string _descripcion;
    
        [DataMember]
        public Nullable<bool> isActive
        {
            get { return _isActive; }
            set
            {
                if (_isActive != value)
                {
                    _isActive = value;
                    OnPropertyChanged("isActive");
                }
            }
        }
        private Nullable<bool> _isActive;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public TrackableCollection<Rol> bk_tc_Rol
        {
            get
            {
                if (_bk_tc_Rol == null)
                {
                    _bk_tc_Rol = new TrackableCollection<Rol>();
                    _bk_tc_Rol.CollectionChanged += Fixupbk_tc_Rol;
                }
                return _bk_tc_Rol;
            }
            set
            {
                if (!ReferenceEquals(_bk_tc_Rol, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_bk_tc_Rol != null)
                    {
                        _bk_tc_Rol.CollectionChanged -= Fixupbk_tc_Rol;
                    }
                    _bk_tc_Rol = value;
                    if (_bk_tc_Rol != null)
                    {
                        _bk_tc_Rol.CollectionChanged += Fixupbk_tc_Rol;
                    }
                    OnNavigationPropertyChanged("bk_tc_Rol");
                }
            }
        }
        private TrackableCollection<Rol> _bk_tc_Rol;

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
            bk_tc_Rol.Clear();
        }

        #endregion

        #region Association Fixup
    
        private void Fixupbk_tc_Rol(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (Rol item in e.NewItems)
                {
                    if (!item.bk_tc_Accion.Contains(this))
                    {
                        item.bk_tc_Accion.Add(this);
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("bk_tc_Rol", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Rol item in e.OldItems)
                {
                    if (item.bk_tc_Accion.Contains(this))
                    {
                        item.bk_tc_Accion.Remove(this);
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("bk_tc_Rol", item);
                    }
                }
            }
        }

        #endregion

    }
}
