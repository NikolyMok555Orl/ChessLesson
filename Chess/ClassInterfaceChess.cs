using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    class ClassInterfaceChess
    {
        Board board;
        Point firstCellClick;
        Button firstButtonCellClick;
        TableLayoutPanel tableChess;
        Color whiteCell = Color.LemonChiffon;
        Color blackCell = Color.Chocolate;
        bool wasClick = false;


        public ClassInterfaceChess(TableLayoutPanel tableChess)
        {
            board = new Board();
            this.tableChess = tableChess;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Button button = new Button();
                    button.Dock = DockStyle.Fill;
                    button.FlatStyle = FlatStyle.Flat;
                    if ((i + j) % 2 == 0)
                    {
                        button.BackColor = Color.LemonChiffon;
                        button.FlatAppearance.MouseDownBackColor = Color.Goldenrod;
                    }
                    else
                    {
                        button.BackColor = Color.Chocolate;
                        button.FlatAppearance.MouseDownBackColor = Color.SaddleBrown;
                    }
                    //button.Size = new System.Drawing.Size(tableChess.RowStyles., 56);
                    button.UseVisualStyleBackColor = false;
                    button.Click += new System.EventHandler(this.button_Click);
                    if (board[i,7-j] != null) button.Text = board[i, 7-j].ToString();
                    button.Tag = new Point( i,  7-j);
                    

                    tableChess.Controls.Add(button, i, j);


                    /*this.button2.BackColor = System.Drawing.Color.LemonChiffon;
                    this.button2.Location = new System.Drawing.Point(3, 3);
                    this.button2.Name = "button2";
                    this.button2.Size = new System.Drawing.Size(56, 56);*/

                    //this.tableLayoutPanelChess.Controls.Add(this.button2, 0, 0);
                }
            }

           
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)(sender);
            Point newCord = (Point) button.Tag;
            if (!wasClick)
            {
                wasClick = true;
                firstCellClick = newCord;
                firstButtonCellClick = button;
                button.BackColor= button.FlatAppearance.MouseDownBackColor;
            }
            else
            {
                if (newCord != firstCellClick)
                {

                    if (board.Move(firstCellClick, newCord)) Redrawing();
                    if (board.GameState == Board.GameStates.check) MessageBox.Show("Шах");
                    MessageBox.Show((!board.IsBlack?"Ход белых":"Ход черных")+" "+ newCord.ToString());
                    //if (board.GameState == Board.GameStates.check) MessageBox.Show("Шах");
                   

                }

                wasClick = false;
                if (firstButtonCellClick.FlatAppearance.MouseDownBackColor == Color.Goldenrod) firstButtonCellClick.BackColor = whiteCell;
                else firstButtonCellClick.BackColor = blackCell;
                firstButtonCellClick = null;


            }

        }

        private void Redrawing()
        {
            foreach (var item in tableChess.Controls)
            {
                if(item is Button)
                {
                    Button button = (Button)(item);
                    Point cord = (Point)button.Tag;
                    if (board[cord] is null) button.Text = "";
                    else button.Text = board[cord].ToString();
                }
            }
        }


    }
}
