using HoldfastSharedMethods;
using UnityEngine;

public class TestScript2Mod : IHoldfastSharedMethods2
{
    public void OnOfficerOrderStart(int officerPlayerId, OfficerOrderType officerOrderType, Vector3 orderPosition, float orderRotationY, int voicePhraseRandomIndex)
    {
        Debug.LogFormat("OnOfficerOrderStart {0} {1}", officerPlayerId, officerOrderType);
    }

    public void OnOfficerOrderStop(int officerPlayerId, OfficerOrderType officerOrderType)
    {
        Debug.LogFormat("OnOfficerOrderStop {0} {1}", officerPlayerId, officerOrderType);
    }

    public void OnPlayerPacket(int playerId, byte? instance, Vector3? ownerPosition, double? packetTimestamp, Vector2? ownerInputAxis, float? ownerRotationY, float? ownerPitch, float? ownerYaw, PlayerActions[] actionCollection, Vector3? cameraPosition, Vector3? cameraForward, ushort? shipID, bool swimming)
    {
        Debug.LogWarningFormat("OnPlayerPacket {0}", playerId);
    }

    public void OnVehiclePacket(int vehicleId, Vector2 inputAxis, bool shift, bool strafe, PlayerVehicleActions[] actionCollection)
    {
        Debug.LogWarningFormat("OnVehiclePacket {0}", vehicleId);
    }
}
