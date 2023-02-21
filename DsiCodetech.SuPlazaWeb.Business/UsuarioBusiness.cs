using DsiCodetech.SuPlazaWeb.Business.Interface;
using DsiCodeTech.SuPlazaWeb.Domain;
using DsiCodeTech.SuPlazaWeb.Repository;
using DsiCodeTech.SuPlazaWeb.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.SuPlazaWeb.Business
{
    public class UsuarioBusiness: IUsuarioBusiness
    {
        /// <summary>
        /// implementacion de la unidad de trabajo
        /// </summary>
        private readonly IUnitOfWorks unitOfWork;
        private readonly UsuarioRepository repository;
        public UsuarioBusiness(IUnitOfWorks _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new UsuarioRepository(unitOfWork);
        }

        /// <summary>
        /// este metodo se encarga de consultar un usaurio por nombre de usuario y password
        /// </summary>
        /// <param name="usuarioDM">la entidad del tipo usuario</param>
        /// <returns>un valor true/false</returns>
        public bool GetUsuario(UsuarioDM usuarioDM)
        {
            bool respuesta = false;
            var usuario = repository.SingleOrDefault(u => u.user_name.Equals(usuarioDM.User_name) && u.password.Equals(usuarioDM.Password));
            if (usuario != null)
            {
                respuesta = true;
            }
            return respuesta;
        }

        /// <summary>
        /// Este metodo se encarga de validar un usuario por password y nombre de usuario
        /// </summary>
        /// <param name="usuarioDM">la entidad del tipo usuarioDM</param>
        /// <returns>retorna una entidad del tipo usuarioDM</returns>
        public UsuarioDM ValidarUsuario(UsuarioDM usuarioDM)
        {
            var usuario = repository.SingleOrDefault(u => u.user_name.Equals(usuarioDM.User_name) && u.password.Equals(usuarioDM.Password));
            if (usuario != null)
            {
                return new UsuarioDM
                {
                    User_name = usuarioDM.User_name,
                    Password = usuarioDM.Password,  
                    Enable = usuarioDM.Enable,
                    Fecha_registro = usuarioDM.Fecha_registro,
                    Tipo_usuario = usuarioDM.Tipo_usuario,
                    User_code_bascula= usuarioDM.User_code_bascula
                };
            }
            return null;
        }

    }
}
