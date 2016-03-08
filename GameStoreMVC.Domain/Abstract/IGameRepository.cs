using System.Collections.Generic;
using GameStoreMVC.Domain.Entities;

namespace GameStoreMVC.Domain.Abstract
{
    public interface IGameRepository
    {
        IEnumerable<Game> Games { get; }
    }
}
