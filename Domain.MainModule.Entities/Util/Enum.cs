using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities.Util
{
    public enum enumTable
    {
        CristalesExp,
        RoboAlarma,
        RoboPolicia,
        RoboCircuito,
        RoboGiro,
        DinValCilindro,
        DinValTipoAlarma,
        DinValPolicia,
        DinValGiro,        
        CalderaMant,
        CalderaTipoProc,
        CalderaPCEqRva,
        CalderaPCRefCriticas,
        CalderaPCDeducible,
        CalderaPCPeriodo,        
        RotMaqMant,
        RotMaqGiro,        
        RotMaqPCEqRpto,
        RotMaqPCRefCriticas,
        RotMaqPCDeducible,
        RotMaqPCPeriodo,        
        EqContratistaMant,
        EqContratistaRiesgo,
        EqContratistaRastreo,
        EqContratistaInc,
        EqContratistaMov,
        EqElecRiesgo,
        EqElecInc,
        EqElecGiro,
        EqElecMovilTipo,
        RCActInmTipoRiesgo,
        RCActInmLimAgregado,
        RCProdLimAgregado,
        RCProdTipoCobertura,
        RCProdBaseDeducible,
        RCRecallCategory,
        RCRecallCoverage,
        RCRecallExposureType,
        RCRecallBatchAmount,
        RCRecallLimit,
        RCRecallDeducible,
        RCRecallOccupancy,
        TransModalidadPoliza,
        TransCommodity,
        TransTipoBien,
        TransModalidadCob,
        TransTipoMerca,
        TransTrayectoAseg,
        TransMedios,
        TransAjusteAltaSin,
        TransEvaluacion,
        RRRetroactive,
        RRTrigger,
        RRTypeOcurrency,
        RRISO,
        PerConsGanBrutas,
        PerConsIndemnizacion,
        PerConsRedIngreso,
        PerConsSegConting,
        Defaults,
        DeducibleValor,
        UnidadDeducible,
        DeducibleAplica,
        TipoBeneficiario,
        RCActInmCruzada,
        RCEvaluacion,
        RCInclinacion
    }

    public enum globalParam
    {
        DiasRetro = 11,
        DSIK = 12,
        ServerOFAC = 13,
        OFACAvailable = 14,
        WSSiseAvailable = 15,
        DiasFuturo = 16,
        MaxPagoVolRC = 18
    }

    public enum enumTableID
    {
        TipoBien,
        Class
    }

    public enum enumTableCotizacion
    {
        EqContratista,
        RCEqContratista,
        RCActInm
    }
 }
