using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PurpleTask.Models;

public partial class Loc
{
    public int LocId { get; set; }

    public int LocEpsId { get; set; }

    public string LocCod { get; set; } = null!;

    public string LocNom { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public int LocSts { get; set; }

    [JsonIgnore]
    [NotMapped]
    public int LocUsrIncId { get; set; }

    [JsonIgnore]
    [NotMapped]
    public int? LocUsrAltId { get; set; }

    [JsonIgnore]
    [NotMapped]
    public int? LocUsrExcId { get; set; }

    [JsonIgnore]
    [NotMapped]
    public DateTime LocDatInc { get; set; }

    [JsonIgnore]
    [NotMapped]
    public DateTime? LocDatAlt { get; set; }

    [JsonIgnore]
    [NotMapped]
    public DateTime? LocDatExc { get; set; }

    public int? LocIstId { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<AvlItm> AvlItms { get; set; } = new List<AvlItm>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Cec> Cecs { get; set; } = new List<Cec>();

    [JsonIgnore]
    [NotMapped]
    public virtual Ep LocEps { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual Usr? LocUsrAlt { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual Usr? LocUsrExc { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual Usr LocUsrInc { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Set> Sets { get; set; } = new List<Set>();
}
