using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PurpleTask.Models;

public partial class Cec
{
    public int CecId { get; set; }

    public int CecEpsId { get; set; }

    public int CecLocId { get; set; }

    public string CecCod { get; set; } = null!;

    public string CecNom { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public int CecSts { get; set; }

    [JsonIgnore]
    [NotMapped]
    public int CecUsrIncId { get; set; }

    [JsonIgnore]
    [NotMapped]
    public int? CecUsrAltId { get; set; }

    [JsonIgnore]
    [NotMapped]
    public int? CecUsrExcId { get; set; }

    [JsonIgnore]
    [NotMapped]
    public DateTime CecDatInc { get; set; }

    [JsonIgnore]
    [NotMapped]
    public DateTime? CecDatAlt { get; set; }

    [JsonIgnore]
    [NotMapped]
    public DateTime? CecDatExc { get; set; }

    public int? CecIstId { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual Ep CecEps { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual Loc CecLoc { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual Usr? CecUsrAlt { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual Usr? CecUsrExc { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual Usr CecUsrInc { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Set> Sets { get; set; } = new List<Set>();
}
