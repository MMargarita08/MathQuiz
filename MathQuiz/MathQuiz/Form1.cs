using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        //Создайте случайный объект под названием randomizer
        //для генерации случайных чисел.
        Random randomizer = new Random();

        //Эти целочисленные переменные хранят числа 
        //для задачи сложения. 
        int addend1;
        int addend2;

        //Эти целочисленные переменные хранят числа 
        //для задачи вычитания.
        int minuend;
        int subtrahend;

        //Эти целочисленные переменные хранят числа 
        //для задачи умножения. 
        int multiplicand;
        int multiplier;

        //Эти целочисленные переменные хранят числа 
        //для задачи о разделении. 
        int dividend;
        int divisor;

        //Эта целочисленная переменная отслеживает
        //оставшееся время.
        int timeLeft;

        public Form1()
        {
            InitializeComponent();
        }

        ///</краткое содержание>
        ///Начните тест, заполнив все задачи
        ///и запуск таймера.
        ///</краткое содержание>
        public void StartTheQuiz()
        {
            //Заполните задачу сложения.
            //Сгенерируйте два случайных числа для добавления.
            //Сохраните значения в переменных 'addend1' и 'addend2'.
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            //Преобразовать два случайно сгенерированных числа
            //в строки, чтобы их можно было отобразить
            //в элементах управления метками.
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            //'sum' - это имя элемента управления NumericUpDown.
            //На этом шаге убедитесь, что его значение равно нулю, прежде чем
            //добавлять к нему какие-либо значения.
            sum.Value = 0;

            //Заполните задачу на вычитание.
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            //Заполните задачу на умножение.
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            //Заполните задачу о разделении.
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;
            //Запустите таймер.
            timeLeft = 30;
            timeLabel.Text = "30 секунд";
            timer1.Start();
            
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        ///</краткое содержание>
        ///Проверьте ответы, чтобы убедиться, что пользователь все понял правильно.
        ///</краткое содержание>
        ///<возвращает>True, если ответ правильный, false в противном случае.</возвращает>
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                //Если функция CheckTheAnswer() возвращает значение true, то пользователь 
                //получил правильный ответ. Остановите таймер 
                //и показать окно сообщений.
                timer1.Stop();
                MessageBox.Show("Вы правильно ответили на все вопросы!", "Поздравляю!");
                startButton.Enabled = true;
                
            }
            else if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " секунд";
                if (timeLeft <= 5) { timeLabel.BackColor = Color.Red; }
            }
            else
            {
                timer1.Stop();
                timeLabel.BackColor = Color.White;
                timeLabel.Text = "Время вышло";
                MessageBox.Show("Вы не закончили вовремя", "Извините!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            //Выберите полный ответ в элементе управления NumericUpDown.
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void sum_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void difference_ValueChanged(object sender, EventArgs e)
        {

        }

        private void product_ValueChanged(object sender, EventArgs e)
        {

        }

        private void quotient_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
