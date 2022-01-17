using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Player;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GenerateButton : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameManager gameManager;

    public void Generate(int groupId)
    {
        GameObject buttonPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity,this.transform);
        buttonPrefab.transform.GetChild(0).GetComponent<Text>().text = "Group" + groupId.ToString();
        buttonPrefab.transform.GetComponent<Button>().onClick.AddListener(() => gameManager.SerectGroup(groupId));
    }
}
