using System;
using System.Collections.Generic;
using System.Text;

namespace BestHB.Domain.Commands
{
    public class DeleteOrderCommand //TODO: Comando vazio 
    {
    }

    public enum DeleteOrderStatus
    {
        Success = 0,
        RejectedByExchange
    }
}
