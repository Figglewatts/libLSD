﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libLSD.Interfaces;

namespace libLSD.Types
{
    public struct Vec3 : IWriteable
    {
        public float X;
        public float Y;
        public float Z;

        public Vec3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vec3(BinaryReader br)
        {
            X = br.ReadInt16();
            Y = br.ReadInt16();
            Z = br.ReadInt16();
            br.ReadInt16();
        }

        public static Vec3 operator +(Vec3 a, Vec3 b)
        {
            Vec3 returnVal = new Vec3
            {
                X = (a.X + b.X),
                Y = (a.Y + b.Y),
                Z = (a.Z + b.Z)
            };
            return returnVal;
        }

        public static Vec3 operator -(Vec3 a)
        {
            Vec3 returnVal = new Vec3
            {
                X = -a.X,
                Y = -a.Y,
                Z = -a.Z
            };
            return returnVal;
        }

        public static Vec3 operator -(Vec3 a, Vec3 b)
        {
            return a + -b;
        }

        public static Vec3 operator *(Vec3 a, float s)
        {
            Vec3 returnVal = new Vec3
            {
                X = (a.X * s),
                Y = (a.Y * s),
                Z = (a.Z * s)
            };
            return returnVal;
        }

        public static Vec3 operator /(Vec3 a, float s)
        {
            Vec3 returnVal = new Vec3
            {
                X = (a.X / s),
                Y = (a.Y / s),
                Z = (a.Z / s)
            };
            return returnVal;
        }

        public static float Dot(Vec3 a, Vec3 b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }

        public static Vec3 Cross(Vec3 a, Vec3 b)
        {
            Vec3 returnVal = new Vec3
            {
                X = a.Y * b.Z - a.Z * b.Y,
                Y = a.Z * b.X - a.X * b.Z,
                Z = a.X * b.Y - a.Y * b.X
            };
            return returnVal;
        }

        public static float Magnitude(Vec3 a)
        {
            return (float)Math.Sqrt(a.X * a.X + a.Y * a.Y + a.Z * a.Z);
        }

        public static Vec3 Normalize(Vec3 a)
        {
            return a / Magnitude(a);
        }

        public override string ToString()
        {
            return string.Format("Vec3: ({0}, {1}, {2})", X, Y, Z);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write((short)X);
            bw.Write((short)Y);
            bw.Write((short)Z);
            bw.Write((short)0);
        }

        public bool Equals(Vec3 other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
        }

        public override bool Equals(object obj)
        {
            return obj is Vec3 other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                return hashCode;
            }
        }
    }
}
