using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurpleTask.Models;

public partial class Usr
{
    public int UsrId { get; set; }

    public string UsrCod { get; set; } = null!;

    public string? UsrNom { get; set; }

    public DateTime? UsrDatNasc { get; set; }

    public string? UsrSex { get; set; }

    public string? UsrEma { get; set; }

    public string? UsrFot { get; set; }

    public string? UsrSnh { get; set; }

    public DateTime? UsrDatInc { get; set; }

    public DateTime? UsrDatExl { get; set; }

    public DateTime? UsrDatAlt { get; set; }

    public int? UsrEmlVld { get; set; }

    public int? UsrAreAtu { get; set; }

    public int? UsrNvlCnh { get; set; }

    public DateTime? UsrDatAdm { get; set; }

    public string? UsrCidTra { get; set; }

    public string? UsrStaTra { get; set; }

    public decimal? UsrSal { get; set; }

    public string? UsrLgaPpg { get; set; }

    public int? UsrAss { get; set; }

    public int? UsrPfl { get; set; }

    public int? UsrIstId { get; set; }

    public int? UsrEpsId { get; set; }

    [NotMapped]
    public virtual ICollection<AvlItm> AvlItmAvlItmUsrAlts { get; set; } = new List<AvlItm>();

    [NotMapped]
    public virtual ICollection<AvlItm> AvlItmAvlItmUsrExcs { get; set; } = new List<AvlItm>();

    [NotMapped]
    public virtual ICollection<AvlItm> AvlItmAvlItmUsrIncs { get; set; } = new List<AvlItm>();

    [NotMapped]
    public virtual ICollection<Cec> CecCecUsrAlts { get; set; } = new List<Cec>();

    [NotMapped]
    public virtual ICollection<Cec> CecCecUsrExcs { get; set; } = new List<Cec>();

    [NotMapped]
    public virtual ICollection<Cec> CecCecUsrIncs { get; set; } = new List<Cec>();
    [NotMapped]
    public virtual ICollection<Ctt> CttCttUsrAlts { get; set; } = new List<Ctt>();
    [NotMapped]
    public virtual ICollection<Ctt> CttCttUsrExcs { get; set; } = new List<Ctt>();
    [NotMapped]
    public virtual ICollection<Ctt> CttCttUsrIncs { get; set; } = new List<Ctt>();
    [NotMapped]
    public virtual ICollection<Ctt> CttCttUsrs { get; set; } = new List<Ctt>();
    [NotMapped]
    public virtual ICollection<Ep> EpEpsUsrAlts { get; set; } = new List<Ep>();
    [NotMapped]
    public virtual ICollection<Ep> EpEpsUsrExcs { get; set; } = new List<Ep>();
    [NotMapped]
    public virtual ICollection<Ep> EpEpsUsrIncs { get; set; } = new List<Ep>();
    [NotMapped]
    public virtual ICollection<Itm> ItmItmUsrAlts { get; set; } = new List<Itm>();
    [NotMapped]
    public virtual ICollection<Itm> ItmItmUsrExcs { get; set; } = new List<Itm>();
    [NotMapped]
    public virtual ICollection<Itm> ItmItmUsrIncs { get; set; } = new List<Itm>();
    [NotMapped]
    public virtual ICollection<Loc> LocLocUsrAlts { get; set; } = new List<Loc>();
    [NotMapped]
    public virtual ICollection<Loc> LocLocUsrExcs { get; set; } = new List<Loc>();
    [NotMapped]
    public virtual ICollection<Loc> LocLocUsrIncs { get; set; } = new List<Loc>();
    [NotMapped]
    public virtual ICollection<Set> SetSetUsrAlts { get; set; } = new List<Set>();
    [NotMapped]
    public virtual ICollection<Set> SetSetUsrExcs { get; set; } = new List<Set>();
    [NotMapped]
    public virtual ICollection<Set> SetSetUsrIncs { get; set; } = new List<Set>();
    [NotMapped]
    public virtual Ep? UsrEps { get; set; }
    [NotMapped]
    public virtual Ist? UsrIst { get; set; }
}
