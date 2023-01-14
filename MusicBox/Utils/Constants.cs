using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Utils;

public static class Constants
{
    public static string OPENAI_API_KEY = "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";

    //spotify 
    public static string CLIENT_ID = "7a0d479c405d475784b3a011c295b57d";
    public static string CLIENT_SECRET = "ec31ee83f24c49ab8a1f947a2578b109";

    public static string WebApiKey_Login = "AIzaSyAiOuFGLUVw-ahyBDief7Rd0bSU0F5JzLk";

    public static double ScreenWidth = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;
    public static double ScreenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
}
