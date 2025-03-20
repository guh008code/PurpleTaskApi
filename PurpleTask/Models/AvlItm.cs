using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PurpleTask.Models;

public partial class AvlItm
{
    public int? AvlItmId { get; set; }

    [Required]

    public int? AvlItmEpsId { get; set; }

    [Required]
    public int? AvlItmLocId { get; set; }

    [Required]
    public int? AvlItmCecId { get; set; }

    [Required]
    public int? AvlItmSetId { get; set; }

    public string? AvlItmPlq { get; set; }

    public string? AvlItmPlqAnt { get; set; }

    [Required(ErrorMessage ="Descrição é Obrigatório")]
    [MaxLength(100, ErrorMessage ="A Descrição não pode ser maior que 100 caracteres")]
    public string? AvlItmDes { get; set; }

    public string? AvlItmComp { get; set; }

    public string? AvlItmNumSer { get; set; }

    public int? AvlItmCon { get; set; }

    public string? AvlItmAnd { get; set; }

    public string? AvlItmSit { get; set; } = null!;

    public decimal? AvlItmVlrAqs { get; set; }

    public int? AvlItmSts { get; set; }

    [NotMapped]
    public int? AvlItmUsrIncId { get; set; }

    [NotMapped]
    public int? AvlItmUsrAltId { get; set; }

    [NotMapped]
    public int? AvlItmUsrExcId { get; set; }

    public DateTime AvlItmDatInc { get; set; }

    public DateTime? AvlItmDatAlt { get; set; }

    public DateTime? AvlItmDatExc { get; set; }

    [NotMapped]
    public int? AvlItmIstId { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual Ep AvlItmEps { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual Loc AvlItmLoc { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual Set? AvlItmSet { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual Usr? AvlItmUsrAlt { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual Usr? AvlItmUsrExc { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual Usr AvlItmUsrInc { get; set; } = null!;
}
