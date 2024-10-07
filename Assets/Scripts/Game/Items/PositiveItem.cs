using System;

namespace Caught.Game.Items
{
    public class PositiveItem : Item
    {
        #region Events

        public static event Action<int> OnCaught;
        public static event Action<int> OnFall;

        #endregion

        #region Protected methods

        protected override void OnCaughtAction()
        {
            OnCaught?.Invoke(1);
        }

        protected override void OnFallAction()
        {
            OnFall?.Invoke(-1);
        }

        #endregion
    }
}