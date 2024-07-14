using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : MonoBehaviour
{

    public GameObject[] plotPrefabs;
    public float zSpawn = 0;
    public float plotLength = 20f;
    public int numberOfplots = 3;
    public Transform playerTransform;
    private List<GameObject> activeplots = new List<GameObject>();

    void Start()
    {
        for(int i=0; i<numberOfplots; i++)
        {

           if(i==0){
             SpawnPlot(0);
            }
           else{
             SpawnPlot(Random.Range(0,plotPrefabs.Length));
            }
            
        }
    }

    void Update()
    {
        if(playerTransform.position.z -35 > zSpawn - (numberOfplots*plotLength)){
            SpawnPlot(Random.Range(0,plotPrefabs.Length));
            Deleteplot();
        }
    }



    public void SpawnPlot(int plotIndex){
        GameObject go = Instantiate(plotPrefabs[plotIndex], transform.forward * zSpawn, transform.rotation);
        activeplots.Add(go);
        zSpawn+=plotLength;
    }

    private void Deleteplot(){
        Destroy(activeplots[0]);
        activeplots.RemoveAt(0);
    }


}
