using UnityEngine;
using System.Collections;

public class EnemySpawnBox : MonoBehaviour {

    public int healthChance = 100;
    public int healthAmmount = 20;
    public int TNTChance = 100;
    public int TNTAmmount = 1;
    public int RocketChance = 100;
    public int RocketDuration = 15;

    bool isHealthBox;
    bool isTNTBox;
    bool isRocketBox;

    static int boxVariants = 3;

    static Vector3[,]spawnPoints = new Vector3[boxVariants+1,boxVariants+1];
    float offset = 0.5f;

    void Awake()
    {
        spawnPoints[1,1] = new Vector3(0, 0, 0);

        spawnPoints[2,1] = new Vector3(offset, 0, 0);
        spawnPoints[2,2] = new Vector3(-offset, 0, 0);

        spawnPoints[3, 1] = Vector3.Normalize( new Vector3(-offset, 0, -offset));
        spawnPoints[3, 2] = new Vector3(offset, 0, -offset);
        spawnPoints[3, 3] =  Vector3.Normalize( new Vector3(0, 0, offset));

    }

	public void SpawnBoxes()
    {
        GameObject boxHolder;
        int randHealthBox = Random.Range(1, 100);
        int randTNTBox = Random.Range(1, 100);
        int randRocketBox = Random.Range(1, 100);

        isHealthBox = randHealthBox <= healthChance;
        isTNTBox = randTNTBox <= TNTChance;
        isRocketBox = randRocketBox <= RocketChance;

        int boxQty =0;

        if(isHealthBox)
            boxQty++;
        if(isTNTBox)
            boxQty++;
        if (isRocketBox)
            boxQty++;

        int spotIndex = 1;

        if (isHealthBox)
        {
            boxHolder = (GameObject) Instantiate(Resources.Load("HealthBox",typeof(GameObject)));
            Vector3 spot = transform.position + spawnPoints[boxQty, spotIndex];
            boxHolder.transform.position = new Vector3( spot.x ,boxHolder.transform.position.y, spot.z);
            boxHolder.GetComponentInChildren<HealthBoxScript>().ammount = TNTAmmount;

            spotIndex++;
        }

        if(isTNTBox)
        {
            boxHolder = (GameObject) Instantiate(Resources.Load("TNTBox",typeof(GameObject)));
            Vector3 spot = transform.position + spawnPoints[boxQty,spotIndex];
            boxHolder.transform.position = new Vector3( spot.x ,boxHolder.transform.position.y, spot.z);
            boxHolder.GetComponentInChildren<TNTBoxScript>().ammount = healthAmmount;

            spotIndex++;
        }


        if (isRocketBox)
        {
            boxHolder = (GameObject)Instantiate(Resources.Load("RocketBox", typeof(GameObject)));
            Vector3 spot = transform.position + spawnPoints[boxQty, spotIndex];
            boxHolder.transform.position = new Vector3(spot.x, boxHolder.transform.position.y, spot.z);
            boxHolder.GetComponentInChildren<RocketBoxScript>().duration= RocketDuration;

            spotIndex++;
        }


    }
}
