﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBuscaCep.Models
{
    public class Cep
    {
        public string CEP { get; set; }
        public string id_logradouro { get; set; }
        public string tipo { get; set; }
        public string descricao { get; set; }
        public int id_cidade { get; set; }
        public string UF { get; set; }
        public string complemento { get; set; }
        public string desc_sem_num { get; set; }
        public string desc_cidade { get; set; }
        public int code_cidade_ibge { get; set; }
        public string desc_bairro { get; set; }
    }
}