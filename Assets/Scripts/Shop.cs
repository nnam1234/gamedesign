using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint defaultTurret;
    public TurretBlueprint fireTurret;
    public TurretBlueprint waterTurret;
    public TurretBlueprint earthTurret;



    BuildManager bm;

    private void Start()
    {
        bm = BuildManager.instance;
    }
    public void SelectDefaultTurret()
    {
       //Debug.Log("default turret");
        bm.SelectTurretToBuild(defaultTurret);

    }

    public void SelectFireTurret()
    {
        //Debug.Log("Fire turret");
        bm.SelectTurretToBuild(fireTurret);
    }
    public void SelectWaterTurret()
    {
        //Debug.Log("Water turret");
        bm.SelectTurretToBuild(waterTurret);
    }
    public void SelectEarthTurret()
    {
        //Debug.Log("Earth  turret");
        bm.SelectTurretToBuild(earthTurret);
    }

}
