using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class MoveRangeLine : MonoBehaviour
{
    [SerializeField] private Material _material;
    
    private CreateStage createStage;
    private LineRenderer _lineRenderer;
    private float _gridSize;


    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        createStage = GameObject.Find("PointCreateStage").GetComponent<CreateStage>();
        _gridSize = createStage.GridSize * 10;
    }

    public void DrawLine(IwasiCore iwasiCore)
    {
        var corner = _gridSize / 2 + _gridSize * iwasiCore.moveRange;
        var halfGrid = _gridSize / 2; 
        var supX = Mathf.Clamp(iwasiCore.x + corner, -halfGrid, _gridSize * createStage.X - halfGrid);
        var infX = Mathf.Clamp(iwasiCore.x - corner, -halfGrid, _gridSize * createStage.X - halfGrid);
        var supZ = Mathf.Clamp(iwasiCore.y + corner, -halfGrid, _gridSize * createStage.Z - halfGrid);
        var infZ = Mathf.Clamp(iwasiCore.y - corner, -halfGrid, _gridSize * createStage.Z - halfGrid);

        var positions = new Vector3[]
        {
            new Vector3(infX, 0, infZ),
            new Vector3(supX, 0, infZ),
            new Vector3(supX, 0, supZ),
            new Vector3(infX, 0, supZ),
            new Vector3(infX, 0, infZ)
        };

        _lineRenderer.positionCount = positions.Length;
        _lineRenderer.SetPositions(positions);
        _lineRenderer.material = _material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
