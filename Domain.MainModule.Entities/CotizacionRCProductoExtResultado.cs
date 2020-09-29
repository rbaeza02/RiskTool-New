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
    [KnownType(typeof(SICClassMap))]
    [System.CodeDom.Compiler.GeneratedCode("STE-EF",".NET 4.0")]
    #if !SILVERLIGHT
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage()]
    #endif
    public partial class CotizacionRCProductoExtResultado: IObjectWithChangeTracker, INotifyPropertyChanged
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
        public int RCProdGrupoPaisID
        {
            get { return _rCProdGrupoPaisID; }
            set
            {
                if (_rCProdGrupoPaisID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'RCProdGrupoPaisID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _rCProdGrupoPaisID = value;
                    OnPropertyChanged("RCProdGrupoPaisID");
                }
            }
        }
        private int _rCProdGrupoPaisID;
    
        [DataMember]
        public Nullable<int> SICClassMapID
        {
            get { return _sICClassMapID; }
            set
            {
                if (_sICClassMapID != value)
                {
                    ChangeTracker.RecordOriginalValue("SICClassMapID", _sICClassMapID);
                    if (!IsDeserializing)
                    {
                        if (bk_tc_SICClassMap != null && bk_tc_SICClassMap.SICClassMapID != value)
                        {
                            bk_tc_SICClassMap = null;
                        }
                    }
                    _sICClassMapID = value;
                    OnPropertyChanged("SICClassMapID");
                }
            }
        }
        private Nullable<int> _sICClassMapID;
    
        [DataMember]
        public Nullable<bool> isCostoAdicional
        {
            get { return _isCostoAdicional; }
            set
            {
                if (_isCostoAdicional != value)
                {
                    _isCostoAdicional = value;
                    OnPropertyChanged("isCostoAdicional");
                }
            }
        }
        private Nullable<bool> _isCostoAdicional;
    
        [DataMember]
        public Nullable<int> RCProdTipoCoberturaID
        {
            get { return _rCProdTipoCoberturaID; }
            set
            {
                if (_rCProdTipoCoberturaID != value)
                {
                    _rCProdTipoCoberturaID = value;
                    OnPropertyChanged("RCProdTipoCoberturaID");
                }
            }
        }
        private Nullable<int> _rCProdTipoCoberturaID;
    
        [DataMember]
        public Nullable<double> MontoExposicion
        {
            get { return _montoExposicion; }
            set
            {
                if (_montoExposicion != value)
                {
                    _montoExposicion = value;
                    OnPropertyChanged("MontoExposicion");
                }
            }
        }
        private Nullable<double> _montoExposicion;
    
        [DataMember]
        public Nullable<double> MontoIngreso
        {
            get { return _montoIngreso; }
            set
            {
                if (_montoIngreso != value)
                {
                    _montoIngreso = value;
                    OnPropertyChanged("MontoIngreso");
                }
            }
        }
        private Nullable<double> _montoIngreso;
    
        [DataMember]
        public Nullable<double> Deducible
        {
            get { return _deducible; }
            set
            {
                if (_deducible != value)
                {
                    _deducible = value;
                    OnPropertyChanged("Deducible");
                }
            }
        }
        private Nullable<double> _deducible;
    
        [DataMember]
        public Nullable<bool> isInclGastosDefensa
        {
            get { return _isInclGastosDefensa; }
            set
            {
                if (_isInclGastosDefensa != value)
                {
                    _isInclGastosDefensa = value;
                    OnPropertyChanged("isInclGastosDefensa");
                }
            }
        }
        private Nullable<bool> _isInclGastosDefensa;
    
        [DataMember]
        public Nullable<int> RCProdBaseDeducibleID
        {
            get { return _rCProdBaseDeducibleID; }
            set
            {
                if (_rCProdBaseDeducibleID != value)
                {
                    _rCProdBaseDeducibleID = value;
                    OnPropertyChanged("RCProdBaseDeducibleID");
                }
            }
        }
        private Nullable<int> _rCProdBaseDeducibleID;
    
        [DataMember]
        public Nullable<bool> isRCActInm
        {
            get { return _isRCActInm; }
            set
            {
                if (_isRCActInm != value)
                {
                    _isRCActInm = value;
                    OnPropertyChanged("isRCActInm");
                }
            }
        }
        private Nullable<bool> _isRCActInm;
    
        [DataMember]
        public Nullable<bool> isRCProducto
        {
            get { return _isRCProducto; }
            set
            {
                if (_isRCProducto != value)
                {
                    _isRCProducto = value;
                    OnPropertyChanged("isRCProducto");
                }
            }
        }
        private Nullable<bool> _isRCProducto;
    
        [DataMember]
        public Nullable<double> PremOpsBaseLimit
        {
            get { return _premOpsBaseLimit; }
            set
            {
                if (_premOpsBaseLimit != value)
                {
                    _premOpsBaseLimit = value;
                    OnPropertyChanged("PremOpsBaseLimit");
                }
            }
        }
        private Nullable<double> _premOpsBaseLimit;
    
        [DataMember]
        public Nullable<double> ProductsBaseLimit
        {
            get { return _productsBaseLimit; }
            set
            {
                if (_productsBaseLimit != value)
                {
                    _productsBaseLimit = value;
                    OnPropertyChanged("ProductsBaseLimit");
                }
            }
        }
        private Nullable<double> _productsBaseLimit;
    
        [DataMember]
        public Nullable<double> PremOpsBaseRate
        {
            get { return _premOpsBaseRate; }
            set
            {
                if (_premOpsBaseRate != value)
                {
                    _premOpsBaseRate = value;
                    OnPropertyChanged("PremOpsBaseRate");
                }
            }
        }
        private Nullable<double> _premOpsBaseRate;
    
        [DataMember]
        public Nullable<double> ProductsBaseRate
        {
            get { return _productsBaseRate; }
            set
            {
                if (_productsBaseRate != value)
                {
                    _productsBaseRate = value;
                    OnPropertyChanged("ProductsBaseRate");
                }
            }
        }
        private Nullable<double> _productsBaseRate;
    
        [DataMember]
        public Nullable<double> InterpolatedValuePremOps
        {
            get { return _interpolatedValuePremOps; }
            set
            {
                if (_interpolatedValuePremOps != value)
                {
                    _interpolatedValuePremOps = value;
                    OnPropertyChanged("InterpolatedValuePremOps");
                }
            }
        }
        private Nullable<double> _interpolatedValuePremOps;
    
        [DataMember]
        public Nullable<double> Pre_PremOpsDedAdj
        {
            get { return _pre_PremOpsDedAdj; }
            set
            {
                if (_pre_PremOpsDedAdj != value)
                {
                    _pre_PremOpsDedAdj = value;
                    OnPropertyChanged("Pre_PremOpsDedAdj");
                }
            }
        }
        private Nullable<double> _pre_PremOpsDedAdj;
    
        [DataMember]
        public Nullable<double> InterpolatedValueProducts
        {
            get { return _interpolatedValueProducts; }
            set
            {
                if (_interpolatedValueProducts != value)
                {
                    _interpolatedValueProducts = value;
                    OnPropertyChanged("InterpolatedValueProducts");
                }
            }
        }
        private Nullable<double> _interpolatedValueProducts;
    
        [DataMember]
        public Nullable<double> Pre_ProductsDedAdj
        {
            get { return _pre_ProductsDedAdj; }
            set
            {
                if (_pre_ProductsDedAdj != value)
                {
                    _pre_ProductsDedAdj = value;
                    OnPropertyChanged("Pre_ProductsDedAdj");
                }
            }
        }
        private Nullable<double> _pre_ProductsDedAdj;
    
        [DataMember]
        public Nullable<double> PCTotalMod
        {
            get { return _pCTotalMod; }
            set
            {
                if (_pCTotalMod != value)
                {
                    _pCTotalMod = value;
                    OnPropertyChanged("PCTotalMod");
                }
            }
        }
        private Nullable<double> _pCTotalMod;
    
        [DataMember]
        public Nullable<double> Limit2
        {
            get { return _limit2; }
            set
            {
                if (_limit2 != value)
                {
                    _limit2 = value;
                    OnPropertyChanged("Limit2");
                }
            }
        }
        private Nullable<double> _limit2;
    
        [DataMember]
        public Nullable<double> PremOpsDeductibleAdj1stMill
        {
            get { return _premOpsDeductibleAdj1stMill; }
            set
            {
                if (_premOpsDeductibleAdj1stMill != value)
                {
                    _premOpsDeductibleAdj1stMill = value;
                    OnPropertyChanged("PremOpsDeductibleAdj1stMill");
                }
            }
        }
        private Nullable<double> _premOpsDeductibleAdj1stMill;
    
        [DataMember]
        public Nullable<double> B34_grossPrem
        {
            get { return _b34_grossPrem; }
            set
            {
                if (_b34_grossPrem != value)
                {
                    _b34_grossPrem = value;
                    OnPropertyChanged("B34_grossPrem");
                }
            }
        }
        private Nullable<double> _b34_grossPrem;
    
        [DataMember]
        public Nullable<double> PremOpsFinalPremium
        {
            get { return _premOpsFinalPremium; }
            set
            {
                if (_premOpsFinalPremium != value)
                {
                    _premOpsFinalPremium = value;
                    OnPropertyChanged("PremOpsFinalPremium");
                }
            }
        }
        private Nullable<double> _premOpsFinalPremium;
    
        [DataMember]
        public Nullable<double> ProductsDeductibleAdj1stMill
        {
            get { return _productsDeductibleAdj1stMill; }
            set
            {
                if (_productsDeductibleAdj1stMill != value)
                {
                    _productsDeductibleAdj1stMill = value;
                    OnPropertyChanged("ProductsDeductibleAdj1stMill");
                }
            }
        }
        private Nullable<double> _productsDeductibleAdj1stMill;
    
        [DataMember]
        public Nullable<double> B34_grossProducts
        {
            get { return _b34_grossProducts; }
            set
            {
                if (_b34_grossProducts != value)
                {
                    _b34_grossProducts = value;
                    OnPropertyChanged("B34_grossProducts");
                }
            }
        }
        private Nullable<double> _b34_grossProducts;
    
        [DataMember]
        public Nullable<double> ProductsFinalPremium
        {
            get { return _productsFinalPremium; }
            set
            {
                if (_productsFinalPremium != value)
                {
                    _productsFinalPremium = value;
                    OnPropertyChanged("ProductsFinalPremium");
                }
            }
        }
        private Nullable<double> _productsFinalPremium;
    
        [DataMember]
        public Nullable<double> PremOpsFinalPremiumUSEquiv
        {
            get { return _premOpsFinalPremiumUSEquiv; }
            set
            {
                if (_premOpsFinalPremiumUSEquiv != value)
                {
                    _premOpsFinalPremiumUSEquiv = value;
                    OnPropertyChanged("PremOpsFinalPremiumUSEquiv");
                }
            }
        }
        private Nullable<double> _premOpsFinalPremiumUSEquiv;
    
        [DataMember]
        public Nullable<double> ProductsFinalPremiumUSEquiv
        {
            get { return _productsFinalPremiumUSEquiv; }
            set
            {
                if (_productsFinalPremiumUSEquiv != value)
                {
                    _productsFinalPremiumUSEquiv = value;
                    OnPropertyChanged("ProductsFinalPremiumUSEquiv");
                }
            }
        }
        private Nullable<double> _productsFinalPremiumUSEquiv;
    
        [DataMember]
        public Nullable<double> LimiteEvento
        {
            get { return _limiteEvento; }
            set
            {
                if (_limiteEvento != value)
                {
                    _limiteEvento = value;
                    OnPropertyChanged("LimiteEvento");
                }
            }
        }
        private Nullable<double> _limiteEvento;

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
    
        [DataMember]
        public SICClassMap bk_tc_SICClassMap
        {
            get { return _bk_tc_SICClassMap; }
            set
            {
                if (!ReferenceEquals(_bk_tc_SICClassMap, value))
                {
                    var previousValue = _bk_tc_SICClassMap;
                    _bk_tc_SICClassMap = value;
                    Fixupbk_tc_SICClassMap(previousValue);
                    OnNavigationPropertyChanged("bk_tc_SICClassMap");
                }
            }
        }
        private SICClassMap _bk_tc_SICClassMap;

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
            bk_tc_SICClassMap = null;
        }

        #endregion

        #region Association Fixup
    
        private void Fixupbk_te_Cotizacion(Cotizacion previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.bk_te_CotizacionRCProductoExtResultado.Contains(this))
            {
                previousValue.bk_te_CotizacionRCProductoExtResultado.Remove(this);
            }
    
            if (bk_te_Cotizacion != null)
            {
                if (!bk_te_Cotizacion.bk_te_CotizacionRCProductoExtResultado.Contains(this))
                {
                    bk_te_Cotizacion.bk_te_CotizacionRCProductoExtResultado.Add(this);
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
    
        private void Fixupbk_tc_SICClassMap(SICClassMap previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.bk_te_CotizacionRCProductoExtResultado.Contains(this))
            {
                previousValue.bk_te_CotizacionRCProductoExtResultado.Remove(this);
            }
    
            if (bk_tc_SICClassMap != null)
            {
                if (!bk_tc_SICClassMap.bk_te_CotizacionRCProductoExtResultado.Contains(this))
                {
                    bk_tc_SICClassMap.bk_te_CotizacionRCProductoExtResultado.Add(this);
                }
    
                SICClassMapID = bk_tc_SICClassMap.SICClassMapID;
            }
            else if (!skipKeys)
            {
                SICClassMapID = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("bk_tc_SICClassMap")
                    && (ChangeTracker.OriginalValues["bk_tc_SICClassMap"] == bk_tc_SICClassMap))
                {
                    ChangeTracker.OriginalValues.Remove("bk_tc_SICClassMap");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("bk_tc_SICClassMap", previousValue);
                }
                if (bk_tc_SICClassMap != null && !bk_tc_SICClassMap.ChangeTracker.ChangeTrackingEnabled)
                {
                    bk_tc_SICClassMap.StartTracking();
                }
            }
        }

        #endregion

    }
}
