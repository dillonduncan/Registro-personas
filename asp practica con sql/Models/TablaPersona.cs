using System;
using System.Collections.Generic;

namespace asp_practica_con_sql.Models;

public partial class TablaPersona
{
    public int Id { get; set; }

    public string? NombrePersona { get; set; }

    public int IdGenero { get; set; }

    public int? EdadPersona { get; set; }

    public virtual TablaGenero IdGeneroNavigation { get; set; } = null!;
}
