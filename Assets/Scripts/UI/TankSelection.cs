using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSelection : MonoBehaviour
{
    public void SelectGreenTank()
    {
        GameService.Instance.PlayerTankSpawnService.CreateTank(PlayerTankClass.GreenTank);
        this.gameObject.SetActive(false);
    }

    public void SelectBlueTank()
    {
        GameService.Instance.PlayerTankSpawnService.CreateTank(PlayerTankClass.BlueTank);
        this.gameObject.SetActive(false);
    }

    public void SelectRedTank()
    {
        GameService.Instance.PlayerTankSpawnService.CreateTank(PlayerTankClass.RedTank);
        this.gameObject.SetActive(false);
    }
}
