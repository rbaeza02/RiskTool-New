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
    public partial class SISEInc_Result : INotifyComplexPropertyChanging, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public Nullable<int> id_pv
        {
            get { return _id_pv; }
            set
            {
                if (_id_pv != value)
                {
                    OnComplexPropertyChanging();
                    _id_pv = value;
                    OnPropertyChanged("id_pv");
                }
            }
        }
        private Nullable<int> _id_pv;
    
        [DataMember]
        public int cod_item
        {
            get { return _cod_item; }
            set
            {
                if (_cod_item != value)
                {
                    OnComplexPropertyChanging();
                    _cod_item = value;
                    OnPropertyChanged("cod_item");
                }
            }
        }
        private int _cod_item;
    
        [DataMember]
        public int cod_ind_cob
        {
            get { return _cod_ind_cob; }
            set
            {
                if (_cod_ind_cob != value)
                {
                    OnComplexPropertyChanging();
                    _cod_ind_cob = value;
                    OnPropertyChanged("cod_ind_cob");
                }
            }
        }
        private int _cod_ind_cob;
    
        [DataMember]
        public string cod_giro_negocio
        {
            get { return _cod_giro_negocio; }
            set
            {
                if (_cod_giro_negocio != value)
                {
                    OnComplexPropertyChanging();
                    _cod_giro_negocio = value;
                    OnPropertyChanged("cod_giro_negocio");
                }
            }
        }
        private string _cod_giro_negocio;
    
        [DataMember]
        public Nullable<int> cod_pais
        {
            get { return _cod_pais; }
            set
            {
                if (_cod_pais != value)
                {
                    OnComplexPropertyChanging();
                    _cod_pais = value;
                    OnPropertyChanged("cod_pais");
                }
            }
        }
        private Nullable<int> _cod_pais;
    
        [DataMember]
        public Nullable<int> cod_dpto
        {
            get { return _cod_dpto; }
            set
            {
                if (_cod_dpto != value)
                {
                    OnComplexPropertyChanging();
                    _cod_dpto = value;
                    OnPropertyChanged("cod_dpto");
                }
            }
        }
        private Nullable<int> _cod_dpto;
    
        [DataMember]
        public Nullable<int> cod_municipio
        {
            get { return _cod_municipio; }
            set
            {
                if (_cod_municipio != value)
                {
                    OnComplexPropertyChanging();
                    _cod_municipio = value;
                    OnPropertyChanged("cod_municipio");
                }
            }
        }
        private Nullable<int> _cod_municipio;
    
        [DataMember]
        public Nullable<int> cod_ciudad
        {
            get { return _cod_ciudad; }
            set
            {
                if (_cod_ciudad != value)
                {
                    OnComplexPropertyChanging();
                    _cod_ciudad = value;
                    OnPropertyChanged("cod_ciudad");
                }
            }
        }
        private Nullable<int> _cod_ciudad;
    
        [DataMember]
        public Nullable<int> cod_colonia
        {
            get { return _cod_colonia; }
            set
            {
                if (_cod_colonia != value)
                {
                    OnComplexPropertyChanging();
                    _cod_colonia = value;
                    OnPropertyChanged("cod_colonia");
                }
            }
        }
        private Nullable<int> _cod_colonia;
    
        [DataMember]
        public string txt_direccion
        {
            get { return _txt_direccion; }
            set
            {
                if (_txt_direccion != value)
                {
                    OnComplexPropertyChanging();
                    _txt_direccion = value;
                    OnPropertyChanged("txt_direccion");
                }
            }
        }
        private string _txt_direccion;
    
        [DataMember]
        public string nro_exterior
        {
            get { return _nro_exterior; }
            set
            {
                if (_nro_exterior != value)
                {
                    OnComplexPropertyChanging();
                    _nro_exterior = value;
                    OnPropertyChanged("nro_exterior");
                }
            }
        }
        private string _nro_exterior;
    
        [DataMember]
        public string nro_interior
        {
            get { return _nro_interior; }
            set
            {
                if (_nro_interior != value)
                {
                    OnComplexPropertyChanging();
                    _nro_interior = value;
                    OnPropertyChanged("nro_interior");
                }
            }
        }
        private string _nro_interior;
    
        [DataMember]
        public string cod_postal
        {
            get { return _cod_postal; }
            set
            {
                if (_cod_postal != value)
                {
                    OnComplexPropertyChanging();
                    _cod_postal = value;
                    OnPropertyChanged("cod_postal");
                }
            }
        }
        private string _cod_postal;
    
        [DataMember]
        public Nullable<int> cod_hazard_grade
        {
            get { return _cod_hazard_grade; }
            set
            {
                if (_cod_hazard_grade != value)
                {
                    OnComplexPropertyChanging();
                    _cod_hazard_grade = value;
                    OnPropertyChanged("cod_hazard_grade");
                }
            }
        }
        private Nullable<int> _cod_hazard_grade;
    
        [DataMember]
        public string cod_constr
        {
            get { return _cod_constr; }
            set
            {
                if (_cod_constr != value)
                {
                    OnComplexPropertyChanging();
                    _cod_constr = value;
                    OnPropertyChanged("cod_constr");
                }
            }
        }
        private string _cod_constr;
    
        [DataMember]
        public Nullable<double> imp_deremi_me
        {
            get { return _imp_deremi_me; }
            set
            {
                if (_imp_deremi_me != value)
                {
                    OnComplexPropertyChanging();
                    _imp_deremi_me = value;
                    OnPropertyChanged("imp_deremi_me");
                }
            }
        }
        private Nullable<double> _imp_deremi_me;
    
        [DataMember]
        public Nullable<double> imp_iva_me
        {
            get { return _imp_iva_me; }
            set
            {
                if (_imp_iva_me != value)
                {
                    OnComplexPropertyChanging();
                    _imp_iva_me = value;
                    OnPropertyChanged("imp_iva_me");
                }
            }
        }
        private Nullable<double> _imp_iva_me;
    
        [DataMember]
        public Nullable<double> imp_recfin_me
        {
            get { return _imp_recfin_me; }
            set
            {
                if (_imp_recfin_me != value)
                {
                    OnComplexPropertyChanging();
                    _imp_recfin_me = value;
                    OnPropertyChanged("imp_recfin_me");
                }
            }
        }
        private Nullable<double> _imp_recfin_me;
    
        [DataMember]
        public Nullable<int> cnt_pisos
        {
            get { return _cnt_pisos; }
            set
            {
                if (_cnt_pisos != value)
                {
                    OnComplexPropertyChanging();
                    _cnt_pisos = value;
                    OnPropertyChanged("cnt_pisos");
                }
            }
        }
        private Nullable<int> _cnt_pisos;
    
        [DataMember]
        public string cod_SIC
        {
            get { return _cod_SIC; }
            set
            {
                if (_cod_SIC != value)
                {
                    OnComplexPropertyChanging();
                    _cod_SIC = value;
                    OnPropertyChanged("cod_SIC");
                }
            }
        }
        private string _cod_SIC;
    
        [DataMember]
        public int cnt_pisos_sot
        {
            get { return _cnt_pisos_sot; }
            set
            {
                if (_cnt_pisos_sot != value)
                {
                    OnComplexPropertyChanging();
                    _cnt_pisos_sot = value;
                    OnPropertyChanged("cnt_pisos_sot");
                }
            }
        }
        private int _cnt_pisos_sot;
    
        [DataMember]
        public Nullable<int> aaaa_construccion
        {
            get { return _aaaa_construccion; }
            set
            {
                if (_aaaa_construccion != value)
                {
                    OnComplexPropertyChanging();
                    _aaaa_construccion = value;
                    OnPropertyChanged("aaaa_construccion");
                }
            }
        }
        private Nullable<int> _aaaa_construccion;
    
        [DataMember]
        public Nullable<int> zona_amis_terremoto
        {
            get { return _zona_amis_terremoto; }
            set
            {
                if (_zona_amis_terremoto != value)
                {
                    OnComplexPropertyChanging();
                    _zona_amis_terremoto = value;
                    OnPropertyChanged("zona_amis_terremoto");
                }
            }
        }
        private Nullable<int> _zona_amis_terremoto;
    
        [DataMember]
        public Nullable<double> imp_premio_me
        {
            get { return _imp_premio_me; }
            set
            {
                if (_imp_premio_me != value)
                {
                    OnComplexPropertyChanging();
                    _imp_premio_me = value;
                    OnPropertyChanged("imp_premio_me");
                }
            }
        }
        private Nullable<double> _imp_premio_me;
    
        [DataMember]
        public Nullable<int> zona_amis_huracan
        {
            get { return _zona_amis_huracan; }
            set
            {
                if (_zona_amis_huracan != value)
                {
                    OnComplexPropertyChanging();
                    _zona_amis_huracan = value;
                    OnPropertyChanged("zona_amis_huracan");
                }
            }
        }
        private Nullable<int> _zona_amis_huracan;
    
        [DataMember]
        public Nullable<double> Imp_participa_me
        {
            get { return _imp_participa_me; }
            set
            {
                if (_imp_participa_me != value)
                {
                    OnComplexPropertyChanging();
                    _imp_participa_me = value;
                    OnPropertyChanged("Imp_participa_me");
                }
            }
        }
        private Nullable<double> _imp_participa_me;
    
        [DataMember]
        public Nullable<int> cod_benef_1
        {
            get { return _cod_benef_1; }
            set
            {
                if (_cod_benef_1 != value)
                {
                    OnComplexPropertyChanging();
                    _cod_benef_1 = value;
                    OnPropertyChanged("cod_benef_1");
                }
            }
        }
        private Nullable<int> _cod_benef_1;
    
        [DataMember]
        public Nullable<int> cod_tipo_benef1
        {
            get { return _cod_tipo_benef1; }
            set
            {
                if (_cod_tipo_benef1 != value)
                {
                    OnComplexPropertyChanging();
                    _cod_tipo_benef1 = value;
                    OnPropertyChanged("cod_tipo_benef1");
                }
            }
        }
        private Nullable<int> _cod_tipo_benef1;
    
        [DataMember]
        public string txt_nombre_benef1
        {
            get { return _txt_nombre_benef1; }
            set
            {
                if (_txt_nombre_benef1 != value)
                {
                    OnComplexPropertyChanging();
                    _txt_nombre_benef1 = value;
                    OnPropertyChanged("txt_nombre_benef1");
                }
            }
        }
        private string _txt_nombre_benef1;
    
        [DataMember]
        public Nullable<int> cod_benef_2
        {
            get { return _cod_benef_2; }
            set
            {
                if (_cod_benef_2 != value)
                {
                    OnComplexPropertyChanging();
                    _cod_benef_2 = value;
                    OnPropertyChanged("cod_benef_2");
                }
            }
        }
        private Nullable<int> _cod_benef_2;
    
        [DataMember]
        public Nullable<int> cod_tipo_benef2
        {
            get { return _cod_tipo_benef2; }
            set
            {
                if (_cod_tipo_benef2 != value)
                {
                    OnComplexPropertyChanging();
                    _cod_tipo_benef2 = value;
                    OnPropertyChanged("cod_tipo_benef2");
                }
            }
        }
        private Nullable<int> _cod_tipo_benef2;
    
        [DataMember]
        public string txt_nombre_benef2
        {
            get { return _txt_nombre_benef2; }
            set
            {
                if (_txt_nombre_benef2 != value)
                {
                    OnComplexPropertyChanging();
                    _txt_nombre_benef2 = value;
                    OnPropertyChanged("txt_nombre_benef2");
                }
            }
        }
        private string _txt_nombre_benef2;
    
        [DataMember]
        public Nullable<int> cod_benef_3
        {
            get { return _cod_benef_3; }
            set
            {
                if (_cod_benef_3 != value)
                {
                    OnComplexPropertyChanging();
                    _cod_benef_3 = value;
                    OnPropertyChanged("cod_benef_3");
                }
            }
        }
        private Nullable<int> _cod_benef_3;
    
        [DataMember]
        public Nullable<int> cod_tipo_benef3
        {
            get { return _cod_tipo_benef3; }
            set
            {
                if (_cod_tipo_benef3 != value)
                {
                    OnComplexPropertyChanging();
                    _cod_tipo_benef3 = value;
                    OnPropertyChanged("cod_tipo_benef3");
                }
            }
        }
        private Nullable<int> _cod_tipo_benef3;
    
        [DataMember]
        public string txt_nombre_benef3
        {
            get { return _txt_nombre_benef3; }
            set
            {
                if (_txt_nombre_benef3 != value)
                {
                    OnComplexPropertyChanging();
                    _txt_nombre_benef3 = value;
                    OnPropertyChanged("txt_nombre_benef3");
                }
            }
        }
        private string _txt_nombre_benef3;

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
    
        public static void RecordComplexOriginalValues(String parentPropertyName, SISEInc_Result complexObject, ObjectChangeTracker changeTracker)
        {
            if (String.IsNullOrEmpty(parentPropertyName))
            {
                throw new ArgumentException("String parameter cannot be null or empty.", "parentPropertyName");
            }
    
            if (changeTracker == null)
            {
                throw new ArgumentNullException("changeTracker");
            }
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.id_pv", parentPropertyName), complexObject == null ? null : (object)complexObject.id_pv);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.cod_item", parentPropertyName), complexObject == null ? null : (object)complexObject.cod_item);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.cod_ind_cob", parentPropertyName), complexObject == null ? null : (object)complexObject.cod_ind_cob);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.cod_giro_negocio", parentPropertyName), complexObject == null ? null : (object)complexObject.cod_giro_negocio);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.cod_pais", parentPropertyName), complexObject == null ? null : (object)complexObject.cod_pais);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.cod_dpto", parentPropertyName), complexObject == null ? null : (object)complexObject.cod_dpto);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.cod_municipio", parentPropertyName), complexObject == null ? null : (object)complexObject.cod_municipio);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.cod_ciudad", parentPropertyName), complexObject == null ? null : (object)complexObject.cod_ciudad);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.cod_colonia", parentPropertyName), complexObject == null ? null : (object)complexObject.cod_colonia);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.txt_direccion", parentPropertyName), complexObject == null ? null : (object)complexObject.txt_direccion);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.nro_exterior", parentPropertyName), complexObject == null ? null : (object)complexObject.nro_exterior);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.nro_interior", parentPropertyName), complexObject == null ? null : (object)complexObject.nro_interior);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.cod_postal", parentPropertyName), complexObject == null ? null : (object)complexObject.cod_postal);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.cod_hazard_grade", parentPropertyName), complexObject == null ? null : (object)complexObject.cod_hazard_grade);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.cod_constr", parentPropertyName), complexObject == null ? null : (object)complexObject.cod_constr);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.imp_deremi_me", parentPropertyName), complexObject == null ? null : (object)complexObject.imp_deremi_me);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.imp_iva_me", parentPropertyName), complexObject == null ? null : (object)complexObject.imp_iva_me);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.imp_recfin_me", parentPropertyName), complexObject == null ? null : (object)complexObject.imp_recfin_me);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.cnt_pisos", parentPropertyName), complexObject == null ? null : (object)complexObject.cnt_pisos);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.cod_SIC", parentPropertyName), complexObject == null ? null : (object)complexObject.cod_SIC);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.cnt_pisos_sot", parentPropertyName), complexObject == null ? null : (object)complexObject.cnt_pisos_sot);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.aaaa_construccion", parentPropertyName), complexObject == null ? null : (object)complexObject.aaaa_construccion);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.zona_amis_terremoto", parentPropertyName), complexObject == null ? null : (object)complexObject.zona_amis_terremoto);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.imp_premio_me", parentPropertyName), complexObject == null ? null : (object)complexObject.imp_premio_me);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.zona_amis_huracan", parentPropertyName), complexObject == null ? null : (object)complexObject.zona_amis_huracan);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.Imp_participa_me", parentPropertyName), complexObject == null ? null : (object)complexObject.Imp_participa_me);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.cod_benef_1", parentPropertyName), complexObject == null ? null : (object)complexObject.cod_benef_1);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.cod_tipo_benef1", parentPropertyName), complexObject == null ? null : (object)complexObject.cod_tipo_benef1);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.txt_nombre_benef1", parentPropertyName), complexObject == null ? null : (object)complexObject.txt_nombre_benef1);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.cod_benef_2", parentPropertyName), complexObject == null ? null : (object)complexObject.cod_benef_2);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.cod_tipo_benef2", parentPropertyName), complexObject == null ? null : (object)complexObject.cod_tipo_benef2);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.txt_nombre_benef2", parentPropertyName), complexObject == null ? null : (object)complexObject.txt_nombre_benef2);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.cod_benef_3", parentPropertyName), complexObject == null ? null : (object)complexObject.cod_benef_3);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.cod_tipo_benef3", parentPropertyName), complexObject == null ? null : (object)complexObject.cod_tipo_benef3);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.txt_nombre_benef3", parentPropertyName), complexObject == null ? null : (object)complexObject.txt_nombre_benef3);
        }

        #endregion

    }
}