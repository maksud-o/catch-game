using System;

namespace Caught.Game.Items
{
    public class NegativeItem : Item
    {
        #region Events

        public static event Action<int> OnCaught;

        #endregion

        #region Protected methods

        protected override void OnCaughtAction()
        {
            OnCaught?.Invoke(-1);
        }

        #endregion
    }
}