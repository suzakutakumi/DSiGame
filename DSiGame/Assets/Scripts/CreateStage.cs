using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStage : MonoBehaviour
{

    [SerializeField]
    private float GridScale = 0.7f;   //�}�X�̔{��
    [SerializeField]
    private int NumX = 10;    //�����W�̐�
    [SerializeField]
    private int NumZ = 10;    //�����W�̐�

    public int GetX => NumX;
    public int GetZ => NumZ;
    
    float EdgeLength()
    {
        return 10 * GridScale;
    }

    // Start is called before the first frame update
    void Start()
    {

        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Plane);
        obj.transform.localScale = new Vector3(GridScale, GridScale, GridScale);

        for (float x = 0; x < NumX * EdgeLength(); x += EdgeLength())
        {
            for (float z = 0; z < NumZ * EdgeLength(); z += EdgeLength())
            {
                Instantiate(obj, new Vector3(x, 0, z), Quaternion.identity);
            }
        }
        Destroy(obj);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
