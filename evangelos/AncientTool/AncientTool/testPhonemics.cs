using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AncientTool
{
    class testPhonemics
    {
        private phon checkMethods;

        public testPhonemics()
        {
            checkMethods = new phon();
        }

        public void checkSingle()
        {
            try
            {
                /*ΑΝΟΙΓΜΑ ΑΡΧΕΙΟΥ ΤΟ ΟΠΟΙΟ ΒΡΙΣΚΕΤΑΙ ΣΤΟ ΣΧΕΤΙΚΟ ΜΟΝΟΠΑΤΙ ΤΟΥ project*/
                using (StreamReader inputFile = new StreamReader("input.txt"))  /*Το using στο τέλος κλείνει το stream*/
                {
                    Console.WriteLine("Άνοιγμα και έλεγχος αρχείου \"input.txt\"...");

                    /*Εφόσον όλα πήγαν ΟΚ με το άνοιγμα του input file θα δημιουργήσουμε το αρχείο των αποτελεσμάτων*/
                    /*ΑΝΟΙΓΜΑ ΑΡΧΕΙΟΥ ΑΠΟΤΕΛΕΣΜΑΤΩΝ*/
                    using (StreamWriter outputFile = new StreamWriter("output.txt"))
                    {
                        //phon checkMethods = new phon();

                        /*ΔΙΑΒΑΣΜΑ ΓΡΑΜΜΗ-ΓΡΑΜΜΗ ΤΟΥ ΑΡΧΕΙΟΥ ΜΕΧΡΙ ΤΟ EOF*/
                        string line = null;
                        string templine = null;

                        while ((line = inputFile.ReadLine()) != null)
                        {
                            /*πέρασμα αυτού του χαραχτήρα στο αρχείο*/
                            outputFile.WriteLine(line);

                            /* έλεγχος της τιμής του χαρακτήρα για κάθε διαθέσιμη μέθοδο και αντίστοιχη εκτύπωση στο file των αποτελεσμάτων*/
                            Boolean isVowel = checkMethods.IsVowel(line[0]);
                            Boolean isBrake = checkMethods.IsBrake(line[0]);
                            Boolean isConsonant = checkMethods.IsConsonant(line[0]);
                            Boolean isLong = checkMethods.IsLong(line[0]);
                            Boolean isShort = checkMethods.IsShort(line[0]);
                            Boolean isAncepts = checkMethods.IsAnceps(line[0]);
                            Boolean isDouble = checkMethods.IsDouble(line[0]);

                            templine = "IsVowel: " + isVowel + "  IsBrake: " + isBrake + "  IsConsonant: " + isConsonant + "  IsLong: " + isLong +
                                        "  IsShort: " + isShort + "  IsAncepts: " + isAncepts + "  IsDouble: " + isDouble;

                            /*πέρασμα των αποτελεσμάτων γι' αυτό το χαραχτήρα στο αρχείο*/
                            outputFile.WriteLine(templine);
                        }
                    }

                    Console.WriteLine("ΟΛΟΚΛΗΡΩΘΗΚΕ Ο ΕΛΕΓΧΟΣ.\nΤα αποτελέσματα αποθηκεύτηκαν στο αρχείο \"output.txt\" !!!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in file handling:");
                Console.WriteLine(e.Message);
            }
        }

        public void checkDouble()
        {
            try
            {
                /*ΑΝΟΙΓΜΑ ΑΡΧΕΙΟΥ ΤΟ ΟΠΟΙΟ ΒΡΙΣΚΕΤΑΙ ΣΤΟ ΣΧΕΤΙΚΟ ΜΟΝΟΠΑΤΙ ΤΟΥ project*/
                using (StreamReader inputFile = new StreamReader("input2.txt"))  /*Το using στο τέλος κλείνει το stream*/
                {
                    Console.WriteLine("\nΆνοιγμα και έλεγχος αρχείου \"input2.txt\"...");

                    /*Εφόσον όλα πήγαν ΟΚ με το άνοιγμα του input file θα δημιουργήσουμε το αρχείο των αποτελεσμάτων*/
                    /*ΑΝΟΙΓΜΑ ΑΡΧΕΙΟΥ ΑΠΟΤΕΛΕΣΜΑΤΩΝ*/
                    using (StreamWriter outputFile = new StreamWriter("output2.txt"))
                    {
                        //phon checkMethods = new phon();

                        /*ΔΙΑΒΑΣΜΑ ΓΡΑΜΜΗ-ΓΡΑΜΜΗ ΤΟΥ ΑΡΧΕΙΟΥ ΜΕΧΡΙ ΤΟ EOF*/
                        string line = null;
                        string templine = null;

                        while ((line = inputFile.ReadLine()) != null)
                        {
                            /*πέρασμα αυτών των χαραχτήρων στο αρχείο*/
                            outputFile.WriteLine(line);

                            /* έλεγχος της τιμής του χαρακτήρα για κάθε διαθέσιμη μέθοδο και αντίστοιχη εκτύπωση στο file των αποτελεσμάτων*/
                            Boolean isDiphthong = checkMethods.Diphthong(line[0], line[1]);
                            Boolean isInitials = checkMethods.Initials(line[0], line[1]);

                            templine = "Diphthong: " + isDiphthong + "  Initials: " + isInitials;

                            /*πέρασμα των αποτελεσμάτων γι' αυτούς τους χαραχτήρες στο αρχείο*/
                            outputFile.WriteLine(templine);
                        }
                    }

                    Console.WriteLine("ΟΛΟΚΛΗΡΩΘΗΚΕ Ο ΕΛΕΓΧΟΣ.\nΤα αποτελέσματα αποθηκεύτηκαν στο αρχείο \"output2.txt\" !!!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in file handling:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
