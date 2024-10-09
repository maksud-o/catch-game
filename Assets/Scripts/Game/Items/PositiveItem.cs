using Caught.Services.Game;

namespace Caught.Game.Items
{
    public class PositiveItem : Item
    {
        #region Protected methods

        protected override void OnCaughtAction()
        {
            PlayerStatsService.Instance.ChangeScore(1);
        }

        protected override void OnFallAction()
        {
            PlayerStatsService.Instance.ChangeLives(-1);
        }

        #endregion
    }
}