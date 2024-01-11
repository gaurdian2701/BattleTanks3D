using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSelection : MonoBehaviour
{
    public TankSpawner tankSpawner;

    public void SelectGreenTank()
    {
        tankSpawner.CreateTank(TankType.GreenTank);
        this.gameObject.SetActive(false);
    }

    public void SelectBlueTank()
    {
        tankSpawner.CreateTank(TankType.BlueTank);
        this.gameObject.SetActive(false);
    }

    public void SelectRedTank()
    {
        tankSpawner.CreateTank (TankType.RedTank);
        this.gameObject.SetActive(false);
    }
}
