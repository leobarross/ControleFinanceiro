
using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.Models
{
    public class FormaPagamento
    {
        [Key]
        [StringLength(40)]
        public string Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }

    }
}
