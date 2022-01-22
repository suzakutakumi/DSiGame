using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Item
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class StargazyPie : BaseItem, IAvailableItem
    {
        [SerializeField] private int _deltaSize;
        [SerializeField] private AudioClip _pickupSound;
        
        private IwasiCore _iwasiCore;
        private Vector3 _iwasiPos;

        void Start()
        {
            type = ItemType.StargazyPie;
        }
        public void PickUp()
        {
            _iwasiCore.sizeOfGroup += _deltaSize;
           AudioSource.PlayClipAtPoint(_pickupSound, transform.position);
            Debug.Log(type + " ゲット!");
            Destroy(gameObject);
        }
        
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out _iwasiCore))
            {
                PickUp();
            }
        }
    }
}
