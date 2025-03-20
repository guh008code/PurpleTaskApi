using System;
using System.Collections.Generic;

namespace PurpleTask.Models;

public partial class Loc
{
    public int LocId { get; set; }

    public int LocEpsId { get; set; }

    public string LocCod { get; set; } = null!;

    public string LocNom { get; set; } = null!;

    public int LocSts { get; set; }

    public int LocUsrIncId { get; set; }

    public int? LocUsrAltId { get; set; }

    public int? LocUsrExcId { get; set; }

    public DateTime LocDatInc { get; set; }

    public DateTime? LocDatAlt { get; set; }

    public DateTime? LocDatExc { get; set; }

    public int? LocIstId { get; set; }

    public virtual ICollection<AvlItm> AvlItms { get; set; } = new List<AvlItm>();

    public virtual ICollection<Cec> Cecs { get; set; } = new List<Cec>();

    public virtual Ep LocEps { get; set; } = null!;

    public virtual Usr? LocUsrAlt { get; set; }

    public virtual Usr? LocUsrExc { get; set; }

    public virtual Usr LocUsrInc { get; set; } = null!;

    public virtual ICollection<Set> Sets { get; set; } = new List<Set>();
}
