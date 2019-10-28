using System;
using System.Collections.Generic;
using System.Text;

namespace MaticesInRaylib
{
    /// <summary>
    /// abstract Collider class
    /// </summary>
    public abstract class Collider
    {
        /// <summary>
        /// Used to differentiate aabb colliders and cicle colliders
        /// </summary>
        public enum ColliderType
        {
            aabb,circle
        }

        /// <summary>
        /// stores this colliders collider type
        /// </summary>
        public ColliderType colliderType;
        /// <summary>
        /// this string is used control which colliders will react with each other
        /// </summary>
        public string tag;

        /// <summary>
        /// abtract method to make the collider change size to just fit all points within the collider
        /// </summary>
        /// <param name="points"></param>
        public abstract void Fit(List<Vector3> points);
        /// <summary>
        /// abtract method to make the collider change size to just fit all points within the collider
        /// </summary>
        /// <param name="points"></param>
        public abstract void Fit(Vector3[] points);

        /// <summary>
        /// abstract method to test if a point is overlapping the collider
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public abstract bool Overlaps(Vector3 p);
        /// <summary>
        /// method to test if a collider is overlapping the collider. Will call correct overlaps method
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>        public bool Overlaps(Collider col)
        {
            if (col.colliderType == ColliderType.aabb)
            {
                // if the passed collider is an aabb call that method
                return Overlaps((AABB)col);
            }
            else if (col.colliderType == ColliderType.circle)
            {
                // if the passed collider is a cicle call that method
                return Overlaps((Circle)col);
            }
            // collider is not initialized to an aabb or circle and must be abstract
            throw new FormatException("Collider is not a valid type.");
        }
        /// <summary>
        /// abstract method to test if an aabb is overlapping the collider
        /// </summary>
        /// <param name="aabb"></param>
        /// <returns></returns>
        public abstract bool Overlaps(AABB aabb);
        /// <summary>
        /// abstract method to test if a cicle is overlapping the collider
        /// </summary>
        /// <param name="circle"></param>
        /// <returns></returns>
        public abstract bool Overlaps(Circle circle);
        /// <summary>
        /// abstract method to find the closest point in this colliser to the given point
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public abstract Vector3 ClosestPoint(Vector3 p);

        /// <summary>
        /// abstract OnDraw method
        /// </summary>
        public abstract void OnDraw();
    }
}
