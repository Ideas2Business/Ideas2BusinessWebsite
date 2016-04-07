using Ideas2Business.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Ideas2Business.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Renderiza página principal
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //Define a linguagem selecionada pelo usuário. Se não foi selecionado nada, coloca portugues.
            var linguagem = this.GetLanguage();
            if (linguagem == Linguagem.Portugues.ToString())
            {
                return View("IndexPt");
            }
            else
            {
                return View();
            }
            
        }

        /// <summary>
        /// Renderiza view de Sobre nos
        /// </summary>
        /// <returns></returns>
        public ActionResult AboutUs()
        {
            var linguagem = this.GetLanguage();
            if (linguagem == Linguagem.Portugues.ToString())
            {
                return View("AboutUsPt");
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// Renderiza view de contato
        /// </summary>
        /// <returns>View</returns>
        public ActionResult ContactUs()
        {
            var linguagem = this.GetLanguage();
            if (linguagem == Linguagem.Portugues.ToString())
            {
                return View("ContactUsPt");
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// Rnderiza view de Quem somos nós.
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Team()
        {
            var linguagem = this.GetLanguage();
            if (linguagem == Linguagem.Portugues.ToString())
            {
                return View("TeamPt");
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// Envia o email da página de contato
        /// </summary>
        /// <param name="name">Nome preenchido no formulário</param>
        /// <param name="email">Email preenchido no formulário</param>
        /// <param name="message">Mensagem preenchida no formulário</param>
        [HttpPost]
        public void SendEmail(string name, string email, string message)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.Credentials = new System.Net.NetworkCredential("contato.ideas2business@gmail.com", "Abracadabra1");
                smtpClient.EnableSsl = true;

                MailMessage mail = new MailMessage();
                var builder = new StringBuilder();
                builder.Append("Nova mensagem recebida via Site\n\n");
                builder.AppendFormat("Nome: {0}\nEmail: {1}\nMensagem: {2}\n", name, email, message);

                //Setting From , To and CC
                mail.From = new MailAddress("naoresponder@ideas2business.com.br", "Fale Conosco");
                mail.To.Add(new MailAddress("contato@ideas2business.com.br"));
                mail.Body = builder.ToString();
                mail.Subject = "[SITE] - Nova mensagem";

                smtpClient.Send(mail);
            }
            catch (Exception)
            {
                //nao enviada, azar
            }
        }

        /// <summary>
        /// Altera a linguagem padrão para portugues
        /// </summary>
        [HttpGet]
        public void ChangePt()
        {
            HttpCookie cookie = Request.Cookies["lang"];
            cookie.Value = Linguagem.Portugues.ToString();
            Response.SetCookie(cookie);
        }

        /// <summary>
        /// Altera a linguagem padrão para ingles
        /// </summary>
        [HttpGet]
        public void ChangeEn()
        {
            HttpCookie cookie = Request.Cookies["lang"];
            cookie.Value = Linguagem.Ingles.ToString();
            Response.SetCookie(cookie);
        }

        /// <summary>
        /// Retorna a liguagem configurada pelo usuário
        /// </summary>
        /// <returns>Linguagem configurada pelo usuário</returns>
        private string GetLanguage()
        {
            HttpCookie cookie = Request.Cookies["lang"];
            if (cookie == null || cookie.Value == "")
            {
                cookie = new HttpCookie("lang");
                cookie.Value = Linguagem.Portugues.ToString();
                cookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(cookie);
            }
            return cookie.Value;
        }
    }
}
