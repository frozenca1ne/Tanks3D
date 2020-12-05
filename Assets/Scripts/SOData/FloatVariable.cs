using System;
using UnityEngine;

namespace SOData
{
    [CreateAssetMenu(fileName = "FloatVariable",menuName = "SinglePlayer/FloatVariable",order = 0)]
    public class FloatVariable : ScriptableObject,ISerializationCallbackReceiver
    {
        public event Action<float> OnValueChanged;
        [SerializeField] private float initialValue;

        private float value;

        public float InitialValue => initialValue;
        public float Value
        {
            get => value;
            set
            {
                this.value = value;
                OnValueChanged?.Invoke(value);
            }
        }
        public void OnBeforeSerialize() { }

        public void OnAfterDeserialize()
        {
            value = initialValue;
        }
    }
}
