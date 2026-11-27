using System;
using System.Collections.Generic;

namespace shoppingweb3.Models;

public partial class Sanpham
{
    public int Masp { get; set; }

    public string Tensp { get; set; } = null!;

    public decimal Gia { get; set; }

    public int Madm { get; set; }

    public virtual Danhmuc? MadmNavigation { get; set; }
}
