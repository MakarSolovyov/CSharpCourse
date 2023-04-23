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

        /// <summary>
        /// Wright input parameters in instance.
        /// </summary>
        /// <param name="actions">Action list of parameters.</param>
        public void InputParameters(List<Action> actions)
        {
            foreach (var action in actions)
            {
                action.Invoke();
            }
        }
    }
}
