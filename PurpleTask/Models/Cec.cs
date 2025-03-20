using System;
using System.Collections.Generic;

namespace PurpleTask.Models;

public partial class Cec
{
    public int CecId { get; set; }

    public int CecEpsId { get; set; }

    public int CecLocId { get; set; }

    public string CecCod { get; set; } = null!;

    public string CecNom { get; set; } = null!;

    public int CecSts { get; set; }

    public int CecUsrIncId { get; set; }

    public int? CecUsrAltId { get; set; }

    public int? CecUsrExcId { get; set; }

    public DateTime CecDatInc { get; set; }

    public DateTime? CecDatAlt { get; set; }

    public DateTime? CecDatExc { get; set; }

    public int? CecIstId { get; set; }

    public virtual Ep CecEps { get; set; } = null!;

    public virtual Loc CecLoc { get; set; } = null!;

    public virtual Usr? CecUsrAlt { get; set; }

    public virtual Usr? CecUsrExc { get; set; }

    public virtual Usr CecUsrInc { get; set; } = null!;

    public virtual ICollection<Set> Sets { get; set; } = new List<Set>();
}
