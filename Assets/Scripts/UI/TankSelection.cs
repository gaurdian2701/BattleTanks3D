using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSelection : MonoBehaviour
{
    public void SelectGreenTank()
    {
        GameService.Instance.PlayerTankSpawnService.CreateTank(TankType.GreenTank);
        this.gameObject.SetActive(false);
    }

    public void SelectBlueTank()
    {
        GameService.Instance.PlayerTankSpawnService.CreateTank(TankType.BlueTank);
        this.gameObject.SetActive(false);
    }

    public void SelectRedTank()
    {
        GameService.Instance.PlayerTankSpawnService.CreateTank(TankType.RedTank);
        this.gameObject.SetActive(false);
    }
}
