namespace game_tic_tac_toe
{
    public partial class Form1 : Form
    {
        bool turn = true; //true=  x turn and false = o turn
        int turn_count = 0;
        bool Thewinner = false;
        string winner = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }//end exit

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Aroosa", "About");
        }//end about

        private void Button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }

            b.Enabled = false;
            turn = !turn;
            turn_count++;
            Checkforwinner();

        }//end button_click
        private void Checkforwinner()
        {
            //horizotal check
            if (((A1.Text == A2.Text)&&(A2.Text == A3.Text))&&((!A1.Enabled)||(!A2.Enabled)||(!A3.Enabled)))
                Thewinner = true;
            else if (((B1.Text == B2.Text) && (B2.Text == B3.Text)) && ((!B1.Enabled) || (!B2.Enabled) || (!B3.Enabled)))
                Thewinner =true;
            else if (((C1.Text == C2.Text) && (C2.Text == C3.Text)) && ((!C1.Enabled) || (!C2.Enabled) || (!C3.Enabled)))
                Thewinner = true;
            //horixontal chck ends

            //vertical check
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text)&& (!A1.Enabled))
                Thewinner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text)&& (!A2.Enabled))
                Thewinner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text)&& (!A3.Enabled))
                Thewinner = true;
            //vertical ckeck ends here

            //diagonal check
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                Thewinner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text)&& (!C1.Enabled))
                Thewinner = true;
            //diagonal check ends here
            Makeannouncement();


        }//ckeck for winner ends 
        private void Makeannouncement()
        {
            if ((Thewinner == true) && (turn == true))
            {
                winner = "O";
                disablebutton();
                MessageBox.Show(winner + " is the winner", "yaay!");
            }
            else if ((Thewinner == true) && (turn == false))
            {
                winner = "X";
                disablebutton();
                MessageBox.Show(winner + " is the winner", "yaay!");
            }

            else if (turn_count == 9)
                MessageBox.Show(" its draw", "hey!");
        }//Makeannouncement ends 
        private void disablebutton()
        {
             try
             { 
                 foreach (Control c in Controls)
                 {
                    Button b = (Button)c;
                    b.Enabled = false;
                 }
             }
             catch { }
        }//disablebutton ends here

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Text = "";
                    b.Enabled = true;
                    turn = true; //true=  x turn and false = o turn
                    turn_count = 0;
                    Thewinner = false;
                    winner = "";
                }
            }
            catch { }
        }
    }
}