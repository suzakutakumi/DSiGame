using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Item
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class StargazyPie : BaseItem
    {
        [SerializeField] private int _deltaSize;
        [SerializeField] private AudioClip _pickupSound;

        void Start()
        {
            type = ItemType.StargazyPie;
        }
        protected override void PickUp()
        {
            iwasiCore.sizeOfGroup += _deltaSize;
            AudioSource.PlayClipAtPoint(_pickupSound, transform.position);
            Debug.Log(type + " ゲット!");
            Destroy(gameObject);
        }
        
        void Update()
        {

        }

        
    }
}
