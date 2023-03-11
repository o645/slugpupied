using BepInEx;
using On;
using System.Security;
using System.Security.Permissions;
using UnityEngine;
#pragma warning disable CS0618 // Type or member is obsolete
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[module: UnverifiableCode]
#pragma warning restore CS0618 // Type or member is obsolete

namespace slugpupied
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            On.Player.GetInitialSlugcatClass += slugpupforce;
            On.PlayerState.ctor += PlayerState_ctor;
        }

        private void PlayerState_ctor(On.PlayerState.orig_ctor orig, PlayerState self, AbstractCreature crit, int playerNumber, SlugcatStats.Name slugcatCharacter, bool isGhost)
        {
            orig(self, crit, playerNumber, MoreSlugcats.MoreSlugcatsEnums.SlugcatStatsName.Slugpup, isGhost);
            Logger.LogInfo("returned class to slugpup");
        }

        private void slugpupforce(On.Player.orig_GetInitialSlugcatClass orig, Player self)
        {
                self.SlugCatClass = MoreSlugcats.MoreSlugcatsEnums.SlugcatStatsName.Slugpup;
                Logger.LogInfo("set class to slugpup");
                return;
        }
    }
}
