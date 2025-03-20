using System;
using System.Collections.Generic;

namespace PurpleTask.Models;

public partial class Rmd
{
    public int RmdId { get; set; }

    public int? RmdUsrId { get; set; }

    public int? RmdUsrUsrId { get; set; }

    public DateTime? RmdDatInc { get; set; }

    public int? RmdIstId { get; set; }
}
