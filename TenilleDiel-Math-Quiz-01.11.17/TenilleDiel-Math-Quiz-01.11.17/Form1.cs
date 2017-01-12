using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace TenilleDiel_Math_Quiz_01._11._17
{
    public partial class myQuiz : Form
    {
        Random randomizer = new Random();

        int addend1;
        int addend2;

        int minuend;
        int subtrahend;

        int multiplicand;
        int multiplier;

        int dividend;
        int divisor;

        int timeLeft;

        public void StartTheQuiz()
        {
            //Addition Problem
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            sum.Value = 0;

            //Subtraction Problem
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            //Multiplication Problem
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            //Division Problem
            divisor = randomizer.Next(2, 11);
            int tempQuotient = randomizer.Next(2, 11);
            dividend = divisor * tempQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            timeLeft = 30;
            timeLabel1.Text = "30 seconds";
            timer1.Start();
        }

        public bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
            {
                return true;
            }
            else
                return false;
        }

        public myQuiz()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Congratulations!!");
                sum.BackColor = Color.White;
                sum.ForeColor = Color.Black;
                difference.BackColor = Color.White;
                difference.ForeColor = Color.Black;
                product.BackColor = Color.White;
                product.ForeColor = Color.Black;
                quotient.BackColor = Color.White;
                quotient.ForeColor = Color.Black;
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                if (timeLeft == 5)
                {
                    timeLabel1.BackColor = Color.Red;
                }
                timeLeft = timeLeft - 1;
                timeLabel1.Text = timeLeft + " seconds";
            }
            else
            {
                timer1.Stop();
                timeLabel1.Text = "Time's up!!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                timeLabel1.BackColor = Color.White;
                sum.BackColor = Color.White;
                sum.ForeColor = Color.Black;
                difference.BackColor = Color.White;
                difference.ForeColor = Color.Black;
                product.BackColor = Color.White;
                product.ForeColor = Color.Black;
                quotient.BackColor = Color.White;
                quotient.ForeColor = Color.Black;
                startButton.Enabled = true;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void checkTheSum(object sender, EventArgs e)
        {

            if (addend1 + addend2 == sum.Value)
            {
                SpeechSynthesizer synth = new SpeechSynthesizer();
                synth.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Senior);
                synth.SpeakAsync("Correct");

                sum.BackColor = Color.Green;
                sum.ForeColor = Color.White;
            }
            else
                return;
        }
        private void checkTheDifference(object sender, EventArgs e)
        {
            if (minuend - subtrahend == difference.Value)
            {
                SpeechSynthesizer synth = new SpeechSynthesizer();
                synth.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Senior);
                synth.SpeakAsync("Correct");

                difference.BackColor = Color.Green;
                difference.ForeColor = Color.White;

            }
            else
                return;
        }
        private void checkTheProduct(object sender, EventArgs e)
        {
            if (multiplicand * multiplier == product.Value)
            {
                SpeechSynthesizer synth = new SpeechSynthesizer();
                synth.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Senior);
                synth.SpeakAsync("Correct");

                product.BackColor = Color.Green;
                product.ForeColor = Color.White;

            }
            else
                return;
        }
        private void checkTheQuotient(object sender, EventArgs e)
        {
            if (dividend / divisor == quotient.Value)
            {
                SpeechSynthesizer synth = new SpeechSynthesizer();
                synth.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Senior);
                synth.SpeakAsync("Correct");

                quotient.BackColor = Color.Green;
                quotient.ForeColor = Color.White;

            }
            else
                return;
        }
    }
}
