using System;
using System.Collections.Generic;

namespace ApiServiceExample.Models;

public partial class Customer
{
    public int Uid { get; set; }

    public string? FormattedUid { get; set; }

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime CreateTime { get; set; }

    public int HasDelete { get; set; }

    public DateTime? DeleteTime { get; set; }
}
