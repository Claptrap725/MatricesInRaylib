using System;
using System.Collections.Generic;
using System.Text;
using rl = Raylib.Raylib;

namespace MaticesInRaylib
{
    /// <summary>
    /// Circle shaped collider
    /// </summary>
    public class Circle : Collider
    {
        /// <summary>
        /// center point of the circle
        /// </summary>
        public Vector3 center = new Vector3();
        /// <summary>
        /// radius of the circle
        /// </summary>
        public float radius;
        /// <summary>
        /// default constructor
        /// </summary>
        public Circle()
        {
            // set colliderType to circle
            colliderType = ColliderType.circle;
        }
        /// <summary>
        /// contructor that takes in the center point and radius
        /// </summary>
        /// <param name="center point"></param>
        /// <param name="radius"></param>
        public Circle(Vector3 p, float r)
        {
            // set center
            center = p;
            // set radius
            radius = r;
            // set colliderType to cicle
            colliderType = ColliderType.circle;
        }

        /// <summary>
        /// makes a circle that includes all points
        /// </summary>
        /// <param name="points"></param>
        public override void Fit(Vector3[] points)
        {
            // invalidate extents
            Vector3 min = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            Vector3 max = new Vector3(float.MinValue, float.MinValue, float.MinValue);
            // find min and max of the points
            for (int i = 0; i < points.Length; ++i)
            {
                min = Vector3.Min(min, points[i]);
                max = Vector3.Max(max, points[i]);
            }
            // put a circle around the min/max box
            center = (min + max) * 0.5f;
            radius = center.Distance(max);
        }
        /// <summary>
        /// makes a circle that includes all points
        /// </summary>
        /// <param name="points"></param>
        public override void Fit(List<Vector3> points)
        {
            // invalidate extents
            Vector3 min = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            Vector3 max = new Vector3(float.MinValue, float.MinValue, float.MinValue);
            // find min and max of the points
            foreach (Vector3 p in points)
            {
                min = Vector3.Min(min, p);
                max = Vector3.Max(max, p);
            }
            // put a circle around the min/max box
            center = (min + max) * 0.5f;
            radius = center.Distance(max);
        }

        /// <summary>
        /// checks to see if the point overlaps this circle
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public override bool Overlaps(Vector3 p)
        {
            Vector3 toPoint = p - center;
            return toPoint.magnitudeSqr <= (radius * radius);
        }        /// <summary>
        /// checks to see if the other circle overlaps this circle
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool Overlaps(Circle other)
        {
            Vector3 diff = other.center - center;
            // compare distance between spheres to combined radii
            float r = radius + other.radius;
            return diff.magnitudeSqr <= (r * r);
        }
        /// <summary>
        /// checks to see if the aabb overlaps this circle
        /// </summary>
        /// <param name="aabb"></param>
        /// <returns></returns>
        public override bool Overlaps(AABB aabb)
        {
            Vector3 diff = aabb.ClosestPoint(center) - center;
            return diff.Dot(diff) <= (radius * radius);
        }

        /// <summary>
        /// returns a point within this cicle that is closest to the provided point
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public override Vector3 ClosestPoint(Vector3 p)
        {
            // distance from center
            Vector3 toPoint = p - center;
            // if outside of radius bring it back to the radius
            if (toPoint.magnitudeSqr > radius * radius)
            {
                toPoint = toPoint.normalized * radius;
            }
            return center + toPoint;
        }

        /// <summary>
        /// Draws collider if DrawColliders is enabled in the Game class
        /// </summary>
        public override void OnDraw()
        {
            if (Game.DrawColliders)
                rl.DrawCircleLines((int)center.x, (int)center.y, radius, Raylib.Color.RED);
        }

    }
}
