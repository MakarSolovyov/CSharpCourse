using Model;
using System.ComponentModel;

namespace WinFormsApp1
{
    /// <summary>
    /// Class MotionEventArgsList.
    /// </summary>
    public class MotionEventArgsList : EventArgs
    {
        /// <summary>
        /// Filtered motion list.
        /// </summary>
        public BindingList<MotionBase> MotionListFiltered { get; private set; }

        /// <summary>
        /// Constructor of event MotionEventArgs class with filtered motion list.
        /// </summary>
        /// <param name="motionListFiltered">Filtered motion list.</param>
        public MotionEventArgsList(BindingList<MotionBase> motionListFiltered)
        {
            MotionListFiltered = motionListFiltered;
        }
    }
}
