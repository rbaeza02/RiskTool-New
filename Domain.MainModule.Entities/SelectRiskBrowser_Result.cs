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
    public partial class SelectRiskBrowser_Result : INotifyComplexPropertyChanging, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public string ACCNTNUM
        {
            get { return _aCCNTNUM; }
            set
            {
                if (_aCCNTNUM != value)
                {
                    OnComplexPropertyChanging();
                    _aCCNTNUM = value;
                    OnPropertyChanged("ACCNTNUM");
                }
            }
        }
        private string _aCCNTNUM;
    
        [DataMember]
        public string ACCNTNAME
        {
            get { return _aCCNTNAME; }
            set
            {
                if (_aCCNTNAME != value)
                {
                    OnComplexPropertyChanging();
                    _aCCNTNAME = value;
                    OnPropertyChanged("ACCNTNAME");
                }
            }
        }
        private string _aCCNTNAME;
    
        [DataMember]
        public string POLICYNUM
        {
            get { return _pOLICYNUM; }
            set
            {
                if (_pOLICYNUM != value)
                {
                    OnComplexPropertyChanging();
                    _pOLICYNUM = value;
                    OnPropertyChanged("POLICYNUM");
                }
            }
        }
        private string _pOLICYNUM;
    
        [DataMember]
        public string LOBNAME
        {
            get { return _lOBNAME; }
            set
            {
                if (_lOBNAME != value)
                {
                    OnComplexPropertyChanging();
                    _lOBNAME = value;
                    OnPropertyChanged("LOBNAME");
                }
            }
        }
        private string _lOBNAME;
    
        [DataMember]
        public System.DateTime INCEPTDATE
        {
            get { return _iNCEPTDATE; }
            set
            {
                if (_iNCEPTDATE != value)
                {
                    OnComplexPropertyChanging();
                    _iNCEPTDATE = value;
                    OnPropertyChanged("INCEPTDATE");
                }
            }
        }
        private System.DateTime _iNCEPTDATE;
    
        [DataMember]
        public System.DateTime EXPIREDATE
        {
            get { return _eXPIREDATE; }
            set
            {
                if (_eXPIREDATE != value)
                {
                    OnComplexPropertyChanging();
                    _eXPIREDATE = value;
                    OnPropertyChanged("EXPIREDATE");
                }
            }
        }
        private System.DateTime _eXPIREDATE;
    
        [DataMember]
        public string UNDCOVAMT
        {
            get { return _uNDCOVAMT; }
            set
            {
                if (_uNDCOVAMT != value)
                {
                    OnComplexPropertyChanging();
                    _uNDCOVAMT = value;
                    OnPropertyChanged("UNDCOVAMT");
                }
            }
        }
        private string _uNDCOVAMT;
    
        [DataMember]
        public string UNDCOVCUR
        {
            get { return _uNDCOVCUR; }
            set
            {
                if (_uNDCOVCUR != value)
                {
                    OnComplexPropertyChanging();
                    _uNDCOVCUR = value;
                    OnPropertyChanged("UNDCOVCUR");
                }
            }
        }
        private string _uNDCOVCUR;
    
        [DataMember]
        public Nullable<double> PARTOF
        {
            get { return _pARTOF; }
            set
            {
                if (_pARTOF != value)
                {
                    OnComplexPropertyChanging();
                    _pARTOF = value;
                    OnPropertyChanged("PARTOF");
                }
            }
        }
        private Nullable<double> _pARTOF;
    
        [DataMember]
        public string PARTOFCUR
        {
            get { return _pARTOFCUR; }
            set
            {
                if (_pARTOFCUR != value)
                {
                    OnComplexPropertyChanging();
                    _pARTOFCUR = value;
                    OnPropertyChanged("PARTOFCUR");
                }
            }
        }
        private string _pARTOFCUR;
    
        [DataMember]
        public int POLICYTYPE
        {
            get { return _pOLICYTYPE; }
            set
            {
                if (_pOLICYTYPE != value)
                {
                    OnComplexPropertyChanging();
                    _pOLICYTYPE = value;
                    OnPropertyChanged("POLICYTYPE");
                }
            }
        }
        private int _pOLICYTYPE;
    
        [DataMember]
        public int MINDEDAMT
        {
            get { return _mINDEDAMT; }
            set
            {
                if (_mINDEDAMT != value)
                {
                    OnComplexPropertyChanging();
                    _mINDEDAMT = value;
                    OnPropertyChanged("MINDEDAMT");
                }
            }
        }
        private int _mINDEDAMT;
    
        [DataMember]
        public string MINDEDCUR
        {
            get { return _mINDEDCUR; }
            set
            {
                if (_mINDEDCUR != value)
                {
                    OnComplexPropertyChanging();
                    _mINDEDCUR = value;
                    OnPropertyChanged("MINDEDCUR");
                }
            }
        }
        private string _mINDEDCUR;
    
        [DataMember]
        public int MAXDEDAMT
        {
            get { return _mAXDEDAMT; }
            set
            {
                if (_mAXDEDAMT != value)
                {
                    OnComplexPropertyChanging();
                    _mAXDEDAMT = value;
                    OnPropertyChanged("MAXDEDAMT");
                }
            }
        }
        private int _mAXDEDAMT;
    
        [DataMember]
        public string MAXDEDCUR
        {
            get { return _mAXDEDCUR; }
            set
            {
                if (_mAXDEDCUR != value)
                {
                    OnComplexPropertyChanging();
                    _mAXDEDCUR = value;
                    OnPropertyChanged("MAXDEDCUR");
                }
            }
        }
        private string _mAXDEDCUR;
    
        [DataMember]
        public int BLANDEDAMT
        {
            get { return _bLANDEDAMT; }
            set
            {
                if (_bLANDEDAMT != value)
                {
                    OnComplexPropertyChanging();
                    _bLANDEDAMT = value;
                    OnPropertyChanged("BLANDEDAMT");
                }
            }
        }
        private int _bLANDEDAMT;
    
        [DataMember]
        public string BLANDEDCUR
        {
            get { return _bLANDEDCUR; }
            set
            {
                if (_bLANDEDCUR != value)
                {
                    OnComplexPropertyChanging();
                    _bLANDEDCUR = value;
                    OnPropertyChanged("BLANDEDCUR");
                }
            }
        }
        private string _bLANDEDCUR;
    
        [DataMember]
        public Nullable<double> BLANLIMAMT
        {
            get { return _bLANLIMAMT; }
            set
            {
                if (_bLANLIMAMT != value)
                {
                    OnComplexPropertyChanging();
                    _bLANLIMAMT = value;
                    OnPropertyChanged("BLANLIMAMT");
                }
            }
        }
        private Nullable<double> _bLANLIMAMT;
    
        [DataMember]
        public string BLANLIMCUR
        {
            get { return _bLANLIMCUR; }
            set
            {
                if (_bLANLIMCUR != value)
                {
                    OnComplexPropertyChanging();
                    _bLANLIMCUR = value;
                    OnPropertyChanged("BLANLIMCUR");
                }
            }
        }
        private string _bLANLIMCUR;
    
        [DataMember]
        public string ACCNTNUM1
        {
            get { return _aCCNTNUM1; }
            set
            {
                if (_aCCNTNUM1 != value)
                {
                    OnComplexPropertyChanging();
                    _aCCNTNUM1 = value;
                    OnPropertyChanged("ACCNTNUM1");
                }
            }
        }
        private string _aCCNTNUM1;
    
        [DataMember]
        public int LOCNUM
        {
            get { return _lOCNUM; }
            set
            {
                if (_lOCNUM != value)
                {
                    OnComplexPropertyChanging();
                    _lOCNUM = value;
                    OnPropertyChanged("LOCNUM");
                }
            }
        }
        private int _lOCNUM;
    
        [DataMember]
        public string LOCNAME
        {
            get { return _lOCNAME; }
            set
            {
                if (_lOCNAME != value)
                {
                    OnComplexPropertyChanging();
                    _lOCNAME = value;
                    OnPropertyChanged("LOCNAME");
                }
            }
        }
        private string _lOCNAME;
    
        [DataMember]
        public string STREETNAME
        {
            get { return _sTREETNAME; }
            set
            {
                if (_sTREETNAME != value)
                {
                    OnComplexPropertyChanging();
                    _sTREETNAME = value;
                    OnPropertyChanged("STREETNAME");
                }
            }
        }
        private string _sTREETNAME;
    
        [DataMember]
        public string CITY
        {
            get { return _cITY; }
            set
            {
                if (_cITY != value)
                {
                    OnComplexPropertyChanging();
                    _cITY = value;
                    OnPropertyChanged("CITY");
                }
            }
        }
        private string _cITY;
    
        [DataMember]
        public string STATECODE
        {
            get { return _sTATECODE; }
            set
            {
                if (_sTATECODE != value)
                {
                    OnComplexPropertyChanging();
                    _sTATECODE = value;
                    OnPropertyChanged("STATECODE");
                }
            }
        }
        private string _sTATECODE;
    
        [DataMember]
        public string CodigoPostal
        {
            get { return _codigoPostal; }
            set
            {
                if (_codigoPostal != value)
                {
                    OnComplexPropertyChanging();
                    _codigoPostal = value;
                    OnPropertyChanged("CodigoPostal");
                }
            }
        }
        private string _codigoPostal;
    
        [DataMember]
        public string NUMBLDGS
        {
            get { return _nUMBLDGS; }
            set
            {
                if (_nUMBLDGS != value)
                {
                    OnComplexPropertyChanging();
                    _nUMBLDGS = value;
                    OnPropertyChanged("NUMBLDGS");
                }
            }
        }
        private string _nUMBLDGS;
    
        [DataMember]
        public string BLDGSCHEME
        {
            get { return _bLDGSCHEME; }
            set
            {
                if (_bLDGSCHEME != value)
                {
                    OnComplexPropertyChanging();
                    _bLDGSCHEME = value;
                    OnPropertyChanged("BLDGSCHEME");
                }
            }
        }
        private string _bLDGSCHEME;
    
        [DataMember]
        public string BLDGCLASS
        {
            get { return _bLDGCLASS; }
            set
            {
                if (_bLDGCLASS != value)
                {
                    OnComplexPropertyChanging();
                    _bLDGCLASS = value;
                    OnPropertyChanged("BLDGCLASS");
                }
            }
        }
        private string _bLDGCLASS;
    
        [DataMember]
        public string OCCSCHEME
        {
            get { return _oCCSCHEME; }
            set
            {
                if (_oCCSCHEME != value)
                {
                    OnComplexPropertyChanging();
                    _oCCSCHEME = value;
                    OnPropertyChanged("OCCSCHEME");
                }
            }
        }
        private string _oCCSCHEME;
    
        [DataMember]
        public string OCCTYPE
        {
            get { return _oCCTYPE; }
            set
            {
                if (_oCCTYPE != value)
                {
                    OnComplexPropertyChanging();
                    _oCCTYPE = value;
                    OnPropertyChanged("OCCTYPE");
                }
            }
        }
        private string _oCCTYPE;
    
        [DataMember]
        public Nullable<int> YEARBUILT
        {
            get { return _yEARBUILT; }
            set
            {
                if (_yEARBUILT != value)
                {
                    OnComplexPropertyChanging();
                    _yEARBUILT = value;
                    OnPropertyChanged("YEARBUILT");
                }
            }
        }
        private Nullable<int> _yEARBUILT;
    
        [DataMember]
        public int NUMSTORIES
        {
            get { return _nUMSTORIES; }
            set
            {
                if (_nUMSTORIES != value)
                {
                    OnComplexPropertyChanging();
                    _nUMSTORIES = value;
                    OnPropertyChanged("NUMSTORIES");
                }
            }
        }
        private int _nUMSTORIES;
    
        [DataMember]
        public string CNTRYSCHEME
        {
            get { return _cNTRYSCHEME; }
            set
            {
                if (_cNTRYSCHEME != value)
                {
                    OnComplexPropertyChanging();
                    _cNTRYSCHEME = value;
                    OnPropertyChanged("CNTRYSCHEME");
                }
            }
        }
        private string _cNTRYSCHEME;
    
        [DataMember]
        public string CNTRYCODE
        {
            get { return _cNTRYCODE; }
            set
            {
                if (_cNTRYCODE != value)
                {
                    OnComplexPropertyChanging();
                    _cNTRYCODE = value;
                    OnPropertyChanged("CNTRYCODE");
                }
            }
        }
        private string _cNTRYCODE;
    
        [DataMember]
        public Nullable<double> LATITUDE
        {
            get { return _lATITUDE; }
            set
            {
                if (_lATITUDE != value)
                {
                    OnComplexPropertyChanging();
                    _lATITUDE = value;
                    OnPropertyChanged("LATITUDE");
                }
            }
        }
        private Nullable<double> _lATITUDE;
    
        [DataMember]
        public Nullable<double> LONGITUDE
        {
            get { return _lONGITUDE; }
            set
            {
                if (_lONGITUDE != value)
                {
                    OnComplexPropertyChanging();
                    _lONGITUDE = value;
                    OnPropertyChanged("LONGITUDE");
                }
            }
        }
        private Nullable<double> _lONGITUDE;
    
        [DataMember]
        public Nullable<double> EQCV1LIMIT
        {
            get { return _eQCV1LIMIT; }
            set
            {
                if (_eQCV1LIMIT != value)
                {
                    OnComplexPropertyChanging();
                    _eQCV1LIMIT = value;
                    OnPropertyChanged("EQCV1LIMIT");
                }
            }
        }
        private Nullable<double> _eQCV1LIMIT;
    
        [DataMember]
        public string EQCV1LCUR
        {
            get { return _eQCV1LCUR; }
            set
            {
                if (_eQCV1LCUR != value)
                {
                    OnComplexPropertyChanging();
                    _eQCV1LCUR = value;
                    OnPropertyChanged("EQCV1LCUR");
                }
            }
        }
        private string _eQCV1LCUR;
    
        [DataMember]
        public string EQCV1DED
        {
            get { return _eQCV1DED; }
            set
            {
                if (_eQCV1DED != value)
                {
                    OnComplexPropertyChanging();
                    _eQCV1DED = value;
                    OnPropertyChanged("EQCV1DED");
                }
            }
        }
        private string _eQCV1DED;
    
        [DataMember]
        public Nullable<double> EQCV1VAL
        {
            get { return _eQCV1VAL; }
            set
            {
                if (_eQCV1VAL != value)
                {
                    OnComplexPropertyChanging();
                    _eQCV1VAL = value;
                    OnPropertyChanged("EQCV1VAL");
                }
            }
        }
        private Nullable<double> _eQCV1VAL;
    
        [DataMember]
        public string EQCV1VCUR
        {
            get { return _eQCV1VCUR; }
            set
            {
                if (_eQCV1VCUR != value)
                {
                    OnComplexPropertyChanging();
                    _eQCV1VCUR = value;
                    OnPropertyChanged("EQCV1VCUR");
                }
            }
        }
        private string _eQCV1VCUR;
    
        [DataMember]
        public Nullable<double> EQCV2LIMIT
        {
            get { return _eQCV2LIMIT; }
            set
            {
                if (_eQCV2LIMIT != value)
                {
                    OnComplexPropertyChanging();
                    _eQCV2LIMIT = value;
                    OnPropertyChanged("EQCV2LIMIT");
                }
            }
        }
        private Nullable<double> _eQCV2LIMIT;
    
        [DataMember]
        public string EQCV2LCUR
        {
            get { return _eQCV2LCUR; }
            set
            {
                if (_eQCV2LCUR != value)
                {
                    OnComplexPropertyChanging();
                    _eQCV2LCUR = value;
                    OnPropertyChanged("EQCV2LCUR");
                }
            }
        }
        private string _eQCV2LCUR;
    
        [DataMember]
        public string EQCV2DED
        {
            get { return _eQCV2DED; }
            set
            {
                if (_eQCV2DED != value)
                {
                    OnComplexPropertyChanging();
                    _eQCV2DED = value;
                    OnPropertyChanged("EQCV2DED");
                }
            }
        }
        private string _eQCV2DED;
    
        [DataMember]
        public Nullable<double> EQCV2VAL
        {
            get { return _eQCV2VAL; }
            set
            {
                if (_eQCV2VAL != value)
                {
                    OnComplexPropertyChanging();
                    _eQCV2VAL = value;
                    OnPropertyChanged("EQCV2VAL");
                }
            }
        }
        private Nullable<double> _eQCV2VAL;
    
        [DataMember]
        public string EQCV2VCUR
        {
            get { return _eQCV2VCUR; }
            set
            {
                if (_eQCV2VCUR != value)
                {
                    OnComplexPropertyChanging();
                    _eQCV2VCUR = value;
                    OnPropertyChanged("EQCV2VCUR");
                }
            }
        }
        private string _eQCV2VCUR;
    
        [DataMember]
        public Nullable<double> EQCV3LIMIT
        {
            get { return _eQCV3LIMIT; }
            set
            {
                if (_eQCV3LIMIT != value)
                {
                    OnComplexPropertyChanging();
                    _eQCV3LIMIT = value;
                    OnPropertyChanged("EQCV3LIMIT");
                }
            }
        }
        private Nullable<double> _eQCV3LIMIT;
    
        [DataMember]
        public string EQCV3LCUR
        {
            get { return _eQCV3LCUR; }
            set
            {
                if (_eQCV3LCUR != value)
                {
                    OnComplexPropertyChanging();
                    _eQCV3LCUR = value;
                    OnPropertyChanged("EQCV3LCUR");
                }
            }
        }
        private string _eQCV3LCUR;
    
        [DataMember]
        public string EQCV3DED
        {
            get { return _eQCV3DED; }
            set
            {
                if (_eQCV3DED != value)
                {
                    OnComplexPropertyChanging();
                    _eQCV3DED = value;
                    OnPropertyChanged("EQCV3DED");
                }
            }
        }
        private string _eQCV3DED;
    
        [DataMember]
        public Nullable<double> EQCV3VAL
        {
            get { return _eQCV3VAL; }
            set
            {
                if (_eQCV3VAL != value)
                {
                    OnComplexPropertyChanging();
                    _eQCV3VAL = value;
                    OnPropertyChanged("EQCV3VAL");
                }
            }
        }
        private Nullable<double> _eQCV3VAL;
    
        [DataMember]
        public string EQCV3DCUR
        {
            get { return _eQCV3DCUR; }
            set
            {
                if (_eQCV3DCUR != value)
                {
                    OnComplexPropertyChanging();
                    _eQCV3DCUR = value;
                    OnPropertyChanged("EQCV3DCUR");
                }
            }
        }
        private string _eQCV3DCUR;
    
        [DataMember]
        public string COINSURED
        {
            get { return _cOINSURED; }
            set
            {
                if (_cOINSURED != value)
                {
                    OnComplexPropertyChanging();
                    _cOINSURED = value;
                    OnPropertyChanged("COINSURED");
                }
            }
        }
        private string _cOINSURED;
    
        [DataMember]
        public string tipoOperacion
        {
            get { return _tipoOperacion; }
            set
            {
                if (_tipoOperacion != value)
                {
                    OnComplexPropertyChanging();
                    _tipoOperacion = value;
                    OnPropertyChanged("tipoOperacion");
                }
            }
        }
        private string _tipoOperacion;
    
        [DataMember]
        public Nullable<double> Participacion
        {
            get { return _participacion; }
            set
            {
                if (_participacion != value)
                {
                    OnComplexPropertyChanging();
                    _participacion = value;
                    OnPropertyChanged("Participacion");
                }
            }
        }
        private Nullable<double> _participacion;
    
        [DataMember]
        public string EQZONE
        {
            get { return _eQZONE; }
            set
            {
                if (_eQZONE != value)
                {
                    OnComplexPropertyChanging();
                    _eQZONE = value;
                    OnPropertyChanged("EQZONE");
                }
            }
        }
        private string _eQZONE;
    
        [DataMember]
        public string MUNICIPIO
        {
            get { return _mUNICIPIO; }
            set
            {
                if (_mUNICIPIO != value)
                {
                    OnComplexPropertyChanging();
                    _mUNICIPIO = value;
                    OnPropertyChanged("MUNICIPIO");
                }
            }
        }
        private string _mUNICIPIO;
    
        [DataMember]
        public string COLONIA
        {
            get { return _cOLONIA; }
            set
            {
                if (_cOLONIA != value)
                {
                    OnComplexPropertyChanging();
                    _cOLONIA = value;
                    OnPropertyChanged("COLONIA");
                }
            }
        }
        private string _cOLONIA;

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
    
        public static void RecordComplexOriginalValues(String parentPropertyName, SelectRiskBrowser_Result complexObject, ObjectChangeTracker changeTracker)
        {
            if (String.IsNullOrEmpty(parentPropertyName))
            {
                throw new ArgumentException("String parameter cannot be null or empty.", "parentPropertyName");
            }
    
            if (changeTracker == null)
            {
                throw new ArgumentNullException("changeTracker");
            }
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.ACCNTNUM", parentPropertyName), complexObject == null ? null : (object)complexObject.ACCNTNUM);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.ACCNTNAME", parentPropertyName), complexObject == null ? null : (object)complexObject.ACCNTNAME);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.POLICYNUM", parentPropertyName), complexObject == null ? null : (object)complexObject.POLICYNUM);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.LOBNAME", parentPropertyName), complexObject == null ? null : (object)complexObject.LOBNAME);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.INCEPTDATE", parentPropertyName), complexObject == null ? null : (object)complexObject.INCEPTDATE);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.EXPIREDATE", parentPropertyName), complexObject == null ? null : (object)complexObject.EXPIREDATE);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.UNDCOVAMT", parentPropertyName), complexObject == null ? null : (object)complexObject.UNDCOVAMT);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.UNDCOVCUR", parentPropertyName), complexObject == null ? null : (object)complexObject.UNDCOVCUR);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.PARTOF", parentPropertyName), complexObject == null ? null : (object)complexObject.PARTOF);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.PARTOFCUR", parentPropertyName), complexObject == null ? null : (object)complexObject.PARTOFCUR);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.POLICYTYPE", parentPropertyName), complexObject == null ? null : (object)complexObject.POLICYTYPE);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.MINDEDAMT", parentPropertyName), complexObject == null ? null : (object)complexObject.MINDEDAMT);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.MINDEDCUR", parentPropertyName), complexObject == null ? null : (object)complexObject.MINDEDCUR);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.MAXDEDAMT", parentPropertyName), complexObject == null ? null : (object)complexObject.MAXDEDAMT);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.MAXDEDCUR", parentPropertyName), complexObject == null ? null : (object)complexObject.MAXDEDCUR);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.BLANDEDAMT", parentPropertyName), complexObject == null ? null : (object)complexObject.BLANDEDAMT);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.BLANDEDCUR", parentPropertyName), complexObject == null ? null : (object)complexObject.BLANDEDCUR);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.BLANLIMAMT", parentPropertyName), complexObject == null ? null : (object)complexObject.BLANLIMAMT);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.BLANLIMCUR", parentPropertyName), complexObject == null ? null : (object)complexObject.BLANLIMCUR);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.ACCNTNUM1", parentPropertyName), complexObject == null ? null : (object)complexObject.ACCNTNUM1);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.LOCNUM", parentPropertyName), complexObject == null ? null : (object)complexObject.LOCNUM);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.LOCNAME", parentPropertyName), complexObject == null ? null : (object)complexObject.LOCNAME);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.STREETNAME", parentPropertyName), complexObject == null ? null : (object)complexObject.STREETNAME);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.CITY", parentPropertyName), complexObject == null ? null : (object)complexObject.CITY);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.STATECODE", parentPropertyName), complexObject == null ? null : (object)complexObject.STATECODE);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.CodigoPostal", parentPropertyName), complexObject == null ? null : (object)complexObject.CodigoPostal);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.NUMBLDGS", parentPropertyName), complexObject == null ? null : (object)complexObject.NUMBLDGS);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.BLDGSCHEME", parentPropertyName), complexObject == null ? null : (object)complexObject.BLDGSCHEME);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.BLDGCLASS", parentPropertyName), complexObject == null ? null : (object)complexObject.BLDGCLASS);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.OCCSCHEME", parentPropertyName), complexObject == null ? null : (object)complexObject.OCCSCHEME);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.OCCTYPE", parentPropertyName), complexObject == null ? null : (object)complexObject.OCCTYPE);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.YEARBUILT", parentPropertyName), complexObject == null ? null : (object)complexObject.YEARBUILT);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.NUMSTORIES", parentPropertyName), complexObject == null ? null : (object)complexObject.NUMSTORIES);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.CNTRYSCHEME", parentPropertyName), complexObject == null ? null : (object)complexObject.CNTRYSCHEME);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.CNTRYCODE", parentPropertyName), complexObject == null ? null : (object)complexObject.CNTRYCODE);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.LATITUDE", parentPropertyName), complexObject == null ? null : (object)complexObject.LATITUDE);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.LONGITUDE", parentPropertyName), complexObject == null ? null : (object)complexObject.LONGITUDE);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.EQCV1LIMIT", parentPropertyName), complexObject == null ? null : (object)complexObject.EQCV1LIMIT);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.EQCV1LCUR", parentPropertyName), complexObject == null ? null : (object)complexObject.EQCV1LCUR);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.EQCV1DED", parentPropertyName), complexObject == null ? null : (object)complexObject.EQCV1DED);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.EQCV1VAL", parentPropertyName), complexObject == null ? null : (object)complexObject.EQCV1VAL);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.EQCV1VCUR", parentPropertyName), complexObject == null ? null : (object)complexObject.EQCV1VCUR);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.EQCV2LIMIT", parentPropertyName), complexObject == null ? null : (object)complexObject.EQCV2LIMIT);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.EQCV2LCUR", parentPropertyName), complexObject == null ? null : (object)complexObject.EQCV2LCUR);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.EQCV2DED", parentPropertyName), complexObject == null ? null : (object)complexObject.EQCV2DED);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.EQCV2VAL", parentPropertyName), complexObject == null ? null : (object)complexObject.EQCV2VAL);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.EQCV2VCUR", parentPropertyName), complexObject == null ? null : (object)complexObject.EQCV2VCUR);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.EQCV3LIMIT", parentPropertyName), complexObject == null ? null : (object)complexObject.EQCV3LIMIT);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.EQCV3LCUR", parentPropertyName), complexObject == null ? null : (object)complexObject.EQCV3LCUR);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.EQCV3DED", parentPropertyName), complexObject == null ? null : (object)complexObject.EQCV3DED);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.EQCV3VAL", parentPropertyName), complexObject == null ? null : (object)complexObject.EQCV3VAL);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.EQCV3DCUR", parentPropertyName), complexObject == null ? null : (object)complexObject.EQCV3DCUR);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.COINSURED", parentPropertyName), complexObject == null ? null : (object)complexObject.COINSURED);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.tipoOperacion", parentPropertyName), complexObject == null ? null : (object)complexObject.tipoOperacion);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.Participacion", parentPropertyName), complexObject == null ? null : (object)complexObject.Participacion);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.EQZONE", parentPropertyName), complexObject == null ? null : (object)complexObject.EQZONE);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.MUNICIPIO", parentPropertyName), complexObject == null ? null : (object)complexObject.MUNICIPIO);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.COLONIA", parentPropertyName), complexObject == null ? null : (object)complexObject.COLONIA);
        }

        #endregion

    }
}
