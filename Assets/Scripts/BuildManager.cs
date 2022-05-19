using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("more than 1 build manager is in the scene");
        }
        instance = this;
    }
    public static BuildManager instance;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;
    public GameObject buildEffect;
    public GameObject sellEffect;
    public NodeUI nodeui;
    public AudioClip clipBuild;
    public AudioClip clipCoins;
    public AudioClip clipUpgrade;
      public AudioClip clipFire;
    public AudioSource audioSource;




    //void Update()
    //{
        // if (Input.GetMouseButtonDown(0))
        // {
        //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //     RaycastHit hit;
        //     if (Physics.Raycast(ray, out hit))
        //     {
        //         if (hit.collider != null)
        //         {
        //             if(selectedNode != null && selectedNode.name != hit.collider.name ){
        //                 Debug.Log("selected node:" + selectedNode.name);
        //                 selectedNode = null;
        //                 nodeui.Hide();
        //             }                   
        //         }
        //         else
        //         {
        //             return;
        //         }
        //     }
        // }
    //}

    // Start is called before the first frame update


    public bool CanBuild
    {
        get { return turretToBuild != null; }
    }
    public bool HasMoney
    {
        get { return PlayerStats.Money >= turretToBuild.cost; }
    }

    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;
        nodeui.SetTarget(node);

    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }
    public void DeselectNode()
    {
        selectedNode = null;
        nodeui.Hide();
    }

    public void PlayBuild()
    {
        audioSource.PlayOneShot(clipBuild);
    }
    public void PlayCoins()
    {
        audioSource.PlayOneShot(clipCoins);

    }
    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
