using System;
using Raylib;

namespace MaticesInRaylib
{
    public class Vector3
    {
        /// <summary>
        /// Axis of the vector
        /// </summary>
        public float x, y, z;

        /// <summary>
        /// Returns the smaller of the two Vectors
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector3 Min(Vector3 a, Vector3 b)
        {
            return new Vector3(Math.Min(a.x, b.x), Math.Min(a.y, b.y), Math.Min(a.z, b.z));
        }
        /// <summary>
        /// Returns the larger of the two Vectors
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector3 Max(Vector3 a, Vector3 b)
        {
            return new Vector3(Math.Max(a.x, b.x), Math.Max(a.y, b.y), Math.Max(a.z, b.z));
        }

        /// <summary>
        /// Creates a new Vector3 and sets all axies to 0
        /// </summary>
        public Vector3()
        {
            x = 0;
            y = 0;
            z = 0;
        }
        /// <summary>
        /// Creates a new Vector3 with the same values
        /// </summary>
        /// <param name="vector"></param>
        public Vector3(Vector3 v)
        {
            x = v.x;
            y = v.y;
            z = v.z;
        }
        /// <summary>
        /// Creates a new Vector3 and sets the axies to the values given
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Vector3(float _x, float _y, float _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }


        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static Vector3 operator *(Vector3 v, float scaler)
        {
            return new Vector3(v.x * scaler, v.y * scaler, v.z * scaler);
        }

        public static Vector3 operator *(float scaler, Vector3 v)
        {
            return new Vector3(v.x * scaler, v.y * scaler, v.z * scaler);
        }

        public static Vector3 operator /(Vector3 v, float scaler)
        {
            return new Vector3(v.x / scaler, v.y / scaler, v.z / scaler);
        }

        public static bool operator ==(Vector3 v1, Vector3 v2)
        {
            return (Math.Round(v1.x, 4) == Math.Round(v2.x, 4)) && (Math.Round(v1.y, 4) == Math.Round(v2.y, 4) && (Math.Round(v1.z, 4) == Math.Round(v2.z, 4)));
        }

        public static bool operator !=(Vector3 v1, Vector3 v2)
        {
            return Math.Round(v1.x, 4) != Math.Round(v2.x, 4) && Math.Round(v1.y, 4) != Math.Round(v2.y, 4) && Math.Round(v1.z, 4) != Math.Round(v2.z, 4);
        }

        /// <summary>
        /// Returns a clamped Vector t to fit iniside the bounds of max and min
        /// </summary>
        /// <param name="t"></param>
        /// <param name="max"></param>
        /// <param name="min"></param>
        /// <returns></returns>
        public static Vector3 Clamp(Vector3 t, Vector3 max, Vector3 min)
        {
            return Max(max, Min(min, t));
        }

        /// <summary>
        /// Returns the Magnitude of the Vector
        /// </summary>
        /// <returns></returns>
        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }
        /// <summary>
        /// Returns the Magnitude of the Vector
        /// </summary>
        public float magnitude
        {
            get
            {
                return (float)Math.Sqrt(x * x + y * y + z * z);
            }
        }
        /// <summary>
        /// Returns the Magnitude of the Vector squared
        /// </summary>
        public float magnitudeSqr
        {
            get
            {
                return x * x + y * y + z * z;
            }
        }

        /// <summary>
        /// Makes this vector normalized
        /// </summary>
        public void Normalize()
        {
            Vector3 v = normalized;
            x = v.x;
            y = v.y;
            z = v.z;
        }
        /// <summary>
        /// Returns a new vector that is the normalized vector of this
        /// </summary>
        public Vector3 normalized
        {
            get
            {
                float mag = magnitude;
                return new Vector3(x / mag, y / mag, z / mag);
            }
        }

        /// <summary>
        /// Returns the distance between this and the given point
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public float Distance(Vector3 v)
        {
            return (float)Math.Sqrt(Math.Pow(x - v.x, 2) + Math.Pow(y - v.y, 2) + Math.Pow(z - v.z, 2));
        }
        /// <summary>
        /// Returns the distance between this and the given point squared
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public float DistanceSqr(Vector3 v)
        {
            return (float)(Math.Pow(x - v.x, 2) + Math.Pow(y - v.y, 2) + Math.Pow(z - v.z, 2));
        }

        /// <summary>
        /// Returns the vector in string format
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"({x}, {y}, {z})";
        }

        /// <summary>
        /// Moves this point by the vector
        /// </summary>
        /// <param name="vector"></param>
        public void Move(Vector3 v)
        {
            x += v.x;
            y += v.y;
            z += v.z;
        }
        /// <summary>
        /// Returns the dot product of this and the Vector
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public float Dot(Vector3 v)
        {
            return x * v.x + y * v.y + z * v.z;
        }
        /// <summary>
        /// Returns the cross product of this and the Vector
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public Vector3 Cross(Vector3 v)
        {
            float i = y * v.z - z * v.y;
            float j = z * v.x - x * v.z;
            float k = x * v.y - y * v.x;
            return new Vector3(i, j, k);
        }
        /// <summary>
        /// Returns the angle between this and the Vector
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public float GetAngleBetween(Vector3 v)
        {
            Vector3 v1 = normalized;
            Vector3 v2 = v.normalized;

            return (float)Math.Acos(v1.Dot(v2));
        }

    }

    public class Vector4
    {
        /// <summary>
        /// Axis of the vector
        /// </summary>
        public float x, y, z, w;

        /// <summary>
        /// Creates a new Vector4 and sets all axies to 0
        /// </summary>
        public Vector4()
        {
            x = 0;
            y = 0;
            z = 0;
            w = 1;
        }
        /// <summary>
        /// Creates a new Vector4 with the same values
        /// </summary>
        /// <param name="vector"></param>
        public Vector4(Vector4 v)
        {
            x = v.x;
            y = v.y;
            z = v.z;
            w = v.w;
        }
        /// <summary>
        /// Creates a new Vector4 and sets the axies to the values given
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="w"></param>
        public Vector4(float _x, float _y, float _z, float _w)
        {
            x = _x;
            y = _y;
            z = _z;
            w = _w;
        }


        public static Vector4 operator +(Vector4 v1, Vector4 v2)
        {
            return new Vector4(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z, v1.w + v2.w);
        }

        public static Vector4 operator -(Vector4 v1, Vector4 v2)
        {
            return new Vector4(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z, v1.w - v2.w);
        }

        public static Vector4 operator *(Vector4 v, float scaler)
        {
            return new Vector4(v.x * scaler, v.y * scaler, v.z * scaler, v.w * scaler);
        }

        public static Vector4 operator *(float scaler, Vector4 v)
        {
            return new Vector4(v.x * scaler, v.y * scaler, v.z * scaler, v.w * scaler);
        }

        public static Vector4 operator /(Vector4 v, float scaler)
        {
            return new Vector4(v.x / scaler, v.y / scaler, v.z / scaler, v.w / scaler);
        }

        public static bool operator ==(Vector4 v1, Vector4 v2)
        {
            return Math.Round(v1.x, 4) == Math.Round(v2.x, 4) && Math.Round(v1.y, 4) == Math.Round(v2.y, 4) && Math.Round(v1.z, 4) == Math.Round(v2.z, 4) && Math.Round(v1.w, 4) == Math.Round(v2.w, 4);
        }

        public static bool operator !=(Vector4 v1, Vector4 v2)
        {
            return Math.Round(v1.x, 4) != Math.Round(v2.x, 4) && Math.Round(v1.y, 4) != Math.Round(v2.y, 4) && Math.Round(v1.z, 4) != Math.Round(v2.z, 4) && Math.Round(v1.w, 4) != Math.Round(v2.w, 4);
        }


        /// <summary>
        /// Returns the Magnitude of the Vector
        /// </summary>
        /// <returns></returns>
        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z + w * w);
        }
        /// <summary>
        /// Returns the Magnitude of the Vector
        /// </summary>
        public float magnitude
        {
            get
            {
                return (float)Math.Sqrt(x * x + y * y + z * z + w * w);
            }
        }
        /// <summary>
        /// Returns the Magnitude of the Vector squared
        /// </summary>
        public float magnitudeSqr
        {
            get
            {
                return x * x + y * y + z * z + w * w;
            }
        }

        /// <summary>
        /// Makes this vector normalized
        /// </summary>
        public void Normalize()
        {
            Vector4 v = normalized;
            x = v.x;
            y = v.y;
            z = v.z;
            w = v.w;
        }
        /// <summary>
        /// Returns a new vector that is the normalized vector of this
        /// </summary>
        public Vector4 normalized
        {
            get
            {
                float mag = magnitude;
                return new Vector4(x / mag, y / mag, z / mag, w / mag);
            }
        }

        /// <summary>
        /// Returns the distance between this and the given point
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public float Distance(Vector4 v)
        {
            return (float)Math.Sqrt(Math.Pow(x - v.x, 2) + Math.Pow(y - v.y, 2) + Math.Pow(z - v.z, 2) + Math.Pow(w - v.w, 2));
        }
        /// <summary>
        /// Returns the distance between this and the given point squared
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public float DistanceSqr(Vector4 v)
        {
            return (float)(Math.Pow(x - v.x, 2) + Math.Pow(y - v.y, 2) + Math.Pow(z - v.z, 2) + Math.Pow(w - v.w, 2));
        }

        /// <summary>
        /// Returns the vector in string format
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"({x}, {y}, {z}, {w})";
        }

        /// <summary>
        /// Moves this point by the vector
        /// </summary>
        /// <param name="vector"></param>
        public void Move(Vector4 v)
        {
            x += v.x;
            y += v.y;
            z += v.z;
            w += v.w;
        }
        /// <summary>
        /// Returns the dot product of this and the Vector
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public float Dot(Vector4 v)
        {
            return x * v.x + y * v.y + z * v.z + w * v.w;
        }
        /// <summary>
        /// Returns the cross product of this and the Vector
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public Vector4 Cross(Vector4 v)
        {
            float i = y * v.z - z * v.y;
            float j = z * v.x - x * v.z;
            float k = x * v.y - y * v.x;
            return new Vector4(i, j, k, 0);
        }
        /// <summary>
        /// Returns the angle between this and the Vector
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public float GetAngleBetween(Vector4 v)
        {
            Vector4 v1 = normalized;
            Vector4 v2 = v.normalized;

            return (float)Math.Acos(v1.Dot(v2));
        }

    }

    public class Matrix3
    {
        /// <summary>
        /// Elment in the Matrix
        /// </summary>
        public float m1, m2, m3, m4, m5, m6, m7, m8, m9;
        /// <summary>
        /// Returns an identity Matrix3
        /// </summary>
        public static Matrix3 identity
        {
            get
            {
                return new Matrix3(
                    1, 0, 0,
                    0, 1, 0,
                    0, 0, 1);
            }
        }

        /// <summary>
        /// Creates Matrix3 and sets it to identiy
        /// </summary>
        public Matrix3()
        {
            m1 = 1; m4 = 0; m7 = 0;
            m2 = 0; m5 = 1; m8 = 0;
            m3 = 0; m6 = 0; m9 = 1;
        }

        /// <summary>
        /// Creates a Matrix3 and sets the elements to the values
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <param name="m3"></param>
        /// <param name="m4"></param>
        /// <param name="m5"></param>
        /// <param name="m6"></param>
        /// <param name="m7"></param>
        /// <param name="m8"></param>
        /// <param name="m9"></param>
        public Matrix3(float _m1, float _m2, float _m3, float _m4, float _m5, float _m6, float _m7, float _m8, float _m9)
        {
            m1 = _m1;
            m2 = _m2;
            m3 = _m3;
            m4 = _m4;
            m5 = _m5;
            m6 = _m6;
            m7 = _m7;
            m8 = _m8;
            m9 = _m9;
        }


        /// <summary>
        /// Teleports to the location
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetTranslation(float x, float y)
        {
            m7 = x;
            m8 = y;
            m9 = 1;
        }
        /// <summary>
        /// Teleports to the location
        /// </summary>
        /// <param name="point"></param>
        public void SetTranslation(Vector3 v)
        {
            m7 = v.x;
            m8 = v.y;
            m9 = 1;
        }
        /// <summary>
        /// Teleports to the location by adding the vector to the current location
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Translate(float x, float y)
        {
            // apply vector offset
            m7+= x;
            m8+= y;
        }
        /// <summary>
        /// Teleports to the location by adding the vector to the current location
        /// </summary>
        /// <param name="vector"></param>
        public void Translate(Vector3 v)
        {
            // apply vector offset
            m7 += v.x ;
            m8 += v.y ;
        }


        /// <summary>
        /// Creates a scaler Matrix3
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void SetScaled(float x, float y, float z)
        {
            m1 = x;
            m2 = 0;
            m3 = 0;
            m4 = 0;
            m5 = y;
            m6 = 0;
            m7 = 0;
            m8 = 0;
            m9 = z;
        }
        /// <summary>
        /// Creates a scaler Matrix3
        /// </summary>
        /// <param name="vector"></param>
        public void SetScaled(Vector3 v)
        {
            m1 = v.x;
            m2 = 0;
            m3 = 0;
            m4 = 0;
            m5 = v.y;
            m6 = 0;
            m7 = 0;
            m8 = 0;
            m9 = v.z;
        }


        /// <summary>
        /// Sets the Matrix3 to be the same as another Matrix3
        /// </summary>
        /// <param name="matrixBeingCopied"></param>
        public void Set(Matrix3 m)
        {
            m1 = m.m1;
            m2 = m.m2;
            m3 = m.m3;
            m4 = m.m4;
            m5 = m.m5;
            m6 = m.m6;
            m7 = m.m7;
            m8 = m.m8;
            m9 = m.m9;
        }
        /// <summary>
        /// Sets the Matrix3 to be the same as another Matrix3
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <param name="m3"></param>
        /// <param name="m4"></param>
        /// <param name="m5"></param>
        /// <param name="m6"></param>
        /// <param name="m7"></param>
        /// <param name="m8"></param>
        /// <param name="m9"></param>
        public void Set(float m1, float m2, float m3, float m4, float m5, float m6, float m7, float m8, float m9)
        {
            this.m1 = m1;
            this.m2 = m2;
            this.m3 = m3;
            this.m4 = m4;
            this.m5 = m5;
            this.m6 = m6;
            this.m7 = m7;
            this.m8 = m8;
            this.m9 = m9;
        }


        /// <summary>
        /// Scales the Matrix by the values
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void Scale(float x, float y, float z)
        {
            Matrix3 m = new Matrix3();
            m.SetScaled(x, y, z);

            Set(this * m);
        }
        /// <summary>
        /// Scales the Matrix by the vector
        /// </summary>
        /// <param name="vector"></param>
        public void Scale(Vector3 v)
        {
            Matrix3 m = new Matrix3();
            m.SetScaled(v.x, v.y, v.z);

            Set(this * m);
        }


        /// <summary>
        /// Sets the Matrix to be a template for rotating X
        /// </summary>
        /// <param name="radians"></param>
        public void SetRotateX(float radians)
        {
            Set(1, 0, 0,
                0, (float)Math.Cos(radians), (float)-Math.Sin(radians),
                0, (float)Math.Sin(radians), (float)Math.Cos(radians));
        }
        /// <summary>
        /// Rotates the Matrix X axis
        /// </summary>
        /// <param name="radians"></param>
        public void RotateX(float radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateX(radians);

            Set(this * m);
        }


        /// <summary>
        /// Sets the Matrix to be a template for rotating Y
        /// </summary>
        /// <param name="radians"></param>
        public void SetRotateY(float radians)
        {
            Set((float)Math.Cos(radians), 0, (float)Math.Sin(radians),
                0, 1, 0,
                (float)-Math.Sin(radians), 0, (float)Math.Cos(radians));
        }
        /// <summary>
        /// Rotates the Matrix Y axis
        /// </summary>
        /// <param name="radians"></param>
        public void RotateY(float radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateY(radians);

            Set(this * m);
        }


        /// <summary>
        /// Sets the Matrix to be a template for rotating Z
        /// </summary>
        /// <param name="radians"></param>
        public void SetRotateZ(float radians)
        {
            Set((float)Math.Cos(radians), (float)Math.Sin(radians), 0,
                (float)-Math.Sin(radians), (float)Math.Cos(radians), 0,
                0, 0, 1);
        }
        /// <summary>
        /// Rotates the Matrix Z axis
        /// </summary>
        /// <param name="radians"></param>
        public void RotateZ(float radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateZ(radians);

            Set(this * m);
        }
        public float GetRotateZ()
        {
            if (m2 > 0)
            {
                return (float)Math.Acos(m1);
            }
            else
            {
                return -(float)Math.Acos(m1);
            }
        }


        /// <summary>
        /// Rotates all rotational axises of the Matrix
        /// </summary>
        /// <param name="pitch"></param>
        /// <param name="yaw"></param>
        /// <param name="roll"></param>
        void SetEuler(float pitch, float yaw, float roll)
        {

            Matrix3 x = new Matrix3();
            Matrix3 y = new Matrix3();
            Matrix3 z = new Matrix3();
            x.SetRotateX(pitch);
            y.SetRotateY(yaw);
            z.SetRotateZ(roll);

            Set(z * y * x);
        }



        public static Matrix3 operator +(Matrix3 M1, Matrix3 M2)
        {
            Matrix3 M3 = new Matrix3();
            M3.m1 = M1.m1 + M2.m1;
            M3.m2 = M1.m2 + M2.m2;
            M3.m3 = M1.m3 + M2.m3;
            M3.m4 = M1.m4 + M2.m4;
            M3.m5 = M1.m5 + M2.m5;
            M3.m6 = M1.m6 + M2.m6;
            M3.m7 = M1.m7 + M2.m7;
            M3.m8 = M1.m8 + M2.m8;
            M3.m9 = M1.m9 + M2.m9;
            return M3;
        }
        public static Matrix3 operator -(Matrix3 M1, Matrix3 M2)
        {
            Matrix3 M3 = new Matrix3();
            M3.m1 = M1.m1 - M2.m1;
            M3.m2 = M1.m2 - M2.m2;
            M3.m3 = M1.m3 - M2.m3;
            M3.m4 = M1.m4 - M2.m4;
            M3.m5 = M1.m5 - M2.m5;
            M3.m6 = M1.m6 - M2.m6;
            M3.m7 = M1.m7 - M2.m7;
            M3.m8 = M1.m8 - M2.m8;
            M3.m9 = M1.m9 - M2.m9;
            return M3;
        }
        public static Vector3 operator *(Matrix3 m, Vector3 v)
        {
            Vector3 v1 = new Vector3();
            v1.x = m.m1 * v.x + m.m4 * v.y + m.m7 * v.z;
            v1.y = m.m2 * v.x + m.m5 * v.y + m.m8 * v.z;
            v1.z = m.m3 * v.x + m.m6 * v.y + m.m9 * v.z;
            return v1;
        }
        public static Matrix3 operator *(Matrix3 M1, Matrix3 M2)
        {
            //123
            //456
            //789

            Matrix3 M3 = new Matrix3(0, 0, 0, 0, 0, 0, 0, 0, 0);

            M3.m1 = M1.m1 * M2.m1 + M1.m4 * M2.m2 + M1.m7 * M2.m3;
            M3.m2 = M1.m2 * M2.m1 + M1.m5 * M2.m2 + M1.m8 * M2.m3;
            M3.m3 = M1.m3 * M2.m1 + M1.m6 * M2.m2 + M1.m9 * M2.m3;

            M3.m4 = M1.m1 * M2.m4 + M1.m4 * M2.m5 + M1.m7 * M2.m6;
            M3.m5 = M1.m2 * M2.m4 + M1.m5 * M2.m5 + M1.m8 * M2.m6;
            M3.m6 = M1.m3 * M2.m4 + M1.m6 * M2.m5 + M1.m9 * M2.m6;

            M3.m7 = M1.m1 * M2.m7 + M1.m4 * M2.m8 + M1.m7 * M2.m9;
            M3.m8 = M1.m2 * M2.m7 + M1.m5 * M2.m8 + M1.m8 * M2.m9;
            M3.m9 = M1.m3 * M2.m7 + M1.m6 * M2.m8 + M1.m9 * M2.m9;
            return M3;
        }


        /// <summary>
        /// Creates a string to display a Matrix4
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string s = $"[{m1}] [{m2}] [{m3}] \n" +
                        $"[{m4}] [{m5}] [{m6}] \n" +
                        $"[{m7}] [{m8}] [{m9}]";

            return $"Matrix3 - \n{s}";
        }
    }

    public class Matrix4
    {
        /// <summary>
        /// Elment in the Matrix
        /// </summary>
        public float m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16;

        /// <summary>
        /// Returns an identity Matrix4 
        /// </summary>
        public static Matrix4 identity
        {
            get
            {
                return new Matrix4(
                    1, 0, 0, 0,
                    0, 1, 0, 0,
                    0, 0, 1, 0,
                    0, 0, 0, 1);
            }
        }

        /// <summary>
        /// Creates Matrix4 and sets it to identiy
        /// </summary>
        public Matrix4()
        {
            m1 = 1; m2 = 0; m3 = 0; m4 = 0;
            m5 = 0; m6 = 1; m7 = 0; m8 = 0;
            m9 = 0; m10 = 0; m11 = 1; m12 = 0;
            m13 = 0; m14 = 0; m15 = 0; m16 = 1;
        }

        /// <summary>
        /// Creates a Matrix4 and sets the elements to the values
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <param name="m3"></param>
        /// <param name="m4"></param>
        /// <param name="m5"></param>
        /// <param name="m6"></param>
        /// <param name="m7"></param>
        /// <param name="m8"></param>
        /// <param name="m9"></param>
        /// <param name="m10"></param>
        /// <param name="m11"></param>
        /// <param name="m12"></param>
        /// <param name="m13"></param>
        /// <param name="m14"></param>
        /// <param name="m15"></param>
        /// <param name="m16"></param>
        public Matrix4(float _m1, float _m2, float _m3, float _m4, float _m5, float _m6, float _m7, float _m8, float _m9, float _m10, float _m11, float _m12, float _m13, float _m14, float _m15, float _m16)
        {
            m1 = _m1; m2 = _m2; m3 = _m3; m4 = _m4;
            m5 = _m5; m6 = _m6; m7 = _m7; m8 = _m8;
            m9 = _m9; m10 = _m10; m11 = _m11; m12 = _m12;
            m13 = _m13; m14 = _m14; m15 = _m15; m16 = _m16;
        }

        /// <summary>
        /// Teleports to the location
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void SetTranslation(float x, float y, float z)
        {
            m3 = x;
            m6 = y;
            m9 = z;
            m16 = 1;
        }
        /// <summary>
        /// Teleports to the location
        /// </summary>
        /// <param name="location"></param>
        public void SetTranslation(Vector4 v)
        {
            m3 = v.x;
            m6 = v.y;
            m9 = v.z;
            m16 = 1;
        }
        /// <summary>
        /// Teleports to the location by adding the vector to the current location
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void Translate(float x, float y, float z)
        {
            // apply vector offset
            m3 = x + m3;
            m6 = y + m6;
            m9 = z + m9;
        }
        /// <summary>
        /// Teleports to the location by adding the vector to the current location
        /// </summary>
        /// <param name="vector"></param>
        public void Translate(Vector4 v)
        {
            // apply vector offset
            m3 = v.x + m3;
            m6 = v.y + m6;
            m9 = v.z + m9;
        }

        /// <summary>
        /// Creates a scaler Matrix4
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="w"></param>
        public void SetScaled(float x, float y, float z, float w)
        {
            m1 = x; m2 = 0; m3 = 0; m4 = 0;
            m5 = 0; m6 = y; m7 = 0; m8 = 0;
            m9 = 0; m10 = 0; m11 = z; m12 = 0;
            m13 = 0; m14 = 0; m15 = 0; m16 = w;
        }
        /// <summary>
        /// Creates a Scaler Matrix4
        /// </summary>
        /// <param name="vector"></param>
        public void SetScaled(Vector4 v)
        {
            m1 = v.x; m2 = 0; m3 = 0; m4 = 0;
            m5 = 0; m6 = v.y; m7 = 0; m8 = 0;
            m9 = 0; m10 = 0; m11 = v.z; m12 = 0;
            m13 = 0; m14 = 0; m15 = 0; m16 = v.w;
        }

        /// <summary>
        /// Sets the Matrix4 to be the same as another Matrix4
        /// </summary>
        /// <param name="matrixBeingCopied"></param>
        public void Set(Matrix4 m)
        {
            m1 = m.m1; m2 = m.m2; m3 = m.m3; m4 = m.m4;
            m5 = m.m5; m6 = m.m6; m7 = m.m7; m8 = m.m8;
            m9 = m.m9; m10 = m.m10; m11 = m.m11; m12 = m.m12;
            m13 = m.m13; m14 = m.m14; m15 = m.m15; m16 = m.m16;
        }
        /// <summary>
        /// Sets the values of the Matrix to the values
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <param name="m3"></param>
        /// <param name="m4"></param>
        /// <param name="m5"></param>
        /// <param name="m6"></param>
        /// <param name="m7"></param>
        /// <param name="m8"></param>
        /// <param name="m9"></param>
        /// <param name="m10"></param>
        /// <param name="m11"></param>
        /// <param name="m12"></param>
        /// <param name="m13"></param>
        /// <param name="m14"></param>
        /// <param name="m15"></param>
        /// <param name="m16"></param>
        public void Set(float _m1, float _m2, float _m3, float _m4, float _m5, float _m6, float _m7, float _m8, float _m9, float _m10, float _m11, float _m12, float _m13, float _m14, float _m15, float _m16)
        {
            m1 = _m1; m2 = _m2; m3 = _m3; m4 = _m4;
            m5 = _m5; m6 = _m6; m7 = _m7; m8 = _m8;
            m9 = _m9; m10 = _m10; m11 = _m11; m12 = _m12;
            m13 = _m13; m14 = _m14; m15 = _m15; m16 = _m16;
        }

        /// <summary>
        /// Scales the Matrix by the values
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="w"></param>
        public void Scale(float x, float y, float z, float w)
        {
            Matrix4 m = new Matrix4();
            m.SetScaled(x, y, z, w);

            Set(this * m);
        }
        /// <summary>
        /// Scales the Matrix by the values
        /// </summary>
        /// <param name="v"></param>
        public void Scale(Vector4 v)
        {
            Matrix4 m = new Matrix4();
            m.SetScaled(v.x, v.y, v.z, v.w);

            Set(this * m);
        }

        /// <summary>
        /// Sets the Matrix to be a template for rotating X
        /// </summary>
        /// <param name="radians"></param>
        public void SetRotateX(float radians)
        {
            Set(1, 0, 0, 0,
                0, (float)Math.Cos(radians), (float)Math.Sin(radians), 0,
                0, (float)-Math.Sin(radians), (float)Math.Cos(radians), 0,
                0, 0, 0, 1);
        }
        /// <summary>
        /// Rotates the Matrix X axis
        /// </summary>
        /// <param name="radians"></param>
        public void RotateX(float radians)
        {
            Matrix4 m = new Matrix4();
            m.SetRotateX(radians);

            Set(this * m);
        }

        /// <summary>
        /// Sets the Matrix to be a template for rotating Y
        /// </summary>
        /// <param name="radians"></param>
        public void SetRotateY(float radians)
        {
            Set((float)Math.Cos(radians), 0, (float)-Math.Sin(radians), 0,
                0, 1, 0, 0,
                (float)Math.Sin(radians), 0, (float)Math.Cos(radians), 0,
                0, 0, 0, 1);
        }
        /// <summary>
        /// Rotates the Matrix Y axis
        /// </summary>
        /// <param name="radians"></param>
        public void RotateY(float radians)
        {
            Matrix4 m = new Matrix4();
            m.SetRotateY(radians);

            Set(this * m);
        }

        /// <summary>
        /// Sets the Matrix to be a template for rotating Z
        /// </summary>
        /// <param name="radians"></param>
        public void SetRotateZ(float radians)
        {
            Set((float)Math.Cos(radians), (float)Math.Sin(radians), 0, 0,
                (float)-Math.Sin(radians), (float)Math.Cos(radians), 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1);
        }
        /// <summary>
        /// Rotates the Matrix Z axis
        /// </summary>
        /// <param name="radians"></param>
        public void RotateZ(float radians)
        {
            Matrix4 m = new Matrix4();
            m.SetRotateZ(radians);

            Set(this * m);
        }

        /// <summary>
        /// Rotates all rotational axises of the Matrix
        /// </summary>
        /// <param name="pitch"></param>
        /// <param name="yaw"></param>
        /// <param name="roll"></param>
        void SetEuler(float pitch, float yaw, float roll)
        {

            Matrix4 x = new Matrix4();
            Matrix4 y = new Matrix4();
            Matrix4 z = new Matrix4();
            x.SetRotateX(pitch);
            y.SetRotateY(yaw);
            z.SetRotateZ(roll);

            Set(z * y * x);
        }
        

        public static Matrix4 operator +(Matrix4 M1, Matrix4 M2)
        {
            Matrix4 M3 = new Matrix4();
            M3.m1 = M1.m1 + M2.m1;
            M3.m2 = M1.m2 + M2.m2;
            M3.m3 = M1.m3 + M2.m3;
            M3.m4 = M1.m4 + M2.m4;
            M3.m5 = M1.m5 + M2.m5;
            M3.m6 = M1.m6 + M2.m6;
            M3.m7 = M1.m7 + M2.m7;
            M3.m8 = M1.m8 + M2.m8;
            M3.m9 = M1.m9 + M2.m9;
            M3.m10 = M1.m10 + M2.m10;
            M3.m11 = M1.m11 + M2.m11;
            M3.m12 = M1.m12 + M2.m12;
            M3.m13 = M1.m13 + M2.m13;
            M3.m14 = M1.m14 + M2.m14;
            M3.m15 = M1.m15 + M2.m15;
            M3.m16 = M1.m16 + M2.m16;
            return M3;
        }

        public static Matrix4 operator -(Matrix4 M1, Matrix4 M2)
        {
            Matrix4 M3 = new Matrix4();
            M3.m1 = M1.m1 - M2.m1;
            M3.m2 = M1.m2 - M2.m2;
            M3.m3 = M1.m3 - M2.m3;
            M3.m4 = M1.m4 - M2.m4;
            M3.m5 = M1.m5 - M2.m5;
            M3.m6 = M1.m6 - M2.m6;
            M3.m7 = M1.m7 - M2.m7;
            M3.m8 = M1.m8 - M2.m8;
            M3.m9 = M1.m9 - M2.m9;
            M3.m10 = M1.m10 - M2.m10;
            M3.m11 = M1.m11 - M2.m11;
            M3.m12 = M1.m12 - M2.m12;
            M3.m13 = M1.m13 - M2.m13;
            M3.m14 = M1.m14 - M2.m14;
            M3.m15 = M1.m15 - M2.m15;
            M3.m16 = M1.m16 - M2.m16;
            return M3;
        }

        public static Vector4 operator *(Matrix4 m, Vector4 v)
        {
            Vector4 v1 = new Vector4();
            v1.x = m.m1 * v.x + m.m5 * v.y + m.m9 * v.z + m.m13 * v.w;
            v1.y = m.m2 * v.x + m.m6 * v.y + m.m10 * v.z + m.m14 * v.w;
            v1.z = m.m3 * v.x + m.m7 * v.y + m.m11 * v.z + m.m15 * v.w;
            v1.w = m.m4 * v.x + m.m8 * v.y + m.m12 * v.z + m.m16 * v.w;
            return v1;
        }

        public static Matrix4 operator *(Matrix4 M2, Matrix4 M1)
        {
            Matrix4 M3 = new Matrix4();
            M3.m1 = M1.m1 * M2.m1 + M1.m2 * M2.m5 + M1.m3 * M2.m9 + M1.m4 * M2.m13;
            M3.m2 = M1.m1 * M2.m2 + M1.m2 * M2.m6 + M1.m3 * M2.m10 + M1.m4 * M2.m14;
            M3.m3 = M1.m1 * M2.m3 + M1.m2 * M2.m7 + M1.m3 * M2.m11 + M1.m4 * M2.m15;
            M3.m4 = M1.m1 * M2.m4 + M1.m2 * M2.m8 + M1.m3 * M2.m12 + M1.m4 * M2.m16;

            M3.m5 = M1.m5 * M2.m1 + M1.m6 * M2.m5 + M1.m7 * M2.m9 + M1.m8 * M2.m13;
            M3.m6 = M1.m5 * M2.m2 + M1.m6 * M2.m6 + M1.m7 * M2.m10 + M1.m8 * M2.m14;
            M3.m7 = M1.m5 * M2.m3 + M1.m6 * M2.m7 + M1.m7 * M2.m11 + M1.m8 * M2.m15;
            M3.m8 = M1.m5 * M2.m4 + M1.m6 * M2.m8 + M1.m7 * M2.m12 + M1.m8 * M2.m16;

            M3.m9 = M1.m9 * M2.m1 + M1.m10 * M2.m5 + M1.m11 * M2.m9 + M1.m12 * M2.m13;
            M3.m10 = M1.m9 * M2.m2 + M1.m10 * M2.m6 + M1.m11 * M2.m10 + M1.m12 * M2.m14;
            M3.m11 = M1.m9 * M2.m3 + M1.m10 * M2.m7 + M1.m11 * M2.m11 + M1.m12 * M2.m15;
            M3.m12 = M1.m9 * M2.m4 + M1.m10 * M2.m8 + M1.m11 * M2.m12 + M1.m12 * M2.m16;

            M3.m13 = M1.m13 * M2.m1 + M1.m14 * M2.m5 + M1.m15 * M2.m9 + M1.m16 * M2.m13;
            M3.m14 = M1.m13 * M2.m2 + M1.m14 * M2.m6 + M1.m15 * M2.m10 + M1.m16 * M2.m14;
            M3.m15 = M1.m13 * M2.m3 + M1.m14 * M2.m7 + M1.m15 * M2.m11 + M1.m16 * M2.m15;
            M3.m16 = M1.m13 * M2.m4 + M1.m14 * M2.m8 + M1.m15 * M2.m12 + M1.m16 * M2.m16;
            return M3;
        }


        /// <summary>
        /// Creates a string to display a Matrix4
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string s =  $"[{m1}] [{m2}] [{m3}] [{m4}] \n" +
                        $"[{m5}] [{m6}] [{m7}] [{m8}] \n" +
                        $"[{m9}] [{m10}] [{m11}] [{m12}] \n" +
                        $"[{m13}] [{m14}] [{m15}] [{m16}]";

            return $"Matrix4 - \n{s}";
        }
    }

    public class Colour
    {
        /// <summary>
        /// Returns a Colour with the values for light gray
        /// </summary>
        public static Colour lightgray { get { return new Colour(200, 200, 200, 255); } }
        /// <summary>
        /// Returns a Colour with the values for gray
        /// </summary>
        public static Colour gray { get { return new Colour(130, 130, 130, 255); } }
        /// <summary>
        /// Returns a Colour with the values for drak gray
        /// </summary>
        public static Colour darkgray { get { return new Colour(80, 80, 80, 255); } }
        /// <summary>
        /// Returns a Colour with the values for yellow
        /// </summary>
        public static Colour yellow { get { return new Colour(253, 249, 0, 255); } }
        /// <summary>
        /// Returns a Colour with the values for gold
        /// </summary>
        public static Colour gold { get { return new Colour(255, 203, 0, 255); } }
        /// <summary>
        /// Returns a Colour with the values for orange
        /// </summary>
        public static Colour orange { get { return new Colour(255, 161, 0, 255); } }
        /// <summary>
        /// Returns a Colour with the values for pink
        /// </summary>
        public static Colour pink { get { return new Colour(255, 109, 194, 255); } }
        /// <summary>
        /// Returns a Colour with the values for red
        /// </summary>
        public static Colour red { get { return new Colour(230, 41, 55, 255); } }
        /// <summary>
        /// Returns a Colour with the values for maroon
        /// </summary>
        public static Colour maroon { get { return new Colour(190, 33, 55, 255); } }
        /// <summary>
        /// Returns a Colour with the values for green
        /// </summary>
        public static Colour green { get { return new Colour(0, 228, 48, 255); } }
        /// <summary>
        /// Returns a Colour with the values for lime
        /// </summary>
        public static Colour lime { get { return new Colour(0, 158, 47, 255); } }
        /// <summary>
        /// Returns a Colour with the values for dark green
        /// </summary>
        public static Colour darkgreen { get { return new Colour(0, 117, 44, 255); } }
        /// <summary>
        /// Returns a Colour with the values for sky blue
        /// </summary>
        public static Colour skyblue { get { return new Colour(102, 191, 255, 255); } }
        /// <summary>
        /// Returns a Colour with the values for blue
        /// </summary>
        public static Colour blue { get { return new Colour(0, 121, 241, 255); } }
        /// <summary>
        /// Returns a Colour with the values for dark blue
        /// </summary>
        public static Colour darkblue { get { return new Colour(0, 82, 172, 255); } }
        /// <summary>
        /// Returns a Colour with the values for purple
        /// </summary>
        public static Colour purple { get { return new Colour(200, 122, 255, 255); } }
        /// <summary>
        /// Returns a Colour with the values for violet
        /// </summary>
        public static Colour violet { get { return new Colour(135, 60, 190, 255); } }
        /// <summary>
        /// Returns a Colour with the values for dark purple
        /// </summary>
        public static Colour darkpurple { get { return new Colour(112, 31, 126, 255); } }
        /// <summary>
        /// Returns a Colour with the values for beige
        /// </summary>
        public static Colour beige { get { return new Colour(211, 176, 131, 255); } }
        /// <summary>
        /// Returns a Colour with the values for brown
        /// </summary>
        public static Colour brown { get { return new Colour(127, 106, 79, 255); } }
        /// <summary>
        /// Returns a Colour with the values for dark brown
        /// </summary>
        public static Colour darkbrown { get { return new Colour(76, 63, 47, 255); } }
        /// <summary>
        /// Returns a Colour with the values for white
        /// </summary>
        public static Colour white { get { return new Colour(255, 255, 255, 255); } }
        /// <summary>
        /// Returns a Colour with the values for black
        /// </summary>
        public static Colour black { get { return new Colour(0, 0, 0, 255); } }
        /// <summary>
        /// Returns a Colour with blank values
        /// </summary>
        public static Colour blank { get { return new Colour(0, 0, 0, 0); } }
        /// <summary>
        /// Returns a Colour with the values for magenta
        /// </summary>
        public static Colour magenta { get { return new Colour(255, 0, 255, 255); } }

        /// <summary>
        /// Variable that stores the colour values
        /// </summary>
        public uint colour;

        /// <summary>
        /// Default Constructor. Colour will be blank.
        /// </summary>
        public Colour()
        {
            colour = 0;
        }

        /// <summary>
        /// Creates a new Colour and Sets the colour values to the number provided. Format: AARRGGBB
        /// </summary>
        public Colour(uint c)
        {
            colour = c;

        }

        /// <summary>
        /// Creates a new Colour and Sets RGB values and sets A to 255
        /// </summary>
        public Colour(uint R, uint G, uint B)
        {
            colour = (uint)255 * (uint)Math.Pow(2, 24) + R * (uint)Math.Pow(2, 16) + G * (uint)Math.Pow(2, 8) + B;
        }

        /// <summary>
        /// Creates a new Colour and Sets RGBA values
        /// </summary>
        public Colour(uint R, uint G, uint B, uint A)
        {
            colour = A * (uint)Math.Pow(2, 24) + R * (uint)Math.Pow(2, 16) + G * (uint)Math.Pow(2, 8) + B;
        }

        /// <summary>
        /// Creates a new Colour and Sets RGB values and sets A to 255
        /// </summary>
        public Colour(Vector3 v)
        {
            colour = (uint)255 * (uint)Math.Pow(2, 24) + (uint)v.x * (uint)Math.Pow(2, 16) + (uint)v.y * (uint)Math.Pow(2, 8) + (uint)v.z;
        }

        /// <summary>
        /// Creates a new Colour and Sets RGBA values
        /// </summary>
        public Colour(Vector4 v)
        {
            colour = (uint)v.w * (uint)Math.Pow(2, 24) + (uint)v.x * (uint)Math.Pow(2, 16) + (uint)v.y * (uint)Math.Pow(2, 8) + (uint)v.z;
        }

        /// <summary>
        /// Sets the colour values to the number provided. Format: AARRGGBB
        /// </summary>
        public void Set(uint c)
        {
            colour = c;
        }

        /// <summary>
        /// Sets RGB values and sets A to 255
        /// </summary>
        public void Set(uint R, uint G, uint B)
        {
            colour = (uint)255 * (uint)Math.Pow(2, 24) + R * (uint)Math.Pow(2, 16) + G * (uint)Math.Pow(2, 8) + B;
        }

        /// <summary>
        /// Sets RGBA values
        /// </summary>
        public void Set(uint R, uint G, uint B, uint A)
        {
            colour = A * (uint)Math.Pow(2, 24) + R * (uint)Math.Pow(2, 16) + G * (uint)Math.Pow(2, 8) + B;
        }

        /// <summary>
        /// Sets RGB values and sets A to 255
        /// </summary>
        public void Set(Vector3 v)
        {
            colour = (uint)255 * (uint)Math.Pow(2, 24) + (uint)v.x * (uint)Math.Pow(2, 16) + (uint)v.y * (uint)Math.Pow(2, 8) + (uint)v.z;
        }

        /// <summary>
        /// Sets RGBA values
        /// </summary>
        public void Set(Vector4 v)
        {
            colour = (uint)v.w * (uint)Math.Pow(2, 24) + (uint)v.x * (uint)Math.Pow(2, 16) + (uint)v.y * (uint)Math.Pow(2, 8) + (uint)v.z;
        }

        /// <summary>
        /// Returns the A value for this Colour
        /// </summary>
        public byte GetAlpha()
        {
            return (byte)(colour >> 24);
        }

        /// <summary>
        /// Returns the R value for this Colour
        /// </summary>
        public byte GetRed()
        {
            return (byte)(colour >> 16);
        }

        /// <summary>
        /// Returns the G value for this Colour
        /// </summary>
        public byte GetGreen()
        {
            return (byte)(colour >> 8);
        }

        /// <summary>
        /// Returns the B value for this Colour
        /// </summary>
        public byte GetBlue()
        {
            return (byte)colour;
        }

        /// <summary>
        /// Sets the A value for this Colour
        /// </summary>
        public void SetAlpha(uint val)
        {
            BlankRed();
            colour = colour | (val << 24);
        }

        /// <summary>
        /// Sets the R value for this Colour
        /// </summary>
        public void SetRed(uint val)
        {
            BlankGreen();
            colour = colour | (val << 16);
        }

        /// <summary>
        /// Sets the G value for this Colour
        /// </summary>
        public void SetGreen(uint val)
        {
            BlankBlue();
            colour = colour | (val << 8);
        }

        /// <summary>
        /// Sets the B value for this Colour
        /// </summary>
        public void SetBlue(uint val)
        {
            BlankAlpha();
            colour = colour | val;
        }

        /// <summary>
        /// Sets the A value for this Colour to 0
        /// </summary>
        public void BlankAlpha()
        {
            colour = colour & (uint)16777215;
        }

        /// <summary>
        /// Sets the R value for this Colour to 0
        /// </summary>
        public void BlankRed()
        {
            colour = colour & 4278255615;
        }

        /// <summary>
        /// Sets the G value for this Colour to 0
        /// </summary>
        public void BlankGreen()
        {
            colour = colour & 4294902015;
        }

        /// <summary>
        /// Sets the B value for this Colour to 0
        /// </summary>
        public void BlankBlue()
        {
            colour = colour & 4294967040;
        }

        /// <summary>
        /// Sets the RGBA values for this Colour to 0
        /// </summary>
        public void Blank()
        {
            colour = 0;
        }

        /// <summary>
        /// Used in Raylib to convert to their color type for drawing
        /// </summary>
        /// <param name="colour"></param>
        public static explicit operator Color(Colour colour)
        {
            return new Color(colour.GetRed(), colour.GetGreen(), colour.GetBlue(), colour.GetAlpha());
        }
    }
}
