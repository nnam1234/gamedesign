using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpot : MonoBehaviour
{

    void OnMouseUp()
    {
        Vector3 dir = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        BuildingManager bm = GameObject.FindObjectOfType<BuildingManager>();

        if(bm.selectedTower != null)
        {
            ScoreManager sm = GameObject.FindObjectOfType<ScoreManager>();
            if(sm.money < bm.selectedTower.GetComponent<Turret>().cost)
            {
                Debug.Log("we broke");
                return;
            }

            sm.money -= bm.selectedTower.GetComponent<Turret>().cost;
            Instantiate(bm.selectedTower, dir, transform.rotation);
        }
    }
}
