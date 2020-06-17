using System;
using UnityEngine;

public class KillMapBorder : MonoBehaviour
{
    private void Awake()
    {
        try
        {
            var BorderLayerMask = LayerMask.NameToLayer("Players Out of Bounds Collider");

            GameObject[] gos = FindObjectsOfType(typeof(GameObject)) as GameObject[];

            for (int i = 0; i < gos.Length; i++)
            {
                // Walki: This is ugly asf, but it has to do
                if (gos[i].layer == BorderLayerMask ||
                    gos[i].name == "LowpolyCollider" ||
                    gos[i].name == "ShipCollidersOutbound" ||
                    gos[i].name == "LowPoly - StaticEnvironment" ||
                    gos[i].name == "Out of Bounds Colliders  Ocean" ||
                    gos[i].name == "OutOfBounds Box Colliders-LowPoly" ||
                    gos[i].name.IndexOf("OutOfBounds", StringComparison.OrdinalIgnoreCase) >= 0 ||
                    gos[i].name.IndexOf("Out Of Bounds", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    Destroy(gos[i]);
                }
            }

            Destroy(this);
        }
        catch (Exception)
        {

        }
    }
}