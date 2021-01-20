using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Teste.Direcional.Dominio.Entidades
{
    [DataContract]
    public class Usuario : ClassMapper<Usuario>
    {
        public Usuario()
        {
            Table("Usuario");
            Map(x => x.Id).Column("Id");
            Map(x => x.Login).Column("Login");
            Map(x => x.Senha).Column("Senha");
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Login { get; set; }

        [DataMember]
        public string Senha { get; set; }
    }
}
