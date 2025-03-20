using System;
using System.Collections.Generic;

namespace PurpleTask.Models;

public partial class Ctt
{
    public int CttId { get; set; }

    public string CttOri { get; set; } = null!;

    public int? CttEpsId { get; set; }

    public int? CttUsrId { get; set; }

    public string? CttNom { get; set; }

    public string? CttCgo { get; set; }

    public string? CttTip { get; set; }

    public string? CttTel { get; set; }

    public string? CttEml { get; set; }

    public string? CttTwi { get; set; }

    public string? CttLin { get; set; }

    public int CttSts { get; set; }

    public int CttUsrIncId { get; set; }

    public int? CttUsrAltId { get; set; }

    public int? CttUsrExcId { get; set; }

    public DateTime CttDatInc { get; set; }

    public DateTime? CttDatAlt { get; set; }

    public DateTime? CttDatExc { get; set; }

    public int? CttIstId { get; set; }

    public virtual Ep? CttEps { get; set; }

    public virtual Usr? CttUsr { get; set; }

    public virtual Usr? CttUsrAlt { get; set; }

    public virtual Usr? CttUsrExc { get; set; }

    public virtual Usr CttUsrInc { get; set; } = null!;
}
