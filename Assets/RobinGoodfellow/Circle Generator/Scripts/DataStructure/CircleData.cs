using UnityEngine;
using System;
namespace RobinGoodfellow.CircleGenerator {
    [Serializable]
    public class CircleData : ICloneable {

        public CircleData(float radius, float completion, float angle, int polygonQuantity, bool keepPolygonQuantityConsistent) {
            Radius = radius;
            Completion = completion;
            Angle = angle;
            PolygonQuantity = polygonQuantity;
            KeepPolygonQuantityConsistent = keepPolygonQuantityConsistent;
        }

        [Min(0f), SerializeField]
        private float _radius = 1;
        /// <summary>
        /// Defines the radius of the circle. This is the distance from the centre of the circle to its inner edge and does not include its border. A radius of 1 is equal to one grid square in the Unity Editor. Cannot be a negative number.
        /// </summary>
        public float Radius {
            get { return _radius; }
            set {
                if (value < 0) {
                    throw new ArgumentOutOfRangeException("radius should be >= 0");
                }
                _radius = value;
            }
        }

        [Range(0f, 360f), SerializeField]
        float _completion = 360;
        /// <summary>
        /// Defines a portion of the circle to be rendered, given in degrees. For example, to render a quarter of the circle, use a value of 90. Can range from 0 to 360.
        /// </summary>
        public float Completion {
            get { return _completion; }
            set {
                if (value < 0 || value > 360) {
                    throw new ArgumentOutOfRangeException("completion should be >= 0 and <= 360");
                }
                _completion = value;
            }
        }

        [Range(0f, 360f), SerializeField]
        float _angle = 0;
        /// <summary>
        /// Defines the rotation of the circle. Can range from 0 to 360.
        /// </summary>
        public float Angle {
            get { return _angle; }
            set {
                if (value < 0 || value > 360) {
                    throw new ArgumentOutOfRangeException("angle should be >= 0 and <= 360");
                }
                _angle = value;
            }
        }

        [Range(3, 360), SerializeField]
        int _polygonQuantity = 32;
        /// <summary>
        /// Defines the number of polygons to use when generating the circle. The minimum amount is 3, which would result in a triangular object. The number is arbitrarily capped at 360 as a safety feature to prevent accidental increase beyond the machine's capabilities. The more polygons, the smoother the circle will appear, at an expense in performance, depending on the machine's power.
        /// </summary>
        public int PolygonQuantity {
            get {

                if (KeepPolygonQuantityConsistent) {
                    return (int)Mathf.Ceil(Completion / 360f * _polygonQuantity);
                } else {
                    return _polygonQuantity;
                }
            }
            set {
                if (value < 3 || value > 360) {
                    throw new ArgumentOutOfRangeException("polygonQuantity should be >= 3 and <= 360");
                }
                _polygonQuantity = value;
            }
        }

        [SerializeField]
        bool _keepPolygonQuantityConsistent = true;
        /// <summary>
        /// Toggle the ability to change Circle Generator's internal polygon count depending on the Completion value. For example, when set to true, with a Polygon Quantity set to 60, and with a Completion of 90, the polygon quantity will reduce by roughly 1/4 to around 15. When set to false, no such reduction in polygon count will happen and polygon count will remain at 60. It is recommended to keep this set to true.
        /// </summary>
        public bool KeepPolygonQuantityConsistent {
            get { return _keepPolygonQuantityConsistent; }
            set { _keepPolygonQuantityConsistent = value; }
        }

        public object Clone() {
            return MemberwiseClone();
        }
    }
}