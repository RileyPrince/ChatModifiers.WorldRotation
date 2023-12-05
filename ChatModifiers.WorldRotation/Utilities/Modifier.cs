using ChatModifiers.API;
using CatCore.Models.Twitch.IRC;
using ChatModifiers.WorldRotation.Patches;

namespace ChatModifiers.WorldRotation.Utilities
{
    internal class Modifier
    {
        internal static CustomModifier modifier = new CustomModifier("World Rotation", "rotate", Rotate);

        private static void Rotate(TwitchMessage message, string chatMessage)
        {
            string[] splitChatMessage = chatMessage.Split(' ');

            switch (splitChatMessage[1].ToLower())
            {
                case "left":
                    RotationPatches.rotationDirection = RotationDirection.LEFT;
                    Plugin.Log.Info("Rotation direction set to left");
                    break;
                case "right":
                    RotationPatches.rotationDirection = RotationDirection.RIGHT;
                    Plugin.Log.Info("Rotation direction set to right!");
                    break;
                case "start":
                    RotationPatches.rotationDirection = RotationDirection.START;
                    Plugin.Log.Info("Rotation direction set to start!");
                    break;
                case "stop":
                    RotationPatches.rotationDirection = RotationDirection.STOP;
                    Plugin.Log.Info("Rotation direction set to stop!");
                    break;
            }
        }   
    }
}
