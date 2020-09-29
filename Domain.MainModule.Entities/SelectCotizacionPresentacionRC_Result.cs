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
    [System.CodeDom.Compiler.GeneratedCode("STE-EF",".NET 4.0")]
    #if !SILVERLIGHT
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage()]
    #endif
    public partial class SelectCotizacionPresentacionRC_Result : INotifyComplexPropertyChanging, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public string DescripcionCNSF_AMIS
        {
            get { return _descripcionCNSF_AMIS; }
            set
            {
                if (_descripcionCNSF_AMIS != value)
                {
                    OnComplexPropertyChanging();
                    _descripcionCNSF_AMIS = value;
                    OnPropertyChanged("DescripcionCNSF_AMIS");
                }
            }
        }
        private string _descripcionCNSF_AMIS;
    
        [DataMember]
        public string division
        {
            get { return _division; }
            set
            {
                if (_division != value)
                {
                    OnComplexPropertyChanging();
                    _division = value;
                    OnPropertyChanged("division");
                }
            }
        }
        private string _division;
    
        [DataMember]
        public string grupo
        {
            get { return _grupo; }
            set
            {
                if (_grupo != value)
                {
                    OnComplexPropertyChanging();
                    _grupo = value;
                    OnPropertyChanged("grupo");
                }
            }
        }
        private string _grupo;
    
        [DataMember]
        public string desde
        {
            get { return _desde; }
            set
            {
                if (_desde != value)
                {
                    OnComplexPropertyChanging();
                    _desde = value;
                    OnPropertyChanged("desde");
                }
            }
        }
        private string _desde;
    
        [DataMember]
        public string hasta
        {
            get { return _hasta; }
            set
            {
                if (_hasta != value)
                {
                    OnComplexPropertyChanging();
                    _hasta = value;
                    OnPropertyChanged("hasta");
                }
            }
        }
        private string _hasta;
    
        [DataMember]
        public string contacto
        {
            get { return _contacto; }
            set
            {
                if (_contacto != value)
                {
                    OnComplexPropertyChanging();
                    _contacto = value;
                    OnPropertyChanged("contacto");
                }
            }
        }
        private string _contacto;

        #endregion

        #region ChangeTracking
    
        private void OnComplexPropertyChanging()
        {
            if (_complexPropertyChanging != null)
            {
                _complexPropertyChanging(this, new EventArgs());
            }
        }
    
        event EventHandler INotifyComplexPropertyChanging.ComplexPropertyChanging { add { _complexPropertyChanging += value; } remove { _complexPropertyChanging -= value; } }
        private event EventHandler _complexPropertyChanging;
    
        private void OnPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged { add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
    
        public static void RecordComplexOriginalValues(String parentPropertyName, SelectCotizacionPresentacionRC_Result complexObject, ObjectChangeTracker changeTracker)
        {
            if (String.IsNullOrEmpty(parentPropertyName))
            {
                throw new ArgumentException("String parameter cannot be null or empty.", "parentPropertyName");
            }
    
            if (changeTracker == null)
            {
                throw new ArgumentNullException("changeTracker");
            }
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.DescripcionCNSF_AMIS", parentPropertyName), complexObject == null ? null : (object)complexObject.DescripcionCNSF_AMIS);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.division", parentPropertyName), complexObject == null ? null : (object)complexObject.division);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.grupo", parentPropertyName), complexObject == null ? null : (object)complexObject.grupo);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.desde", parentPropertyName), complexObject == null ? null : (object)complexObject.desde);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.hasta", parentPropertyName), complexObject == null ? null : (object)complexObject.hasta);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.contacto", parentPropertyName), complexObject == null ? null : (object)complexObject.contacto);
        }

        #endregion

    }
}
