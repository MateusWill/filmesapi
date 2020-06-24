using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace filmesapi.Models
{
    [Table("tb_filme")]
    public partial class TbFilme
    {
        public TbFilme()
        {
            TbAtorFilme = new HashSet<TbAtorFilme>();
            TbDiretor = new HashSet<TbDiretor>();
        }

        [Key]
        [Column("id_filme")]
        public int IdFilme { get; set; }
        [Column("nm_filme", TypeName = "varchar(200)")]
        public string NmFilme { get; set; }
        [Column("ds_genero", TypeName = "varchar(45)")]
        public string DsGenero { get; set; }
        [Column("dt_lancamento", TypeName = "datetime")]
        public DateTime? DtLancamento { get; set; }
        [Column("vl_avaliacao", TypeName = "decimal(10,2)")]
        public decimal? VlAvaliacao { get; set; }
        [Column("bt_disponivel")]
        public bool? BtDisponivel { get; set; }
        [Column("nr_duracao")]
        public int? NrDuracao { get; set; }

        [InverseProperty("IdFilmeNavigation")]
        public virtual ICollection<TbAtorFilme> TbAtorFilme { get; set; }
        [InverseProperty("IdFilmeNavigation")]
        public virtual ICollection<TbDiretor> TbDiretor { get; set; }
    }
}
