using System;
using System.Web;

namespace CadeMeuMedico.Repositorios
{
    public class RepositorioCookies
    {
        public static void RegistraCookieAutenticacao(long idUsuario)
        {
            // Cria objeto cookie.
            HttpCookie UserCookie = new HttpCookie("UserCookieAuthentication");

            // Seta ID do usuário no cookie.
            UserCookie.Values["IDUsuario"] = RepositorioCriptografia.Criptografar(idUsuario.ToString());

            // Define prazo de vida do cookie.
            UserCookie.Expires = DateTime.Now.AddDays(1);

            // Adiciona cookie no contexto da aplicacao.
            HttpContext.Current.Response.Cookies.Add(UserCookie);
        }
    }
}