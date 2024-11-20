using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFinanceiro.Models
{
    public class ContaBancaria
    {
        [Key]
        [StringLength(40)]
        public string Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Agencia { get; set; }
        [Required]
        [StringLength(50)]
        public string Conta {  get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Saldo { get; set; }
        [Required]
        [StringLength(50)]
        public string Titular { get; set; }

        public List<Despesa> Despesas { get; set; }
        public List<Receita> Receitas { get; set; }

    }
}
