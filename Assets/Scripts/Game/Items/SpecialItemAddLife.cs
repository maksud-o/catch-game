using Caught.Services.Game;

namespace Caught.Game.Items
{
    public class SpecialItemAddLife : SpecialItem
    {
        #region Protected methods

        protected override void OnCaughtAction()
        {
            PlayerStatsService.Instance.ChangeLives(1);
        }

        #endregion
    }
}