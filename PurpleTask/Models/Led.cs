using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PurpleTask.Models;

public partial class Led
{
    public int LedId { get; set; }

    public string? LedNom { get; set; } 

    public string? LedMail{ get; set; }

    public string? LedTel { get; set; }

    public string? LedDes { get; set; }

    public DateTime LedDatInc { get; set; }


}
