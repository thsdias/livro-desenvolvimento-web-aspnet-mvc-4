using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadeMeuMedico.Models
{
    [MetadataType(typeof(MedicoMetadado))]
    public partial class Medico
    {
    }

    public class MedicoMetadado
    {
        public long IDMedico { get; set; }

        [Required(ErrorMessage = "* Obrigatório informar o CRM")]
        [StringLength(30, ErrorMessage = "O CRM deve possuir no máximo 30 caracteres")]
        public string CRM { get; set; }

        [Required(ErrorMessage = "* Obrigatório informar o Nome")]
        [StringLength(80, ErrorMessage = "O Nome deve possuir no máximo 80 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "* Obrigatório informar o Endereço")]
        [StringLength(100, ErrorMessage = "O Endereço deve possuir no máximo 100 caracteres")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "* Obrigatório informar o Bairro")]
        [StringLength(60, ErrorMessage = "O Bairro deve possuir no máximo 60 caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "* Obrigatório informar o E-mail")]
        [StringLength(100, ErrorMessage = "O E-mail deve possuir no máximo 100 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "* Obrigatório informar se Atende por Convênio")]
        [Display(Name = "Atende por convênvio?")]
        public bool AtendePorConvenio { get; set; }

        [Required(ErrorMessage = "* Obrigatório informar se Tem Clínica")]
        [Display(Name = "Possui clínica própria?")]
        public bool TemClinica { get; set; }

        [StringLength(80, ErrorMessage = "O Website deve possuir no máximo 80 caracteres")]
        [Display(Name = "Blog / Web site")]
        public string WebsiteBlog { get; set; }

        [Required(ErrorMessage = "* Obrigatório informar a Cidade")]
        [Display(Name = "Cidade")]
        public int IDCidade { get; set; }

        [Required(ErrorMessage = "* Obrigatório informar a Especialidade")]
        [Display(Name = "Especialidade")]
        public int IDEspecialidade { get; set; }
    }
}