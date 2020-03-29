using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeRotator : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabtree;

    [SerializeField]
    private Terrain terrain;

    private Vector3 position;

    private ArrayList treeArray;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("test");
        float randomRotationValue = Random.Range(0, 360); 

        //TreeInstance newTree = new TreeInstance();

       // List<TreeInstance> newTrees = new List<TreeInstance>(terrain.terrainData.treeInstances);
        //newTrees.RemoveAll(x => x.position == newTrees[i].position);


        //Vector3 spawnPos = new Vector3();
        /*  for (int i = 0;  i < newTrees.Count; i++)
            {
              //TreeInstance newTree = new TreeInstance();
              //spawnPos = newTrees[i].position;

              // newTrees[i] = newTree;

             //terrain.AddTreeInstance(newTree);

              //newTrees.RemoveAll(x => x.position == newTrees[i].position);
              // newTrees.Remove(newTrees[i]);
              //terrain.AddTreeInstance(newTree);

                spawnTree(newTrees[i].position);
          }*/
        spawnTree(new Vector3(0, 0, 0));


        /*   spawnPos.x = Mathf.InverseLerp(-2048, 2048, transform.position.x); //Set the min and max global values for both X and Z. X and Z can either be grabbed from an object or random.
           spawnPos.z = Mathf.InverseLerp(-2048, 2048, transform.position.z);
           spawnPos.y = 0f; //The Y position seems to be automatically handled. The trees are always on the terrain.
           TreeInstance newTree = new TreeInstance();
           newTree.color = new Color(1, 1, 1);
           newTree.lightmapColor = new Color(1, 1, 1);
           newTree.heightScale = 1;
           newTree.widthScale = 1;
           newTree.prototypeIndex = 1; //There are 2 entries here by default. Index 0 is an oak tree, index 1 is a pine tree.
           newTree.position = spawnPos;
           newTree.rotation = Random.Range(0f, 180f);
           terrain.AddTreeInstance(newTree);*/

        //  newTrees.Clear();

        //terrain.terrainData.treeInstances = newTrees.ToArray();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnTree(Vector3 position)
    {
        Vector3 spawnPos = new Vector3();
        spawnPos.x = Mathf.InverseLerp(-2048, 2048, transform.position.x); //Set the min and max global values for both X and Z. X and Z can either be grabbed from an object or random.
        spawnPos.z = Mathf.InverseLerp(-2048, 2048, transform.position.z);
        spawnPos.y = 0f; //The Y position seems to be automatically handled. The trees are always on the terrain.
        TreeInstance newTree = new TreeInstance();
        newTree.color = new Color(1, 1, 1);
        newTree.lightmapColor = new Color(1, 1, 1);
        newTree.rotation = Random.Range(0f, 180f);
        newTree.heightScale = 1;
        newTree.widthScale = 1;
        newTree.prototypeIndex = 2; //There are 2 entries here by default. Index 0 is an oak tree, index 1 is a pine tree.
        
        newTree.position = spawnPos;//new Vector3(0, 0, 0);
        // = Mathf.Deg2Rad * 180;// Random.Range(0f, 180f); //Completely optional for making the trees a little more varied
        terrain.AddTreeInstance(newTree); //Causes a spike in processing time, as all trees and grasses reset. My testing puts this at 50ms +/- 20ms, but only for 1 frame.
        //treelist.refreshTreeList(); //This causes our script for finding trees to refresh. No additional processing time noted in Profiler.
    }
}
