using System.Collections.Generic;
using UnityEngine;
using HoldfastSharedMethods;
using UnityEngine.UI;

public class NoStuckServerInterface : IHoldfastSharedMethods
{
    private bool isServer;
    private Dictionary<int, bool> playersInServer;
    private int timeElapsedToCheck;
    private bool didWeCheck;
    private int playerCountRequired;
    private int mapRotationRotate;
    private InputField f1MenuInput;
    private float currentTime;

    public void OnIsServer(bool server)
    {
        isServer = server;
        playersInServer = new Dictionary<int, bool>();
        didWeCheck = false;

        var canvases = Resources.FindObjectsOfTypeAll<Canvas>();
        for (int i = 0; i < canvases.Length; i++)
        {
            //Find the one that's called "Game Console Panel"
            if (string.Compare(canvases[i].name, "Game Console Panel", true) == 0)
            {
                //Inside this, now we need to find the input field where the player types messages.
                f1MenuInput = canvases[i].GetComponentInChildren<InputField>(true);
                if (f1MenuInput != null)
                {
                    Debug.Log("ModInterface::OnIsServer() Found the Game Console Panel");
                }
                else
                {
                    Debug.Log("ModInterface::OnIsServer() We did Not find the Game Console Panel");
                }
                break;
            }
        }
    }

    public void OnPlayerJoined(int playerId, ulong steamId, string name, string regimentTag, bool isBot)
    {
        if (!isBot)
        {
            playersInServer.Add(playerId, true);
        }
    }

    public void OnPlayerLeft(int playerId)
    {
        playersInServer.Remove(playerId);
    }

    public void OnUpdateTimeRemaining(float time)
    {
        currentTime = (float)time;
    }

    public void OnUpdateElapsedTime(float time)
    {
        if (!didWeCheck && time >= timeElapsedToCheck)
        {
            didWeCheck = true;
            if (playersInServer.Count < playerCountRequired && isServer)
            {
                //do rc command to map rotate;
                f1MenuInput.onEndEdit.Invoke("broadcast Swapping Map, not enough people on server.");
                var msg = "delayed " + Mathf.FloorToInt(currentTime - 5f) + " mapRotation " + mapRotationRotate;
                f1MenuInput.onEndEdit.Invoke(msg);
            }
        }
    }

    public void PassConfigVariables(string[] value)
    {
        playerCountRequired = 2;
        mapRotationRotate = 1;
        timeElapsedToCheck = 120;

        for (int i = 0; i < value.Length; i++)
        {
            var splitData = value[i].Split(':');
            if (splitData.Length != 3)
            {
                continue;
            }

            //so first variable should be the mod id
            if (splitData[0] == "2657896988")
            {
                //the second variable should be the variable type
                if (splitData[1] == "playerCount")
                {
                    //and the third variable should be the variable value
                    if (!int.TryParse(splitData[2], out playerCountRequired))
                    {
                        Debug.Log("Tried parsing playerCount but invalid format was found.");
                    }
                }
                //similarly, reason is the variable type
                else if (splitData[1] == "mapRotation")
                {
                    //and the third variable should be the variable value
                    if (!int.TryParse(splitData[2], out mapRotationRotate))
                    {
                        Debug.Log("Tried parsing mapRotation but invalid format was found.");
                    }
                }
                //similarly, reason is the variable type
                else if (splitData[1] == "timeElapsed")
                {
                    //and the third variable should be the variable value
                    if (!int.TryParse(splitData[2], out timeElapsedToCheck))
                    {
                        Debug.Log("Tried parsing timeElapsed but invalid format was found.");
                    }
                }
            }
        }

    }

    public void OnSyncValueState(int value)
    {
    }

    public void OnAdminPlayerAction(int playerId, int adminId, ServerAdminAction action, string reason)
    {
    }

    public void OnBuffStart(int playerId, BuffType buff)
    {
    }

    public void OnBuffStop(int playerId, BuffType buff)
    {
    }

    public void OnCapturePointCaptured(int capturePoint)
    {
    }

    public void OnCapturePointDataUpdated(int capturePoint, int defendingPlayerCount, int attackingPlayerCount)
    {
    }

    public void OnCapturePointOwnerChanged(int capturePoint, FactionCountry factionCountry)
    {
    }

    public void OnConsoleCommand(string input, string output, bool success)
    {
    }

    public void OnDamageableObjectDamaged(GameObject damageableObject, int damageableObjectId, int shipId, int oldHp, int newHp)
    {
    }

    public void OnEmplacementConstructed(int itemId)
    {
    }

    public void OnEmplacementPlaced(int itemId, GameObject objectBuilt, EmplacementType emplacementType)
    {
    }

    public void OnInteractableObjectInteraction(int playerId, int interactableObjectId, GameObject interactableObject, InteractionActivationType interactionActivationType, int nextActivationStateTransitionIndex)
    {
    }

    public void OnIsClient(bool client, ulong steamId)
    {
    }

    public void OnPlayerBlock(int attackingPlayerId, int defendingPlayerId)
    {
    }

    public void OnPlayerEndCarry(int playerId)
    {
    }

    public void OnPlayerHurt(int playerId, byte oldHp, byte newHp, EntityHealthChangedReason reason)
    {
    }

    public void OnPlayerKilledPlayer(int killerPlayerId, int victimPlayerId, EntityHealthChangedReason reason, string details)
    {
    }

    public void OnPlayerKilledVehicle(int killerPlayerId, int victimVehicleId, EntityHealthChangedReason reason, string details)
    {
    }

    public void OnPlayerMeleeStartSecondaryAttack(int playerId)
    {
    }

    public void OnPlayerShoot(int playerId, bool dryShot)
    {
    }

    public void OnPlayerShout(int playerId, CharacterVoicePhrase voicePhrase)
    {
    }

    public void OnPlayerSpawned(int playerId, int spawnSectionId, FactionCountry playerFaction, PlayerClass playerClass, int uniformId, GameObject playerObject)
    {
    }

    public void OnPlayerStartCarry(int playerId, CarryableObjectType carryableObject)
    {
    }

    public void OnPlayerWeaponSwitch(int playerId, string weapon)
    {
    }

    public void OnRCCommand(int playerId, string input, string output, bool success)
    {
    }

    public void OnRCLogin(int playerId, string inputPassword, bool isLoggedIn)
    {
    }

    public void OnRoundDetails(int roundId, string serverName, string mapName, FactionCountry attackingFaction, FactionCountry defendingFaction, GameplayMode gameplayMode, GameType gameType)
    {
    }

    public void OnRoundEndFactionWinner(FactionCountry factionCountry, FactionRoundWinnerReason reason)
    {
    }

    public void OnRoundEndPlayerWinner(int playerId)
    {
    }

    public void OnScorableAction(int playerId, int score, ScorableActionType reason)
    {
    }

    public void OnShipDamaged(int shipId, int oldHp, int newHp)
    {
    }

    public void OnShipSpawned(int shipId, GameObject shipObject, FactionCountry shipfaction, ShipType shipType, int shipName)
    {
    }

    public void OnShotInfo(int playerId, int shotCount, Vector3[][] shotsPointsPositions, float[] trajectileDistances, float[] distanceFromFiringPositions, float[] horizontalDeviationAngles, float[] maxHorizontalDeviationAngles, float[] muzzleVelocities, float[] gravities, float[] damageHitBaseDamages, float[] damageRangeUnitValues, float[] damagePostTraitAndBuffValues, float[] totalDamages, Vector3[] hitPositions, Vector3[] hitDirections, int[] hitPlayerIds, int[] hitDamageableObjectIds, int[] hitShipIds, int[] hitVehicleIds)
    {
    }

    public void OnTextMessage(int playerId, TextChatChannel channel, string text)
    {
    }

    public void OnUpdateSyncedTime(double time)
    {
    }
    public void OnVehicleHurt(int vehicleId, byte oldHp, byte newHp, EntityHealthChangedReason reason)
    {
    }

    public void OnVehicleSpawned(int vehicleId, FactionCountry vehicleFaction, PlayerClass vehicleClass, GameObject vehicleObject, int ownerPlayerId)
    {
    }
}
