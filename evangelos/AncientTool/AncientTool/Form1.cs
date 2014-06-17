using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AncientTool
{
    public partial class Form1 : Form
    {
        string VerseLine;
        string ScansionLine;
        int TotalLines;
        int ErrorLines;

        private metrics Metrics;

        public Form1()
        {
            InitializeComponent();

            //Δήλωση του χειριστή συμβάντος (handler) για τη χρήση του "Enter" στο TxtInput RichTextBox
            this.TxtInput.KeyDown += new KeyEventHandler(TxtInput_KeyDown);

            TxtInput.Clear();
            TxtInput.Focus();

            VerseLine = null;
            ScansionLine = null;
            TotalLines = 0;
            ErrorLines = 0;

            Metrics = new metrics();
        }

        private void CmdFiles_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Αρχείο εισαγωγής στίχων: inverse.txt\nΑρχείο εγγραφής αποτελεσμάτων: outverse.txt\nΝα συνεχίσω ;", "Έγκριση ...", MessageBoxButtons.OKCancel);
            String message = null;
            ErrorLines = 0;
            TotalLines = 0;

            if (result1 == DialogResult.OK)
            {
                try
                {
                    /*ΑΝΟΙΓΜΑ ΑΡΧΕΙΟΥ ΤΟ ΟΠΟΙΟ ΒΡΙΣΚΕΤΑΙ ΣΤΟ ΣΧΕΤΙΚΟ ΜΟΝΟΠΑΤΙ ΤΟΥ project*/
                    using (StreamReader inputFile = new StreamReader("inverse.txt"))  /*Το using στο τέλος κλείνει το stream*/
                    {
                        /*Εφόσον όλα πήγαν ΟΚ με το άνοιγμα του input file θα δημιουργήσουμε το αρχείο των αποτελεσμάτων*/
                        /*ΑΝΟΙΓΜΑ ΑΡΧΕΙΟΥ ΑΠΟΤΕΛΕΣΜΑΤΩΝ*/
                        using (StreamWriter outputFile = new StreamWriter("outverse.txt"))
                        {
                            LblResult.Text = "Μετρική ανάλυση σε εξέλιξη ..."; //Εμφάνιση μηνύματος στο LblResult 
                            LblResult.SelectAll();
                            LblResult.SelectionColor = Color.Black;

                            /*ΔΙΑΒΑΣΜΑ ΓΡΑΜΜΗ-ΓΡΑΜΜΗ ΤΟΥ ΑΡΧΕΙΟΥ ΜΕΧΡΙ ΤΟ EOF*/
                            while ((VerseLine = inputFile.ReadLine()) != null)
                            {
                                //Αύξηση της τιμής του counter των γραμμών
                                TotalLines++;

                                //Μετρική ανάλυση αυτού του στίχου
                                Metrics.DoScansion(ref VerseLine, ref ScansionLine, ref ErrorLines);

                                outputFile.WriteLine(VerseLine);   //Εγγραφή στο αρχείο αποτελεσμάτων του στίχου
                                outputFile.WriteLine(ScansionLine);//και του αποτελέσματος της μετρικής του ανάλυσης
                            }
                       
                        }

                        message = "Η μετρική ανάλυση μέσω αρχείων ολοκληρώθηκε.\nΣύνολο στίχων: " + TotalLines + "\nΣύνολο λαθών: " + ErrorLines;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Λάθος στη διαχείριση των αρχείων !", MessageBoxButtons.OK);
                    LblResult.Clear();
                    TxtInput.Focus();
                    return;
                }
            }
            else
                message = "Η διαδικασία ακυρώθηκε !";

            MessageBox.Show(message, "Τέλος μετρικής ανάλυσης", MessageBoxButtons.OK);
            LblResult.Clear();
            TxtInput.Focus();
        }

        //Χειριστής συμβάντος για τη χρήση του "Enter" στο TxtInput RichTextBox
        private void TxtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true; //Για να μην ακούγεται ο default ήχος από το πάτημα του "Enter"
                CmdVerse.Focus();
            }
        }

        private void CmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmdVerse_Click(object sender, EventArgs e) 
        {
            ErrorLines = 0;
            VerseLine = TxtInput.Text;
            Metrics.DoScansion(ref VerseLine, ref ScansionLine, ref ErrorLines);
            
            if (ErrorLines != 0)
                ScansionLine = "Λάθος ανάλυση...";

            LblResult.Text = VerseLine + "\n" + ScansionLine;
            LblResult.SelectAll();
            LblResult.SelectionColor = Color.Black;

            TxtInput.Clear();
            CmdClear.Focus();
        }

        private void CmdClear_Click(object sender, EventArgs e)
        {
            LblResult.Clear();
            TxtInput.Clear();
            TxtInput.Focus();
        }

        //Μέθοδοι που δημιουργούνται αυτόματα αλλά δε χρειάζεται να γράψουμε κάτι μέσα σε αυτές
        private void LblInput_Click(object sender, EventArgs e) { }

        private void TxtInput_TextChanged(object sender, EventArgs e) { }

        private void LblOutput_Click(object sender, EventArgs e) { }

        private void LblResult_TextChanged(object sender, EventArgs e) { }
    }
}
