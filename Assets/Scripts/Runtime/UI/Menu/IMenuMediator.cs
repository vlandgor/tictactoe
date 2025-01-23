using Runtime.MatchManager;

namespace Runtime.UI.Menu
{
    public interface IMenuMediator
    {
        public void SetPlayerInfo(string playerName);
        
        public void ShowShop();
        public void ShowPieces();
        public void ShowQuests();
        public void ShowSettings();
        public void ShowGameSetup(MatchMode matchMode);
    }
}