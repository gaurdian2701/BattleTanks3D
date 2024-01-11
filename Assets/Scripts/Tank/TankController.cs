using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController
{
    private TankView tankView;
    private TankModel tankModel;

    public TankController(TankView _tankView, TankModel _tankModel)
    {
        tankView = _tankView;
        tankModel = _tankModel;

        tankModel.SetTankController(this);
        tankView.SetTankController(this);
        GameObject.Instantiate(tankView.gameObject);
    }

}
