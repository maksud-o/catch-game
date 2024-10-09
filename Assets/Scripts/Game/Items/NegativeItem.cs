using Caught.Services.Game;

namespace Caught.Game.Items
{
    public class NegativeItem : Item
    {
        #region Protected methods

        protected override void OnCaughtAction()
        {
            PlayerStatsService.Instance.ChangeScore(-1);
        }

        #endregion
    }
}