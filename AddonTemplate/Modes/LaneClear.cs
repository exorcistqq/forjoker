using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using Settings = AddonTemplate.Config.Modes.LaneClear;

namespace AddonTemplate.Modes
{
    public sealed class LaneClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear);
        }

        public override void Execute()
        {
            if (Player.Instance.ManaPercent < Settings.ManaUsage)
                return;
            var minions =
                EntityManager.MinionsAndMonsters.GetLaneMinions().Where(m => m.IsValidTarget(W.Range)).ToArray();
            if (minions.Length == 0)
                return;
            var pos = EntityManager.MinionsAndMonsters.GetLineFarmLocation(minions, W.Width, (int) W.Range);
            if (pos.HitNumber >= Settings.HitNumberW && Settings.UseW && W.IsReady())
            {
                W.Cast(pos.CastPosition);
            }
        }

        internal static void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}