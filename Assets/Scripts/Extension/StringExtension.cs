
using Assets.Scripts.CodeResource;
using Assets.Scripts.StateMachine;
using UnityEngine;

namespace Assets.Scripts.Extension
{
    static class StringExtension
    {
        public static string ToTitleCase(this string str)
        {
            string result = "";
            foreach (string st in str.Split(' '))
            {
                result = string.Concat(result," ",st[0].ToString().ToUpper() + st.Substring(1).ToLower());
            }
            return result.Trim();
        }

    }
}
