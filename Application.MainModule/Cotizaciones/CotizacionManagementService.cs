using Domain.MainModule.Cotizaciones;
using Domain.MainModule.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core;
using Domain.MainModule.Catalogos;
using System.Text.RegularExpressions;
using Domain.MainModule.Ubicaciones;
using Domain.MainModule.Entities.Util;
//using Domain.Core.Entities;
//using Domain.MainModule.CotizacionCoberturas;
//using Domain.MainModule.CotizacionCoberturaUbicaciones;

namespace Application.MainModule.Cotizaciones
{
    public class CotizacionManagementService : ICotizacionManagementService
    {
        #region Constructor

        ICotizacionRepository _cotizacionRepository;
        ICatalogoRepository _catalogoRepository;
        IUbicacionRepository _ubicacionRepository;
        //ICotizacionCoberturaRepository _cotizacionCoberturaRepository;
        //ICotizacionCoberturaUbicacionRepository _cotizacionCoberturaUbicacionRepository;

        public CotizacionManagementService(ICotizacionRepository cotizacionRepository, ICatalogoRepository catalogoRepository, IUbicacionRepository ubicacionRepository)
            //ICotizacionCoberturaRepository cotizacionCoberturaRepository, ICotizacionCoberturaUbicacionRepository cotizacionCoberturaUbicacionRepository)
        {
            if (cotizacionRepository == (ICotizacionRepository)null)
                throw new ArgumentNullException("CotizacionRepository");

            if (catalogoRepository == (ICotizacionRepository)null)
                throw new ArgumentNullException("CatalogoRepository");

            if (ubicacionRepository == (IUbicacionRepository)null)
                throw new ArgumentNullException("UbicacionRepository");

            //if (cotizacionCoberturaRepository == (ICotizacionCoberturaRepository)null)
            //    throw new ArgumentNullException("CotizacionCoberturaRepository");

            //if (cotizacionCoberturaUbicacionRepository == (ICotizacionCoberturaUbicacionRepository)null)
            //    throw new ArgumentNullException("CotizacionCoberturaUbicacionRepository");

            _cotizacionRepository = cotizacionRepository;
            _catalogoRepository = catalogoRepository;
            _ubicacionRepository = ubicacionRepository; 
            //_cotizacionCoberturaRepository = cotizacionCoberturaRepository;
            //_cotizacionCoberturaUbicacionRepository = cotizacionCoberturaUbicacionRepository;
        }

        #endregion
        
        #region Cotizacion

        public List<Cotizacion> FindCotizacionesbyFiltro(Nullable<DateTime> inicioVigencia, Nullable<DateTime> finVigencia, string rfc, int usuarioID, string nombre, string nroPol)
        {
            DesdeHastaRFCSpecification cotizacionSpec = new DesdeHastaRFCSpecification(inicioVigencia, finVigencia, rfc, usuarioID, nombre, nroPol);
            return _cotizacionRepository.FindCotizaciones(cotizacionSpec);
        }

        public Cotizacion FindCotizacionbyID(int cotizacionID)
        {
            Domain.MainModule.Cotizaciones.CotizacionIDSpecification cotizacionSpec = new Domain.MainModule.Cotizaciones.CotizacionIDSpecification(cotizacionID);
            return _cotizacionRepository.FindCotizacion(cotizacionSpec);
        }

        public void SaveCotizacion(Cotizacion cotizacion)
        {

            //Grabar Cotizacion 
            IUnitOfWork unitOfWork = _cotizacionRepository.UnitOfWork as IUnitOfWork;
            //cotizacion.usuarioid = 1; //Esto debe cambiar!!!

            if(!cotizacion.PrimerRiesgo)
            {
                cotizacion.PrimerRiesgoSubLinea = null;
                cotizacion.PrimerTipoCobertura = null;
                cotizacion.LimitPrimerRiesgo = null;
            }

            if (cotizacion.TipoOperacionID == 1)
                cotizacion.Participacion = 100D;

            if (cotizacion.CotizacionID == 0)
            {
                cotizacion.CotizacionID = _cotizacionRepository.LastCotizacionID() + 1;
                _cotizacionRepository.Add(cotizacion);
            }
            else
                _cotizacionRepository.Modify(cotizacion);

            unitOfWork.Commit();

            //Actualizar PrimerRiesgo
            _cotizacionRepository.execUpdatePrimerRiesgo(cotizacion.CotizacionID);

            //Grabar SubLineas de negocio
            _cotizacionRepository.execUpdateCotizacionSubLineaNegocio(cotizacion.CotizacionID, cotizacion.SubLineaNegocioToXML().InnerXml, cotizacion.IncendioToXML().InnerXml, cotizacion.PrimerRiesgoToXML().InnerXml);

            //Insertar Valores Iniciales Diversos + RC 
            _cotizacionRepository.execUpdateCotizacionDiversos(cotizacion.CotizacionID);

            //Insertar Valores Iniciales por ubicacion para Diversos
            _cotizacionRepository.execUpdateCotizacionDiversosUbi(cotizacion.CotizacionID);

        }

        #endregion

        public List<Ubicacion> FindValoresUbicacionesbyCotizacionID(int cotizacionID)
        {
            List<Ubicacion> ubicaciones = _ubicacionRepository.FindUbicacionesValores(cotizacionID);
           
            ubicaciones.ForEach(x => x.bk_tr_CotizacionCoberturaUbi.ToList().ForEach(y =>
            {
                y.NombreCobertura = y.bk_tc_Cobertura.nombre;
                y.isPct_Mes = y.bk_tc_Cobertura.isMes.HasValue ? (y.bk_tc_Cobertura.isMes.Value ? true : false) : y.bk_tc_Cobertura.isPct.HasValue ? (y.bk_tc_Cobertura.isPct.Value ? true : false) : false;
                y.isPct = y.bk_tc_Cobertura.isPct.HasValue ? (y.bk_tc_Cobertura.isPct.Value ? true : false) : false;
                y.isMes = y.bk_tc_Cobertura.isMes.HasValue ? (y.bk_tc_Cobertura.isMes.Value ? true : false) : false;
            }));

            ubicaciones.ForEach(x => x.bk_tr_CotizacionSubLineaUbi.ToList().ForEach(y => {
                y.NombreSubLinea = y.bk_tc_SubLineaNegocio.nombre;
            }));
            return ubicaciones;//_ubicacionRepository.FindUbicacionesValores(cotizacionID);
            
        }

        public void SaveValores(List<Ubicacion> ubicaciones, int cotizacionID)
        {
            IUnitOfWork unitOfWork = _ubicacionRepository.UnitOfWork as IUnitOfWork;
            Ubicacion ubic;
            CotizacionCoberturaUbi cob;
            CotizacionSubLineaUbi sub;

            //Application.MainModule.Utils.Log.WriteLog(@"D:\Data\trace.txt", "Paso1");

            foreach (Ubicacion ubicacion in ubicaciones)
            {
                //Application.MainModule.Utils.Log.WriteLog(@"D:\Data\trace.txt", "Paso2_" + ubicacion.UbicacionID.ToString());
                ubic = _ubicacionRepository.FindUbicacion(ubicacion.UbicacionID);

                //Application.MainModule.Utils.Log.WriteLog(@"D:\Data\trace.txt", "Paso21_" + ubicacion.UbicacionID.ToString());
                if (ubicacion.bk_te_CotizacionUbicacion.Count() > 0)
                {
                    ubic.bk_te_CotizacionUbicacion[0].ComisionIncendio = ubicacion.bk_te_CotizacionUbicacion[0].ComisionIncendio;
                    ubic.bk_te_CotizacionUbicacion[0].DeducibleUSD = ubicacion.bk_te_CotizacionUbicacion[0].DeducibleUSD;
                    ubic.bk_te_CotizacionUbicacion[0].GrupoIncendioID = ubicacion.bk_te_CotizacionUbicacion[0].GrupoIncendioID;
                    ubic.bk_te_CotizacionUbicacion[0].GradoExposicionID = ubicacion.bk_te_CotizacionUbicacion[0].GradoExposicionID;
                    ubic.bk_te_CotizacionUbicacion[0].ProteccionPublicaID = ubicacion.bk_te_CotizacionUbicacion[0].ProteccionPublicaID;
                    ubic.bk_te_CotizacionUbicacion[0].ProteccionPrivadaID = ubicacion.bk_te_CotizacionUbicacion[0].ProteccionPrivadaID;
                    ubic.bk_te_CotizacionUbicacion[0].ExposicionIDInterna = ubicacion.bk_te_CotizacionUbicacion[0].ExposicionIDInterna;
                    ubic.bk_te_CotizacionUbicacion[0].ExposicionIDExterna = ubicacion.bk_te_CotizacionUbicacion[0].ExposicionIDExterna;
                    ubic.bk_te_CotizacionUbicacion[0].ExposicionIDAgua = ubicacion.bk_te_CotizacionUbicacion[0].ExposicionIDAgua;
                    ubic.bk_te_CotizacionUbicacion[0].ExposicionIDHumo = ubicacion.bk_te_CotizacionUbicacion[0].ExposicionIDHumo;
                    ubic.bk_te_CotizacionUbicacion[0].CoaseguroTerremoto = ubicacion.bk_te_CotizacionUbicacion[0].CoaseguroTerremoto;

                    //Application.MainModule.Utils.Log.WriteLog(@"D:\Data\trace.txt", "Paso22_" + ubicacion.UbicacionID.ToString());
                }

                //Application.MainModule.Utils.Log.WriteLog(@"D:\Data\trace.txt", "Paso23_" + ubicacion.UbicacionID.ToString());
                ubicacion.bk_tr_CotizacionCoberturaUbi.ToList().ForEach(x =>
                {
                    cob = ubic.bk_tr_CotizacionCoberturaUbi.Where(y => y.CoberturaID == x.CoberturaID && y.CotizacionID == x.CotizacionID).FirstOrDefault();
                    cob.valorAdicional = x.valorAdicional;
                    cob.ValorAsegurable = x.ValorAsegurable;
                });

                ubicacion.bk_tr_CotizacionSubLineaUbi.ToList().ForEach(x =>
                {
                    sub = ubic.bk_tr_CotizacionSubLineaUbi.Where(y => y.SubLineaNegocioID == x.SubLineaNegocioID && y.CotizacionID == x.CotizacionID).FirstOrDefault();                    
                    sub.ValorAsegurable = x.ValorAsegurable;
                });

                _ubicacionRepository.Modify(ubic);

                //Application.MainModule.Utils.Log.WriteLog(@"D:\Data\trace.txt", "Paso3_" + ubicacion.UbicacionID.ToString());
            }

            unitOfWork.Commit();

            //Application.MainModule.Utils.Log.WriteLog(@"D:\Data\trace.txt", "Paso4");
            //Actualizar PrimerRiesgo
            _cotizacionRepository.execUpdatePrimerRiesgo(cotizacionID);

            //Application.MainModule.Utils.Log.WriteLog(@"D:\Data\trace.txt", "Paso5");
            //Insertar Valores Iniciales por ubicacion para Diversos
            _cotizacionRepository.execUpdateCotizacionDiversosUbi(cotizacionID);

            //Application.MainModule.Utils.Log.WriteLog(@"D:\Data\trace.txt", "Paso6");

        }
        
        public Cotizacion FindCotizacionDiversobyID(int cotizacionID)
        {
            Cotizacion cot = _cotizacionRepository.FindCotizacionDiversos(cotizacionID);
            AddCotizacionEquipo(cot);

            foreach (var item in cot.bk_te_CotizacionDeducible)
            {
                item.NombreTarifa = item.bk_tc_Tarifa.NombreDeducible;
            }

            return cot;
        }

        private void AddCotizacionEquipo(Cotizacion cot)
        {
            if (cot.bk_te_CotizacionEqContratista != null)
            {
                cot.bk_tw_EqContratistaEquipo.ToList().ForEach(x => { x.Visible = true; x.Eliminado = false; });
                int multiplicador = Convert.ToInt32(Math.Floor(cot.bk_tw_EqContratistaEquipo.Count() / 20.0) + 1);

                for (int i = 20 * multiplicador - cot.bk_tw_EqContratistaEquipo.Count(); i > 0; i--)
                {
                    cot.bk_tw_EqContratistaEquipo.Add(new EqContratistaEquipo() { EqContratistaEquipoID = 0, Inciso = 0 - i, CotizacionID = cot.CotizacionID, Visible = false });
                }
            }
        }

        public Cotizacion FindCotizacionRCbyID(int cotizacionID)
        {
            double maxVaorUSD = Convert.ToDouble(_catalogoRepository.GetGlobalParam((int)globalParam.MaxPagoVolRC));
            Cotizacion cot = _cotizacionRepository.FindCotizacionRC(cotizacionID);
            
            //Valor maximo para la cobertura (24 mil USD)
            cot.bk_te_CotizacionRCActInm.MaxPagoVoluntarioUrgenciaMedica = cot.MonedaID == 1 ? maxVaorUSD * cot.TipoCambio.Value : maxVaorUSD;

            //Deducibles
            if (cot.bk_te_CotizacionDeducible != null)
            {
                CotizacionDeducible cotDeduc;
                
                cotDeduc = cot.bk_te_CotizacionDeducible.Where(x => x.SubLineaNegocioID == 9).FirstOrDefault();
                cot.bk_te_CotizacionRCActInm.DeducibleValorID = cotDeduc.DeducibleValorID;
                cot.bk_te_CotizacionRCActInm.DeducibleUnidadID = cotDeduc.UnidadDeducibleID;
                cot.bk_te_CotizacionRCActInm.DeducibleAplicaID = cotDeduc.DeducibleAplicaID;
                cot.bk_te_CotizacionRCActInm.DeducibleValorIDMin = cotDeduc.DeducibleValorIDMinimo;
                cot.bk_te_CotizacionRCActInm.DeducibleUnidadIDMin = cotDeduc.UnidadDeducibleIDMinimo;
                
                cotDeduc = cot.bk_te_CotizacionDeducible.Where(x => x.SubLineaNegocioID == 30).FirstOrDefault();
                cot.bk_te_CotizacionRCActInm.ArrendatarioDeducibleValorID = cotDeduc.DeducibleValorID;
                cot.bk_te_CotizacionRCActInm.ArrendatarioDeducibleUnidadID = cotDeduc.UnidadDeducibleID;
                cot.bk_te_CotizacionRCActInm.ArrendatarioDeducibleAplicaID = cotDeduc.DeducibleAplicaID;
                cot.bk_te_CotizacionRCActInm.ArrendatarioDeducibleValorIDMin = cotDeduc.DeducibleValorIDMinimo;
                cot.bk_te_CotizacionRCActInm.ArrendatarioDeducibleUnidadIDMin = cotDeduc.UnidadDeducibleIDMinimo;

                cotDeduc = cot.bk_te_CotizacionDeducible.Where(x => x.SubLineaNegocioID == 31).FirstOrDefault();
                cot.bk_te_CotizacionRCActInm.BienesDeducibleValorID = cotDeduc.DeducibleValorID;
                cot.bk_te_CotizacionRCActInm.BienesDeducibleUnidadID = cotDeduc.UnidadDeducibleID;
                cot.bk_te_CotizacionRCActInm.BienesDeducibleAplicaID = cotDeduc.DeducibleAplicaID;
                cot.bk_te_CotizacionRCActInm.BienesDeducibleValorIDMin = cotDeduc.DeducibleValorIDMinimo;
                cot.bk_te_CotizacionRCActInm.BienesDeducibleUnidadIDMin = cotDeduc.UnidadDeducibleIDMinimo;

                switch (cot.bk_te_CotizacionRCActInm.RCActInmCruzadaID)
                {
                    case 1: cotDeduc = cot.bk_te_CotizacionDeducible.Where(x => x.TarifaID == 24).FirstOrDefault(); break;
                    case 2: cotDeduc = cot.bk_te_CotizacionDeducible.Where(x => x.TarifaID == 25).FirstOrDefault(); break;
                    case 3: cotDeduc = cot.bk_te_CotizacionDeducible.Where(x => x.TarifaID == 26).FirstOrDefault(); break;
                    case 4: cotDeduc = cot.bk_te_CotizacionDeducible.Where(x => x.TarifaID == 27).FirstOrDefault(); break;
                }

                cot.bk_te_CotizacionRCActInm.CruzadaDeducibleValorID = cotDeduc.DeducibleValorID;
                cot.bk_te_CotizacionRCActInm.CruzadaDeducibleUnidadID = cotDeduc.UnidadDeducibleID;
                cot.bk_te_CotizacionRCActInm.CruzadaDeducibleAplicaID = cotDeduc.DeducibleAplicaID;
                cot.bk_te_CotizacionRCActInm.CruzadaDeducibleValorIDMin = cotDeduc.DeducibleValorIDMinimo;
                cot.bk_te_CotizacionRCActInm.CruzadaDeducibleUnidadIDMin = cotDeduc.UnidadDeducibleIDMinimo;

                cotDeduc = cot.bk_te_CotizacionDeducible.Where(x => x.SubLineaNegocioID == 32).FirstOrDefault();
                cot.bk_te_CotizacionRCActInm.ContaminacionDeducibleValorID = cotDeduc.DeducibleValorID;
                cot.bk_te_CotizacionRCActInm.ContaminacionDeducibleUnidadID = cotDeduc.UnidadDeducibleID;
                cot.bk_te_CotizacionRCActInm.ContaminacionDeducibleAplicaID = cotDeduc.DeducibleAplicaID;
                cot.bk_te_CotizacionRCActInm.ContaminacionDeducibleValorIDMin = cotDeduc.DeducibleValorIDMinimo;
                cot.bk_te_CotizacionRCActInm.ContaminacionDeducibleUnidadIDMin = cotDeduc.UnidadDeducibleIDMinimo;

                cotDeduc = cot.bk_te_CotizacionDeducible.Where(x => x.SubLineaNegocioID == 33).FirstOrDefault();
                cot.bk_te_CotizacionRCActInm.AsumidaDeducibleValorID = cotDeduc.DeducibleValorID;
                cot.bk_te_CotizacionRCActInm.AsumidaDeducibleUnidadID = cotDeduc.UnidadDeducibleID;
                cot.bk_te_CotizacionRCActInm.AsumidaDeducibleAplicaID = cotDeduc.DeducibleAplicaID;
                cot.bk_te_CotizacionRCActInm.AsumidaDeducibleValorIDMin = cotDeduc.DeducibleValorIDMinimo;
                cot.bk_te_CotizacionRCActInm.AsumidaDeducibleUnidadIDMin = cotDeduc.UnidadDeducibleIDMinimo;

                cotDeduc = cot.bk_te_CotizacionDeducible.Where(x => x.SubLineaNegocioID == 34).FirstOrDefault();
                cot.bk_te_CotizacionRCActInm.ContIndependienteDeducibleValorID = cotDeduc.DeducibleValorID;
                cot.bk_te_CotizacionRCActInm.ContIndependienteDeducibleUnidadID = cotDeduc.UnidadDeducibleID;
                cot.bk_te_CotizacionRCActInm.ContIndependienteDeducibleAplicaID = cotDeduc.DeducibleAplicaID;
                cot.bk_te_CotizacionRCActInm.ContIndependienteDeducibleValorIDMin = cotDeduc.DeducibleValorIDMinimo;
                cot.bk_te_CotizacionRCActInm.ContIndependienteDeducibleUnidadIDMin = cotDeduc.UnidadDeducibleIDMinimo;

                //Productos en Mexico
                if(cot.bk_te_CotizacionRCTrabajoTerm != null)
                { 
                    cotDeduc = cot.bk_te_CotizacionDeducible.Where(x => x.TarifaID == 28).FirstOrDefault();
                    cot.bk_te_CotizacionRCTrabajoTerm.DeducibleValorID = cotDeduc.DeducibleValorID;
                    cot.bk_te_CotizacionRCTrabajoTerm.DeducibleUnidadID = cotDeduc.UnidadDeducibleID;
                    cot.bk_te_CotizacionRCTrabajoTerm.DeducibleAplicaID = cotDeduc.DeducibleAplicaID;
                    cot.bk_te_CotizacionRCTrabajoTerm.DeducibleValorIDMin = cotDeduc.DeducibleValorIDMinimo;
                    cot.bk_te_CotizacionRCTrabajoTerm.DeducibleUnidadIDMin = cotDeduc.UnidadDeducibleIDMinimo;

                    cotDeduc = cot.bk_te_CotizacionDeducible.Where(x => x.TarifaID == 29).FirstOrDefault();
                    cot.bk_te_CotizacionRCTrabajoTerm.UnionMezclaDeducibleValorID = cotDeduc.DeducibleValorID;
                    cot.bk_te_CotizacionRCTrabajoTerm.UnionMezclaDeducibleUnidadID = cotDeduc.UnidadDeducibleID;
                    cot.bk_te_CotizacionRCTrabajoTerm.UnionMezclaDeducibleAplicaID = cotDeduc.DeducibleAplicaID;
                    cot.bk_te_CotizacionRCTrabajoTerm.UnionMezclaDeducibleValorIDMin = cotDeduc.DeducibleValorIDMinimo;
                    cot.bk_te_CotizacionRCTrabajoTerm.UnionMezclaDeducibleUnidadIDMin = cotDeduc.UnidadDeducibleIDMinimo;
                }
            }

            return cot;
        }

        public Cotizacion FindCotizacionRCExtRecallbyID(int cotizacionID)
        {
            Cotizacion cot = _cotizacionRepository.FindCotizacionRCExtRecall(cotizacionID);
            
            if(cot != null)
                FillCotizacionRCRecall(cot);

            return cot;
        }

        private void FillCotizacionRCRecall(Cotizacion cot)
        {
            List<Pais> p = _catalogoRepository.GetPaises(false);

            foreach (var anterior in cot.bk_te_CotizacionRCProductoExtPais)
            {
                anterior.NombrePais = p.Where(x => x.PaisID == anterior.paisID).FirstOrDefault().Descripcion;
            }

            var a = p.GroupJoin(cot.bk_te_CotizacionRCProductoExtPais, pa => pa.PaisID, co => co.paisID, (x, y) => new { P = x, C = y }).SelectMany(x => x.C.DefaultIfEmpty(), (x, y) => new { P = x.P, C = y }).Where(y => y.C == null).Select(x => new CotizacionRCProductoExtPais { CotizacionID = cot.CotizacionID, paisID = x.P.PaisID, NombrePais = x.P.Descripcion, isPhysicalLocation = false });
            a.ToList().ForEach(x => cot.bk_te_CotizacionRCProductoExtPais.Add(x));
        }

        public SelectAdjustedRateRang_Result FindCotizacionRCRecallRate(int categoryID, int exposureTypeID, int limitID)
        {
            return _cotizacionRepository.FinAdjustedRateRang(categoryID, exposureTypeID, limitID);            
        }

        public Cotizacion FindCotizacionTransportebyID(int cotizacionID)
        {
            Cotizacion cot = _cotizacionRepository.FindCotizacionTransporte(cotizacionID);

            cot.bk_te_CotizacionTransConceptoEvaluacion.ToList().ForEach(x => { x.Nombre = x.bk_tw_TransConceptoEval.nombre; x.Pct = x.bk_tw_TransConceptoEval.pct; });

            return cot;
        }
        
        public Cotizacion SaveCotizacionDiversos(Cotizacion cotizacion)
        {
            //Grabar Cotizacion 
            IUnitOfWork unitOfWork = _cotizacionRepository.UnitOfWork as IUnitOfWork;

            //Cotizacion cotDatos = _cotizacionRepository.FindCotizacion(cotizacion.CotizacionID);
            
            Cotizacion cotDatos = _cotizacionRepository.FindCotizacionDiversos(cotizacion.CotizacionID);
            cotDatos.bk_te_CotizacionCristal = cotizacion.bk_te_CotizacionCristal;
            cotDatos.bk_te_CotizacionAnuncio = cotizacion.bk_te_CotizacionAnuncio;
            cotDatos.bk_te_CotizacionRobo = cotizacion.bk_te_CotizacionRobo;
            cotDatos.bk_te_CotizacionDinVal = cotizacion.bk_te_CotizacionDinVal;
            cotDatos.bk_te_CotizacionCaldera = cotizacion.bk_te_CotizacionCaldera;
            cotDatos.bk_te_CotizacionCalderaPC = cotizacion.bk_te_CotizacionCalderaPC;
            cotDatos.bk_te_CotizacionRotMaq = cotizacion.bk_te_CotizacionRotMaq;
            cotDatos.bk_te_CotizacionRotMaqPC = cotizacion.bk_te_CotizacionRotMaqPC;
            cotDatos.bk_te_CotizacionEqContratista = cotizacion.bk_te_CotizacionEqContratista;
            cotDatos.bk_te_CotizacionRCEqContratista = cotizacion.bk_te_CotizacionRCEqContratista;
            cotDatos.bk_te_CotizacionEqElec = cotizacion.bk_te_CotizacionEqElec;            
            cotDatos.bk_te_CotizacionEqElecPortExt = cotizacion.bk_te_CotizacionEqElecPortExt;
            cotDatos.bk_te_CotizacionEqElecCostoOper = cotizacion.bk_te_CotizacionEqElecCostoOper;
            cotDatos.bk_te_CotizacionEqElecMovil = cotizacion.bk_te_CotizacionEqElecMovil;

            //Deducibles generales                    
            cotDatos.bk_te_CotizacionDeducible.Clear();
            cotizacion.bk_te_CotizacionDeducible.ToList().ForEach(x => {           
                cotDatos.bk_te_CotizacionDeducible.Add(x);                 
            });

           

            if (cotizacion.bk_tw_EqContratistaEquipo != null)
            {
                if (cotizacion.bk_tw_EqContratistaEquipo.Where(x => x.Visible).Count() > 0)
                {
                    EqContratistaEquipo equipo;
                    int inciso = 1;
                    int maxID = _cotizacionRepository.LastCotizacionEqContratistaEquipoID() + 1;
                    cotizacion.bk_tw_EqContratistaEquipo.Where(x => x.Visible && x.Valor.HasValue).ToList().ForEach(x =>
                    {
                        x.Inciso = inciso;
                        inciso++;

                        if (x.EqContratistaEquipoID == 0)
                        {
                            x.EqContratistaEquipoID = maxID;
                            maxID++;
                            cotDatos.bk_tw_EqContratistaEquipo.Add(x);
                        }
                        else
                        {
                            equipo = cotDatos.bk_tw_EqContratistaEquipo.Where(y => y.EqContratistaEquipoID == x.EqContratistaEquipoID).SingleOrDefault();
                            equipo.CotizacionID = x.CotizacionID;
                            equipo.Descripcion = x.Descripcion;
                            equipo.Inciso = x.Inciso;
                            equipo.Marca = x.Marca;
                            equipo.nroSerie = x.nroSerie;
                            equipo.Valor = x.Valor;
                        }


                    });
                }

                cotizacion.bk_tw_EqContratistaEquipo.Where(x => x.Eliminado).ToList().ForEach(x =>
                {                    
                    cotDatos.bk_tw_EqContratistaEquipo.Remove(cotDatos.bk_tw_EqContratistaEquipo.Where(y => y.EqContratistaEquipoID == x.EqContratistaEquipoID).FirstOrDefault());
                });
            }

                    
            _cotizacionRepository.Modify(cotDatos);

            unitOfWork.Commit();

            //Deducibles aplica si no es CMIC para eq contratista (se insertan por default los valores)
            if (cotDatos.bk_te_CotizacionEqContratista != null)
                if (cotDatos.bk_te_CotizacionEqContratista.isCMICDeduc)
                    _cotizacionRepository.execUpdateCMICDeducibles(cotizacion.CotizacionID);

            _cotizacionRepository.execDeleteCotizacionEqContratistaEquipo(); //Eliminar de la BD los que no tienen cotizacionID
            AddCotizacionEquipo(cotDatos); //Agregamos adicionales para la parte visual no para la BD
                        
            _cotizacionRepository.execProcesarDiversos(cotizacion.CotizacionID); //Procesamos para obtener cuota y prima

            if (cotDatos.bk_te_CotizacionEqContratista != null)
            {
                ResultadoPrima eq = _cotizacionRepository.GetPrimaCuota((int)enumTableCotizacion.EqContratista, cotizacion.CotizacionID);
                cotDatos.bk_te_CotizacionEqContratista.Cuota = eq.Cuota;
                cotDatos.bk_te_CotizacionEqContratista.Prima = eq.Prima;
            }
                        

            if (cotDatos.bk_te_CotizacionRCEqContratista != null)
            {
                ResultadoPrima rcEq = _cotizacionRepository.GetPrimaCuota((int)enumTableCotizacion.RCEqContratista, cotizacion.CotizacionID);
                cotDatos.bk_te_CotizacionRCEqContratista.Cuota = rcEq.Cuota;
                cotDatos.bk_te_CotizacionRCEqContratista.Prima = rcEq.Prima;
            }

            return cotDatos;
        }

        public Cotizacion SaveParamCotizacion(double comision, double otrosGastosAdq, double utilidad, double gastosAdm, int cotizacionID)
        {
            IUnitOfWork unitOfWork = _cotizacionRepository.UnitOfWork as IUnitOfWork;

            Cotizacion cot = _cotizacionRepository.FindCotizacionbyID(cotizacionID);
            cot.Comision = comision;
            cot.OtrosGastosAdq = otrosGastosAdq;
            cot.Utilidad = utilidad;
            cot.GastosAdministracion = gastosAdm;
            cot.GastosAdquisicion = otrosGastosAdq + comision;


            _cotizacionRepository.Modify(cot);

            unitOfWork.Commit();

            _cotizacionRepository.execUpdateCotizacionDiversosUbi(cotizacionID); //Actualizamos la comision en los ramos
            _cotizacionRepository.execProcesarDiversos(cotizacionID); //Procesamos para obtener cuota y prima

            return _cotizacionRepository.FindCotizacionEQbyID(cotizacionID);

        }


        public Cotizacion SaveCotizacionRC(Cotizacion cotizacion)
        {
            //Grabar Cotizacion 
            IUnitOfWork unitOfWork = _cotizacionRepository.UnitOfWork as IUnitOfWork;

            Cotizacion cotDatos = _cotizacionRepository.FindCotizacionRC(cotizacion.CotizacionID);
            cotDatos.bk_te_CotizacionRCActInm = cotizacion.bk_te_CotizacionRCActInm;
            //cotDatos.bk_te_CotizacionRCProducto = cotizacion.bk_te_CotizacionRCProducto;
            cotDatos.bk_te_CotizacionRCTrabajoTerm = cotizacion.bk_te_CotizacionRCTrabajoTerm;
            cotDatos.bk_te_CotizacionRCTaller = cotizacion.bk_te_CotizacionRCTaller;
            cotDatos.bk_te_CotizacionRCEstacionamiento = cotizacion.bk_te_CotizacionRCEstacionamiento;
            cotDatos.bk_te_CotizacionRCVehiculoExc = cotizacion.bk_te_CotizacionRCVehiculoExc;
            cotDatos.bk_te_CotizacionRCConstruccion = cotizacion.bk_te_CotizacionRCConstruccion;
            cotDatos.bk_te_CotizacionRCHoteleria = cotizacion.bk_te_CotizacionRCHoteleria;
            cotDatos.bk_te_CotizacionRCAdicional = cotizacion.bk_te_CotizacionRCAdicional;

            if (cotDatos.bk_te_CotizacionDeducible != null)
            {
                CotizacionDeducible cotDeduc;

                cotDeduc = cotDatos.bk_te_CotizacionDeducible.Where(x => x.SubLineaNegocioID == 9).FirstOrDefault();
                cotDeduc.DeducibleValorID = cotDatos.bk_te_CotizacionRCActInm.DeducibleValorID;
                cotDeduc.UnidadDeducibleID = cotDatos.bk_te_CotizacionRCActInm.DeducibleUnidadID;
                cotDeduc.DeducibleAplicaID = cotDatos.bk_te_CotizacionRCActInm.DeducibleAplicaID;
                cotDeduc.DeducibleValorIDMinimo = cotDatos.bk_te_CotizacionRCActInm.DeducibleValorIDMin;
                cotDeduc.UnidadDeducibleIDMinimo = cotDatos.bk_te_CotizacionRCActInm.DeducibleUnidadIDMin;

                cotDeduc = cotDatos.bk_te_CotizacionDeducible.Where(x => x.SubLineaNegocioID == 30).FirstOrDefault();
                cotDeduc.DeducibleValorID = cotDatos.bk_te_CotizacionRCActInm.ArrendatarioDeducibleValorID;
                cotDeduc.UnidadDeducibleID = cotDatos.bk_te_CotizacionRCActInm.ArrendatarioDeducibleUnidadID;
                cotDeduc.DeducibleAplicaID = cotDatos.bk_te_CotizacionRCActInm.ArrendatarioDeducibleAplicaID;
                cotDeduc.DeducibleValorIDMinimo = cotDatos.bk_te_CotizacionRCActInm.ArrendatarioDeducibleValorIDMin;
                cotDeduc.UnidadDeducibleIDMinimo = cotDatos.bk_te_CotizacionRCActInm.ArrendatarioDeducibleUnidadIDMin;

                cotDeduc = cotDatos.bk_te_CotizacionDeducible.Where(x => x.SubLineaNegocioID == 31).FirstOrDefault();
                cotDeduc.DeducibleValorID = cotDatos.bk_te_CotizacionRCActInm.BienesDeducibleValorID;
                cotDeduc.UnidadDeducibleID = cotDatos.bk_te_CotizacionRCActInm.BienesDeducibleUnidadID;
                cotDeduc.DeducibleAplicaID = cotDatos.bk_te_CotizacionRCActInm.BienesDeducibleAplicaID;
                cotDeduc.DeducibleValorIDMinimo = cotDatos.bk_te_CotizacionRCActInm.BienesDeducibleValorIDMin;
                cotDeduc.UnidadDeducibleIDMinimo = cotDatos.bk_te_CotizacionRCActInm.BienesDeducibleUnidadIDMin;

                switch (cotDatos.bk_te_CotizacionRCActInm.RCActInmCruzadaID)
                {
                    case 1: cotDeduc = cotDatos.bk_te_CotizacionDeducible.Where(x => x.TarifaID == 24).FirstOrDefault(); break;
                    case 2: cotDeduc = cotDatos.bk_te_CotizacionDeducible.Where(x => x.TarifaID == 25).FirstOrDefault(); break;
                    case 3: cotDeduc = cotDatos.bk_te_CotizacionDeducible.Where(x => x.TarifaID == 26).FirstOrDefault(); break;
                    case 4: cotDeduc = cotDatos.bk_te_CotizacionDeducible.Where(x => x.TarifaID == 27).FirstOrDefault(); break;
                }

                cotDeduc.DeducibleValorID = cotDatos.bk_te_CotizacionRCActInm.CruzadaDeducibleValorID;
                cotDeduc.UnidadDeducibleID = cotDatos.bk_te_CotizacionRCActInm.CruzadaDeducibleUnidadID;
                cotDeduc.DeducibleAplicaID = cotDatos.bk_te_CotizacionRCActInm.CruzadaDeducibleAplicaID;
                cotDeduc.DeducibleValorIDMinimo = cotDatos.bk_te_CotizacionRCActInm.CruzadaDeducibleValorIDMin;
                cotDeduc.UnidadDeducibleIDMinimo = cotDatos.bk_te_CotizacionRCActInm.CruzadaDeducibleUnidadIDMin;

                cotDeduc = cotDatos.bk_te_CotizacionDeducible.Where(x => x.SubLineaNegocioID == 32).FirstOrDefault();
                cotDeduc.DeducibleValorID = cotDatos.bk_te_CotizacionRCActInm.ContaminacionDeducibleValorID;
                cotDeduc.UnidadDeducibleID = cotDatos.bk_te_CotizacionRCActInm.ContaminacionDeducibleUnidadID;
                cotDeduc.DeducibleAplicaID = cotDatos.bk_te_CotizacionRCActInm.ContaminacionDeducibleAplicaID;
                cotDeduc.DeducibleValorIDMinimo = cotDatos.bk_te_CotizacionRCActInm.ContaminacionDeducibleValorIDMin;
                cotDeduc.UnidadDeducibleIDMinimo = cotDatos.bk_te_CotizacionRCActInm.ContaminacionDeducibleUnidadIDMin;

                cotDeduc = cotDatos.bk_te_CotizacionDeducible.Where(x => x.SubLineaNegocioID == 33).FirstOrDefault();
                cotDeduc.DeducibleValorID = cotDatos.bk_te_CotizacionRCActInm.AsumidaDeducibleValorID;
                cotDeduc.UnidadDeducibleID = cotDatos.bk_te_CotizacionRCActInm.AsumidaDeducibleUnidadID;
                cotDeduc.DeducibleAplicaID = cotDatos.bk_te_CotizacionRCActInm.AsumidaDeducibleAplicaID;
                cotDeduc.DeducibleValorIDMinimo = cotDatos.bk_te_CotizacionRCActInm.AsumidaDeducibleValorIDMin;
                cotDeduc.UnidadDeducibleIDMinimo = cotDatos.bk_te_CotizacionRCActInm.AsumidaDeducibleUnidadIDMin;

                cotDeduc = cotDatos.bk_te_CotizacionDeducible.Where(x => x.SubLineaNegocioID == 34).FirstOrDefault();
                cotDeduc.DeducibleValorID = cotDatos.bk_te_CotizacionRCActInm.ContIndependienteDeducibleValorID;
                cotDeduc.UnidadDeducibleID = cotDatos.bk_te_CotizacionRCActInm.ContIndependienteDeducibleUnidadID;
                cotDeduc.DeducibleAplicaID = cotDatos.bk_te_CotizacionRCActInm.ContIndependienteDeducibleAplicaID;
                cotDeduc.DeducibleValorIDMinimo = cotDatos.bk_te_CotizacionRCActInm.ContIndependienteDeducibleValorIDMin;
                cotDeduc.UnidadDeducibleIDMinimo = cotDatos.bk_te_CotizacionRCActInm.ContIndependienteDeducibleUnidadIDMin;

                if(cotDatos.bk_te_CotizacionRCTrabajoTerm != null)
                { 
                    cotDeduc = cotDatos.bk_te_CotizacionDeducible.Where(x => x.TarifaID == 28).FirstOrDefault();
                    cotDeduc.DeducibleValorID = cotDatos.bk_te_CotizacionRCTrabajoTerm.DeducibleValorID;
                    cotDeduc.UnidadDeducibleID = cotDatos.bk_te_CotizacionRCTrabajoTerm.DeducibleUnidadID;
                    cotDeduc.DeducibleAplicaID = cotDatos.bk_te_CotizacionRCTrabajoTerm.DeducibleAplicaID;
                    cotDeduc.DeducibleValorIDMinimo = cotDatos.bk_te_CotizacionRCTrabajoTerm.DeducibleValorIDMin;
                    cotDeduc.UnidadDeducibleIDMinimo = cotDatos.bk_te_CotizacionRCTrabajoTerm.DeducibleUnidadIDMin;

                    cotDeduc = cotDatos.bk_te_CotizacionDeducible.Where(x => x.TarifaID == 29).FirstOrDefault();
                    cotDeduc.DeducibleValorID = cotDatos.bk_te_CotizacionRCTrabajoTerm.UnionMezclaDeducibleValorID;
                    cotDeduc.UnidadDeducibleID = cotDatos.bk_te_CotizacionRCTrabajoTerm.UnionMezclaDeducibleUnidadID;
                    cotDeduc.DeducibleAplicaID = cotDatos.bk_te_CotizacionRCTrabajoTerm.UnionMezclaDeducibleAplicaID;
                    cotDeduc.DeducibleValorIDMinimo = cotDatos.bk_te_CotizacionRCTrabajoTerm.UnionMezclaDeducibleValorIDMin;
                    cotDeduc.UnidadDeducibleIDMinimo = cotDatos.bk_te_CotizacionRCTrabajoTerm.UnionMezclaDeducibleUnidadIDMin;
                }
            }
            
            _cotizacionRepository.Modify(cotDatos);

            unitOfWork.Commit();

            _cotizacionRepository.execProcesarRC(cotizacion.CotizacionID, false); //Procesamos para obtener cuota y prima

            if(cotDatos.bk_te_CotizacionRCAdicional.isPrimaMinima.Value)
                _cotizacionRepository.execProcesarRC(cotizacion.CotizacionID, true);

            if (cotDatos.bk_te_CotizacionRCActInm != null)
            {
                ResultadoPrima rcActInm = _cotizacionRepository.GetPrimaCuota((int)enumTableCotizacion.RCActInm, cotizacion.CotizacionID);
                cotDatos.bk_te_CotizacionRCActInm.Cuota = rcActInm.Cuota;
                cotDatos.bk_te_CotizacionRCActInm.Prima = rcActInm.Prima;
            }

            return cotDatos;
        }

        public Cotizacion SaveCotizacionRCExtRecall(Cotizacion cotizacion)
        {
            //Grabar Cotizacion 
            IUnitOfWork unitOfWork = _cotizacionRepository.UnitOfWork as IUnitOfWork;

            Cotizacion cotDatos = _cotizacionRepository.FindCotizacionRCExtRecall(cotizacion.CotizacionID);

            //TransactionOptions txSettings = new TransactionOptions()
            //{
            //    Timeout = TransactionManager.DefaultTimeout,
            //    IsolationLevel = IsolationLevel.Serializable // review this option
            //};

            cotDatos.bk_te_CotizacionRCProductoExt = cotizacion.bk_te_CotizacionRCProductoExt;
            cotDatos.bk_te_CotizacionRCProductoExtResultado[0] = cotizacion.bk_te_CotizacionRCProductoExtResultado[0];
            cotDatos.bk_te_CotizacionRCProductoExtResultado[1] = cotizacion.bk_te_CotizacionRCProductoExtResultado[0];
            cotDatos.bk_te_CotizacionRCProductoExtResultado[2] = cotizacion.bk_te_CotizacionRCProductoExtResultado[0];
            cotDatos.bk_te_CotizacionRCRecall = cotizacion.bk_te_CotizacionRCRecall;

            cotDatos.bk_te_CotizacionRCProductoExtPais.Clear();

            cotizacion.bk_te_CotizacionRCProductoExtPais.ToList().ForEach(x =>
            {
                if (x.GrossSales.HasValue && x.GrossSales.Value != 0)
                    cotDatos.bk_te_CotizacionRCProductoExtPais.Add(x);
            });
            //cotDatos.bk_te_CotizacionRCProductoExtPais = cotizacion.bk_te_CotizacionRCProductoExtPais;
            //cotDatos.bk_te_CotizacionRCProductoExtPais.Where(x => !x.GrossSales.HasValue || x.GrossSales == 0).ToList().ForEach(x => cotDatos.bk_te_CotizacionRCProductoExtPais.Remove(x));


            _cotizacionRepository.Modify(cotDatos);


            unitOfWork.Commit();

            FillCotizacionRCRecall(cotDatos);
            return cotDatos;
        }

        public Cotizacion SaveCotizacionTransporte(Cotizacion cotizacion)
        {
            //Grabar Cotizacion 
            IUnitOfWork unitOfWork = _cotizacionRepository.UnitOfWork as IUnitOfWork;

            Cotizacion cotDatos = _cotizacionRepository.FindCotizacionTransporte(cotizacion.CotizacionID);
            cotDatos.bk_te_CotizacionTrans = cotizacion.bk_te_CotizacionTrans;

            cotDatos.bk_te_CotizacionTransConceptoEvaluacion.Clear();
            cotizacion.bk_te_CotizacionTransConceptoEvaluacion.ToList().ForEach(x => {
                //x.Nombre = x.bk_tw_TransConceptoEval.nombre;
                //x.Pct = x.Pct;
                cotDatos.bk_te_CotizacionTransConceptoEvaluacion.Add(x);
            });
            //cotDatos.bk_te_CotizacionTransConceptoEvaluacion = cotizacion.bk_te_CotizacionTransConceptoEvaluacion;

            _cotizacionRepository.Modify(cotDatos);

            unitOfWork.Commit();

            //Actualizar valores cotizacion
            UpdateCotizacionTransporte_Result updateTrans = _cotizacionRepository.execUpdateCotizacionTransporte(cotizacion.CotizacionID);
            cotDatos.bk_te_CotizacionTrans.primaTarifaMinRenovacion = updateTrans.primaTarifaMinRenovacion;
            cotDatos.bk_te_CotizacionTrans.primaTarifaMaxRenovacion = updateTrans.primaTarifaMaxRenovacion;
            cotDatos.bk_te_CotizacionTrans.primaNetaNuevo = updateTrans.primaNetaNuevo;
            cotDatos.bk_te_CotizacionTrans.primaNetaRenovacion = updateTrans.primaNetaRenovacion;
            cotDatos.bk_te_CotizacionTrans.CuotaRenovacion = updateTrans.CuotaRenovacion;
            cotDatos.bk_te_CotizacionTrans.primaNetaNuevo = updateTrans.primaNetaNuevo;
            cotDatos.bk_te_CotizacionTrans.CuotaNuevo = updateTrans.CuotaNuevo;
            cotDatos.bk_te_CotizacionTrans.PrimaNetaModificada = updateTrans.PrimaNetaModificada;

            return cotDatos;
        }

        //public void SaveCotizacionTransporteCuota(double prima, int cotizacionID)
        //{
        //    //Grabar Cotizacion 
        //    IUnitOfWork unitOfWork = _cotizacionRepository.UnitOfWork as IUnitOfWork;
        //    Cotizacion cotDatos = _cotizacionRepository.FindCotizacionTransporte(cotizacionID);
        //    //double? newCuota;
            
        //    if (cotDatos.isNew)
        //    {
        //        cotDatos.bk_te_CotizacionTrans.primaNetaNuevo = prima;
        //        cotDatos.bk_te_CotizacionTrans.CuotaNuevo = prima / cotDatos.bk_te_CotizacionTrans.EstimadoAnual;
        //        //newCuota = cotDatos.bk_te_CotizacionTrans.CuotaNuevo;
        //    }
        //    else
        //    {
        //        cotDatos.bk_te_CotizacionTrans.primaNetaRenovacion = prima;
        //        cotDatos.bk_te_CotizacionTrans.CuotaRenovacion = prima / cotDatos.bk_te_CotizacionTrans.EstimadoAnual;
        //        //newCuota = cotDatos.bk_te_CotizacionTrans.CuotaRenovacion;
        //    }

        //    _cotizacionRepository.Modify(cotDatos);

        //    unitOfWork.Commit();
        //    //return newCuota;
        //}

        //#region CotizacionCobertura

        //public List<CotizacionCobertura> FindCotizacionCoberturasbyID(int cotizacionID)
        //{
        //    Domain.MainModule.CotizacionCoberturas.CotizacionIDSpecification cotizacionCobSpec = new Domain.MainModule.CotizacionCoberturas.CotizacionIDSpecification(cotizacionID);
        //    return _cotizacionCoberturaRepository.FindCotizacionCoberturas(cotizacionCobSpec);
        //}

        //public void SaveCotizacionCobertura(int cotizacionID, string[] incendio, string[] terremoto, string[] hidro)
        //{
        //    Domain.MainModule.CotizacionCoberturas.CotizacionIDSpecification cotizacionCobSpec = new Domain.MainModule.CotizacionCoberturas.CotizacionIDSpecification(cotizacionID);
        //    List<CotizacionCobertura> listaInicial = _cotizacionCoberturaRepository.FindCotizacionCoberturas(cotizacionCobSpec);

        //    IUnitOfWork unitOfWork = _cotizacionCoberturaRepository.UnitOfWork as IUnitOfWork;

        //    int id = _cotizacionCoberturaRepository.LastCotizacionCoberturaID();
        //    //Eliminar los que no se encuentran            
        //    listaInicial.Where(t => t.LineaNegocioID == 1).Where(t => !incendio.Contains(t.CoberturaID.ToString())).ToList().ForEach(x => { _cotizacionCoberturaRepository.Remove(x); });
        //    listaInicial.Where(t => t.LineaNegocioID == 6).Where(t => !terremoto.Contains(t.CoberturaID.ToString())).ToList().ForEach(x => { _cotizacionCoberturaRepository.Remove(x); });
        //    listaInicial.Where(t => t.LineaNegocioID == 7).Where(t => !hidro.Contains(t.CoberturaID.ToString())).ToList().ForEach(x => { _cotizacionCoberturaRepository.Remove(x); });

        //    //Insertar los que faltan
        //    incendio.Where(t => !listaInicial.Where(x => x.LineaNegocioID == 1).Select(y => y.CoberturaID).Contains(Convert.ToInt32(t))).ToList().ForEach(x => { id++;  _cotizacionCoberturaRepository.Add(new CotizacionCobertura() { CotizacionCoberturaID = id, CotizacionID = cotizacionID, LineaNegocioID = 1, CoberturaID = Convert.ToInt32(x) }); });
        //    terremoto.Where(t => !listaInicial.Where(x => x.LineaNegocioID == 6).Select(y => y.CoberturaID).Contains(Convert.ToInt32(t))).ToList().ForEach(x => { id++; _cotizacionCoberturaRepository.Add(new CotizacionCobertura() { CotizacionCoberturaID = id, CotizacionID = cotizacionID, LineaNegocioID = 6, CoberturaID = Convert.ToInt32(x) }); });
        //    hidro.Where(t => !listaInicial.Where(x => x.LineaNegocioID == 7).Select(y => y.CoberturaID).Contains(Convert.ToInt32(t))).ToList().ForEach(x => { id++; _cotizacionCoberturaRepository.Add(new CotizacionCobertura() { CotizacionCoberturaID = id, CotizacionID = cotizacionID, LineaNegocioID = 7, CoberturaID = Convert.ToInt32(x) }); });

        //    unitOfWork.Commit();

        //    //Actualizamos campos de valores
        //    _cotizacionCoberturaRepository.execUpdateCotizacionCoberturaUbicacion(cotizacionID);
        //}

        //public List<CotizacionCoberturaUbicacion> FindCotizacionCoberturaUbicacionesbyID(int cotizacionID)
        //{
        //    Domain.MainModule.CotizacionCoberturaUbicaciones.CotizacionIDSpecification cotizacionCobSpec = new Domain.MainModule.CotizacionCoberturaUbicaciones.CotizacionIDSpecification(cotizacionID);
        //    return _cotizacionCoberturaUbicacionRepository.FindCotizacionCoberturaUbicaciones(cotizacionCobSpec);
        //}

        //#endregion

        public Presentacion FindPresentacionCotizacionbyID(int cotizacionID, int usuarioID, bool isRC)
        {
            Presentacion presentacion = new Presentacion();

            presentacion.DatosGenerales = _cotizacionRepository.GetCotizacionPresentacion(cotizacionID);
            
            if (presentacion.DatosGenerales.Count() > 0)
            {
                int diasRetro = Convert.ToInt32(_catalogoRepository.GetGlobalParam((int)globalParam.DiasRetro));
                
                //Validacion retroactividad
                if (_cotizacionRepository.GetActivoCotizacion(cotizacionID) && (DateTime.Now - presentacion.DatosGenerales[0].VigenciaInicio).Days > diasRetro)
                    presentacion.MensajeError = (new Cotizacion()).ErrorRetroactividad(diasRetro);
                else
                {
                    List<string> mensajesLimite = _cotizacionRepository.GetMensajeLimite(cotizacionID, usuarioID); //Limite por Suscriptor
                    mensajesLimite.AddRange(_cotizacionRepository.GetMensajeLimiteReaseguro(cotizacionID));

                    if (mensajesLimite.Count() > 0)
                        mensajesLimite.ForEach(x => { presentacion.MensajeError += x + "<br>"; });
                    else
                    {
                        presentacion.Primas = _cotizacionRepository.GetCotizacionPresentacionPrimas(cotizacionID);

                        if (isRC)
                        {
                            presentacion.TextosRC = _cotizacionRepository.GetCotizacionPresentacionTextosRC(cotizacionID);
                            presentacion.DatosGeneralesRC = _cotizacionRepository.GetCotizacionPresentacionRC(cotizacionID);
                        }
                        else
                        {
                            presentacion.Textos = _cotizacionRepository.GetCotizacionPresentacionTextos(cotizacionID);
                            presentacion.Equipos = _cotizacionRepository.GetCotizacionPresentacionEquipo(cotizacionID);
                        }

                        presentacion.Resumen = _cotizacionRepository.GetCotizacionPresentacionResumen(cotizacionID);                        
                    }
                }
            }
                        
            return presentacion;
        }

        public PresentacionUbicacion FindPresentacionUbicacionbyID(int cotizacionID)
        {
            PresentacionUbicacion presentacion = new PresentacionUbicacion();
            presentacion.GeneralInformation = _cotizacionRepository.GetCotizacionPresentacionUbicacion(cotizacionID);
            
            return presentacion;
        }

        public PresentacionTrans FindPresentacionTransCotizacionbyID(int cotizacionID, int usuarioID)
        {
            PresentacionTrans presentacion = new PresentacionTrans();
            presentacion.Textos = _cotizacionRepository.GetCotizacionPresentacionTrans(cotizacionID);

            if (presentacion.Textos.Count() > 0)
            {
                int diasRetro = Convert.ToInt32(_catalogoRepository.GetGlobalParam((int)globalParam.DiasRetro));
                //Validacion retroactividad
                if (_cotizacionRepository.GetActivoCotizacion(cotizacionID) && (DateTime.Now - presentacion.Textos[0].VigenciaInicio).Days > diasRetro)
                    presentacion.MensajeError = (new Cotizacion()).ErrorRetroactividad(diasRetro);
                else
                {
                    List<string> mensajesLimite = _cotizacionRepository.GetMensajeLimite(cotizacionID, usuarioID);
                    mensajesLimite.AddRange(_cotizacionRepository.GetMensajeLimiteReaseguro(cotizacionID));

                    if (mensajesLimite.Count() > 0)
                        mensajesLimite.ForEach(x => { presentacion.MensajeError += x + "<br>"; });
                    else
                        presentacion.Condiciones = _catalogoRepository.GetCondicionesTrans();
                }
            }
            
            return presentacion;
        }

        public List<Texto> FindTextobyCotizacionID(int cotizacionID)
        {
            return _cotizacionRepository.GetTextobyCotizacionID(cotizacionID);
        }

        public void SaveTextobyCotizacionID(int cotizacionID, string valoresXML, string valoresAdicionalesXML)
        {
            _cotizacionRepository.execUpdateCotizacionTexto(cotizacionID, valoresXML, valoresAdicionalesXML);
        }

        public void Cotizar(int cotizacionID)
        {
            _cotizacionRepository.execCotizar(cotizacionID);
        }

        public Cotizacion FindCotizacionLogbyID(int cotizacionID)
        {
            Cotizacion resultado = _cotizacionRepository.FindCotizacionLogSISE(cotizacionID);
            if (resultado.bk_te_CotizacionPagador != null)
            {
                resultado.bk_te_CotizacionPagador.Banco = _catalogoRepository.GetNombreBanco(null, resultado.bk_te_CotizacionPagador.BancoID);
                resultado.bk_te_CotizacionPagador.Conducto = _catalogoRepository.GetNombreConducto(null, resultado.bk_te_CotizacionPagador.ConductoID);
            }
            return resultado;
        }

        public bool FindActivoCotizacionbyID(int cotizacionID)
        {
            return _cotizacionRepository.GetActivoCotizacion(cotizacionID);
        }

        public string FindRFCCotizacionbyID(int cotizacionID)
        {
            return _cotizacionRepository.GetRFCbyCotizacionID(cotizacionID);
        }

        public void SaveCotizacionPagador(CotizacionPagador cotizacionPagador)
        {
            _cotizacionRepository.execSaveCotizacionPagador(cotizacionPagador);
            cotizacionPagador.Banco = _catalogoRepository.GetNombreBanco(Convert.ToInt32(cotizacionPagador.COD_BANCO_EMI), null);
            cotizacionPagador.Conducto = _catalogoRepository.GetNombreConducto(Convert.ToInt32(cotizacionPagador.COD_CONDUCTO), null);
        }

        public void SaveEquiposbyCotizacionID(int cotizacionID, string equiposXML, string nombreArchivo)
        {
            _cotizacionRepository.execUpdateCotizacionEq(cotizacionID, equiposXML, nombreArchivo);
        }

        public double FindGastosAdmCalculado(int cotizacionID, double cuotaDeseada)
        {
            return _cotizacionRepository.execSelectGastosAdmCalculado(cotizacionID,cuotaDeseada);
        }

    }
}
