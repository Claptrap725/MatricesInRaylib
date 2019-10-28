using System;
using System.Collections.Generic;
using System.Text;
using rl = Raylib.Raylib;

namespace MaticesInRaylib
{
    /// <summary>
    /// Square Shaped Collider
    /// </summary>
    public class AABB : Collider
    {
        /// <summary>
        /// bottem left corner
        /// </summary>
        Vector3 min = new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
        /// <summary>
        /// top right corner
        /// </summary>
        Vector3 max = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);

        /// <summary>
        /// return the center point of the rectangle
        /// </summary>
        public Vector3 Center
        {
            get { return (min + max) * 0.5f;  }
        }
        /// <summary>
        /// returns the corners of the rectangle. Format: BL, TL, TR, BR
        /// </summary>
        public List<Vector3> Corners
        {
            get
            {
                // ignoring z axis for 2D
                List<Vector3> corners = new List<Vector3>();
                corners.Add(min); //BL
                corners.Add(new Vector3(min.x, max.y, min.z)); //TL
                corners.Add(max); //TR
                corners.Add(new Vector3(max.x, min.y, min.z)); //BL
                return corners;
            }
        }
        /// <summary>
        /// return width of the rectangle
        /// </summary>
        public float Width
        {
            get { return Math.Abs(min.x - max.x); }
        }
        /// <summary>
        /// return hieght of the rectangle
        /// </summary>
        public float Height
        {
            get { return Math.Abs(min.y - max.y); }
        }

        /// <summary>
        /// returns false if collider is set to default values. True otherwise
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            if (float.IsNegativeInfinity(min.x) && float.IsNegativeInfinity(min.y) && float.IsNegativeInfinity(min.z) && float.IsInfinity(max.x) && float.IsInfinity(max.y) && float.IsInfinity(max.z))
                return true;

            return false;
        }
        /// <summary>
        /// sets collider to default values
        /// </summary>
        public void Empty()
        {
            min = new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
            max = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
        }

        /// <summary>
        /// default contructor
        /// </summary>
        public AABB()
        {
            // set colliderType to aabb
            colliderType = ColliderType.aabb;
        }
        /// <summary>
        /// contructor that takes in the bottem left and top right corners
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public AABB(Vector3 min, Vector3 max)
        {
            // set min and max
            this.min = min;
            this.max = max;
            // set colliderType to aabb
            colliderType = ColliderType.aabb;
        }

        /// <summary>
        /// makes a bounding box that includes all points
        /// </summary>
        /// <param name="points"></param>
        public override void Fit(List<Vector3> points)
        {
            // invalidate the extents
            min = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
            max = new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);

            // find min and max of the points
            foreach (Vector3 p in points)
            {
                min = Vector3.Min(min, p);
                max = Vector3.Max(max, p);
            }
        }
        /// <summary>
        /// makes a bounding box that includes all points
        /// </summary>
        /// <param name="points"></param>
        public override void Fit(Vector3[] points)
        {
            // invalidate the extents
            min = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
            max = new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
            // find min and max of the points
            foreach (Vector3 p in points)
            {
                min = Vector3.Min(min, p);
                max = Vector3.Max(max, p);
            }
        }

        /// <summary>
        /// checks to see if the point overlaps this aabb
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public override bool Overlaps(Vector3 p)
        {
            // test for not overlapped as it exits faster
            return !(p.x < min.x || p.y < min.y ||
            p.x > max.x || p.y > max.y);
        }        /// <summary>
        /// checks to see if the other aabb overlaps this aabb
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool Overlaps(AABB other)
        {
            // test for not overlapped as it exits faster
            return !(max.x < other.min.x || max.y < other.min.y ||
            min.x > other.max.x || min.y > other.max.y);
        }
        /// <summary>
        /// checks to see if the circle overlaps this aabb
        /// </summary>
        /// <param name="circle"></param>
        /// <returns></returns>
        public override bool Overlaps(Circle circle)
        {
            Vector3 diff = ClosestPoint(circle.center) - circle.center;
            return diff.Dot(diff) <= (circle.radius * circle.radius);
        }
        /// <summary>
        /// returns a point within this aabb that is closest to the provided point
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public override Vector3 ClosestPoint(Vector3 p)
        {
            return Vector3.Clamp(p, min, max);
        }

        /// <summary>
        /// Draws collider if DrawColliders is enabled in the Game class
        /// </summary>
        public override void OnDraw()
        {
            if (Game.DrawColliders)
            {
                rl.DrawLine((int)Corners[0].x, (int)Corners[0].y, (int)Corners[1].x, (int)Corners[1].y, Raylib.Color.RED);
                rl.DrawLine((int)Corners[1].x, (int)Corners[1].y, (int)Corners[2].x, (int)Corners[2].y, Raylib.Color.RED);
                rl.DrawLine((int)Corners[2].x, (int)Corners[2].y, (int)Corners[3].x, (int)Corners[3].y, Raylib.Color.RED);
                rl.DrawLine((int)Corners[3].x, (int)Corners[3].y, (int)Corners[0].x, (int)Corners[0].y, Raylib.Color.RED);
            }
        }
    }
}
