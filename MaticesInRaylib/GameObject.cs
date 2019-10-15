using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MaticesInRaylib
{
    class GameObject
    {
        protected GameObject parent = null;
        protected List<GameObject> children = new List<GameObject>();

        protected Matrix3 localTransform = new Matrix3();
        protected Matrix3 globalTransform = new Matrix3();

        public Matrix3 LocalTransform
        {
            get { return localTransform; }
        }

        public Matrix3 GlobalTransform
        {
            get { return globalTransform; }
        }

        public GameObject Parent
        {
            get { return parent; }
        }
        
        public GameObject()
        {

        }

        ~GameObject()
        {
            if (parent != null)
            {
                parent.RemoveChild(this);
            }

            foreach (GameObject so in children)
            {
                so.parent = null;
            }
        }

        public int GetChildCount()
        {
            return children.Count;
        }

        public GameObject GetChild(int index)
        {
            return children[index];
        }

        public void AddChild(GameObject child)
        {
            // make sure it doesn't have a parent already
            Debug.Assert(child.parent == null);
            // assign "this as parent
            child.parent = this;
            // add new child to collection
            children.Add(child);
        }

        public void RemoveChild(GameObject child)
        {
            if (children.Remove(child) == true)
            {
                child.parent = null;
            }
        }

        public void Update(float dT)
        {
            // run OnUpdate behaviour
            OnUpdate(dT);

            // update children
            foreach (GameObject child in children)
            {
                child.Update(dT);
            }
        }

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
        
        public virtual void OnUpdate(float dT)
        {

        }

        public virtual void OnDraw()
        {
            
        }

        public void UpdateTransform()
        {
            if (parent != null)
                globalTransform = parent.globalTransform * localTransform;
            else
                globalTransform = localTransform;

            foreach (GameObject child in children)
                child.UpdateTransform();
        }

        public void SetPosition(float x, float y)
        {
            localTransform.SetTranslation(x, y);
            UpdateTransform();
        }

        public void SetRotate(float radians)
        {
            localTransform.SetRotateZ(radians);
            UpdateTransform();
        }

        public void SetScale(float width, float height)
        {
            localTransform.SetScaled(width, height, 1);
            UpdateTransform();
        }

        public void Translate(float x, float y)
        {
            localTransform.Translate(x, y);
            UpdateTransform();
        }

        public void Translate(Vector3 v)
        {
            localTransform.Translate(v.x, v.y);
            UpdateTransform();
        }

        public void Rotate(float radians)
        {
            localTransform.RotateZ(radians);
            UpdateTransform();
        }

        public void Scale(float width, float height)
        {
            localTransform.Scale(width, height, 1);
            UpdateTransform();
        }



    }
}
