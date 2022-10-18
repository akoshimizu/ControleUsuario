using System.ComponentModel.DataAnnotations.Schema;
using ProjetoUsuario.Domain.DTO;

namespace ProjetoUsuario.Domain.Entidades
{
    [Table("mesa")]
    public class Mesa
    {
        public Mesa()
        {
        }

        public Mesa(MesaDTO mesa)
        {
            this.Id = mesa.Id;
            this.DescricaoMesa = mesa.DescricaoMesa;
            this.IndicadorMesaAtiva = mesa.IndicarorMesaAtiva;
            this.DataDeCriacaoMesa = DateTime.Now;
            this.DataUltimaAlteracaoMesa = DateTime.Now;
        }

        public Mesa(int id, string descricaoMesa, bool indicarorMesaAtiva, DateTime dataDeCriacaoMesa, DateTime dataUltimaAlteracaoMesa)
        {
            Id = id;
            DescricaoMesa = descricaoMesa;
            IndicadorMesaAtiva = indicarorMesaAtiva;
            DataDeCriacaoMesa = dataDeCriacaoMesa;
            DataUltimaAlteracaoMesa = dataUltimaAlteracaoMesa;
        }

        [Column("id")]
        public int Id { get; set; }

        [Column("descricao_mesa")]
        public string DescricaoMesa { get; set; }

        [Column("indicador_mesa")]
        public bool IndicadorMesaAtiva { get; set; }

        [Column("data_criacao_mesa")]
        public DateTime DataDeCriacaoMesa { get; set; }

        [Column("data_ultima_alteracao_mesa")]
        public DateTime DataUltimaAlteracaoMesa { get; set; }
    }
}