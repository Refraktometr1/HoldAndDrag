using System.Linq;
using Codebase.Factory;
using Zenject;

namespace Codebase.Services
{
    public class CardsService
    {
        private GameFactory _gameFactory;
        
        [Inject]
        public void Construct(GameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void CreateNewCard()
        {
            if (_gameFactory.CardsMovers.Any(move => move.isEndMove == false))
                return;

            _gameFactory.CreateCard();
        }
    }
}