using StorageManager.App.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace StorageManager.App.Models;

public partial class Dictionary : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<DictionaryItem> DictionaryItems { get; set; } = new List<DictionaryItem>();

    [NotMapped]
    public int DictionaryItemsCount
    {
        get { return DictionaryItems.Count; }
    }
}
