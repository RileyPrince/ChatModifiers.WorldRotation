using ChatModifiers.WorldRotation.Utilities;
using HarmonyLib;

namespace ChatModifiers.WorldRotation.Patches
{
    internal class RotationPatches // Incomplete
    {
        internal static RotationDirection rotationDirection;
        private static float rotation;

        [HarmonyPrefix]
        [HarmonyPatch(typeof(EnvironmentSpawnRotation), nameof(EnvironmentSpawnRotation.LateUpdate))]
        public static void Prefix(ref float ____targetRotation)
        {
            switch (rotationDirection)
            {
                case RotationDirection.LEFT:
                    ____targetRotation -= 5f;
                    break;
                case RotationDirection.RIGHT:
                    ____targetRotation += 5f;
                    break;
                case RotationDirection.START:
                    if (____targetRotation == 0)
                        return;
                    else if (____targetRotation > 180)
                        ____targetRotation -= 5f;
                    else
                        ____targetRotation += 5f;
                    break;
                case RotationDirection.STOP:
                    break;
            }
            if (____targetRotation > 360 || ____targetRotation < -360)
                ____targetRotation = 0;
        }
    }
}
