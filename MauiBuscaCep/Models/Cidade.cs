﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBuscaCep.Models
{
    public class Cidade
    {
        public int id_cidade { get; set; }
        public string descricao { get; set; }
        public string UF { get; set; }
        public int code_ibge { get; set; }
        public int ddd { get; set; }
    }
}