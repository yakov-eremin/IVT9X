using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Library _library;
        HiddenWord _hiddenWord;
        Player[] _players = new Player[3];
        int[] _points = new int[] { 100, 200, 300, 400, 500 };
        Random random = new Random();
        Label[] _answerletters;
        int _playerTurn;
        int _currentpoints;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            _library = new Library("AnswerQuestions.xml");
            Start();
        }
        private void Start()
        {
            string _answer;
            string _question;
            Library.GetRandomPuzzle(out _question, out _answer);
            textBox_question.Text = _question;
            _hiddenWord = new HiddenWord(_answer);
            _players = new Player[3];
            _answerletters = new Label[_answer.Length];
            int _x = 10;
            for (int i = 0; i < _answerletters.Length; i++)
            {
                _answerletters[i] = new Label();
                _answerletters[i].AutoSize = false;
                _answerletters[i].Width = 15;
                _answerletters[i].Text = "_";
                _answerletters[i].Location = new Point(_x, 150);
                _x += 25;
                Controls.Add(_answerletters[i]);
            }
            _x = 10;
            for (int i = 0; i < _players.Length; i++)
            {
                _players[i] = new Player();
                _players[i].Name = "Игрок " + (i + 1);
                _players[i].ResetPoints();
                Label _label = new Label();
                _label.Text = _players[i].Name;
                _label.Location = new Point(_x, 205);
                _x += 120;
                Controls.Add(_label);
            }
            label_points_1.Text = _players[0].Points.ToString();
            label_points_2.Text = _players[1].Points.ToString();
            label_points_3.Text = _players[2].Points.ToString();
            _playerTurn = 0;
            NextTurn();
        }

        private void NextTurn()
        {
            TurnWheel();
            _playerTurn++;
            if (_playerTurn > 3)
                _playerTurn = 1;
            if (_playerTurn == 1)
            {
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = false;
            }
            if (_playerTurn == 2)
            {
                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = false;
            }
            if (_playerTurn == 3)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = true;
            }
            button_start.Enabled = true;
        }

        private void OpenLetters(List<int> index)
        {
            char _letter = _hiddenWord.Word[index[0]];
            for (int i = 0; i < index.Count; i++)
            {
                _answerletters[index[i]].Text = _letter.ToString();
            }
        }
        
        private void ShowWord()
        {
            for(int i = 0; i < _answerletters.Length; i++)
            {
                _answerletters[i].Text = _hiddenWord.Word[i].ToString();
            }
        }

        private void TurnWheel()
        {
            _currentpoints = _points[random.Next(0, _points.Length)];
            label_points.Text = _currentpoints.ToString();
            button_start.Enabled = false;
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> _index = new List<int>();            
            if (textBox1.Text.Length == 1)
            {
                if(_hiddenWord.TryGuessLetter(Convert.ToChar(textBox1.Text), _index) == true)
                {
                    _players[0].IncreasePoints(_currentpoints);
                    label_points_1.Text = _players[0].Points.ToString();
                    OpenLetters(_index);
                }
            }
            else
            {
                if (_hiddenWord.TryGuessWord(textBox1.Text))
                {
                    _players[0].IncreasePoints(_currentpoints);
                    label_points_1.Text = _players[0].Points.ToString();
                    ShowWord();                    
                }
            }
            textBox1.Clear();
            NextTurn();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<int> _index = new List<int>();
            if (textBox2.Text.Length == 1)
            {
                if (_hiddenWord.TryGuessLetter(Convert.ToChar(textBox2.Text), _index) == true)
                {
                    _players[1].IncreasePoints(_currentpoints);
                    label_points_2.Text = _players[1].Points.ToString();
                    OpenLetters(_index);
                }
            }
            else
            {
                if (_hiddenWord.TryGuessWord(textBox2.Text))
                {
                    _players[1].IncreasePoints(_currentpoints);
                    label_points_2.Text = _players[1].Points.ToString();
                    ShowWord();
                    
                }
            }
            textBox2.Clear();
            NextTurn();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<int> _index = new List<int>();
            if (textBox3.Text.Length == 1)
            {
                if (_hiddenWord.TryGuessLetter(Convert.ToChar(textBox3.Text), _index) == true)
                {
                    _players[2].IncreasePoints(_currentpoints);
                    label_points_3.Text = _players[2].Points.ToString();
                    OpenLetters(_index);
                }
            }
            else
            {
                if (_hiddenWord.TryGuessWord(textBox3.Text))
                {
                    _players[2].IncreasePoints(_currentpoints);
                    label_points_3.Text = _players[2].Points.ToString();
                    ShowWord();
                }
            }
            textBox3.Clear();
            NextTurn();
        }
    }
}
