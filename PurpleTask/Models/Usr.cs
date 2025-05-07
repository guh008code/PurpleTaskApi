using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PurpleTask.Models;

public partial class Usr
{
    public int UsrId { get; set; }
    [JsonIgnore]
    [NotMapped]
    public string UsrCod { get; set; } = null!;
    [JsonIgnore]
    [NotMapped]
    public string? UsrNom { get; set; }
    [JsonIgnore]
    [NotMapped]
    public DateTime? UsrDatNasc { get; set; }
    [JsonIgnore]
    [NotMapped]
    public string? UsrSex { get; set; }
    [JsonIgnore]
    [NotMapped]
    public string? UsrEma { get; set; }
    [JsonIgnore]
    [NotMapped]
    public string? UsrFot { get; set; }

    public string? UsrSnh { get; set; }
    [JsonIgnore]
    [NotMapped]
    public DateTime? UsrDatInc { get; set; }
    [JsonIgnore]
    [NotMapped]
    public DateTime? UsrDatExl { get; set; }
    [JsonIgnore]
    [NotMapped]
    public DateTime? UsrDatAlt { get; set; }
    [JsonIgnore]
    [NotMapped]
    public int? UsrEmlVld { get; set; }
    [JsonIgnore]
    [NotMapped]
    public int? UsrAreAtu { get; set; }
    [JsonIgnore]
    [NotMapped]
    public int? UsrNvlCnh { get; set; }
    [JsonIgnore]
    [NotMapped]
    public DateTime? UsrDatAdm { get; set; }
    [JsonIgnore]
    [NotMapped]

    public string? UsrCidTra { get; set; }
    [JsonIgnore]
    [NotMapped]
    public string? UsrStaTra { get; set; }
    [JsonIgnore]
    [NotMapped]
    public decimal? UsrSal { get; set; }
    [JsonIgnore]
    [NotMapped]
    public string? UsrLgaPpg { get; set; }
    [JsonIgnore]
    [NotMapped]
    public int? UsrAss { get; set; }
    [JsonIgnore]
    [NotMapped]
    public int? UsrPfl { get; set; }
    [JsonIgnore]
    [NotMapped]
    public int? UsrIstId { get; set; }
    [JsonIgnore]
    [NotMapped]
    public int? UsrEpsId { get; set; }
    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<AvlItm> AvlItmAvlItmUsrAlts { get; set; } = new List<AvlItm>();
    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<AvlItm> AvlItmAvlItmUsrExcs { get; set; } = new List<AvlItm>();
    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<AvlItm> AvlItmAvlItmUsrIncs { get; set; } = new List<AvlItm>();
    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Cec> CecCecUsrAlts { get; set; } = new List<Cec>();
    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Cec> CecCecUsrExcs { get; set; } = new List<Cec>();
    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Cec> CecCecUsrIncs { get; set; } = new List<Cec>();
    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Ctt> CttCttUsrAlts { get; set; } = new List<Ctt>();
    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Ctt> CttCttUsrExcs { get; set; } = new List<Ctt>();
    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Ctt> CttCttUsrIncs { get; set; } = new List<Ctt>();
    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Ctt> CttCttUsrs { get; set; } = new List<Ctt>();
    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Ep> EpEpsUsrAlts { get; set; } = new List<Ep>();
    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Ep> EpEpsUsrExcs { get; set; } = new List<Ep>();
    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Ep> EpEpsUsrIncs { get; set; } = new List<Ep>();
    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Itm> ItmItmUsrAlts { get; set; } = new List<Itm>();
    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Itm> ItmItmUsrExcs { get; set; } = new List<Itm>();
    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Itm> ItmItmUsrIncs { get; set; } = new List<Itm>();
    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Loc> LocLocUsrAlts { get; set; } = new List<Loc>();
    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Loc> LocLocUsrExcs { get; set; } = new List<Loc>();
    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Loc> LocLocUsrIncs { get; set; } = new List<Loc>();
    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Set> SetSetUsrAlts { get; set; } = new List<Set>();
    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Set> SetSetUsrExcs { get; set; } = new List<Set>();
    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Set> SetSetUsrIncs { get; set; } = new List<Set>();
    [JsonIgnore]
    [NotMapped]
    public virtual Ep? UsrEps { get; set; }
    [JsonIgnore]
    [NotMapped]
    public virtual Ist? UsrIst { get; set; }
}
