using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AncientTool
{
    class testStriman
    {
        private striman checkStriman;

        public testStriman()
        {
            checkStriman = new striman();
        }

        /* The test file will have the following format */
        /* target,line,place  -  string,string,byte */
        /* We will have two test files, one for each method again */

        // Here we consider that the starting point of a string is "1"

        //If method is 0, the DoReplace, else Insert
        public void checkValidity(int method)
        {
            string [] input = {"DoReplace_In.txt", "Insert_In.txt"};
            string [] output = { "DoReplace_Out.txt", "Insert_Out.txt" };
            string[] tokens = { "," };

            /*ΑΝΟΙΓΜΑ ΑΡΧΕΙΟΥ ΤΟ ΟΠΟΙΟ ΒΡΙΣΚΕΤΑΙ ΣΤΟ ΣΧΕΤΙΚΟ ΜΟΝΟΠΑΤΙ ΤΟΥ project*/
            try
            {
                using (StreamReader inputFile = new StreamReader(input[method]))  /*Το using στο τέλος κλείνει το stream*/
                {
                    Console.WriteLine("Άνοιγμα και έλεγχος αρχείου \"" + input[method] + "\"...");

                    /*Εφόσον όλα πήγαν ΟΚ με το άνοιγμα του input file θα δημιουργήσουμε το αρχείο των αποτελεσμάτων*/
                    /*ΑΝΟΙΓΜΑ ΑΡΧΕΙΟΥ ΑΠΟΤΕΛΕΣΜΑΤΩΝ*/
                    using (StreamWriter outputFile = new StreamWriter(output[method]))
                    {
                        /*ΔΙΑΒΑΣΜΑ ΓΡΑΜΜΗ-ΓΡΑΜΜΗ ΤΟΥ ΑΡΧΕΙΟΥ ΜΕΧΡΙ ΤΟ EOF*/
                        string line = null;
                        
                        while ((line = inputFile.ReadLine()) != null)
                        {
                            /*πέρασμα αυτού του χαραχτήρα στο αρχείο*/
                            outputFile.WriteLine(line);

                            /*διαχωρισμός των στοιχείων της γραμμής*/
                            string [] parameters = line.Split(tokens, 3, System.StringSplitOptions.RemoveEmptyEntries);

                            if(method == 0)
                                checkStriman.DoReplace(parameters[0], ref parameters[1], Byte.Parse(parameters[2]));
                            else
                                checkStriman.Insert(parameters[0], ref parameters[1], Byte.Parse(parameters[2]));

                            outputFile.WriteLine(parameters[1]);
                        }
                    }

                    Console.WriteLine("ΟΛΟΚΛΗΡΩΘΗΚΕ Ο ΕΛΕΓΧΟΣ.\nΤα αποτελέσματα αποθηκεύτηκαν στο αρχείο \"" + output[method] + "\" !!!\n");
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
