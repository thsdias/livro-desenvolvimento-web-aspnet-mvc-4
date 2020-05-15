using CadeMeuMedico.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace CadeMeuMedico.Repositorios
{
    public class RepositorioUsuarios
    {
        public static bool AutenticarUsuario(string login, string senha)
        {
            var SenhaCriptografada = FormsAuthentication.HashPasswordForStoringInConfigFile(senha, "sha1");
            try
            {
                using (CadeMeuMedicoBDEntities db = new CadeMeuMedicoBDEntities())
                {
                    var queryAutenticaUsuarios = db.Usuarios.Where(x => x.Login == login && x.Senha == SenhaCriptografada).SingleOrDefault();

                    if (queryAutenticaUsuarios == null)
                    {
                        return false;
                    }
                    else
                    {
                        RepositorioCookies.RegistraCookieAutenticacao(queryAutenticaUsuarios.IDUsuario);
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Usuarios RecuperarUsuarioPorID(long idUsuario)
        {
            try
            {
                using (CadeMeuMedicoBDEntities db = new CadeMeuMedicoBDEntities())
                {
                    var usuario = db.Usuarios.Where(u => u.IDUsuario == idUsuario).SingleOrDefault();

                    return usuario;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Usuarios VerificaSeOUsuarioEstaLogado()
        {
            var usuario = HttpContext.Current.Request.Cookies["UserCookieAuthentication"];

            if (usuario == null)
            {
                return null;
            }
            else
            {
                long iDUsuario = Convert.ToInt64(RepositorioCriptografia.Descriptografar(usuario.Values["IDUsuario"]));
                var usuarioRetornado = RecuperarUsuarioPorID(iDUsuario);

                return usuarioRetornado;
            }
        }
    }
}