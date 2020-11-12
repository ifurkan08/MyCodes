using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class StringEditor
    {
        private bool DoesStringOnlyContainCharset(string controllingString, string charset)
        {
            for (int i = 0; i < controllingString.Length; i++)
            {
                bool control = false;
                for (int j = 0; j < charset.Length; j++)
                {
                    if (controllingString[i] == charset[j])
                    {
                        control = true;
                        break;
                    }
                }
                if (!control)
                {
                    return false;
                }
            }



            return true;
        }

        public bool DoesStringOnlyContainASCII(string controllingString)
        {
            return DoesStringOnlyContainCharset(controllingString, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789");
        }
        public bool DoestStringOnlyNumber(string controllingString)
        {
            return DoesStringOnlyContainCharset(controllingString, "0123456789");
        }

        public string SetZeroFromStart(string str,int length)
        {
            if (str.Length < length)
            {
                int a = str.Length;
                for (int i = 0; i < length - a; i++)
                    str = "0" + str;


            }
            return str;
        }
    }
}
