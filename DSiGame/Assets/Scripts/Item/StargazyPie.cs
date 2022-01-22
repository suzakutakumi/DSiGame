using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Item
{
    public class StargazyPie : BaseItem, IAvailableItem
    {
        [SerializeField] private int _deltaSize;

        private IwasiCore _iwasiCore;
        private Vector3 _iwasiPos;

        public void PickUp()
        {
            _iwasiCore.sizeOfGroup += _deltaSize;
            Debug.Log(type + " ゲット!");
            Destroy(gameObject);
        }

        void Start()
        {
            type = ItemType.StargazyPie;
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
