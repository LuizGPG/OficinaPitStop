using System;

namespace OficinaPitStop.Services.Execptions
{
    public class NotFoundExepction : ApplicationException
    {
        public NotFoundExepction(string mensagem) : base(mensagem)
        {
            
        }
    }
}