using System;
using System.Collections.Generic;

namespace MVC12.DbVirtualViews;

public partial class ViewGpuSpec
{
    public int GpuId { get; set; }
    public int ProductSkuId { get; set; }

    public string GpuName { get; set; } = null!;

    public float MemorySize { get; set; }

    public string MemoryType { get; set; } = null!;

    public int Clock { get; set; }

    public int UnifiedShader { get; set; }

    public int Tmu { get; set; }

    public int Rop { get; set; }

    public bool? Igpu { get; set; }
    public string Bus { get; set; } = null!;
}
