﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioWebAPI_02.Services.Base
{
    public class ServiceResponse<T>
    {
        public ServiceResponse(T objeto)
        {
            Sucesso = true;
            Mensagem = string.Empty;
            ObjetoRetorno = objeto;
        }

        public ServiceResponse(string mensagemDeErro)
        {
            Sucesso = false;
            Mensagem = mensagemDeErro;
            ObjetoRetorno = default;
        }

        public bool Sucesso { get; private set; }
        public string Mensagem { get; private set; }
        public T ObjetoRetorno { get; private set; }
    }
}
