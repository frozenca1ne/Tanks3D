using System;
using UnityEngine;

namespace SOData
{
    [Serializable]
    public class FloatReference
    {
        [SerializeField] private bool useConstant;
        [SerializeField] private float constantValue;

        [SerializeField] private FloatVariable variable;

        public FloatReference()
        {
            useConstant = true;
        }

        public FloatReference(float value)
        {
            useConstant = true;
            constantValue = value;
        }

        public float Value => useConstant ? constantValue : variable.Value;
        public FloatVariable Variable => variable;

        public static implicit operator float(FloatReference reference)
        {
            return reference.Value;
        }
    
    }
}
