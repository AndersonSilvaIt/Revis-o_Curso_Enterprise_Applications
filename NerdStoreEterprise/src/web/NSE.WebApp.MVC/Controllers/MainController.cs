﻿using Microsoft.AspNetCore.Mvc;
using NSE.Core.Communication;

namespace NSE.WebApp.MVC.Controllers
{
    public class MainController : Controller
    {
        protected bool ResponsePossuiErros(ResponseResult response)
        {
            if (response != null && response.Errors.Mensagens.Any())
            {
                foreach (var mensagem in response.Errors.Mensagens)
                {
                    ModelState.AddModelError(string.Empty, mensagem);
                }

                return true;
            }

            return false;
        }

        protected void AdicionarErroValidacao(string mensgem)
        {
            ModelState.AddModelError(string.Empty, mensgem);
        }

        protected bool OperacaoValida()
        {
            return ModelState.ErrorCount == 0;
        }
    }
}