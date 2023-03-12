using BepInEx;
using System.Runtime.CompilerServices;
using System.Security.Permissions;

// Allows access to private members
#pragma warning disable CS0618
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
#pragma warning restore CS0618

namespace ScugAnims;

[BepInPlugin("com.dual.more-slugcat-animations", "MoreScugAnims", "1.0.0")]
sealed class Plugin : BaseUnityPlugin
{
    sealed class PlayerData
    {
        public int cough;
    }

    readonly ConditionalWeakTable<Player, PlayerData> cwt = new();

    PlayerData Data(Player p) => cwt.GetValue(p, _ => new());

    public void OnEnable()
    {
        // Add hooks here
        On.Player.Update += Player_Update;
    }

    private void Player_Update(On.Player.orig_Update orig, Player self, bool eu)
    {
        orig(self, eu);
    }
}
