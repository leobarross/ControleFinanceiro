using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.Models
{
    public class Categoria
    {
        [Key]
        [StringLength(40)]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }

        public List<Despesa> Despesas { get; set; }
        public List<Receita> Receitas { get; set; }
    }
}
