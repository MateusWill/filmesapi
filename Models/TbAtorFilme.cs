using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace filmesapi.Models
{
    [Table("tb_ator_filme")]
    public partial class TbAtorFilme
    {
        [Key]
        [Column("id_ator_filme")]
        public int IdAtorFilme { get; set; }
        [Column("ds_personagem", TypeName = "varchar(200)")]
        public string DsPersonagem { get; set; }
        [Column("id_filme")]
        public int? IdFilme { get; set; }
        [Column("id_ator")]
        public int? IdAtor { get; set; }

        [ForeignKey(nameof(IdAtor))]
        [InverseProperty(nameof(TbAtor.TbAtorFilme))]
        public virtual TbAtor IdAtorNavigation { get; set; }
        [ForeignKey(nameof(IdFilme))]
        [InverseProperty(nameof(TbFilme.TbAtorFilme))]
        public virtual TbFilme IdFilmeNavigation { get; set; }
    }
}
