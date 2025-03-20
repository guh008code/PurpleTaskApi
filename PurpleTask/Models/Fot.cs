using System;
using System.Collections.Generic;

namespace PurpleTask.Models;

public partial class Fot
{
    public int FotId { get; set; }

    public int? FotUsrId { get; set; }

    public string? FotPat { get; set; }

    public string? FotTit { get; set; }

    public string? FotLeg { get; set; }

    public DateTime? FotDatInc { get; set; }
}
