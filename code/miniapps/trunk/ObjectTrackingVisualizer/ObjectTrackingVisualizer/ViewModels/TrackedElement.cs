using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using Microsoft.Kinect;
using ObjectTrackingVisualizer.Service;

namespace ObjectTrackingVisualizer.ViewModels
{
    public class TrackedElement : Notifier
    {
        #region Skeleton to ... Calcualators

        internal static class PositionCalculator
        {
            internal static double CalcLeft(double x)
            {
                return Math.Abs(200 - (x * -400));
            }

            internal static double CalcTop(double y)
            {
                return Math.Abs(200 - (y * 400));
            }
        }

        internal static class SizeCalculator
        {
            internal static double CalcWidth(double z)
            {
                return (100 / Math.Abs(z)) * 3;
            }

            internal static double CalcHeight(double z)
            {
                return (100 / Math.Abs(z)) * 4;
            }
        }

        internal static class ColorCalculator
        {
            internal static Color CalculateColor(int id)
            {
                var random = new Random();
                return Color.FromArgb((byte)(random.Next(100) + 100), (byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256));
            }
        }

        #endregion

        #region Constructor
        public TrackedElement(Skeleton skeleton)
        {
            Skeleton = skeleton;
            _color = ColorCalculator.CalculateColor(Id);
            Notify("Id");
            Notify("Color");
            Notify("Name");
        }
        #endregion

        #region Properties

        #region General

        public int Id { get { return Skeleton.TrackingId; } }
        public string Name { get { return "" + Id; } }
        private readonly Color _color;
        public Color Color { get { return _color; } }

        private Skeleton _skeleton;
        public Skeleton Skeleton
        {
            get { return _skeleton; }
            set
            {
                _skeleton = value;
                Notify("Skeleton");
                Notify("Left");
                Notify("Top");
                Notify("Height");
                Notify("Width");
            }
        }

        #endregion

        #region Position and Size

        public double Left { get { return PositionCalculator.CalcLeft(Skeleton.Position.X); } }
        public double Top { get { return PositionCalculator.CalcTop(Skeleton.Position.Y); } }
        public double Height { get { return SizeCalculator.CalcHeight(Skeleton.Position.Z); } }
        public double Width { get { return SizeCalculator.CalcWidth(Skeleton.Position.Z); } }

        #endregion

        #endregion
    }
}
