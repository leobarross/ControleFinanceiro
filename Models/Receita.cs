using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFinanceiro.Models
{
    public class Receita
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Valor { get; set; }
        [StringLength(40)]
        public string CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
        [StringLength(40)]
        public string FormaPagamentoId { get; set; }
        public virtual FormaPagamento FormaPagamento { get; set; }
        [StringLength(40)]
        public string ContaBancariaId { get; set; }
        public virtual ContaBancaria ContaBancaria { get; set; }
        [Required]
        public DateTime DataRecebimento { get; set; }

    }
}
