using System;
using System.Collections.Generic;

namespace AinAlfahd.Models;

public partial class TblLog
{
    public int Id { get; set; }

    public string? Pvalue { get; set; }
    public string? Env { get; set; }
    public string InputParamiter { get; set; }
    public string OutputParamiter { get; set; }
    public string Result { get; set; }
    public DateTime InsertDt { get; set; }
}
