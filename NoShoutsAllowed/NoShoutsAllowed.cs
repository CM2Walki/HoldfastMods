using UnityEngine;
using HoldfastSharedMethods;
using UnityEngine.UI;

public class NoShoutsAllowed : IHoldfastSharedMethods
{
    private InputField f1MenuInputField;

    //By default, i want to deal 10 damage unless the server hosts override it with the mod variables.
    private int damage = 10;
    private string reason = "Oi shush mate!";

    public void IsServer(bool server)
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
    }

    public void OnPlayerShout(int playerId, CharacterVoicePhrase voicePhrase)
    {
        //We should always make sure our code doesn't break the game
        if (f1MenuInputField != null)
        {
            //Debug.Log("Executing input text");
            //Note: We dont need "rc" prefix since we're running this mod on the server directly.
            var rcCommand = string.Format("serverAdmin slap {0} {1} {2}", playerId, damage, reason);
            f1MenuInputField.onEndEdit.Invoke(rcCommand);
        }
    }

    //Wrex: For my mod i want the data variables to be configured in a:
    //<modid>:<variable>:<value> system
    public void PassConfigVariables(string[] value)
    {
        for (int i = 0; i < value.Length; i++)
        {
            var splitData = value[i].Split(':');
            if (splitData.Length != 3)
            {
                continue;
            }

            //so first variable should be the mod id
            if (splitData[0] == "2531841548")
            {
                //the second variable should be the variable type
                if (splitData[1] == "slap damage")
                {
                    //and the third variable should be the variable value
                    if (!int.TryParse(splitData[2], out damage))
                    {
                        Debug.Log("Tried parsing damage but invalid format was found.");
                    }
                }
                //similarly, reason is the variable type
                else if (splitData[1] == "reason")
                {
                    //fill the reason using the variable value
                    reason = splitData[2];
                }
            }
        }
    }

    public void GetSyncedTime(double time)
    {

    }

    public void GetSyncValue(int value)
    {

    }

    public void GetTimeRemaining(float time)
    {

    }

    public void GetTimeSinceStart(float time)
    {

    }

    public void IsClient(bool client, ulong steamId)
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

    public void OnDamageableObjectDamaged(GameObject damageableObject, int oldHp, int newHp)
    {

    }

    public void OnInteractableObjectInteraction(int playerId, int interactableObjectId, GameObject interactableObject, InteractionActivationType interactionActivationType, int nextActivationStateTransitionIndex)
    {

    }

    public void OnEmplacementConstructed(int itemId)
    {
    }

    public void OnEmplacementPlaced(int itemId, GameObject objectBuilt, EmplacementType emplacementType)
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

    public void OnPlayerMeleeStartSecondaryAttack(int playerId)
    {

    }

    public void OnPlayerShoot(int playerId, bool dryShot)
    {
    }

    public void OnPlayerSpawned(int playerId, FactionCountry playerFaction, PlayerClass playerClass, int uniformId, GameObject playerObject, ulong steamId, string name, string regimentTag)
    {
    }

    public void OnPlayerStartCarry(int playerId, CarryableObjectType carryableObject)
    {

    }

    public void OnPlayerWeaponSwitch(int playerId, string weapon)
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

    public void OnScorableAction(int playerId, byte score, ScorableActionType reason)
    {

    }

    public void OnTextMessage(int playerId, TextChatChannel channel, string text)
    {

    }

    public void OnBuffStart(int playerId, BuffType buff)
    {
    }

    public void OnBuffStop(int playerId, BuffType buff)
    {
    }
}
