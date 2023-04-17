using Model;

namespace WinFormsApp1
{
    /// <summary>
    /// Abstract base class MotionBaseUserControl.
    /// </summary>
    public abstract partial class MotionBaseUserControl : UserControl
    {
        /// <summary>
        /// Abstract method to get an Motion object.
        /// </summary>
        /// <returns>An Motion object.</returns>
        public abstract MotionBase GetMotion();
    }
}
