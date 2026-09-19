using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Joguinho.Scripts.Input
{
    public static class MouseInput
    {
        public static float windowWidthConversion;
        public static float windowHeightConversion;

        private static float mouseOffSetWidth;
        private static float mouseOffSetHeight;

        private static int cameraOffsetX;
        private static int cameraOffsetY;

        static MouseState mousePrev = new MouseState();
        static MouseState mouseCur;

        static float posX;
        static float posY;

        public static void UpdateMouse()
        {
            mouseCur = Mouse.GetState();
            mousePrev = mouseCur;

            UpdatePosition();
        }

        public static Vector2 GetMousePosition()
        {
            return new Vector2(posX, posY);
        }

        public static Vector2 GetMouseMapPosition()
        {
            return new Vector2(posX + GameManager.GMInstance.world.camera.transform.position.X, posY + GameManager.GMInstance.world.camera.transform.position.Y);
        }

        private static void UpdatePosition()
        {
            posX = ((mouseCur.X - mouseOffSetWidth) / windowWidthConversion) - cameraOffsetX;
            posY = ((mouseCur.Y - mouseOffSetHeight) / windowHeightConversion) - cameraOffsetY;
            //Console.WriteLine(posX);
        }

        public static void ConvertWindowWidth(float windowWidth, int newMouseOffSetWidth, int renderWidth, int newCameraOffsetX)
        {
            windowWidthConversion = (windowWidth - renderWidth) / renderWidth;
            mouseOffSetWidth = newMouseOffSetWidth;
            cameraOffsetX = newCameraOffsetX;
        }

        public static void ConvertWindowHeight(float windowHeight, int newMouseOffsetHeight, int renderHeight, int newCameraOffsetY)
        {
            windowHeightConversion = (windowHeight) / renderHeight;
            mouseOffSetHeight = newMouseOffsetHeight;
            cameraOffsetY = newCameraOffsetY;
        }
    }
}
