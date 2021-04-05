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
        Board boardGame;
        Point firstCellClick;
        Button firstButtonCellClick;
        TableLayoutPanel tableChess;
        Color whiteCell = Color.LemonChiffon;
        Color blackCell = Color.Chocolate;
        Color colorBorder;
        bool wasClick = false;


        public ClassInterfaceChess(TableLayoutPanel tableChess)
        {
            boardGame = new Board();
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
                    if (boardGame[i,7-j] != null) button.Text = boardGame[i, 7-j].ToString();
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
        /// <summary>
        /// Нажитие на кнопку. Ход
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                if (button.Text.Length>0) {
                    ShowCanMoveFigures(boardGame.ListFiguresCanMove());
                    ShowCanMove(boardGame[newCord].ListCanMove(boardGame));
                }


            }
            else
            {
                if (newCord != firstCellClick)
                {

                    if (boardGame.Move(firstCellClick, newCord)) Redrawing();
                    if (boardGame.GameState == Board.GameStates.check) MessageBox.Show("Шах");
                    MessageBox.Show((!boardGame.IsBlack?"Ход белых":"Ход черных")+" "+ newCord.ToString());
                    //Form1.labalTurn
                    //if (board.GameState == Board.GameStates.check) MessageBox.Show("Шах");
                    if (boardGame.CheckMate())
                    {
                        MessageBox.Show("Шах и Мат");
                    }
                    else if (boardGame.Check(!boardGame.IsWhiteTurn))
                    {
                        MessageBox.Show("Шах");
                    }


                }

                wasClick = false;
                if (firstButtonCellClick.FlatAppearance.MouseDownBackColor == Color.Goldenrod) firstButtonCellClick.BackColor = whiteCell;
                else firstButtonCellClick.BackColor = blackCell;
                firstButtonCellClick = null;

                ReturntShowCanMove();

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
                    if (boardGame[cord] is null) button.Text = "";
                    else button.Text = boardGame[cord].ToString();
                }
            }
        }

        /// <summary>
        /// Обозначение клеток где фигура может ходить
        /// </summary>
        /// <param name="pointsMoveCan"></param>
        private void ShowCanMove(List<Point> pointsMoveCan)
        {
            foreach (var but in tableChess.Controls)
            {
                Button button = (Button)(but);
                Point newCord = (Point)button.Tag;
                if (pointsMoveCan is null) return;
                foreach (var pointMoveCan in pointsMoveCan)
                {
                    if (newCord.Equals(pointMoveCan))
                    {
                            colorBorder = button.FlatAppearance.BorderColor;
                            button.FlatAppearance.BorderColor = Color.Blue;
                            button.FlatAppearance.BorderSize = 2;
                    }
                }

            }   
        }

        private void ShowCanMoveFigures(List<Point> figuresMoveCan)
        {
            foreach (var but in tableChess.Controls)
            {
                Button button = (Button)(but);
                Point newCord = (Point)button.Tag;
                foreach (var pointMoveCan in figuresMoveCan)
                {
                    if (newCord.Equals(pointMoveCan))
                    {
                        colorBorder = button.FlatAppearance.BorderColor;
                        button.FlatAppearance.BorderColor = Color.Aqua;
                        button.FlatAppearance.BorderSize = 2;
                    }
                }

            }
        }

        /// <summary>
        /// Возраврат границ к стандартному виду.
        /// </summary>
        private void ReturntShowCanMove()
        {
            foreach (var but in tableChess.Controls)
            {
                Button button = (Button)(but);
                button.FlatAppearance.BorderColor = colorBorder;
                button.FlatAppearance.BorderSize = 1;
            }
        }

    }
}
