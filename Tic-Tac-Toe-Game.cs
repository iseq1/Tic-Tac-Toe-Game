using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_Game
{
    public partial class Form1 : Form
    {
        /*
         Есть игровое поле, там 9 кнопок, нажимая на которые по очереди будут появляться имиджи "X" и "0"
         Необходимо:
            1. Игровое поле
            2. Выбор крестика/нолика
            3. Текущий ход (чей ход сейчас)
            4. Форма с регистрацией (ввод имени)
            5. Счёт
            6. 
        */
        
        public Form1()
        {
            InitializeComponent();
            scoreboard();
            field();
        }
        private void field()
        {
            // (ru) создаем в форме графическое игровое поле, где и будет происходить основное действие 
            // (en) create in the form of a graphic playing field, where the main action will be 
            PictureBox b = new PictureBox();
            b.Text = "";
            b.Size = new Size(267,267);
            b.Location = new Point(175,75);
            b.Image = Image.FromFile("field.png");
            b.SizeMode = PictureBoxSizeMode.Zoom;
            this.Controls.Add(b);
        }

        private void scoreboard()
        {
            // (ru) создаем в форме графическую таблицу подсчёта очков
            // (en)  create a graphical scoring table in the form
            PictureBox s = new PictureBox();
            s.Size = new Size(150, 150);
            s.Location = new Point(25, 25);
            s.Image = Image.FromFile("score.png");
            s.SizeMode = PictureBoxSizeMode.Zoom;
            this.Controls.Add(s);
        }

        private void scoreUp(int s)
        {
            if (PlayerTurn)
            {
                label1.Text = Convert.ToString(s);
            }
            else label2.Text = Convert.ToString(s);

        }

        private int i = 0;
        private int j = 0;
        bool PlayerTurn = true; // true -> "x"  false -> "0"
        int TurnCount = 0; // max = 9;

        private void buttonClick(object sender, EventArgs e)
        {
            Button theButton = (Button)sender;
            if (PlayerTurn)
            {
                theButton.Text = "X";
                theButton.Enabled = false;
            }
            else
            {
                theButton.Text = "0";
                theButton.Enabled = false;
            }

            TurnCount++;
            PlayerTurn = !PlayerTurn;
            Winner();
        }

        private void Winner()
        {
            // (ru) метод проверяющий исход партии и определяющий кто вышел победителем с возможной ничьей 
            // (ru) a method that checks the outcome of the game and determines who came out the winner with a possible draw
            bool WeHaveWinner = false;
            
            // horizontally
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && A2.Enabled==false) WeHaveWinner = true;
            else if ((A4.Text == A5.Text) && (A5.Text == A6.Text) && A5.Enabled==false) WeHaveWinner = true;
            else if ((A7.Text == A8.Text) && (A8.Text == A9.Text) && A9.Enabled==false) WeHaveWinner = true;
            
            // vertically
            else if ((A1.Text == A4.Text) && (A4.Text == A7.Text) && A4.Enabled==false) WeHaveWinner = true;
            else if ((A2.Text == A5.Text) && (A5.Text == A8.Text) && A5.Enabled==false) WeHaveWinner = true;
            else if ((A3.Text == A6.Text) && (A6.Text == A9.Text) && A6.Enabled==false) WeHaveWinner = true;

            // diagonally
            else if ((A1.Text == A5.Text) && (A5.Text == A9.Text) && A5.Enabled==false) WeHaveWinner = true;
            else if ((A3.Text == A5.Text) && (A5.Text == A7.Text) && A5.Enabled==false) WeHaveWinner = true;


            if (WeHaveWinner)
            {
                string winner = "";
                if (PlayerTurn)
                {
                    winner = "0";
                    i++;
                    scoreUp(i);
                }
                else 
                {
                    winner = "X";
                    j++;
                    scoreUp(j);
                }

                MessageBox.Show(winner + " is win!");
                regame();
            }
            else
            {
                if (TurnCount == 9)
                {
                    MessageBox.Show("Draw");
                    regame();
                }
            }

        }

        private void regame()
        {
            // (ru) метод для автоматического запуска игры после её завершения 
            // (en) method to automatically start the game after it ends
            PlayerTurn = true;
            TurnCount = 0;
            try
            {
                foreach (Control c in Controls)
                {
                    if (c is Button)
                    {
                        (c as Button).Enabled = true;
                        (c as Button).Text = "";
                    }
                }
            }
            catch
            {
            }
        }
        
    }
}