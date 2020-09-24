using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour
{
    [SerializeField] //this line will make your private variables show up in the editor window
    private GameObject[] trees = new GameObject[3];

    private int totalNumTrees=0;

    //below variables would be used to make sure the tree would appear within the ground plane
    [SerializeField]
    private GameObject ground;

    private float groundXSize;
    private float groundZSize;

    // Start is called before the first frame update
    void Start()
    {
        //If you do not want to drag and drop the tree prefabs in the Editor window,
        //you can put your prefabs in the Resource folder and load them in in the start function


        //Get variable from another object
        groundXSize = ground.transform.localScale.x;
        groundZSize = ground.transform.localScale.z;
        Debug.Log(groundXSize);
    }


    // this function will be called by the TreeManager to generate a random tree at random location
    public void PlantATree()
    {
        Debug.Log("TreeManager/Plant a tree function is called.");
        //Find a random tree prefab from the 3 options
        int treeId = Random.Range(0, 3);
        GameObject curTree = Instantiate(trees[treeId]);

        //Find a random spot within the ground plane
        Vector3 treeLocation = new Vector3(Random.Range(-groundXSize/2,groundXSize/2),0f,Random.Range(-groundZSize/2,groundZSize/2));
        curTree.transform.position = treeLocation;
        curTree.transform.parent = this.transform;//make the tree object the child object of the gameobject that has this script on it - TreeManager
        totalNumTrees++;
    }

    //called by other objects, will return the total number of trees generated
    public int GetTreeCount()
    {
        return totalNumTrees;
    }
}
