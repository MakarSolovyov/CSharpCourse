using Model;
using System.ComponentModel;

namespace WinFormsApp1
{
    /// <summary>
    /// Class MotionEventArgs.
    /// </summary>
    public class MotionEventArgs : EventArgs
    {
        /// <summary>
        /// Motion.
        /// </summary>
        public MotionBase Motion { get; private set; }

        /// <summary>
        /// Constructor of event MotionEventArgs class with MotionBase.
        /// </summary>
        /// <param name="motion">Motion.</param>
        public MotionEventArgs(MotionBase motion)
        {
            Motion = motion;
        }

        /// <summary>
        /// Filtered motion list.
        /// </summary>
        public BindingList<MotionBase> MotionListFiltered { get; private set; }

        /// <summary>
        /// Constructor of event MotionEventArgs class with filtered motion list.
        /// </summary>
        /// <param name="motionListFiltered">Filtered motion list.</param>
        public MotionEventArgs(BindingList<MotionBase> motionListFiltered)
        {
            MotionListFiltered = motionListFiltered;
        }
    }
}
