using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PurpleTask.Models;

public partial class Ep
{
    public int EpsId { get; set; }

    public string EpsNom { get; set; } = null!;

    public string? EpsNomFnt { get; set; }

    public string? EpsCnpj { get; set; }

    [JsonIgnore]
    [NotMapped]
    public string? EpsEdr { get; set; }

    [JsonIgnore]
    [NotMapped]
    public string? EpsNumEdr { get; set; }

    [JsonIgnore]
    [NotMapped]
    public string? EpsEdrCmp { get; set; }

    [JsonIgnore]
    [NotMapped]
    public string? EpsBrr { get; set; }

    [JsonIgnore]
    [NotMapped]
    public string? EpsCid { get; set; }

    [JsonIgnore]
    [NotMapped]
    public string? EpsCep { get; set; }
    [JsonIgnore]
    [NotMapped]
    public string? EpsUf { get; set; }

    [JsonIgnore]
    [NotMapped]
    public string? EpsPai { get; set; }

    [JsonIgnore]
    [NotMapped]
    public string? EpsSit { get; set; }
    [JsonIgnore]
    [NotMapped]
    public string? EpsObs { get; set; }

    [JsonIgnore]
    [NotMapped]
    public int EpsQtdItm { get; set; }

    [JsonIgnore]
    [NotMapped]
    public decimal? EpsVlrItm { get; set; }

    [JsonIgnore]
    [NotMapped]
    public DateTime? EpsDatUltAvl { get; set; }

    [JsonIgnore]
    [NotMapped]
    public int EpsSts { get; set; }

    [JsonIgnore]
    [NotMapped]
    public int EpsUsrIncId { get; set; }

    [JsonIgnore]
    [NotMapped]
    public int? EpsUsrAltId { get; set; }

    [JsonIgnore]
    [NotMapped]
    public int? EpsUsrExcId { get; set; }

    [JsonIgnore]
    [NotMapped]
    public DateTime EpsDatInc { get; set; }

    [JsonIgnore]
    [NotMapped]
    public DateTime? EpsDatAlt { get; set; }

    [JsonIgnore]
    [NotMapped]
    public DateTime? EpsDatExc { get; set; }

    public int? EpsIstId { get; set; }

    [JsonIgnore]
    [NotMapped]

    public virtual ICollection<AvlItm> AvlItms { get; set; } = new List<AvlItm>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Cec> Cecs { get; set; } = new List<Cec>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Ctt> Ctts { get; set; } = new List<Ctt>();

    [JsonIgnore]
    [NotMapped]
    public virtual Ist? EpsIst { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual Usr? EpsUsrAlt { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual Usr? EpsUsrExc { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual Usr EpsUsrInc { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Loc> Locs { get; set; } = new List<Loc>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Set> Sets { get; set; } = new List<Set>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Usr> Usrs { get; set; } = new List<Usr>();
}
