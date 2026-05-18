using UnityEngine;

public class TruckExtensionBoost : TruckExtension
{
    public override TruckExtensionsCoordinator.Extension thisTruckExtension => TruckExtensionsCoordinator.Extension.BoostExtension;
    public override float pointCost => 35.0f;
}
