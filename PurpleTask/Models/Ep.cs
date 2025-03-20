using System;
using System.Collections.Generic;

namespace PurpleTask.Models;

public partial class Ep
{
    public int EpsId { get; set; }

    public string EpsNom { get; set; } = null!;

    public string? EpsNomFnt { get; set; }

    public string? EpsCnpj { get; set; }

    public string? EpsEdr { get; set; }

    public string? EpsNumEdr { get; set; }

    public string? EpsEdrCmp { get; set; }

    public string? EpsBrr { get; set; }

    public string? EpsCid { get; set; }

    public string? EpsCep { get; set; }

    public string? EpsUf { get; set; }

    public string? EpsPai { get; set; }

    public string? EpsSit { get; set; }

    public string? EpsObs { get; set; }

    public int EpsQtdItm { get; set; }

    public decimal? EpsVlrItm { get; set; }

    public DateTime? EpsDatUltAvl { get; set; }

    public int EpsSts { get; set; }

    public int EpsUsrIncId { get; set; }

    public int? EpsUsrAltId { get; set; }

    public int? EpsUsrExcId { get; set; }

    public DateTime EpsDatInc { get; set; }

    public DateTime? EpsDatAlt { get; set; }

    public DateTime? EpsDatExc { get; set; }

    public int? EpsIstId { get; set; }

    public virtual ICollection<AvlItm> AvlItms { get; set; } = new List<AvlItm>();

    public virtual ICollection<Cec> Cecs { get; set; } = new List<Cec>();

    public virtual ICollection<Ctt> Ctts { get; set; } = new List<Ctt>();

    public virtual Ist? EpsIst { get; set; }

    public virtual Usr? EpsUsrAlt { get; set; }

    public virtual Usr? EpsUsrExc { get; set; }

    public virtual Usr EpsUsrInc { get; set; } = null!;

    public virtual ICollection<Loc> Locs { get; set; } = new List<Loc>();

    public virtual ICollection<Set> Sets { get; set; } = new List<Set>();

    public virtual ICollection<Usr> Usrs { get; set; } = new List<Usr>();
}
