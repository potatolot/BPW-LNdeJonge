using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TreeRotation : MonoBehaviour
{
    private float randomRotationValue;
    [SerializeField]
    Terrain terrainTrees;

    private void OnEnable()
    {
        randomRotationValue = Random.Range(0, 360);
        transform.localRotation = Quaternion.Euler(new Vector3(0, 1, 0) * randomRotationValue);
    }
    private void OnActive()
        {
         
        //TreeInstance
       /* for (int i = 0; i < terrainTrees.terrainData.treeInstances.Length; i++)
        {
            Terrain.activeTerrain.terrainData.treeInstances[i].rotation = new Vector3(0, 1 * randomRotationValue, 0);
        }*/
    }
}
