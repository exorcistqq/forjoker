using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using Settings = AddonTemplate.Config.Modes.JungleClear;

namespace AddonTemplate.Modes
{
    public sealed class JungleClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear);
        }

        public override void Execute()
        {
            if (Player.Instance.ManaPercent < Settings.ManaUsage)
                return;
            var jungleminions =
                EntityManager.MinionsAndMonsters.GetJungleMonsters().Where(m => m.IsValidTarget(W.Range)).ToArray();
            if (jungleminions.Length == 0)
                return;
            var pos = EntityManager.MinionsAndMonsters.GetLineFarmLocation(jungleminions, W.Width, (int) W.Range);
            if (pos.HitNumber >= Settings.HitNumberW && Settings.UseW && W.IsReady())
            {
                W.Cast(pos.CastPosition);
            }
        }
    }
}