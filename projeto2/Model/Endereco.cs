﻿using projeto2.API.Model.Base;

namespace projeto2.API.Model
{
    public class Endereco : BaseEntity
    {
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        
    }
}
