using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    public struct SerializableVector3
    {
        public float x;
        public float y;
        public float z;

        public SerializableVector3(float X, float Y, float Z)
        {
            x = X;
            y = Y;
            z = Z;
        }

        public static implicit operator SerializableVector3(Vector3 v)
        {
            return new SerializableVector3(v.x, v.y, v.z);
        }

        public static explicit operator Vector3(SerializableVector3 v)
        {
            return new Vector3(v.x, v.y, v.z);
        }

        public static SerializableVector3 operator + (SerializableVector3 v1, SerializableVector3 v2)
        {
            return new SerializableVector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }
    }
}