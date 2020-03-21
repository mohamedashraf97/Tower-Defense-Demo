using UnityEngine;

public class BuildManager : MonoBehaviour
{

    private TurrentBluePrint turrentToBuild;

    public static BuildManager instance;
    public GameObject standardTurrentPrefab;
    public GameObject missleLauncherPrefab;
    public GameObject buildEffect;




    void Awake()
    {

        if (instance != null)
        {

            Debug.LogError("more than one inst in scene !");
            return;
        }
        instance = this;
    }
    public bool CanBuild { get { return turrentToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turrentToBuild.cost; } }



    public void BuildTurrentOn(Node node)
    {

        if (PlayerStats.Money < turrentToBuild.cost)
        {

            return;

        }
        PlayerStats.Money -= turrentToBuild.cost;

        GameObject turrent = (GameObject)Instantiate(turrentToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turrent = turrent;
        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

    }
    public void SelectTurrentToBuild(TurrentBluePrint turrent)
    { 
        turrentToBuild = turrent;
    }
}
