using System;
using UnityEngine;

public class KillArtilleryAmmo : MonoBehaviour
{
    private readonly string[] artilleryAmmoNames =
    {
        // Artillery ammo variants (they essentially all share the same prefix, rocket stacks included)
        "ammobox",
        "ammo box"
    };

    private void Awake()
    {
        try
        {
            var gos = FindObjectsOfType(typeof(GameObject)) as GameObject[];

            for (var i = 0; i < gos.Length; i++)
            {
                var goName = gos[i].name;
                if (goName.IndexOf("(Clone)", StringComparison.OrdinalIgnoreCase) >= 0) // Prefabs get "(Clone)" appended these were spawned using overrides, so keep them
                {
                    continue;
                }

                for (var j = 0; j < artilleryAmmoNames.Length; j++)
                {
                    if (goName.IndexOf(artilleryAmmoNames[j], StringComparison.OrdinalIgnoreCase) < 0)
                    {
                        continue;
                    }

                    gos[i].SetActive(false);

                    break;
                }
            }
        }
        catch (Exception)
        {
            // We don't care about any errors
        }

        Destroy(gameObject);
    }
}