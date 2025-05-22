using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PurpleTask.Models;

public partial class Set
{
    public int SetId { get; set; }

    public int SetEpsId { get; set; }

    public int SetLocId { get; set; }

    public string SetCod { get; set; } = null!;

    public string SetNom { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public int SetSts { get; set; }

    [JsonIgnore]
    [NotMapped]
    public int SetUsrIncId { get; set; }

    [JsonIgnore]
    [NotMapped]
    public int? SetUsrAltId { get; set; }

    [JsonIgnore]
    [NotMapped]
    public int? SetUsrExcId { get; set; }

    [JsonIgnore]
    [NotMapped]
    public DateTime SetDatInc { get; set; }

    [JsonIgnore]
    [NotMapped]
    public DateTime? SetDatAlt { get; set; }

    [JsonIgnore]
    [NotMapped]
    public DateTime? SetDatExc { get; set; }

    public int? SetIstId { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<AvlItm> AvlItms { get; set; } = new List<AvlItm>();

    [JsonIgnore]
    [NotMapped]
    public virtual Cec SetCec { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual Ep SetEps { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual Loc SetLoc { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual Usr? SetUsrAlt { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual Usr? SetUsrExc { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual Usr SetUsrInc { get; set; } = null!;
}
