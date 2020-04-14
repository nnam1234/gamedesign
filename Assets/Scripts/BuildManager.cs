using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("more than one buildmanager in the scene");
            return;
        }
        instance = this;
    }

    public GameObject defaultTurretPrefab;

    public GameObject fireTurretPrefab;
    public GameObject waterTurretPrefab;
    public GameObject earthTurretPrefab;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public TurretUI turretUI;



    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }


    public void SelectNode(Node node)
    {

        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }
 
        selectedNode = node;
        turretToBuild = null;

        turretUI.SetTarget(node);
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {

        turretToBuild = turret;
        DeselectNode();
    }

    public void DeselectNode()
    {
        selectedNode = null;
        turretUI.Hide();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

}
