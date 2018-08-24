
using Assets.Scripts.CodeResource;
using Assets.Scripts.StateMachine;
using UnityEngine;

namespace Assets.Scripts.Extension
{
    static class TextAssetExtension
    {
        public static string ToValidJson(this TextAsset text)
        {
            return string.Concat("{\"value\":",text.text,"}");
        }
        public static string ToValidJson(this string text)
        {
            return string.Concat("{\"value\":", text, "}");
        }
    }
}
