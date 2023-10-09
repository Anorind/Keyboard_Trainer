using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Threading;

namespace Keyboard_Trainer
{
    public partial class MainWindow : Window
    {
        private int totalChars = 0;
        private int minutesPassed = 0;
        private int totalMistakes = 0;

        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            minutesPassed++;

            LabelChars.Content = "Speed: " + (totalChars / minutesPassed) + " chars/min";
        }
        private void ScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (labelLevel != null)
            {
                if (scrollBarLevel.Value == 1)
                {
                    labelLevel.Content = "Level:Easy";
                }
                else if (scrollBarLevel.Value == 2)
                {
                    labelLevel.Content = "Level:Average";
                }
                else if (scrollBarLevel.Value == 3)
                {
                    labelLevel.Content = "Level:Hard";
                }
            }

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void StartButtonClick(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            timer.Start();

            totalChars = 0;
            minutesPassed = 0;
            currentCharIndex = 0;
            totalMistakes = 0;

            LabelChars.Content = "Speed: 0 chars/min";
            LabelMistakes.Content = "0 mistakes";

            MyRichTextBox.Document.Blocks.Clear();
            MyRichTextBox.Document.Blocks.Add(new Paragraph());

            string fileName = string.Empty;
            if (labelLevel.Content.ToString() == "Level:Easy")
            {
                fileName = @"texts\textEasy.txt";
            }
            else if (labelLevel.Content.ToString() == "Level:Average")
            {
                fileName = @"texts\textAverage.txt";
            }
            else if (labelLevel.Content.ToString() == "Level:Hard")
            {
                fileName = @"texts\textHard.txt";
            }
            if (!string.IsNullOrEmpty(fileName))
            {
                string fileContent = File.ReadAllText(fileName);

                FlowDocument document = new FlowDocument();
                Paragraph paragraph = new Paragraph();
                paragraph.Inlines.Add(new Run(fileContent));
                document.Blocks.Add(paragraph);

                MyRichTextBox.Document = document;
            }
            timer.Interval = TimeSpan.FromMinutes(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Oem3) { ButtonApostrophe.Background = Brushes.Green; }
            if (e.Key == Key.D1) { Button1.Background = Brushes.Green; }
            if (e.Key == Key.D2) { Button2.Background = Brushes.Green; }
            if (e.Key == Key.D3) { Button3.Background = Brushes.Green; }
            if (e.Key == Key.D4) { Button4.Background = Brushes.Green; }
            if (e.Key == Key.D5) { Button5.Background = Brushes.Green; }
            if (e.Key == Key.D6) { Button6.Background = Brushes.Green; }
            if (e.Key == Key.D7) { Button7.Background = Brushes.Green; }
            if (e.Key == Key.D8) { Button8.Background = Brushes.Green; }
            if (e.Key == Key.D9) { Button9.Background = Brushes.Green; }
            if (e.Key == Key.D0) { Button0.Background = Brushes.Green; }
            if (e.Key == Key.OemMinus) { ButtonMinus.Background = Brushes.Green; }
            if (e.Key == Key.OemPlus) { ButtonEquals.Background = Brushes.Green; }
            if (e.Key == Key.Back) { ButtonBackspace.Background = Brushes.Blue; }
            if (e.Key == Key.Tab) { ButtonTab.Background = Brushes.Blue; }
            if (e.Key == Key.Q) { ButtonQ.Background = Brushes.Green; }
            if (e.Key == Key.W) { ButtonW.Background = Brushes.Green; }
            if (e.Key == Key.E) { ButtonE.Background = Brushes.Green; }
            if (e.Key == Key.R) { ButtonR.Background = Brushes.Green; }
            if (e.Key == Key.T) { ButtonT.Background = Brushes.Green; }
            if (e.Key == Key.Y) { ButtonY.Background = Brushes.Green; }
            if (e.Key == Key.U) { ButtonU.Background = Brushes.Green; }
            if (e.Key == Key.I) { ButtonI.Background = Brushes.Green; }
            if (e.Key == Key.O) { ButtonO.Background = Brushes.Green; }
            if (e.Key == Key.P) { ButtonP.Background = Brushes.Green; }
            if (e.Key == Key.OemOpenBrackets) { ButtonOpeningSquareBrackets.Background = Brushes.Green; }
            if (e.Key == Key.OemCloseBrackets) { ButtonClothingSquareBrackets.Background = Brushes.Green; }
            if (e.Key == Key.Oem5) { ButtonSlash.Background = Brushes.Green; }
            if (e.Key == Key.CapsLock) { ButtonCapsLock.Background = Brushes.Blue; }
            if (e.Key == Key.A) { ButtonA.Background = Brushes.Green; }
            if (e.Key == Key.S) { ButtonS.Background = Brushes.Green; }
            if (e.Key == Key.D) { ButtonD.Background = Brushes.Green; }
            if (e.Key == Key.F) { ButtonF.Background = Brushes.Green; }
            if (e.Key == Key.G) { ButtonG.Background = Brushes.Green; }
            if (e.Key == Key.H) { ButtonH.Background = Brushes.Green; }
            if (e.Key == Key.J) { ButtonJ.Background = Brushes.Green; }
            if (e.Key == Key.K) { ButtonK.Background = Brushes.Green; }
            if (e.Key == Key.L) { ButtonL.Background = Brushes.Green; }
            if (e.Key == Key.Oem1) { ButtonSemicolon.Background = Brushes.Green; }
            if (e.Key == Key.OemQuotes) { ButtonMark.Background = Brushes.Green; }
            if (e.Key == Key.Enter) { ButtonEnter.Background = Brushes.Blue; }
            if (e.Key == Key.LeftShift) { ButtonLeftShift.Background = Brushes.Blue; }
            if (e.Key == Key.Z) { ButtonZ.Background = Brushes.Green; }
            if (e.Key == Key.X) { ButtonX.Background = Brushes.Green; }
            if (e.Key == Key.C) { ButtonC.Background = Brushes.Green; }
            if (e.Key == Key.V) { ButtonV.Background = Brushes.Green; }
            if (e.Key == Key.B) { ButtonB.Background = Brushes.Green; }
            if (e.Key == Key.N) { ButtonN.Background = Brushes.Green; }
            if (e.Key == Key.M) { ButtonM.Background = Brushes.Green; }
            if (e.Key == Key.OemComma) { ButtonComma.Background = Brushes.Green; }
            if (e.Key == Key.OemPeriod) { ButtonPoint.Background = Brushes.Green; }
            if (e.Key == Key.OemQuestion) { ButtonBackslash.Background = Brushes.Green; }
            if (e.Key == Key.RightShift) { ButtonRightShift.Background = Brushes.Blue; }
            if (e.Key == Key.LeftCtrl) { ButtonLeftCtrl.Background = Brushes.Blue; }
            if (e.Key == Key.LWin) { ButtonLeftWin.Background = Brushes.Blue; }
            if (e.Key == Key.LeftAlt) { ButtonLeftAlt.Background = Brushes.Blue; }
            if (e.Key == Key.Space) { ButtonSpace.Background = Brushes.Red; }
            if (e.Key == Key.RightAlt) { ButtonRightAlt.Background = Brushes.Blue; }
            if (e.Key == Key.RWin) { ButtonRightWin.Background = Brushes.Blue; }
            if (e.Key == Key.RightCtrl) { ButtonRightCtrl.Background = Brushes.Blue; }

            if ((Keyboard.IsKeyToggled(Key.CapsLock)) || (e.Key == Key.LeftShift || e.Key == Key.RightShift))
            {
                ButtonApostrophe.Content = "~";
                Button1.Content = "!";
                Button2.Content = "@";
                Button3.Content = "#";
                Button4.Content = "$";
                Button5.Content = "%";
                Button6.Content = "^";
                Button7.Content = "&";
                Button8.Content = "*";
                Button9.Content = "(";
                Button0.Content = ")";
                ButtonMinus.Content = "_";
                ButtonEquals.Content = "+";
                ButtonA.Content = "A";
                ButtonB.Content = "B";
                ButtonC.Content = "C";
                ButtonD.Content = "D";
                ButtonE.Content = "E";
                ButtonF.Content = "F";
                ButtonG.Content = "G";
                ButtonH.Content = "H";
                ButtonI.Content = "I";
                ButtonJ.Content = "J";
                ButtonK.Content = "K";
                ButtonL.Content = "L";
                ButtonM.Content = "M";
                ButtonN.Content = "N";
                ButtonO.Content = "O";
                ButtonP.Content = "P";
                ButtonQ.Content = "Q";
                ButtonR.Content = "R";
                ButtonS.Content = "S";
                ButtonT.Content = "T";
                ButtonU.Content = "U";
                ButtonV.Content = "V";
                ButtonW.Content = "W";
                ButtonX.Content = "X";
                ButtonY.Content = "Y";
                ButtonZ.Content = "Z";
                ButtonOpeningSquareBrackets.Content = "{";
                ButtonClothingSquareBrackets.Content = "}";
                ButtonSlash.Content = "|";
                ButtonSemicolon.Content = ":";
                ButtonMark.Content = "\"";
                ButtonComma.Content = "<";
                ButtonPoint.Content = ">";
                ButtonBackslash.Content = "?";
            }
            else
            {
                ButtonApostrophe.Content = "`";
                Button1.Content = "1";
                Button2.Content = "2";
                Button3.Content = "3";
                Button4.Content = "4";
                Button5.Content = "5";
                Button6.Content = "6";
                Button7.Content = "7";
                Button8.Content = "8";
                Button9.Content = "9";
                Button0.Content = "0";
                ButtonMinus.Content = "-";
                ButtonEquals.Content = "=";
                ButtonA.Content = "a";
                ButtonB.Content = "b";
                ButtonC.Content = "c";
                ButtonD.Content = "d";
                ButtonE.Content = "e";
                ButtonF.Content = "f";
                ButtonG.Content = "g";
                ButtonH.Content = "h";
                ButtonI.Content = "i";
                ButtonJ.Content = "j";
                ButtonK.Content = "k";
                ButtonL.Content = "l";
                ButtonM.Content = "m";
                ButtonN.Content = "n";
                ButtonO.Content = "o";
                ButtonP.Content = "p";
                ButtonQ.Content = "q";
                ButtonR.Content = "r";
                ButtonS.Content = "s";
                ButtonT.Content = "t";
                ButtonU.Content = "u";
                ButtonV.Content = "v";
                ButtonW.Content = "w";
                ButtonX.Content = "x";
                ButtonY.Content = "y";
                ButtonZ.Content = "z";
                ButtonOpeningSquareBrackets.Content = "[";
                ButtonClothingSquareBrackets.Content = "]";
                ButtonSlash.Content = "\\";
                ButtonSemicolon.Content = ";";
                ButtonMark.Content = "'";
                ButtonComma.Content = ",";
                ButtonPoint.Content = ".";
                ButtonBackslash.Content = "/";
            }

        }
        private void Window_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Oem3) { ButtonApostrophe.Background = Brushes.LightGray; }
            if (e.Key == Key.D1) { Button1.Background = Brushes.LightGray; }
            if (e.Key == Key.D2) { Button2.Background = Brushes.LightGray; }
            if (e.Key == Key.D3) { Button3.Background = Brushes.LightGray; }
            if (e.Key == Key.D4) { Button4.Background = Brushes.LightGray; }
            if (e.Key == Key.D5) { Button5.Background = Brushes.LightGray; }
            if (e.Key == Key.D6) { Button6.Background = Brushes.LightGray; }
            if (e.Key == Key.D7) { Button7.Background = Brushes.LightGray; }
            if (e.Key == Key.D8) { Button8.Background = Brushes.LightGray; }
            if (e.Key == Key.D9) { Button9.Background = Brushes.LightGray; }
            if (e.Key == Key.D0) { Button0.Background = Brushes.LightGray; }
            if (e.Key == Key.OemMinus) { ButtonMinus.Background = Brushes.LightGray; }
            if (e.Key == Key.OemPlus) { ButtonEquals.Background = Brushes.LightGray; }
            if (e.Key == Key.Back) { ButtonBackspace.Background = Brushes.LightGray; }
            if (e.Key == Key.Tab) { ButtonTab.Background = Brushes.LightGray; }
            if (e.Key == Key.Q) { ButtonQ.Background = Brushes.LightGray; }
            if (e.Key == Key.W) { ButtonW.Background = Brushes.LightGray; }
            if (e.Key == Key.E) { ButtonE.Background = Brushes.LightGray; }
            if (e.Key == Key.R) { ButtonR.Background = Brushes.LightGray; }
            if (e.Key == Key.T) { ButtonT.Background = Brushes.LightGray; }
            if (e.Key == Key.Y) { ButtonY.Background = Brushes.LightGray; }
            if (e.Key == Key.U) { ButtonU.Background = Brushes.LightGray; }
            if (e.Key == Key.I) { ButtonI.Background = Brushes.LightGray; }
            if (e.Key == Key.O) { ButtonO.Background = Brushes.LightGray; }
            if (e.Key == Key.P) { ButtonP.Background = Brushes.LightGray; }
            if (e.Key == Key.OemOpenBrackets) { ButtonOpeningSquareBrackets.Background = Brushes.LightGray; }
            if (e.Key == Key.OemCloseBrackets) { ButtonClothingSquareBrackets.Background = Brushes.LightGray; }
            if (e.Key == Key.Oem5) { ButtonSlash.Background = Brushes.LightGray; }
            if (e.Key == Key.CapsLock) { ButtonCapsLock.Background = Brushes.LightGray; }
            if (e.Key == Key.A) { ButtonA.Background = Brushes.LightGray; }
            if (e.Key == Key.S) { ButtonS.Background = Brushes.LightGray; }
            if (e.Key == Key.D) { ButtonD.Background = Brushes.LightGray; }
            if (e.Key == Key.F) { ButtonF.Background = Brushes.LightGray; }
            if (e.Key == Key.G) { ButtonG.Background = Brushes.LightGray; }
            if (e.Key == Key.H) { ButtonH.Background = Brushes.LightGray; }
            if (e.Key == Key.J) { ButtonJ.Background = Brushes.LightGray; }
            if (e.Key == Key.K) { ButtonK.Background = Brushes.LightGray; }
            if (e.Key == Key.L) { ButtonL.Background = Brushes.LightGray; }
            if (e.Key == Key.Oem1) { ButtonSemicolon.Background = Brushes.LightGray; }
            if (e.Key == Key.OemQuotes) { ButtonMark.Background = Brushes.LightGray; }
            if (e.Key == Key.Enter) { ButtonEnter.Background = Brushes.LightGray; }
            if (e.Key == Key.LeftShift) { ButtonLeftShift.Background = Brushes.LightGray; }
            if (e.Key == Key.Z) { ButtonZ.Background = Brushes.LightGray; }
            if (e.Key == Key.X) { ButtonX.Background = Brushes.LightGray; }
            if (e.Key == Key.C) { ButtonC.Background = Brushes.LightGray; }
            if (e.Key == Key.V) { ButtonV.Background = Brushes.LightGray; }
            if (e.Key == Key.B) { ButtonB.Background = Brushes.LightGray; }
            if (e.Key == Key.N) { ButtonN.Background = Brushes.LightGray; }
            if (e.Key == Key.M) { ButtonM.Background = Brushes.LightGray; }
            if (e.Key == Key.OemComma) { ButtonComma.Background = Brushes.LightGray; }
            if (e.Key == Key.OemPeriod) { ButtonPoint.Background = Brushes.LightGray; }
            if (e.Key == Key.OemQuestion) { ButtonBackslash.Background = Brushes.LightGray; }
            if (e.Key == Key.RightShift) { ButtonRightShift.Background = Brushes.LightGray; }
            if (e.Key == Key.LeftCtrl) { ButtonLeftCtrl.Background = Brushes.LightGray; }
            if (e.Key == Key.LWin) { ButtonLeftWin.Background = Brushes.LightGray; }
            if (e.Key == Key.LeftAlt) { ButtonLeftAlt.Background = Brushes.LightGray; }
            if (e.Key == Key.Space) { ButtonSpace.Background = Brushes.LightGray; }
            if (e.Key == Key.RightAlt) { ButtonRightAlt.Background = Brushes.LightGray; }
            if (e.Key == Key.RWin) { ButtonRightWin.Background = Brushes.LightGray; }
            if (e.Key == Key.RightCtrl) { ButtonRightCtrl.Background = Brushes.LightGray; }
            if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
            {
                ButtonApostrophe.Content = "`";
                Button1.Content = "1";
                Button2.Content = "2";
                Button3.Content = "3";
                Button4.Content = "4";
                Button5.Content = "5";
                Button6.Content = "6";
                Button7.Content = "7";
                Button8.Content = "8";
                Button9.Content = "9";
                Button0.Content = "0";
                ButtonMinus.Content = "-";
                ButtonEquals.Content = "=";
                ButtonA.Content = "a";
                ButtonB.Content = "b";
                ButtonC.Content = "c";
                ButtonD.Content = "d";
                ButtonE.Content = "e";
                ButtonF.Content = "f";
                ButtonG.Content = "g";
                ButtonH.Content = "h";
                ButtonI.Content = "i";
                ButtonJ.Content = "j";
                ButtonK.Content = "k";
                ButtonL.Content = "l";
                ButtonM.Content = "m";
                ButtonN.Content = "n";
                ButtonO.Content = "o";
                ButtonP.Content = "p";
                ButtonQ.Content = "q";
                ButtonR.Content = "r";
                ButtonS.Content = "s";
                ButtonT.Content = "t";
                ButtonU.Content = "u";
                ButtonV.Content = "v";
                ButtonW.Content = "w";
                ButtonX.Content = "x";
                ButtonY.Content = "y";
                ButtonZ.Content = "z";
                ButtonOpeningSquareBrackets.Content = "[";
                ButtonClothingSquareBrackets.Content = "]";
                ButtonSlash.Content = "\\";
                ButtonSemicolon.Content = ";";
                ButtonMark.Content = "'";
                ButtonComma.Content = ",";
                ButtonPoint.Content = ".";
                ButtonBackslash.Content = "/";
            }
        }
        private int currentCharIndex = 0;
        private void Window_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (MyRichTextBox.Document.Blocks.FirstBlock is Paragraph paragraph && paragraph.Inlines.Count > 0 && e.Text.Length > 0)
            {
                Run? currentRun = paragraph.Inlines.ElementAt(currentCharIndex) as Run;

                if (currentRun != null && currentRun.Text.Length > 0)
                {
                    bool isMatch;
                    if (CheckBoxCaseSensitive.IsChecked == true)
                    {
                        isMatch = currentRun.Text[0].ToString().ToLower() == e.Text.ToLower();
                    }
                    else
                    {
                        isMatch = currentRun.Text[0].ToString() == e.Text;
                    }

                    if (isMatch)
                    {
                        currentRun.Foreground = Brushes.Green;
                        totalChars++;
                    }
                    else
                    {
                        currentRun.Foreground = Brushes.Red;
                        totalChars++;
                        LabelMistakes.Content = ++totalMistakes + " mistakes";
                    }

                    Run newRun = new Run(currentRun.Text.Substring(1));

                    currentRun.Text = currentRun.Text[0].ToString();

                    paragraph.Inlines.InsertAfter(currentRun, newRun);

                    currentCharIndex++;
                }
            }
        }


        private void buttonStop_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

