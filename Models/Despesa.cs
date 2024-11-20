using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFinanceiro.Models
{
    public class Despesa
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Valor {  get; set; }
        [Required]
        public DateTime DataEmissao { get; set; }
        [Required]
        public DateTime DataVencimento { get; set; }

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
        public bool Situacao {  get; set; }
        [Required]
        public int Parcela {  get; set; }

    }
}
