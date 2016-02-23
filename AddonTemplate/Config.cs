using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using Settings = AddonTemplate.Config.Modes;

// ReSharper disable InconsistentNaming
// ReSharper disable MemberHidesStaticFromOuterClass

namespace AddonTemplate
{
    public static class Config
    {
        private const string MenuName = "Test Talon Menu";
        private static readonly Menu Menu;

        static Config()
        {
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("Welcome to TestTalon");
            Menu.AddLabel("xxxxxx");
            Menu.AddLabel("xxxxxx");
            Modes.Initialize();
        }

        public static void Initialize()
        {
        }

        public static class Modes
        {
            private static readonly Menu Menu;

            static Modes()
            {
                Menu = Config.Menu.AddSubMenu("Modes");
                Menu.AddSeparator();
                Combo.Initialize();
                Menu.AddSeparator();
                LaneClear.Initialize();
                Harass.Initialize();
                JungleClear.Initialize();
            }

            public static void Initialize()
            {
            }

            public static class Combo
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly CheckBox _useR;

                static Combo()
                {
                    Menu.AddGroupLabel("Combo");
                    _useQ = Menu.Add("comboUseQ", new CheckBox("Use Q"));
                    _useW = Menu.Add("comboUseW", new CheckBox("Use W"));
                    _useE = Menu.Add("comboUseE", new CheckBox("Use E"));
                    _useR = Menu.Add("comboUseR", new CheckBox("Use R"));
                }

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }

                public static bool UseR
                {
                    get { return _useR.CurrentValue; }
                }

                public static void Initialize()
                {
                }
            }

            public static class Harass
            {
                static Harass()
                {
                    Menu.AddGroupLabel("Harass");
                    Menu.Add("harassUseW", new CheckBox("Use W"));
                    Menu.Add("harassMana", new Slider("Maximum mana usage in percent ({0}%)", 40));
                }

                public static bool UseW
                {
                    get { return Menu["harassUseW"].Cast<CheckBox>().CurrentValue; }
                }

                public static int ManaUsage
                {
                    get { return Menu["harassMana"].Cast<Slider>().CurrentValue; }
                }

                public static void Initialize()
                {
                }
            }

            public static class LaneClear
            {
                public const string GroupName = "LaneClear";

                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;

                private static readonly Slider _hitNumQ;
                private static readonly Slider _hitNumW;
                private static readonly Slider _mana;

                static LaneClear()
                {
                    Menu.AddGroupLabel(GroupName);
                    _useW = Menu.Add("laneUseW", new CheckBox("Use W"));

                    Menu.AddLabel("Advanced features:");
                    _hitNumW = Menu.Add("laneHitW", new Slider("How many minions it should hit", 3, 1, 10));
                    _mana = Menu.Add("laneMana", new Slider("Doesnt use if mana is lower than this (%)", 30));
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static int HitNumberW
                {
                    get { return _hitNumW.CurrentValue; }
                }

                public static int ManaUsage
                {
                    get { return _mana.CurrentValue; }
                }

                public static void Initialize()
                {
                }
            }

            public static class JungleClear
            {
                public const string GroupName = "JungleClear";

                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;

                private static readonly Slider _hitNumQ;
                private static readonly Slider _hitNumW;
                private static readonly Slider _mana;

                static JungleClear()
                {
                    Menu.AddGroupLabel(GroupName);
                    _useW = Menu.Add("jungleUseW", new CheckBox("Use W"));

                    Menu.AddLabel("Advanced features:");
                    _hitNumW = Menu.Add("jungleHitW", new Slider("How many monster should W hit", 3, 1, 10));
                    _mana = Menu.Add("jungleMana", new Slider("Doesnt use when mana percent is lower than this (%)", 30));
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static int HitNumberW
                {
                    get { return _hitNumW.CurrentValue; }
                }

                public static int ManaUsage
                {
                    get { return _mana.CurrentValue; }
                }

                public static void Initialize()
                {
                }
            }
        }
    }
}