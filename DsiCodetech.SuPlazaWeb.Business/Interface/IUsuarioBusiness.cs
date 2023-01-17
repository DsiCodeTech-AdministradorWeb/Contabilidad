using DsiCodeTech.SuPlazaWeb.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.SuPlazaWeb.Business.Interface
{
    public interface IUsuarioBusiness
    {
        /// <summary>
        /// este metodo se encarga de consultar un usaurio por nombre de usuario y password
        /// </summary>
        /// <param name="usuarioDM">la entidad del tipo usuario</param>
        /// <returns>un valor true/false</returns>
        bool GetUsuario(UsuarioDM usuarioDM);
        /// <summary>
        /// Este metodo se encarga de validar un usuario por password y nombre de usuario
        /// </summary>
        /// <param name="usuarioDM">la entidad del tipo usuarioDM</param>
        /// <returns>retorna una entidad del tipo usuarioDM</returns>
        UsuarioDM ValidarUsuario(UsuarioDM usuarioDM);
    }
}
