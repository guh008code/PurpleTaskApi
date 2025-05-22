using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PurpleTask.Models;

public partial class Itm
{
    public int ItmId { get; set; }

    public string? ItmNom { get; set; } 

    public int ItmSts { get; set; }

    public int ItmUsrIncId { get; set; }

    public int? ItmUsrAltId { get; set; }

    public int? ItmUsrExcId { get; set; }

    public DateTime ItmDatInc { get; set; }

    public DateTime? ItmDatAlt { get; set; }

    public DateTime? ItmDatExc { get; set; }

    public int? ItmIstId { get; set; }
    [JsonIgnore]
    [NotMapped]
    public virtual Usr? ItmUsrAlt { get; set; }
    [JsonIgnore]
    [NotMapped]
    public virtual Usr? ItmUsrExc { get; set; }
    [JsonIgnore]
    [NotMapped]
    public virtual Usr? ItmUsrInc { get; set; }
}
