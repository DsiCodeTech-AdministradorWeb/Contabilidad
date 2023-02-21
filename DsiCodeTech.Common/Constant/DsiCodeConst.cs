using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodeTech.Common.Constant
{
    public sealed class DsiCodeConst
    {
        public static readonly string RESULT_WITHOUT_DATA_ID = "POS-SYSADM-001";
        public static readonly string RESULT_WITHOUT_DATA = "No se encontraron resultados para esta consulta realizada.";

        public static readonly string RESULT_WITHIN_DATA_ID = "POS-SYSADM-002";
        public static readonly string RESULT_WITHIN_DATA = "Se encontraron resultados para esta consulta realizada.";

        public static readonly string RESULT_SUCCESS_OPERATION_ID = "POS-SYSADM-003";
        public static readonly string RESULT_SUCCESS_OPERATION = "La operación se ejecuto de forma satisfactoria.";

        public static readonly string RESULT_WITHEXCPETION_ID = "POS-SYSADM-100";
        public static readonly string RESULT_WITHEXCPETION = "Ocurrió un error inesperado dentro del sistema, intente de nuevo y si el error persiste, contante al administrador.";

        public static readonly string NOT_HANDLE_ERROR_MESSAGE_ID = "POS-SYSADM-200";
        public static readonly string NOT_HANDLE_ERROR_MESSAGE = "Ocurrió un error controlado por el sistema.";

        public static readonly string HANDLE_ERROR_MESSAGE_ID = "POS-SYSADM-500";
        public static readonly string HANDLE_ERROR_MESSAGE = "Ocurrió un error, contacte al administrador para validar los detalles.";

        private DsiCodeConst() { }
    }
}
