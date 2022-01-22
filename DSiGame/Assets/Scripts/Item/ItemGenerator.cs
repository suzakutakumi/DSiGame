using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Item
{
    public class ItemGenerator : MonoBehaviour
    {
        [SerializeField, Range(0.0f, 1.0f)] private float density;
        [SerializeField] private List<BaseItem> itemList = new List<BaseItem>();
        
        private int size_x;
        private int size_z;

        void Start()
        {
            var createStage = GameObject.Find("PointCreateStage").GetComponent<CreateStage>();
            size_x = createStage.GetX;
            size_z = createStage.GetZ;
            
            for (int i = 0; i < size_x; i++)
            {
                for (int j = 0; j < size_z; j++)
                {
                    if(i < 2 && j == 0) continue; //スタート位置を無視
                    Generate(i * 10, j * 10);
                }
            }
        }

        private void Generate(int x, int z)
        {
            var item = itemList[Random.Range(0, itemList.Count)];
            if (Random.Range(0f, 1.0f) <= density * item.GetComponent<BaseItem>().Ratio)
            {
                Instantiate(item, new Vector3(x, 1, z), Quaternion.identity, transform);
            }
        }

        void Update()
        {

        }
    }
}
