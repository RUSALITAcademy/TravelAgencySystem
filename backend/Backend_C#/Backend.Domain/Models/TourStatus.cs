using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Models
{
    public enum TourStatus
    {
        [Description("Опубликован")]
        Published,
        [Description("Снят с публикации")]
        Archived
    }
}
