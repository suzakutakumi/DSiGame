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
