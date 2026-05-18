using UnityEngine;

public class TruckExtensionSlip : TruckExtension
{
    public override TruckExtensionsCoordinator.Extension thisTruckExtension => TruckExtensionsCoordinator.Extension.SlipExtension;
    public override float pointCost => 15.0f;
}
