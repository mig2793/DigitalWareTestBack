using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    [MetadataType(typeof(productos.MetaData))]
    public partial class productos
    {
        sealed class MetaData {

            [Required]
            public decimal codigo_producto { get; set; }

            [Required]
            public string producto { get; set; }

            [Required]
            public decimal costo { get; set; }

            [Required]
            public int stock { get; set; }

            [Required]
            public byte id_categoria_producto { get; set; }
        }
    }
}
