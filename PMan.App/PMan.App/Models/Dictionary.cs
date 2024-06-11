using StorageManager.App.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;

namespace StorageManager.App.Models;

public partial class Dictionary : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<DictionaryItem> DictionaryItems { get; set; } = new List<DictionaryItem>();
    [NotMapped]
    public DictionaryItem? DefaultItem {
        get {  
            if(DictionaryItems.Any())
            {
                var defaultItem = DictionaryItems.FirstOrDefault(x => x.IsDefault);

                if(defaultItem is null)
                    return DictionaryItems.FirstOrDefault();

                return defaultItem;
            }            
            
            return null;
        }
    
    }

    [NotMapped]
    public int DictionaryItemsCount
    {
        get { return DictionaryItems.Count; }
    }
}
