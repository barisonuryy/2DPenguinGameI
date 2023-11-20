using UnityEngine;
using System;
namespace RobinGoodfellow.CircleGenerator {
    [Serializable]
    public class StrokeData : ICloneable {

        public StrokeData(float strokeSize, bool keepStrokeSizeRelative) {
            StrokeSize = strokeSize;
            KeepStrokeSizeRelative = keepStrokeSizeRelative;
        }


        [Min(0f), SerializeField]
        float _strokeSize = 0.1f;
        /// <summary>
        /// Defines the size of the "stroke" or the "border" of the circle. Like the radius, a value of 1 is equal to one Unity Editor grid square. Cannot be a negative number.
        /// </summary>
        public float StrokeSize {
            get { return _strokeSize; }
            set {
                if (value < 0) {
                    throw new ArgumentOutOfRangeException("strokeSize should be >= 0");
                }
                _strokeSize = value;
            }
        }

        [SerializeField]
        bool _keepStrokeSizeRelative = false;
        /// <summary>
        /// Toggle the ability to make the stroke size increase or decrease in proportion to the radius of the circle. When set to true, the stroke size will change as the radius changes. This is useful if you want to keep the stroke proportionate to the circle while changing the radius. When set to false, the stroke size will always remain constant, no matter the radius.
        /// </summary>
        public bool KeepStrokeSizeRelative { get { return _keepStrokeSizeRelative; } set { _keepStrokeSizeRelative = value; } }

        public object Clone() {
            return MemberwiseClone();
        }
    }
}
