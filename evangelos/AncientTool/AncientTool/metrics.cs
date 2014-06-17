using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AncientTool
{
    class metrics
    {
        /*ΔΗΛΩΣΗ ΙΔΙΩΤΙΚΩΝ ΜΕΤΑΒΛΗΤΩΝ*/
        public byte[,] position = new byte[17, 2]; //Χρησιμοποιείται για να καθορίζει τις θέσεις των φωνηέντων ανά συλλαβή (θεωρούμε πως μετράει τις θέσεις από το 1)
        private byte[,] FtLimit = new byte[5, 2];
        public byte counter;
        private char c1, c2, c3, c4;
        private byte[] FtTrack = new byte[4];
        private byte[] SeTrack = new byte[4];
        private byte[] SeNum = new byte[2];
        private byte[] FtNum = new byte[2];
        private Boolean IsHexameter;

        //Για να μπορώ να χρησιμοποιώ τις συναρτήσεις/μεθόδους από το phon.cs
        private phon phonemicsUtil;

        //Για να μπορώ να χρησιμοποιώ τις συναρτήσεις/μεθόδους από το striman.cs
        private striman strimanUtil;

        public metrics()
        {
            for (int i = 0; i < 17; i++)
            {
                position[i, 0] = 0;
                position[i, 1] = 0;
            }

            for (int i = 0; i < 5; i++)
            {
                FtLimit[i, 0] = 0;
                FtLimit[i, 1] = 0;
            }

            for (int i = 0; i < 4; i++)
            {
                FtTrack[i] = 0;
                SeTrack[i] = 0;
            }

            for (int i = 0; i < 2; i++)
            {
                SeNum[i] = 0;
                FtNum[i] = 0;
            }

            counter = 0;
            IsHexameter = true;

            phonemicsUtil = new phon();
            strimanUtil = new striman();
        }

        /* 1.0 */
        public void DoScansion(ref string verse, ref string scansion, ref int errors)
        {
            counter = 0;
            Syllabify(verse);
            if ((counter >= 12) && (counter <= 17))
            {
                Hexameter(verse, ref scansion);
                Delimit(ref verse, ref scansion);
            }
            else
            {
                scansion = "?";
                errors++;
            }
        }

        /* 2.0 */
        public void Syllabify(string verse) //Μέσω αυτής της μεθόδου γεμίζει ο πίνακας "position" και παράλληλα ενημερώνεται ο μετρητής "counter"
        {
            byte i = 1;
            
            while (i <= (byte)(verse.Length)) 
            {
                if (counter.Equals(18))
                    break;
                //Παίρνει τον πρώτο χαρακτήρα της συλλαβής
                c1 = (char) verse.Substring(i - 1, 1)[0]; //Η substring θεωρεί πως λαμβάνει ως είσοδο κάτι που μετράει από το 0 την πρώτη θέση
                if (phonemicsUtil.IsVowel(c1)) //Αν αυτός είναι φωνήεν
                {
                    counter++;
                    
                    if (i == (byte)(verse.Length)) //Οριακή συνθήκη όπου έχω φτάσει στο τελευταίο γράμμα της φράσης και αυτό είναι φωνήεν
                        c2 = ' ';  //Θέλω κάτι που να μην το βρει ως φωνήεν ώστε να εντοπιστεί κι αυτή η συλλαβή στην οριακή περίπτωση
                    else
                        c2 = (char) verse.Substring(i, 1)[0]; //Παίρνει τον δεύτερο χαρακτήρα της συλλαβής

                    if (phonemicsUtil.IsVowel(c2)) //Αν αυτός είναι φωνήεν
                    {
                        if (phonemicsUtil.Diphthong(c1, c2)) //Ελέγχει αν πρόκειται για δίφθογγο
                        {
                            position[counter - 1, 0] = i;
                            position[counter - 1, 1] = (byte)(i + 1);
                            i++;
                        }
                        else //Αν δεν έχουμε δίφθογγο, το πρώτο και το δεύτερο φωνήεν της συλλαβής βρίσκονται στην ίδια θέση
                        {
                            position[counter - 1, 0] = i; 
                            position[counter - 1, 1] = i;
                        }
                    }
                    else //Αν δεν είναι φωνήεν, τότε το πρώτο και το δεύτερο φωνήεν της συλλαβής βρίσκονται στην ίδια θέση
                    {
                        position[counter - 1, 0] = i;
                        position[counter - 1, 1] = i;
                    }
                }

                i++;
            }
        }

        /* 3.0 */
        private void Hexameter(string verse, ref string scansion)
        {
            byte i;
            scansion = "_";

            for (i = 2; i <= verse.Length; i++) //Γεμίζει όλο το "scansion" με "_"
                scansion = scansion + "_";

            strimanUtil.DoReplace("-", ref scansion, position[0, 1]); //Ενημερώνεται το "scansion". Στη θέση που υποδεικνύει ο "position" τοποθετείται "-"

            for (i = (byte)(counter - 1); i <= counter; i++) //Τοποθετείται στο "scansion" το σύμβολο "-" στην θέση του 2ου φωνήεντος της τελευταίας συλλαβής του στίχου και στην προηγούμενή του 
                strimanUtil.DoReplace("-", ref scansion, position[i - 1, 1]);

            switch (counter)
            {
                case 12:
                    for (i = 2; i <= 10; i++)
                        strimanUtil.DoReplace("-", ref scansion, position[i - 1, 1]);

                    MarkFeet(1, 5, 2, 0, 1);
                    break;
                case 13:
                    Resolve13(verse, ref scansion);
                    break;
                case 14:
                    Resolve14(verse, ref scansion);
                    break;
                case 15:
                    Resolve15(verse, ref scansion);
                    break;
                case 16:
                    Resolve16(verse, ref scansion);
                    break;
                case 17:
                    for (i = 2; i <= 15; i++)
                    {
                        if ((i % (byte)3) == 1)
                            strimanUtil.DoReplace("-", ref scansion, position[i - 1, 1]); //Στις συλλαβές 4,7,10 και 13 στην θέση του 2ου φωνήεντος θα βάλει "-"
                        else
                            strimanUtil.DoReplace("U", ref scansion, position[i - 1, 1]); //Στις υπόλοιπες περιπτώσεις, στην θέση του 2ου φωνήεντος μπαίνει "U"
                    }

                    MarkFeet(1, 5, 3, 0, 1);
                    break;
            }
        }

        /* 4.0 */
        private void Delimit(ref string verse, ref string scansion)
        {
            byte gap, i = 5;

            while (i >= 1)
            {
                gap = (byte)(FtLimit[i - 1, 1] - FtLimit[i - 1, 0]);

                if (gap.Equals(1))
                {
                    strimanUtil.Insert("-", ref verse, FtLimit[i - 1, 1]);
                    strimanUtil.Insert("|", ref scansion, FtLimit[i - 1, 1]);
                }
                else
                    strimanUtil.DoReplace("|", ref scansion, (byte)(FtLimit[i - 1, 0] + 1));

                i--;
            }
        }

        /* 5.0 */
        private void MarkFeet(byte lower, byte upper, byte factor, int value1, int value2)
        {
            byte i;

            for (i = lower; i <= upper; i++)
            {
                FtLimit[i - 1, 0] = position[((i * factor) + value1) - 1, 1];
                FtLimit[i - 1, 1] = position[((i * factor) + value2) - 1, 1];
            }
        }

        /* 6.0 */
        private void Resolve13(string verse, ref string scansion)
        {
            FtTrack[0] = 5; SeTrack[0] = 9;
            FtTrack[1] = 3; SeTrack[1] = 5;
            FtTrack[2] = 4; SeTrack[2] = 7;
            FtTrack[3] = 1; SeTrack[3] = 1;

            SeekFoot(verse, ref scansion, ref FtNum[0], ref SeNum[0], 4);

            if (!IsHexameter)
            {
                FtNum[0] = 2; SeNum[0] = 3;
            }

            strimanUtil.DoReplace("U", ref scansion, position[(byte)((SeNum[0] + 1) - 1), 1]);
            strimanUtil.DoReplace("U", ref scansion, position[(byte)((SeNum[0] + 2) - 1), 1]);
            MarkSpondee(ref scansion, 11, false);
            MarkFeet(1, (byte)(FtNum[0] - 1), 2, 0, 1);
            MarkFeet(FtNum[0], 5, 2, 1, 2);
        }

        /* 7.0 */
        private void Resolve14(string verse, ref string scansion)
        {
            FtTrack[0] = 5; SeTrack[0] = 10;
            FtTrack[1] = 4; SeTrack[1] = 8;
            FtTrack[2] = 3; SeTrack[2] = 6;

            SeekFoot(verse, ref scansion, ref FtNum[1], ref SeNum[1], 3);

            if (!IsHexameter)
            {
                FtNum[1] = 2; SeNum[1] = 4;
            }
            else if (SeNum[1].Equals(10))
            {
                FtTrack[0] = 4; SeTrack[0] = 7;
                FtTrack[1] = 3; SeTrack[1] = 5;
                FtTrack[2] = 2; SeTrack[2] = 3;
                SeekFoot(verse, ref scansion, ref FtNum[0], ref SeNum[0], 3);
            }
            else if (SeNum[1].Equals(8))
            {
                FtTrack[0] = 3; SeTrack[0] = 5;
                FtTrack[1] = 2; SeTrack[1] = 3;
                SeekFoot(verse, ref scansion, ref FtNum[0], ref SeNum[0], 2);
            }
            else
            {
                FtTrack[0] = 2; SeTrack[0] = 3;
                SeekFoot(verse, ref scansion, ref FtNum[0], ref SeNum[0], 1);
            }

            if (!IsHexameter)
            {
                FtNum[0] = 1; SeNum[0] = 1;
            }

            strimanUtil.DoReplace("U", ref scansion, position[(SeNum[0] + 1) - 1, 1]);
            strimanUtil.DoReplace("U", ref scansion, position[(SeNum[0] + 2) - 1, 1]);
            strimanUtil.DoReplace("U", ref scansion, position[(SeNum[1] + 1) - 1, 1]);
            strimanUtil.DoReplace("U", ref scansion, position[(SeNum[1] + 2) - 1, 1]);
            MarkSpondee(ref scansion, SeNum[1], true);
            MarkFeet(1, (byte)(FtNum[0] - 1), 2, 0, 1);
            MarkFeet(FtNum[0], (byte)(FtNum[1] - 1), 2, 1, 2);
            MarkFeet(FtNum[1], 5, 2, 2, 3);
        }

        /* 8.0 */
        private void Resolve15(string verse, ref string scansion)
        {
            FtTrack[0] = 1; SeTrack[0] = 1;
            FtTrack[1] = 2; SeTrack[1] = 4;
            FtTrack[2] = 3; SeTrack[2] = 7;

            SeekFoot(verse, ref scansion, ref FtNum[0], ref SeNum[0], 3);

            if (!IsHexameter)
            {
                FtNum[0] = 4; SeNum[0] = 10;
            }
            else if (SeNum[0].Equals(1))
            {
                FtTrack[0] = 2; SeTrack[0] = 3;
                FtTrack[1] = 3; SeTrack[1] = 6;
                FtTrack[2] = 4; SeTrack[2] = 9;
                SeekFoot(verse, ref scansion, ref FtNum[1], ref SeNum[1], 3);
            }
            else if (SeNum[0].Equals(4))
            {
                FtTrack[0] = 3; SeTrack[0] = 6;
                FtTrack[1] = 4; SeTrack[1] = 9;
                SeekFoot(verse, ref scansion, ref FtNum[1], ref SeNum[1], 2);
            }
            else
            {
                FtTrack[0] = 4; SeTrack[0] = 9;
                SeekFoot(verse, ref scansion, ref FtNum[1], ref SeNum[1], 1);
            }

            if (!IsHexameter)
            {
                FtNum[1] = 5; SeNum[1] = 12;
            }

            strimanUtil.DoReplace("-", ref scansion, position[SeNum[0] - 1, 1]);
            strimanUtil.DoReplace("-", ref scansion, position[(SeNum[0] + 1) - 1, 1]);
            strimanUtil.DoReplace("-", ref scansion, position[SeNum[1] - 1, 1]);
            strimanUtil.DoReplace("-", ref scansion, position[(SeNum[1] + 1) - 1, 1]);
            MarkDactyl(ref scansion, (byte)(SeNum[1] - 1), true);
            MarkFeet(1, (byte)(FtNum[0] - 1), 3, 0, 1);
            MarkFeet(FtNum[0], (byte)(FtNum[1] - 1), 3, -1, 0);
            MarkFeet(FtNum[1], 5, 3, -2, -1);
        }

        /* 9.0 */
        private void Resolve16(string verse, ref string scansion)
        {
            FtTrack[0] = 1; SeTrack[0] = 1;
            FtTrack[1] = 2; SeTrack[1] = 4;
            FtTrack[2] = 3; SeTrack[2] = 7;
            FtTrack[3] = 4; SeTrack[3] = 10;

            SeekFoot(verse, ref scansion, ref FtNum[0], ref SeNum[0], 4);

            if (!IsHexameter)
            {
                FtNum[0] = 5; SeNum[0] = 13;
            }

            strimanUtil.DoReplace("-", ref scansion, position[SeNum[0] - 1, 1]);
            strimanUtil.DoReplace("-", ref scansion, position[(SeNum[0] + 1) - 1, 1]);
            MarkDactyl(ref scansion, 14, false);
            MarkFeet(1, (byte)(FtNum[0] - 1), 3, 0, 1);
            MarkFeet(FtNum[0], 5, 3, -1, 0);
        }

        /* 10.0 */
        private void SeekFoot(string verse, ref string scansion, ref byte FtSpot, ref byte SeSpot, byte max)
        {
            byte i;
            bool value = false;
            IsHexameter = false;

            switch (counter)
            {
                case 13: // Αναζήτηση Δακτυλίου
                    value = true;
                    break;
                case 14: // Αναζήτηση Δακτυλίου
                    value = true;
                    break;
                case 15: // Αναζήτηση Σπονδής
                    value = false;
                    break;
                case 16: // Αναζήτηση Σπονδής
                    value = false;
                    break;
            }

            for (i = 1; i <= max; i++)
            {
                SeSpot = SeTrack[i - 1];

                MarkQuantity(verse, ref scansion, SeSpot);
                c1 = (char) scansion.Substring((position[(SeSpot) - 1, 1] - 1), 1)[0];
                c2 = (char) scansion.Substring((position[(SeSpot + 1) - 1, 1] - 1), 1)[0];
                c3 = (char) scansion.Substring((position[(SeSpot + 2) - 1, 1] - 1), 1)[0];
                c4 = (char) scansion.Substring((position[(SeSpot + 3) - 1, 1] - 1), 1)[0];

                if (IsDactyl(c1, c2, c3, c4) == value)
                {
                    FtSpot = FtTrack[i - 1];
                    IsHexameter = true;
                    break;
                }
            }
        }

        /* 11.0 */
        private void MarkSpondee(ref string scansion, byte final, bool more)
        {
            byte i;

            for (i = 2; i <= SeNum[0]; i++)
                strimanUtil.DoReplace("-", ref scansion, position[i - 1, 1]);

            for (i = (byte)(SeNum[0] + 3); i <= final; i++)
                strimanUtil.DoReplace("-", ref scansion, position[i - 1, 1]);

            if (more)
                for (i = (byte)(final + 3); i <= 12; i++)
                    strimanUtil.DoReplace("-", ref scansion, position[i - 1, 1]);
        }

        /* 12.0 */
        private void MarkDactyl(ref string scansion, byte final, bool more)
        {
            byte i;

            for (i = 2; i <= (byte)(SeNum[0] - 1); i++)
            {
                if ((i % (byte)3) == 1)
                    strimanUtil.DoReplace("-", ref scansion, position[i - 1, 1]);
                else
                    strimanUtil.DoReplace("U", ref scansion, position[i - 1, 1]);
            }

            for (i = (byte)(SeNum[0] + 2); i <= final; i++)
            {
                if ((i % (byte)3) == 0)
                    strimanUtil.DoReplace("-", ref scansion, position[i - 1, 1]);
                else
                    strimanUtil.DoReplace("U", ref scansion, position[i - 1, 1]);
            }

            if (more)
            {
                for (i = (byte)(final + 3); i <= 13; i++)
                {
                    if ((i % (byte)3) == 2)
                        strimanUtil.DoReplace("-", ref scansion, position[i - 1, 1]);
                    else
                        strimanUtil.DoReplace("U", ref scansion, position[i - 1, 1]);
                }
            }
        }

        /* 13 */
        private void MarkQuantity(string verse, ref string scansion, byte start)
        {
            string target;
            byte i, index;

            for (i = start; i <= (byte)(start + 3); i++)
            {
                target = scansion.Substring((position[i - 1, 1] - 1), 1); //Εδω αφαιρούμε -1 γιατί η substring μετράει το start place από το 0 σε αντίθεση με την "Mid$"
                index = (byte)(position[i - 1, 0] - 1); //Και πάλι έχουμε αφαίρεση κατά 1

                if (target.Equals("_"))
                {
                    c1 = (char) verse.Substring(index, 1)[0];
                    c2 = (char) verse.Substring(index + 1, 1)[0];
                    c3 = (char) verse.Substring(index + 2, 1)[0];
                    c4 = (char) verse.Substring(index + 3, 1)[0];
                    strimanUtil.DoReplace(Quantity(c1, c2, c3, c4), ref scansion, position[i - 1, 1]); //Εδώ δεν αφαιρούμε κατά 1. Αυτό γίνεται εντός της DoReplace
                }
            }
        }

        /* 14 */
        public bool IsDactyl(char first, char second, char third, char fourth)
        {
            if (first.CompareTo('U') == 0)
                return false;
            else if (second.CompareTo('-') == 0)
                return false;
            else if (third.CompareTo('-') == 0)
                return false;
            else if (fourth.CompareTo('U') == 0)
                return false;
            else
                return true;
        }

        /* 15 */ 
        public string Quantity(char first, char second, char third, char fourth)
        {
            string quantity = null;

            if (phonemicsUtil.Diphthong(first, second))
            {
                if (!phonemicsUtil.IsBrake(third))
                    quantity = "-";
                else if (phonemicsUtil.IsConsonant(fourth))
                    quantity = "-";
            }
            else if (phonemicsUtil.IsShort(first))
            {
                if (phonemicsUtil.IsDouble(second))
                    quantity = "-";
                else if (IsLiquidPlus(second) && phonemicsUtil.IsConsonant(third))
                    quantity = "-";
                else if (phonemicsUtil.IsConsonant(second))
                {
                    if (!phonemicsUtil.IsDouble(second) && phonemicsUtil.IsVowel(third))
                        quantity = "U";
                    else if (phonemicsUtil.IsBrake(third) && phonemicsUtil.IsConsonant(fourth))
                        quantity = "-";
                    else if (second == third)
                        quantity = "-";
                }
                else if (phonemicsUtil.IsVowel(second) && !IsChar1(second))
                    quantity = "U";
                else if (IsChar2(second))
                    quantity = "U";
                else if (phonemicsUtil.IsBrake(second))
                {
                    if (phonemicsUtil.IsConsonant(third) && phonemicsUtil.IsConsonant(fourth))
                        quantity = "-";
                    else if (phonemicsUtil.IsVowel(third))
                        quantity = "U";
                }
            }
            else if (phonemicsUtil.IsLong(first))
            {
                if (!phonemicsUtil.IsBrake(second))
                    quantity = "-";
                else if (phonemicsUtil.IsConsonant(third))
                    quantity = "-";
            }
            else if (phonemicsUtil.IsAnceps(first))
            {
                if (phonemicsUtil.IsDouble(second))
                    quantity = "-";
                else if (phonemicsUtil.IsConsonant(second))
                {
                    if (phonemicsUtil.IsConsonant(third))
                        quantity = "-";
                    else if (phonemicsUtil.IsBrake(third) && phonemicsUtil.IsConsonant(fourth))
                        quantity = "-";
                }
            }
           
            if (quantity == null)
                quantity = "x";

            return quantity;
        }

        /* 16 */
        private bool IsLiquidPlus(char chrM)
        {
            switch (chrM)
            {
                case 'λ': return true;
                case 'μ': return true;
                case 'ν': return true;
                case 'ρ': return true;
                case 'σ': return true;
                case 'ς': return true;
                case 'Λ': return true;
                case 'Μ': return true;
                case 'Ν': return true;
                case 'Ρ': return true;
                case 'Σ': return true;
                default: return false;
            }
        }

        /* 17 */
        private bool IsChar1(char chrM)
        {
            switch (chrM)
            {
                case 'ι': return true;
                case 'υ': return true;
                case 'ί': return true;
                case 'ύ': return true;
                case 'Ι': return true;
                case 'Υ': return true;
                default: return false;
            }
        }

        /* 18 */
        private bool IsChar2(char chrM)
        {
            switch (chrM)
            {
                case '΄': return true;
                case 'ϊ': return true;
                case 'ϋ': return true;
                case 'ΐ': return true;
                case 'ΰ': return true;
                case 'Ϊ': return true;
                case 'Ϋ': return true;
                default: return false;
            }
        }
    }
}
