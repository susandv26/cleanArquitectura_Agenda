﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Entidades.DireccionDTOs
{
    public class DireccionRequestDTO
    {
        public string NumCasa { get; set; }
        public string Calle { get; set; }
        public string Colonia { get; set; }
        public int IdCiudad { get; set; }
    }
}
