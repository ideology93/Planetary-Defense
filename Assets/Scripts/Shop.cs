using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileTurret;
    public TurretBlueprint multiMissileTurret;
    public TurretBlueprint laserBeamerTurret;
    BuildManager buildManager;
    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(standardTurret);
    }
    public void SelectMissileTurret()
    {
        buildManager.SelectTurretToBuild(missileTurret);
    }
    public void SelectMultiMissileTurret()
    {
        buildManager.SelectTurretToBuild(multiMissileTurret);
    }
    public void SelectLaserBeamerTurret()
    {
        buildManager.SelectTurretToBuild(laserBeamerTurret);
    }


}
