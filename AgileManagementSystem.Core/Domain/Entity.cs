using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Core.Domain
{
    /// <summary>
    /// Tüm entity'ler Id özelliğine sahip olacağı için, entity tanımlarken bu class'tan inherit olacak.
    /// Tüm entity'ler event yollayabilir olmalı.
    /// </summary>
    public abstract class Entity
    {
        public string Id { get; set; }
    }
}
