using HoldfastSharedMethods;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineFormer : IHoldfastSharedMethods
{
    private class RunningCommand
    {
        public int requiredToSpawn;
        public int spawnedCount;
        public Vector3 position;
        public float yRotation;
        public Vector3 rightDirection;
    }

    private InputField f1MenuInputField;
    private Dictionary<int, FactionCountry> playerFactionDictionary = new Dictionary<int, FactionCountry>();
    private Dictionary<int, GameObject> playerObjectDictionary = new Dictionary<int, GameObject>();
    private Dictionary<int, bool> playerIsBotDictionary = new Dictionary<int, bool>();
    private List<RunningCommand> runningCommands = new List<RunningCommand>();
    private FactionCountry attackingFaction;
    private FactionCountry defendingFaction;

    //I only care up to 3 hits max.
    private RaycastHit[] resultHits = new RaycastHit[3];

    public void OnIsServer(bool server)
    {
        //Get all the canvas items in the game
        var canvases = Resources.FindObjectsOfTypeAll<Canvas>();
        for (int i = 0; i < canvases.Length; i++)
        {
            //Find the one that's called "Game Console Panel"
            if (string.Compare(canvases[i].name, "Game Console Panel", true) == 0)
            {
                //Inside this, now we need to find the input field where the player types messages.
                f1MenuInputField = canvases[i].GetComponentInChildren<InputField>(true);
                if (f1MenuInputField != null)
                {
                    Debug.Log("Found the Game Console Panel");
                }
                else
                {
                    Debug.Log("We did Not find Game Console Panel");
                }
                break;
            }
        }

        f1MenuInputField.onEndEdit.Invoke("carbonPlayers devMode 0");
        f1MenuInputField.onEndEdit.Invoke("carbonPlayers ignoreAutoControls true");
    }

    public void OnPlayerJoined(int playerId, ulong steamId, string name, string regimentTag, bool isBot)
    {
        playerIsBotDictionary[playerId] = isBot;
    }

    public void OnPlayerSpawned(int playerId, int spawnSectionId, FactionCountry playerFaction, PlayerClass playerClass, int uniformId, GameObject playerObject)
    {
        playerFactionDictionary[playerId] = playerFaction;
        playerObjectDictionary[playerId] = playerObject;

        if (runningCommands.Count > 0)
        {
            var runningCommand = runningCommands[0];
            bool isBot;
            if (playerIsBotDictionary.TryGetValue(playerId, out isBot) && isBot)
            {
                runningCommand.requiredToSpawn--;
                if (runningCommand.requiredToSpawn == 0)
                {
                    runningCommands.RemoveAt(0);
                }

                var targetPosition = runningCommand.position + (runningCommand.rightDirection * runningCommand.spawnedCount);
                var hits = Physics.RaycastNonAlloc(targetPosition, Vector3.down, resultHits, 2);
                if (hits > 0)
                {
                    var closestDistance = resultHits[0].distance;
                    var closestPoint = resultHits[0].point;
                    for (int i = 1; i < hits; i++)
                    {
                        var raycastHit = resultHits[i];
                        if (closestDistance < raycastHit.distance)
                        {
                            closestDistance = raycastHit.distance;
                            closestPoint = raycastHit.point;
                        }
                    }

                    targetPosition = closestPoint;
                }

                playerObject.transform.position = targetPosition;
                playerObject.transform.eulerAngles = new Vector3(0, runningCommand.yRotation, 0);

                Debug.LogFormat("YRotation set to {0}", playerObject.transform.eulerAngles);

                runningCommand.spawnedCount++;
            }
        }
    }

    public void OnRoundDetails(int roundId, string serverName, string mapName, FactionCountry attackingFaction, FactionCountry defendingFaction, GameplayMode gameplayMode, GameType gameType)
    {
        this.attackingFaction = attackingFaction;
        this.defendingFaction = defendingFaction;
    }

    public void OnTextMessage(int playerId, TextChatChannel channel, string text)
    {
        if (channel == TextChatChannel.Recruitment)
        {
            var commands = text.Split(' ');
            if (commands.Length > 2 && string.Compare(commands[0], "BettyBot", true) == 0)
            {
                FactionCountry factionCountry;
                GameObject playerObject;
                Vector3 playerPosition;
                Vector3 playerRight;
                Vector3 playerForward;
                float playerYRotation;
                if (playerFactionDictionary.TryGetValue(playerId, out factionCountry) && playerObjectDictionary.TryGetValue(playerId, out playerObject))
                {
                    playerPosition = playerObject.transform.position;
                    playerRight = playerObject.transform.right;
                    playerForward = playerObject.transform.forward;
                    playerYRotation = playerObject.transform.eulerAngles.y;
                }
                else if (playerObjectDictionary.Count > 0)
                {
                    //Pick a random person and assume we want to spawn it on that player
                    var values = playerObjectDictionary.Values;
                    var enumeratorValues = values.GetEnumerator();
                    var randomIndex = Random.Range(0, values.Count);

                    Transform playerTransform = enumeratorValues.Current.transform;
                    while (randomIndex > -1 && enumeratorValues.MoveNext())
                    {
                        randomIndex--;
                        if (randomIndex < 0)
                        {
                            playerTransform = enumeratorValues.Current.transform;
                        }
                    }

                    factionCountry = Random.Range(0, 1) == 0 ? attackingFaction : defendingFaction;
                    playerPosition = playerTransform.position;
                    playerRight = playerTransform.right;
                    playerForward = playerTransform.forward;
                    playerYRotation = playerTransform.eulerAngles.y;
                }
                else
                {
                    //Return and do nothing
                    return;
                }

                int spawnCounter;
                if (string.Compare(commands[1], "MakeLine", true) == 0 && int.TryParse(commands[2], out spawnCounter))
                {
                    var playerClass = PlayerClass.ArmyLineInfantry.ToString();
                    if (commands.Length > 3)
                    {
                        playerClass = commands[3];
                    }

                    for (int i = 0; i < spawnCounter; i++)
                    {
                        var rcCommand = string.Format("carbonPlayers spawnSpecific {0} {1}", factionCountry, playerClass);
                        f1MenuInputField.onEndEdit.Invoke(rcCommand);
                    }

                    runningCommands.Add(new RunningCommand()
                    {
                        requiredToSpawn = spawnCounter,
                        position = playerPosition + (playerForward * 0.5f), //the position will be 0.5m infront of the player so the bots dont spawn on the player
                        rightDirection = playerRight * 0.6f,
                        yRotation = playerYRotation,
                    });

                    Debug.LogFormat("YRotation {0}", playerYRotation);
                }
            }
        }
    }

    #region Not Used
    public void OnUpdateSyncedTime(double time)
    {
    }

    public void OnSyncValueState(int value)
    {
    }

    public void OnUpdateTimeRemaining(float time)
    {
    }

    public void OnUpdateElapsedTime(float time)
    {
    }

    public void OnIsClient(bool client, ulong steamId)
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

    public void OnPlayerStartCarry(int playerId, CarryableObjectType carryableObject)
    {
    }

    public void OnPlayerWeaponSwitch(int playerId, string weapon)
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

    public void OnShipSpawned(int shipId, GameObject shipObject, FactionCountry shipfaction, ShipType shipType, int shipNameId)
    {
    }

    public void OnShotInfo(int playerId, int shotCount, Vector3[][] shotsPointsPositions, float[] trajectileDistances, float[] distanceFromFiringPositions, float[] horizontalDeviationAngles, float[] maxHorizontalDeviationAngles, float[] muzzleVelocities, float[] gravities, float[] damageHitBaseDamages, float[] damageRangeUnitValues, float[] damagePostTraitAndBuffValues, float[] totalDamages, Vector3[] hitPositions, Vector3[] hitDirections, int[] hitPlayerIds, int[] hitDamageableObjectIds, int[] hitShipIds, int[] hitVehicleIds)
    {
    }

    public void OnVehicleHurt(int vehicleId, byte oldHp, byte newHp, EntityHealthChangedReason reason)
    {
    }

    public void OnVehicleSpawned(int vehicleId, FactionCountry vehicleFaction, PlayerClass vehicleClass, GameObject vehicleObject, int ownerPlayerId)
    {
    }

    public void PassConfigVariables(string[] value)
    {
    }
    public void OnAdminPlayerAction(int playerId, int adminId, ServerAdminAction action, string reason)
    {
    }

    public void OnPlayerLeft(int playerId)
    {
    }


    public void OnConsoleCommand(string input, string output, bool success)
    {
    }

    public void OnRCLogin(int playerId, string inputPassword, bool isLoggedIn)
    {
    }

    public void OnRCCommand(int playerId, string input, string output, bool success)
    {
    }
    #endregion
}