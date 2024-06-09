using StorageManager.App.Commons;
using System;
using System.Collections.Generic;

namespace StorageManager.App.Models;

public partial class DictionaryItem : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Value { get; set; }

    public int DictionaryId { get; set; }

    public virtual Dictionary Dictionary { get; set; } = null!;
}
