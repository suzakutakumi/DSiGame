using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Item
{
    public class ItemGenerator : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField, Range(0.0f, 1.0f)] private float density;
        [SerializeField] private List<BaseItem> itemList = new List<BaseItem>();

        private int size_x;
        private int size_z;
        private List<Vector2> sponePos = new List<Vector2>();

        void Start()
        {
            var createStage = GameObject.Find("PointCreateStage").GetComponent<CreateStage>();
            size_x = createStage.X;
            size_z = createStage.Z;
            
            FindSponePoint(gameManager.nowPlayerGroup);
            FindSponePoint(gameManager.nowOpponentGroup);

            for (int i = 0; i < size_x; i++)
            {
                for (int j = 0; j < size_z; j++)
                {
                    if(sponePos.Contains(new Vector2(i * 10, j * 10))) continue; //スタート位置を無視
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

        private void FindSponePoint(List<GameObject> iwasiList)
        {
            foreach (var group in iwasiList)
            {
                var core = group.GetComponent<IwasiCore>();
                sponePos.Add(new Vector2(core.x, core.y));
            }
        }

        void Update()
        {

        }
    }
}
