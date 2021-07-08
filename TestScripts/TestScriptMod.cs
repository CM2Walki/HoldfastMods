using HoldfastSharedMethods;
using UnityEngine;

public class TestScriptMod : IHoldfastSharedMethods
{
    public void OnSyncValueState(int value)
    {
        Debug.LogFormat("OnSyncValueState {0}", value);
    }

    public void OnUpdateSyncedTime(double time)
    {
        //Debug.LogWarningFormat("OnUpdateSyncedTime {0}", time);
    }

    public void OnUpdateElapsedTime(float time)
    {
        //Debug.LogWarningFormat("OnUpdateElapsedTime {0}", time);
    }

    public void OnUpdateTimeRemaining(float time)
    {
        //Debug.LogWarningFormat("GetTimeRemaining {0}", time);
    }

    public void OnIsServer(bool server)
    {
        Debug.LogFormat("IsServer {0}", server);
    }

    public void OnIsClient(bool client, ulong steamId)
    {
        Debug.LogFormat("IsClient {0} {1}", client, steamId);
    }

    public void OnDamageableObjectDamaged(GameObject damageableObject, int damageableObjectId, int shipId, int oldHp, int newHp)
    {
        Debug.LogFormat("OnDamageableObjectDamaged {0} {1} {2} {3} {4}", damageableObject.name, damageableObjectId, shipId, oldHp, newHp);
    }

    public void OnPlayerHurt(int playerId, byte oldHp, byte newHp, EntityHealthChangedReason reason)
    {
        Debug.LogFormat("OnPlayerHurt {0} {1} {2} {3}", playerId, oldHp, newHp, reason);
    }

    public void OnPlayerKilledPlayer(int killerPlayerId, int victimPlayerId, EntityHealthChangedReason reason, string additionalDetails)
    {
        Debug.LogFormat("OnPlayerKilledPlayer {0} {1} {2} {3}", killerPlayerId, victimPlayerId, reason, additionalDetails);
    }

    public void OnPlayerShoot(int playerId, bool dryShot)
    {
        Debug.LogFormat("OnPlayerShoot {0} {1}", playerId, dryShot);
    }

    public void OnPlayerJoined(int playerId, ulong steamId, string playerName, string regimentTag, bool isBot)
    {
        Debug.LogFormat("OnPlayerJoined {0} {1} {2} {3} {4}", playerId, steamId, playerName, regimentTag, isBot);
    }

    public void OnPlayerLeft(int playerId)
    {
        Debug.LogFormat("OnPlayerLeft {0}", playerId);
    }

    public void OnPlayerSpawned(int playerId, int spawnSectionId, FactionCountry playerFaction, PlayerClass playerClass, int uniformId, GameObject playerObject)
    {
        Debug.LogFormat("OnPlayerSpawned {0} {1} {2} {3} {4} {5}", playerId, spawnSectionId, playerFaction, playerClass, uniformId, playerObject.name);
    }

    public void OnScorableAction(int playerId, int score, ScorableActionType reason)
    {
        Debug.LogFormat("OnScorableAction {0} {1} {2}", playerId, score, reason.ToString());
    }

    public void OnTextMessage(int playerId, TextChatChannel channel, string text)
    {
        Debug.LogFormat("OnTextMessage {0} {1} {2}", playerId, channel, text);
    }

    public void OnRoundDetails(int roundId, string serverName, string mapName, FactionCountry attackingFaction, FactionCountry defendingFaction, GameplayMode gameplayMode, GameType gameType)
    {
        Debug.LogFormat("OnRoundDetails {0} {1} {2} {3} {4} {5} {6}", roundId, serverName, mapName, attackingFaction, defendingFaction,
            gameplayMode, gameType);
    }

    public void OnPlayerBlock(int attackingPlayerId, int defendingPlayerId)
    {
        Debug.LogFormat("OnPlayerBlock {0} {1}", attackingPlayerId, defendingPlayerId);
    }

    public void OnPlayerMeleeStartSecondaryAttack(int playerId)
    {
        Debug.LogFormat("OnPlayerMeleeStartSecondaryAttack {0}", playerId);
    }

    public void OnPlayerWeaponSwitch(int playerId, string weapon)
    {
        Debug.LogFormat("OnPlayerWeaponSwitch {0} {1}", playerId, weapon);
    }

    public void OnCapturePointCaptured(int capturePoint)
    {
        Debug.LogFormat("OnCapturePointCaptured {0}", capturePoint);
    }

    public void OnCapturePointOwnerChanged(int capturePoint, FactionCountry factionCountry)
    {
        Debug.LogFormat("OnCapturePointOwnerChanged {0} {1}", capturePoint, factionCountry.ToString());
    }

    public void OnCapturePointDataUpdated(int capturePoint, int defendingPlayerCount, int attackingPlayerCount)
    {
        Debug.LogFormat("OnCapturePointDataUpdated {0} {1} {2}", capturePoint, defendingPlayerCount, attackingPlayerCount);
    }

    public void OnRoundEndFactionWinner(FactionCountry factionCountry, FactionRoundWinnerReason reason)
    {
        Debug.LogFormat("OnRoundEndFactionWinner {0} {1}", factionCountry, reason);
    }

    public void OnRoundEndPlayerWinner(int playerId)
    {
        Debug.LogFormat("OnRoundEndPlayerWinner {0}", playerId);
    }

    public void OnPlayerStartCarry(int playerId, CarryableObjectType carryableObject)
    {
        Debug.LogFormat("OnPlayerStartCarry {0} {1}", playerId, carryableObject);
    }

    public void OnPlayerEndCarry(int playerId)
    {
        Debug.LogFormat("OnPlayerEndCarry {0}", playerId);
    }

    public void OnPlayerShout(int playerId, CharacterVoicePhrase voicePhrase)
    {
        Debug.LogFormat("OnPlayerShout {0} {1}", playerId, voicePhrase);
    }

    public void OnInteractableObjectInteraction(int playerId, int interactableObjectId, GameObject interactableObject, InteractionActivationType interactionActivationType, int nextActivationStateTransitionIndex)
    {
        Debug.LogFormat("OnInteractableObjectInteractedWith {0} {1} {2} {3} {4}", playerId, interactableObjectId, interactableObject.name, interactionActivationType, nextActivationStateTransitionIndex);
    }

    public void PassConfigVariables(string[] value)
    {
        Debug.Log("PassConfigVariables : ");
        for (int i = 0; i < value.Length; i++)
        {
            Debug.Log(value[i]);
        }
    }

    public void OnEmplacementPlaced(int itemId, GameObject objectBuilt, EmplacementType emplacementType)
    {
        Debug.LogFormat("OnEmplacementPlaced {0} {1} {2}", itemId, objectBuilt.name, emplacementType);
    }

    public void OnEmplacementConstructed(int itemId)
    {
        Debug.LogFormat("OnEmplacementConstructed {0}", itemId);
    }

    public void OnBuffStart(int playerId, BuffType buff)
    {
        Debug.LogFormat("OnBuffStart {0} {1}", playerId, buff);
    }

    public void OnBuffStop(int playerId, BuffType buff)
    {
        Debug.LogFormat("OnBuffStop {0} {1}", playerId, buff);
    }

    public void OnShotInfo(int playerId, int shotCount, Vector3[][] shotsPointsPositions, float[] trajectileDistances, float[] distanceFromFiringPositions, float[] horizontalDeviationAngles, float[] maxHorizontalDeviationAngles, float[] muzzleVelocities, float[] gravities, float[] damageHitBaseDamages, float[] damageRangeUnitValues, float[] damagePostTraitAndBuffValues, float[] totalDamages, Vector3[] hitPositions, Vector3[] hitDirections, int[] hitPlayerIds, int[] hitDamageableObjectIds, int[] hitShipIds, int[] hitVehicleIds)
    {
        Debug.LogFormat("OnShotInfo Player {0}, Shot Count {1}", playerId, shotCount);
        for (int i = 0; i < shotCount; i++)
        {
            Debug.LogFormat("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14} {15} ... ohh yeah and also positions...", trajectileDistances[i], distanceFromFiringPositions[i], horizontalDeviationAngles[i], maxHorizontalDeviationAngles[i], muzzleVelocities[i], gravities[i], damageHitBaseDamages[i], damageRangeUnitValues[i], damagePostTraitAndBuffValues[i], totalDamages[i], hitPositions[i], hitDirections[i], hitPlayerIds[i], hitDamageableObjectIds[i], hitShipIds[i], hitVehicleIds[i]);
        }
    }

    public void OnVehicleSpawned(int vehicleId, FactionCountry vehicleFaction, PlayerClass vehicleClass, GameObject vehicleObject, int ownerPlayerId)
    {
        Debug.LogFormat("OnVehicleSpawned {0} {1} {2} {3} {4}", vehicleId, vehicleFaction, vehicleClass, vehicleObject.name, ownerPlayerId);
    }

    public void OnVehicleHurt(int vehicleId, byte oldHp, byte newHp, EntityHealthChangedReason reason)
    {
        Debug.LogFormat("OnVehicleHurt {0} {1} {2} {3}", vehicleId, oldHp, newHp, reason);
    }

    public void OnPlayerKilledVehicle(int killerPlayerId, int victimVehicleId, EntityHealthChangedReason reason, string details)
    {
        Debug.LogFormat("OnPlayerKilledVehicle {0} {1} {2} {3}", killerPlayerId, victimVehicleId, reason, details);
    }

    public void OnShipSpawned(int shipId, GameObject shipObject, FactionCountry shipfaction, ShipType shipType, int shipNameId)
    {
        Debug.LogFormat("OnShipSpawned {0} {1} {2} {3}, {4}", shipId, shipObject.name, shipfaction, shipType, shipNameId);
    }

    public void OnShipDamaged(int shipId, int oldHp, int newHp)
    {
        Debug.LogFormat("OnShipDamaged {0} {1} {2}", shipId, oldHp, newHp);
    }

    public void OnAdminPlayerAction(int playerId, int adminId, ServerAdminAction action, string reason)
    {
        Debug.LogFormat("OnShipDamaged {0} {1} {2} {3}", playerId, adminId, action.ToString(), reason);
    }

    public void OnConsoleCommand(string input, string output, bool success)
    {
        Debug.LogFormat("OnConsoleCommand {0} {1} {2}", input, output, success);
    }

    public void OnRCLogin(int playerId, string inputPassword, bool isLoggedIn)
    {
        Debug.LogFormat("OnRCLogin {0} {1} {2}", playerId, inputPassword, isLoggedIn);
    }

    public void OnRCCommand(int playerId, string input, string output, bool success)
    {
        Debug.LogFormat("OnRCCommand {0} {1} {2} {3}", playerId, input, output, success);

    }
}