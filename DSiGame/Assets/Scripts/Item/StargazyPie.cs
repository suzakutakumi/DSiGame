using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Item
{
    [Serializable, RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class StargazyPie : BaseItem
    {
        [SerializeField] private int _deltaSize;
        public int DeltaSize => _deltaSize;

        void Start()
        {
            type = ItemType.StargazyPie;
        }
        protected override void PickUp()
        {
            iwasiCore.sizeOfGroup += _deltaSize;
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            Debug.Log(type + " ゲット!");
            Destroy(gameObject);
        }
        
        void Update()
        {

        }

        
    }
}
