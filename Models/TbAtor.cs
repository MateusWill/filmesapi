using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace filmesapi.Models
{
    [Table("tb_ator")]
    public partial class TbAtor
    {
        public TbAtor()
        {
            TbAtorFilme = new HashSet<TbAtorFilme>();
        }

        [Key]
        [Column("id_ator")]
        public int IdAtor { get; set; }
        [Column("nm_ator", TypeName = "varchar(200)")]
        public string NmAtor { get; set; }
        [Column("vl_altura", TypeName = "decimal(10,2)")]
        public decimal? VlAltura { get; set; }
        [Column("dt_nasc", TypeName = "datetime")]
        public DateTime? DtNasc { get; set; }

        [InverseProperty("IdAtorNavigation")]
        public virtual ICollection<TbAtorFilme> TbAtorFilme { get; set; }
    }
}
