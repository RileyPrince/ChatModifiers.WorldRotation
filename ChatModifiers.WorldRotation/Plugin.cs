using HarmonyLib;
using IPA;
using IPALogger = IPA.Logging.Logger;

namespace ChatModifiers.WorldRotation
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static IPALogger Log { get; private set; }
        private Harmony harmony;

        [Init]
        public Plugin(IPALogger logger)
        {
            Log = logger;
            harmony = new Harmony("Riley.ChatModifiers.WorldRotation");
        }

        [OnEnable]
        public void OnEnable()
        {
            API.RegistrationManager.RegisterModifier(Utilities.Modifier.modifier);
            harmony.PatchAll(System.Reflection.Assembly.GetExecutingAssembly());
        }
    }
}
