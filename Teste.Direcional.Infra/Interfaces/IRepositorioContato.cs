﻿using System;
using System.Collections.Generic;
using System.Text;
using Teste.Direcional.Dominio.Entidades;

namespace Teste.Direcional.Infra.Interfaces
{
    public interface IRepositorioContato : IRepositorioBase<Contato>
    {
        Contato ObterPorCPF(string cpf);
        int Salvar(Contato registro);
    }
}