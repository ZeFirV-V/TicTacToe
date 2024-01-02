using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.Contexts.GameContext.Interfaces;
using TicTacToe.Services;
using TicTacToe.View;

namespace TicTacToe.Controllers
{
    public class Handler : BaseHandler
    {
        public Handler(IGameContext gameContext, IApplicationView applicationView, ExecutorsService executorsService) 
            : base(gameContext, applicationView, executorsService)
        {
        }
    }
}
