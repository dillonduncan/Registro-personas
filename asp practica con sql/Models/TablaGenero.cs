using System;
using System.Collections.Generic;

namespace asp_practica_con_sql.Models;

public partial class TablaGenero
{
    public int Id { get; set; }

    public string NombreGenero { get; set; } = null!;

    public virtual ICollection<TablaPersona> TablaPersonas { get; set; } = new List<TablaPersona>();
}
