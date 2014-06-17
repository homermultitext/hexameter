using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AncientTool
{
    class striman 
    {
        //Το position που έρχεται ως είσοδος είναι βασισμένο στο ότι τσεκάρουμε τη θέση από το 1
        //Αν θεωρήσουμε πως αυτό τελικά θα είναι από το 0, τότε απλά αφαιρούμε σε όλα 1
        public void Insert(String target, ref String line, Byte place)
        {
            String leftPart = line.Substring(0, place - 1);
            String rightPart = line.Substring(place - 1); //Από τη θέση place μέχρι τέλους
            line = leftPart + target + rightPart;
        }

        public void DoReplace(String target, ref String line, Byte place)
        {
            String leftPart = line.Substring(0, place - 1);
            String rightPart = line.Substring((place - 1) + target.Length); //Από τη θέση "place + το length της target" μέχρι τέλους
            line = leftPart + target + rightPart;
        }
    }
}
