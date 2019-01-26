using UnityEngine;

    public static class Vector3Extensions 
    {

        //question marks indicate a nullable type
        public static Vector3 WithValues(this Vector3 original, float? x = null, float? y = null, float? z = null) {

            //double question mark shorthand for if (!= null), else other
            return new Vector3(x ?? original.x, y ?? original.y, z ?? original.z);

        }

        public static Vector3 DirectionTo(this Vector3 source, Vector3 target) {
            //calculate distance and normalize
            return Vector3.Normalize(target - source);
        }

        public static Vector3 Lerp(this Vector3 source, Vector3 target, float t) {

            return Vector3.Lerp(source, target, t);

        }
    
}