using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Models
{
    public enum OrderStatus
    {
        [Description("В ожидании")]
        Pending,
        [Description("Подтвержден")]
        Confirmed,
        [Description("Завершен")]
        Completed,
        [Description("Отменен")]
        Cancelled
    }
}
