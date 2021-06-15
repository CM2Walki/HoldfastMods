using System;
using UnityEngine;

public class KillArtillery : MonoBehaviour
{
    private readonly string[] artilleryNames =
    {
        // Game Map variants
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
        "Rocket_launcher_Gunboat",

        // Mod Map variants
        "Movable_FieldGun_9PDR_Destructible",
        "Movable_RocketLauncher_Destructible",
        "4Pdr(Wheel Carriage)_Destructible",
        "4Pdr(Wheel Carriage)_Naval_Destructible",
        "4Pdr_Gunboat_Naval_Destructible",
        "6Pdr_Destructible",
        "9Pdr(Wheel Carriage)_Naval_Destructible",
        "18Pdr_Naval_Destructible",
        "24Pdr_Destructible",
        "24Pdr_Naval_Destructible",
        "36Pdr_French_Destructible",
        "36Pdr_French_Naval_Destructible",
        "FieldGun_9PDR_Destructible",
        "FieldGun_9PDR_Naval_Destructible",
        "Longgun_RotatingCannonCarriage_Destructible",
        "RocketLauncher_Gunboat_Naval_Destructible"
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

                for (var j = 0; j < artilleryNames.Length; j++)
                {
                    if (goName.IndexOf(artilleryNames[j], StringComparison.OrdinalIgnoreCase) < 0)
                    {
                        continue;
                    }

                    Destroy(gos[i]);

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