using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AncientTool
{
    class testMetrics
    {
        private metrics checkMethods;

        public testMetrics()
        {
            checkMethods = new metrics();
        }

        /*
         * Για τον έλεγχο της Quantity, βάζουμε μια λέξη 4 γραμμάτων σε κάθε γραμμή του input file
         * Οι 4 χαρακτήρες της λέξης χρησιμοποιούνται ως παράμετροι για την κλήση της μεθόδου Quantity
         */
        public void testQuantity()
        {
            Console.WriteLine("\n\n--> Έλεγχος μεθόδου Quantity του Metrics module μέσω αρχείου");

            try
            {
                /*ΑΝΟΙΓΜΑ ΑΡΧΕΙΟΥ ΤΟ ΟΠΟΙΟ ΒΡΙΣΚΕΤΑΙ ΣΤΟ ΣΧΕΤΙΚΟ ΜΟΝΟΠΑΤΙ ΤΟΥ project*/
                using (StreamReader inputFile = new StreamReader("Quantity_IN.txt"))  /*Το using στο τέλος κλείνει το stream*/
                {
                    Console.WriteLine("Άνοιγμα και έλεγχος αρχείου \"Quantity_IN.txt\"...");

                    /*Εφόσον όλα πήγαν ΟΚ με το άνοιγμα του input file θα δημιουργήσουμε το αρχείο των αποτελεσμάτων*/
                    /*ΑΝΟΙΓΜΑ ΑΡΧΕΙΟΥ ΑΠΟΤΕΛΕΣΜΑΤΩΝ*/
                    using (StreamWriter outputFile = new StreamWriter("Quantity_OUT.txt"))
                    {

                        /*ΔΙΑΒΑΣΜΑ ΓΡΑΜΜΗ-ΓΡΑΜΜΗ ΤΟΥ ΑΡΧΕΙΟΥ ΜΕΧΡΙ ΤΟ EOF*/
                        string line = null;
                        string templine = null;

                        while ((line = inputFile.ReadLine()) != null)
                        {
                            /*πέρασμα αυτού του χαραχτήρα στο αρχείο*/
                            outputFile.WriteLine(line);

                            /*πέρνουμε τους πρώτους 4 χαρακτήρες από κάθε γραμμή του αρχείου εισόδου*/
                            templine = checkMethods.Quantity(line[0], line[1], line[2], line[3]);

                            /*πέρασμα των αποτελεσμάτων γι' αυτό το χαραχτήρα στο αρχείο*/
                            outputFile.WriteLine(templine);

                        }

                        Console.WriteLine("ΟΛΟΚΛΗΡΩΘΗΚΕ Ο ΕΛΕΓΧΟΣ.\nΤα αποτελέσματα αποθηκεύτηκαν στο αρχείο \"Quantity_OUT.txt\" !!!");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in file handling:");
                Console.WriteLine(e.Message);
            }
        }

        /* Για τον έλεγχο της Syllabify αυτό το οποίο γίνεται είναι να δούμε αν γεμίζει σωστά ο πίνακας "position"
         * καθώς και αν εντοπίζεται σωστά το πλήθος των συλλαβών για τον κάθε στίχο
         * Για κάθε στίχο του αρχείου εισόδου στο αρχείο εξόδου έχουμε τις θέσεις του πίνακα position (μετρώντας από το 0)
         * καθώς και το πλήθος των συλλαβών του στίχου
         * Στον πίνακα position, η αναφορά στις θέσεις του στίχου γίνεται μετρώντας τις θέσεις από το "1"
         */
        public void testSyllabify()
        {
            Console.WriteLine("\n\n--> Έλεγχος μεθόδου Syllabify του Metrics module μέσω αρχείου");

            try
            {
                /*ΑΝΟΙΓΜΑ ΑΡΧΕΙΟΥ ΤΟ ΟΠΟΙΟ ΒΡΙΣΚΕΤΑΙ ΣΤΟ ΣΧΕΤΙΚΟ ΜΟΝΟΠΑΤΙ ΤΟΥ project*/
                using (StreamReader inputFile = new StreamReader("Syllabify_IN.txt"))  /*Το using στο τέλος κλείνει το stream*/
                {
                    Console.WriteLine("Άνοιγμα και έλεγχος αρχείου \"Syllabify_IN.txt\"...");

                    /*Εφόσον όλα πήγαν ΟΚ με το άνοιγμα του input file θα δημιουργήσουμε το αρχείο των αποτελεσμάτων*/
                    /*ΑΝΟΙΓΜΑ ΑΡΧΕΙΟΥ ΑΠΟΤΕΛΕΣΜΑΤΩΝ*/
                    using (StreamWriter outputFile = new StreamWriter("Syllabify_OUT.txt"))
                    {

                        /*ΔΙΑΒΑΣΜΑ ΓΡΑΜΜΗ-ΓΡΑΜΜΗ ΤΟΥ ΑΡΧΕΙΟΥ ΜΕΧΡΙ ΤΟ EOF*/
                        string line = null;
                        
                        while ((line = inputFile.ReadLine()) != null)
                        {
                            /*πέρασμα αυτού του χαραχτήρα στο αρχείο*/
                            outputFile.WriteLine(line);

                            /*βάζουμε το στίχο στη Syllabify*/
                            checkMethods.Syllabify(line);

                            /*πέρασμα των αποτελεσμάτων γι' αυτό το στίχο στο αρχείο*/

                            /*τυπώνουμε τον πίνακα "position"*/
                            for (int i = 1; i <= checkMethods.position.GetLength(0); i++)
                                outputFile.WriteLine("position[" + (i - 1) + "][0] = " + checkMethods.position[i - 1, 0] + "\tposition[" + (i - 1) + "][1] = " + checkMethods.position[i - 1, 1]);
                            
                            /*τυπώνουμε το πλήθος των συλλαβών μέσω της μεταβλητής "counter" του "metrics"*/
                            outputFile.WriteLine("Πλήθος συλλαβών στίχου: " + checkMethods.counter + "\n");

                            /*δίνουμε τιμή 0 στον μετρητή των συλλαβών για τον επόμενο στίχο*/
                            checkMethods.counter = 0;
                        }

                        Console.WriteLine("ΟΛΟΚΛΗΡΩΘΗΚΕ Ο ΕΛΕΓΧΟΣ.\nΤα αποτελέσματα αποθηκεύτηκαν στο αρχείο \"Syllabify_OUT.txt\" !!!");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in file handling:");
                Console.WriteLine(e.Message);
            }
        }

        public void testIsDactyl()
        {
            Console.WriteLine("\n\n--> Έλεγχος μεθόδου IsDactyl του Metrics module μέσω αρχείου");

            try
            {
                /*ΑΝΟΙΓΜΑ ΑΡΧΕΙΟΥ ΤΟ ΟΠΟΙΟ ΒΡΙΣΚΕΤΑΙ ΣΤΟ ΣΧΕΤΙΚΟ ΜΟΝΟΠΑΤΙ ΤΟΥ project*/
                using (StreamReader inputFile = new StreamReader("IsDactyl_IN.txt"))  /*Το using στο τέλος κλείνει το stream*/
                {
                    Console.WriteLine("Άνοιγμα και έλεγχος αρχείου \"IsDactyl_IN.txt\"...");

                    /*Εφόσον όλα πήγαν ΟΚ με το άνοιγμα του input file θα δημιουργήσουμε το αρχείο των αποτελεσμάτων*/
                    /*ΑΝΟΙΓΜΑ ΑΡΧΕΙΟΥ ΑΠΟΤΕΛΕΣΜΑΤΩΝ*/
                    using (StreamWriter outputFile = new StreamWriter("IsDactyl_OUT.txt"))
                    {

                        /*ΔΙΑΒΑΣΜΑ ΓΡΑΜΜΗ-ΓΡΑΜΜΗ ΤΟΥ ΑΡΧΕΙΟΥ ΜΕΧΡΙ ΤΟ EOF*/
                        string line = null;

                        while ((line = inputFile.ReadLine()) != null)
                        {
                            /*πέρασμα αυτού του χαραχτήρα στο αρχείο*/
                            outputFile.WriteLine(line);

                            /*παίρνουμε τους πρώτους 4 χαρακτήρες από κάθε γραμμή του αρχείου εισόδου*/
                            /*πέρασμα των αποτελεσμάτων γι' αυτό το χαραχτήρα στο αρχείο*/
                            outputFile.WriteLine("IsDactyl: " + checkMethods.IsDactyl(line[0], line[1], line[2], line[3]));

                        }

                        Console.WriteLine("ΟΛΟΚΛΗΡΩΘΗΚΕ Ο ΕΛΕΓΧΟΣ.\nΤα αποτελέσματα αποθηκεύτηκαν στο αρχείο \"IsDactyl_OUT.txt\" !!!");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in file handling:");
                Console.WriteLine(e.Message);
            }
        }

        public void testDoScansion()
        {
            Console.WriteLine("\n\n--> Έλεγχος μεθόδου DoScansion του Metrics module μέσω αρχείου");

            try
            {
                /*ΑΝΟΙΓΜΑ ΑΡΧΕΙΟΥ ΤΟ ΟΠΟΙΟ ΒΡΙΣΚΕΤΑΙ ΣΤΟ ΣΧΕΤΙΚΟ ΜΟΝΟΠΑΤΙ ΤΟΥ project*/
                using (StreamReader inputFile = new StreamReader("inverse.txt"))  /*Το using στο τέλος κλείνει το stream*/
                {
                    string VerseLine = null;
                    string ScansionLine = null;
                    int TotalLines = 0;
                    int ErrorLines = 0;

                    /*Εφόσον όλα πήγαν ΟΚ με το άνοιγμα του input file θα δημιουργήσουμε το αρχείο των αποτελεσμάτων*/
                    /*ΑΝΟΙΓΜΑ ΑΡΧΕΙΟΥ ΑΠΟΤΕΛΕΣΜΑΤΩΝ*/
                    using (StreamWriter outputFile = new StreamWriter("outverse.txt"))
                    {
                        /*ΔΙΑΒΑΣΜΑ ΓΡΑΜΜΗ-ΓΡΑΜΜΗ ΤΟΥ ΑΡΧΕΙΟΥ ΜΕΧΡΙ ΤΟ EOF*/
                        while ((VerseLine = inputFile.ReadLine()) != null)
                        {
                            //Αύξηση της τιμής του counter των γραμμών
                            TotalLines++;

                            //Μετρική ανάλυση αυτού του στίχου
                            checkMethods.DoScansion(ref VerseLine, ref ScansionLine, ref ErrorLines);

                            outputFile.WriteLine(VerseLine);   //Εγγραφή στο αρχείο αποτελεσμάτων του στίχου
                            outputFile.WriteLine(ScansionLine);//και του αποτελέσματος της μετρικής του ανάλυσης
                        }

                    }

                    Console.WriteLine("Η μετρική ανάλυση μέσω αρχείων ολοκληρώθηκε.\nΣύνολο στίχων: " + TotalLines + "\nΣύνολο λαθών: " + ErrorLines);
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
