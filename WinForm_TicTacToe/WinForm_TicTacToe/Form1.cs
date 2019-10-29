using System;
using System.Windows.Forms;
/// <summary>
/// https://www.youtube.com/watch?v=p3gYVcggQOU&t=32s
/// </summary>
/// https://www.youtube.com/watch?v=mRg4FNvxjjo
namespace WinForm_TicTacToe
{
    public partial class Form1 : Form
    {
        bool turnX = true;  // false will be = turn of O
        int turn_count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turnX = true;
            turn_count = 0;


            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
                catch { }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("by Katy, 21/10/19", "Tic Tac Toe Info");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turnX)
                b.Text = "X";
            else
                b.Text = "O";

            turnX = !turnX;
            b.Enabled = false;

            turn_count++;

            CheckForWinner();
        }

        private void CheckForWinner()
        {
            bool isWinner = false;

            // Horizontal Win
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                isWinner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                isWinner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                isWinner = true;

            // Vertical Win
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                isWinner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                isWinner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                isWinner = true;

            // Diagonal Win
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                isWinner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
                isWinner = true;


            if (isWinner)
            {
                disableButtons();
                string winner = "";
                if (turnX)
                {
                    winner = "O";
                    o_win_count.Text = (Int32.Parse(o_win_count.Text) + 1).ToString();
                }
                else
                {
                    winner = "X";
                    x_win_count.Text = (Int32.Parse(x_win_count.Text) + 1).ToString();
                }
                MessageBox.Show(winner + " Wins!", "Cool!");
            }
            else
            {
                if (turn_count == 9)
                {
                    draw_count.Text = (Int32.Parse(draw_count.Text) + 1).ToString();
                    MessageBox.Show("Draw!", "Bummer!");  // ничья

                }
            }
        }

        private void disableButtons()
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
        }

        private void btn_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                if (turnX)
                    b.Text = "X";
                else
                    b.Text = "O";
            }
        }

        private void btn_leave(object sender, EventArgs e)
        {
            Button B = (Button)sender;
            if (B.Enabled)
            {
                B.Text = "";
            }
        }

        private void resetWinCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x_win_count.Text = "0";
            o_win_count.Text = "0";
            draw_count.Text = "0";
        }
    }
}
