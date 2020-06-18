using System;
using UnityEngine;

public class KillArtillery : MonoBehaviour
{
    private readonly string[] artilleryNames =
    {
        "Cannon_4Pdr",
        "Cannon_6Pdr",
        "Cannon_18Pdr",
        "Cannon_24Pdr",
        "Cannon_FieldGun_9PDR",
        "Carronade",
        "CoastalCannon_36Pdr",
        "Longgun_RotatingCannonCarriage",
        "Mortar",
        "MovableCannon_FieldGun_9PDR",
        "Swivlegun",
        "Rocket_Moveable_Usable",
        "Rocket_launcher_Gunboat"
    };

    private void Awake()
    {
        try
        {
            GameObject[] gos = FindObjectsOfType(typeof(GameObject)) as GameObject[];

            for (int i = 0; i < gos.Length; i++)
            {
                var goName = gos[i].name;
                if (goName.IndexOf("(Clone)", StringComparison.OrdinalIgnoreCase) >= 0) // Prefabs get "(Clone)" appended these were spawned using overrides, so keep them
                {
                    continue;
                }

                for (int j = 0; j < artilleryNames.Length; j++)
                {
                    if (goName.IndexOf(artilleryNames[j], StringComparison.OrdinalIgnoreCase) >= 0) // Kill anything that's in the array, leave noone alive!
                    {
                        Destroy(gos[i]);
                        break;
                    }
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