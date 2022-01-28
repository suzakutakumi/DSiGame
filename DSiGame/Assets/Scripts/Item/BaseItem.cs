using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Item
{
    [Serializable]
    public abstract class BaseItem : MonoBehaviour
    {
        protected ItemType type;
        protected IwasiCore iwasiCore;
        public AudioClip pickupSound;
        [SerializeField, Range(0f, 1.0f)] 
        private float ratio;

        public ItemType Type => type;
        public float Ratio => ratio;

        protected virtual void PickUp()
        {
            Destroy(gameObject);
        }
        
        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out iwasiCore))
            {
                PickUp();
            }
        }
    }
}
