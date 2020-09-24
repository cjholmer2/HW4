
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class ForestManager: MonoBehaviour
{
    [SerializeField]
    private GameObject treeManager;
    [SerializeField]
    private GameObject stoneManager;
    [SerializeField]
    private GameObject otherManager;

    private Text guiText;
    private Text guiTrees;
    private Text guiStones;
    private Text guiOthers;
    private Text buttonName;
    private string x = "Hide Forest Stats";
    private bool canShow;

    // Start is called before the first frame update
    void Start()
    {
        //If you do not want to do drag & drop in the editor window, you can still access other objects
        guiText = GameObject.Find("MyDebugText").GetComponent<Text>();
        guiText.text = "Forest Generator";
        guiTrees = GameObject.Find("TreeText").GetComponent<Text>();
        guiStones = GameObject.Find("StoneText").GetComponent<Text>();
        guiOthers = GameObject.Find("OtherText").GetComponent<Text>();
        buttonName = GameObject.Find("ForestStatusButton").GetComponentInChildren<Text>();
    }
    
    //
    public void ShowForestStats()
    {
        int totalTreeCount = treeManager.GetComponent<TreeManager>().GetTreeCount();
        int totalStoneCount = stoneManager.GetComponent<StoneManager>().GetStoneCount();
        int totalOtherCount = otherManager.GetComponent<OtherManager>().GetOtherCount();
        guiText.text = "Forest Generator";
        if(canShow == true)
        {
            guiTrees.text = "Number of trees: " + totalTreeCount.ToString();
            guiStones.text = "Number of stones: " + totalStoneCount.ToString();
            guiOthers.text = "Number of others: " + totalOtherCount.ToString();
        }
        /*else if(canShow == false)
        {
            guiTrees.text = "";
            guiStones.text = "";
            guiOthers.text = "";
        }*/
    }

    
    public void ChangeButton()
    {

        buttonName.text = x;

        if( x == "Hide Forest Stats")
        {
            canShow = true;
            ShowForestStats();
            x = "Show Forest Stats";
        }
        else if (x == "Show Forest Stats")
        {
            canShow = false;
            HideForestStats();
            x = "Hide Forest Stats";
        }

    }

    public void HideForestStats()
    {
        guiTrees.text = "";
        guiStones.text = "";
        guiOthers.text = "";
    }
}
