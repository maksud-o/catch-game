using System;

namespace Caught.Game.Items
{
    public class SpecialItemAddLife : SpecialItem
    {
        #region Events

        public static event Action<int> OnCaught;

        #endregion

        #region Protected methods

        protected override void OnCaughtAction()
        {
            OnCaught?.Invoke(1);
        }

        #endregion
    }
}