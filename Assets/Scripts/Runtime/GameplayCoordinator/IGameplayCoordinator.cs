﻿using Cysharp.Threading.Tasks;
using Runtime.GameplayCoordinator.GameplayStates;
using Runtime.MatchService;

namespace Runtime.GameplayCoordinator
{
    public interface IGameplayCoordinator
    {
        public UniTask InitializeMatch(Match match);
        public UniTask FinalizeMatch();

        public UniTask RestartRound();
        
        public UniTask ChangeState<T>() where T : GameplayState;
        public UniTask ChangeTurn();
    }
}