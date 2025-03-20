using System;
using System.Collections.Generic;

namespace PurpleTask.Models;

public partial class Ist
{
    public int IstId { get; set; }

    public string? IstNomFnt { get; set; }

    public string? IstCnpj { get; set; }

    public int? IstSts { get; set; }

    public int? IstUsrIncId { get; set; }

    public int? IstUsrAltId { get; set; }

    public DateTime? IstUsrDatInc { get; set; }

    public DateTime? IstUsrDatAlt { get; set; }

    public virtual ICollection<Ep> Eps { get; set; } = new List<Ep>();

    public virtual ICollection<Usr> Usrs { get; set; } = new List<Usr>();
}
