using DapperExtensions.Mapper;
using System;
using System.Runtime.Serialization;

namespace Teste.Direcional.Dominio.Entidades
{
    [DataContract]
    public class Contato : ClassMapper<Contato>
    {
        public Contato()
        {
            Table("Contato");
            Map(x => x.Id).Column("Id");
            Map(x => x.Nome).Column("Nome");
            Map(x => x.CPF).Column("CPF");
            Map(x => x.Email).Column("Email");
            Map(x => x.Anexo).Column("Anexo");
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nome { get; set; }

        [DataMember]
        public string CPF { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Anexo { get; set; }
    }
}
