using EloBuddy;
using EloBuddy.SDK;
using Settings = AddonTemplate.Config.Modes.Harass;

namespace AddonTemplate.Modes
{
    public sealed class Harass : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass);
        }

        public override void Execute()
        {
            if (Player.Instance.ManaPercent < Settings.ManaUsage)
                return;
            var harassdusman = TargetSelector.GetTarget(W.Range, DamageType.Physical);
            if (harassdusman != null)
            {
                if (Settings.UseW && W.IsReady() && harassdusman.IsValidTarget(W.Range))
                {
                    W.Cast(harassdusman);
                }
            }
        }
    }
}