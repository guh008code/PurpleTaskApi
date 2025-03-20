using System;
using System.Collections.Generic;

namespace PurpleTask.Models;

public partial class Set
{
    public int SetId { get; set; }

    public int SetEpsId { get; set; }

    public int SetLocId { get; set; }

    public int SetCecId { get; set; }

    public string SetCod { get; set; } = null!;

    public string SetNom { get; set; } = null!;

    public int SetSts { get; set; }

    public int SetUsrIncId { get; set; }

    public int? SetUsrAltId { get; set; }

    public int? SetUsrExcId { get; set; }

    public DateTime SetDatInc { get; set; }

    public DateTime? SetDatAlt { get; set; }

    public DateTime? SetDatExc { get; set; }

    public int? SetIstId { get; set; }

    public virtual ICollection<AvlItm> AvlItms { get; set; } = new List<AvlItm>();

    public virtual Cec SetCec { get; set; } = null!;

    public virtual Ep SetEps { get; set; } = null!;

    public virtual Loc SetLoc { get; set; } = null!;

    public virtual Usr? SetUsrAlt { get; set; }

    public virtual Usr? SetUsrExc { get; set; }

    public virtual Usr SetUsrInc { get; set; } = null!;
}
