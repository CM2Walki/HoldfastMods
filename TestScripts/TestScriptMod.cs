using HoldfastSharedMethods;
using UnityEngine;

public class TestScriptMod : IHoldfastSharedMethods
{
    public void GetSyncValue(int value)
    {
        Debug.LogFormat("GetSyncValue {0}", value);
    }

    public void GetSyncedTime(double time)
    {
        //Debug.LogWarningFormat("GetSyncedTime {0}", time);
    }

    public void GetTimeSinceStart(float time)
    {
        //Debug.LogWarningFormat("GetTimeSinceStart {0}", time);
    }

    public void GetTimeRemaining(float time)
    {
        //Debug.LogWarningFormat("GetTimeRemaining {0}", time);
    }

    public void IsServer(bool server)
    {
        Debug.LogFormat("IsServer {0}", server);
    }

    public void IsClient(bool client, ulong steamId)
    {
        Debug.LogFormat("IsClient {0} {1}", client, steamId);
    }

    public void OnDamageableObjectDamaged(GameObject damageableObject, int oldHp, int newHp)
    {
        Debug.LogFormat("OnDamageableObjectDamaged {0} {1} {2}", damageableObject.name, oldHp, newHp);
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

    public void OnPlayerSpawned(int playerId, FactionCountry playerFaction, PlayerClass playerClass, int uniformId, GameObject playerObject, ulong steamId, string playerName, string regimentTag)
    {
        Debug.LogFormat("OnPlayerSpawned {0} {1} {2} {3} {4} {5} {6} {7}", playerId, playerFaction, playerClass, uniformId, playerObject.name, steamId, playerName, regimentTag);
    }

    public void OnScorableAction(int playerId, byte score, ScorableActionType reason)
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
}