using System;

// program name: IGME105 monopoly game
// created by: charisma allen
// purpose: make a monopoly game but w/ gambling
/* modifications: 
 * 09/03/2025 = added header, tested methods
 */

namespace IGME105HW_cda
{
    internal class Utility
    {
        internal static string VerifyString(string input)
        {
            if (string.IsNullOrEmpty(input))
                return "999";
            else return input.Trim();
        }
    }
}
}

