using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerActions : MonoBehaviour {

    public enum GunMode { Gun, Rocket };

    public GameObject gunHolder;
    public GameObject rocketHolder;

    public KeyCode bombButton;
    public GameObject bombText;
    public int bombQty = 3;
    public GunMode defGunMode = GunMode.Gun;
    GunMode actualGunMode;

    float gunTimer;

    GunMode gunmode {
        get
        {
            return gunmode;
        }
        set
        {
            gunmode = value;
            SwitchGunMode(gunmode);
        }
    }

    

	void Awake () {
        SwitchGunMode(defGunMode);
	}
	
	
	void Update () {

        gunTimer -= Time.deltaTime;
        bombText.GetComponent<Text>().text = bombQty.ToString();

        if (Input.GetKeyDown(bombButton) && bombQty > 0)
        {
            bombQty--;

            GameObject bomb = (GameObject)Instantiate(Resources.Load("TNT"));
            bomb.transform.position = new Vector3(transform.position.x, bomb.transform.position.y, transform.position.z);
        }

        if (gunTimer <= 0 && actualGunMode!= defGunMode)
            SwitchGunMode(defGunMode);
	}

    void SwitchGunMode(GunMode mode)
    {
        Debug.Log("Switch gun to:" + mode.ToString());

        actualGunMode = mode;

        gunHolder.SetActive(false);
        rocketHolder.SetActive(false);

        if (mode == GunMode.Gun)
            gunHolder.SetActive(true);
        if (mode == GunMode.Rocket)
            rocketHolder.SetActive(true);

        //string name = mode.ToString() + "Holder";

        //GameObject.fin

        //GameObject[] gunList = GameObject.FindGameObjectsWithTag("GunTag");

        //foreach (GameObject gun in gunList)
        //{
        //    Debug.Log("gun.name: " + gun.name);
        //    Debug.Log("name: " + name);

        //    if(gun.name == name)
        //    {
        //        gun.SetActive(true);
        //    }
        //    else
        //    {
        //        gun.SetActive(false);
        //    }
        //}
    }

    public void GunBonus(GunMode mode, float duration)
    {
        gunTimer = duration;

        Debug.Log("duration: " + duration);

        SwitchGunMode(mode);
        
    }


}
