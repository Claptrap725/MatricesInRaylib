using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MaticesInRaylib
{
    /// <summary>
    /// Basic abject that exists in the Game. Has a Transform and can take part in heirarchy
    /// </summary>
    class GameObject
    {
        /// <summary>
        /// Parent GameObject of this GameObject
        /// </summary>
        protected GameObject parent = null;
        /// <summary>
        /// All children of this GameObject
        /// </summary>
        protected List<GameObject> children = new List<GameObject>();

        /// <summary>
        /// Local Space Transform. Relative to parent
        /// </summary>
        protected Matrix3 localTransform = new Matrix3();
        /// <summary>
        /// World Space Transform. Relative to screen.
        /// </summary>
        protected Matrix3 globalTransform = new Matrix3();

        /// <summary>
        /// true is the object is alive
        /// </summary>
        public bool alive = true;
        /// <summary>
        /// Collider for this Gameobject
        /// </summary>
        public Collider collider;

        /// <summary>
        /// returns a piont that is the location of this object in world space
        /// </summary>
        public Vector3 Position
        {
            get  { return new Vector3(globalTransform.m7, globalTransform.m8, 1);  }
        }
        /// <summary>
        /// return Local Transform
        /// </summary>
        public Matrix3 LocalTransform
        {
            get { return localTransform; }
        }
        /// <summary>
        /// returns Global Transform
        /// </summary>
        public Matrix3 GlobalTransform
        {
            get { return globalTransform; }
        }
        /// <summary>
        /// returns Parent GameObject
        /// </summary>
        public GameObject Parent
        {
            get { return parent; }
        }
        /// <summary>
        ///  default constructor
        /// </summary>
        public GameObject()
        {

        }
        /// <summary>
        /// contructor that also sets position of the new GameObject
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public GameObject(float x, float y)
        {
            // go to starting position
            SetPosition(x, y);
        }

        /// <summary>
        /// decontructor
        /// </summary>
        ~GameObject()
        {
            // see if this object has a parent
            if (parent != null)
            {
                // remove parent
                parent.RemoveChild(this);
            }

            // trevese children
            foreach (GameObject so in children)
            {
                // remove their parent
                so.parent = null;
            }
        }

        /// <summary>
        /// returns total amount of children
        /// </summary>
        /// <returns></returns>
        public int GetChildCount()
        {
            return children.Count;
        }

        /// <summary>
        /// return child at index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public GameObject GetChild(int index)
        {
            return children[index];
        }

        /// <summary>
        /// add a new child to this object
        /// </summary>
        /// <param name="child"></param>
        public void AddChild(GameObject child)
        {
            // assign "this as parent
            child.parent = this;
            // add new child to collection
            children.Add(child);
        }

        /// <summary>
        /// remove a specific child object
        /// </summary>
        /// <param name="child"></param>
        public void RemoveChild(GameObject child)
        {
            // check if there was a child we removed
            if (children.Remove(child) == true)
            {
                // set child's new localTransform so it doesn't teleport somewhere else
                child.SetLocalTransformToGlobal();
                // remove child's parent
                child.parent = null;
            }
        }

        /// <summary>
        /// Sets this object's localTransform to be the same as the global transform
        /// </summary>
        public void SetLocalTransformToGlobal()
        {
            localTransform.Set(globalTransform);
        }

        /// <summary>
        /// run's OnUpdate methods on this and all children
        /// </summary>
        /// <param name="dT"></param>
        public void Update(float dT)
        {
            if (alive)
            {
                // run OnUpdate behaviour
                OnUpdate(dT);

                // update children
                foreach (GameObject child in children)
                {
                    child.Update(dT);
                }
            }
            
        }

        /// <summary>
        /// run's OnDraw method on this and all children
        /// </summary>
        public void Draw()
        {
            // run OnDraw behaviour
            OnDraw();

            // draw children
            foreach (GameObject child in children)
            {
                child.Draw();
            }
        }
        
        /// <summary>
        /// Does nothing on base GameObject. Override me!
        /// </summary>
        /// <param name="dT"></param>
        public virtual void OnUpdate(float dT)
        {

        }

        /// <summary>
        /// Does nothing on base GameObject. Override me!
        /// </summary>
        public virtual void OnDraw()
        {
            
        }

        /// <summary>
        /// Updates our transform to comply with parent's movements and then updates children
        /// </summary>
        public void UpdateTransform()
        {
            // check if we have a parent
            if (parent != null)
                // set globalTransform based on parent's global and our local
                globalTransform = parent.globalTransform * localTransform;
            else
                // our global equals our local
                globalTransform = localTransform;

            // update children Transforms
            foreach (GameObject child in children)
                child.UpdateTransform();
        }

        /// <summary>
        /// Teleports to the location
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetPosition(float x, float y)
        {
            localTransform.SetTranslation(x, y);
            UpdateTransform();
        }

        /// <summary>
        /// Teleports to the location
        /// </summary>
        /// <param name="v"></param>
        public void SetPosition(Vector3 v)
        {
            localTransform.SetTranslation(v.x, v.y);
            UpdateTransform();
        }

        /// <summary>
        /// snaps rotation of this object to a rotation in radians
        /// </summary>
        /// <param name="radians"></param>
        public void SetRotate(float radians)
        {
            localTransform.SetRotateZ(radians);
            UpdateTransform();
        }

        /// <summary>
        /// Rotates object by radians
        /// </summary>
        /// <param name="radians"></param>
        public void Rotate(float radians)
        {
            localTransform.RotateZ(radians);
            UpdateTransform();
        }

        /// <summary>
        /// return global rotation in radians
        /// </summary>
        /// <returns></returns>
        public float GetRotate()
        {
            return globalTransform.GetRotateZ();
        }

        /// <summary>
        /// sets scale to width and height
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SetScale(float width, float height)
        {
            localTransform.SetScaled(width, height, 1);
            UpdateTransform();
        }

        /// <summary>
        /// teleports to new location by adding x and y to current position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Translate(float x, float y)
        {
            localTransform.Translate(x, y);
            UpdateTransform();
        }

        /// <summary>
        /// teleports to new location by adding vector to current position
        /// </summary>
        /// <param name="v"></param>
        public void Translate(Vector3 v)
        {
            localTransform.Translate(v.x, v.y);
            UpdateTransform();
        }

        /// <summary>
        /// scales transform by width and height
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void Scale(float width, float height)
        {
            localTransform.Scale(width, height, 1);
            UpdateTransform();
        }

        /// <summary>
        /// Called when the object should be killed
        /// </summary>
        public virtual void Die()
        {
            //set that we are no longer alive
            alive = false;
            //get all children
            foreach (var i in children)
            {
                //tell them they are dead as well
                i.Die();
            }
        }

    }
}
