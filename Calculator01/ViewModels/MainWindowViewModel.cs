using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows.Input;

namespace Calculator01.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        // TextBoxのバインディングプロパティの型を数値型にしておけば、ValidationRuleにより数値以外を入力するとTextBoxの枠が赤く表示され、
        // 内部的にはバインディングプロパティ値は直前の数値としての入力値のままとなり、簡易な入力制限になる。
        private decimal _input1Text = 0;
        public decimal Input1Text
        {
            get { return _input1Text; }
            set { SetProperty(ref _input1Text, value); }
        }

        // TextBoxのバインディングプロパティの型を数値型にしておけば、ValidationRuleにより数値以外を入力するとTextBoxの枠が赤く表示され、
        // 内部的にはバインディングプロパティ値は直前の数値としての入力値のままとなり、簡易な入力制限になる。
        private decimal _input2Text = 0;
        public decimal Input2Text
        {
            get { return _input2Text; }
            set { SetProperty(ref _input2Text, value); }
        }

        private string _calcResultText;
        public string CalcResultText
        {
            get { return _calcResultText; }
            set { SetProperty(ref _calcResultText, value); }
        }

        
        public DelegateCommand CalcAdditionCmd { get; }
        public DelegateCommand CalcSubtractionCmd { get; }
        public DelegateCommand CalcMultiplicationCmd { get; }
        public DelegateCommand CalcDivisionCmd { get; }


        public MainWindowViewModel()
        {
            this.CalcAdditionCmd = new DelegateCommand(CalcAddition);
            this.CalcSubtractionCmd = new DelegateCommand(CalcSubtraction);
            this.CalcMultiplicationCmd = new DelegateCommand(CalcMultiplication);
            this.CalcDivisionCmd = new DelegateCommand(CalcDivision);
        }


        private void CalcAddition()
        {
            decimal calcResult = this.Input1Text + this.Input2Text;
            this.CalcResultText = calcResult.ToString();
        }

        private void CalcSubtraction()
        {
            decimal calcResult = this.Input1Text - this.Input2Text;
            this.CalcResultText = calcResult.ToString();
        }

        private void CalcMultiplication()
        {
            decimal calcResult = this.Input1Text * this.Input2Text;
            this.CalcResultText = calcResult.ToString();
        }

        private void CalcDivision()
        {
            if (this.Input2Text != 0)
            {
                decimal calcResult = this.Input1Text / this.Input2Text;
                this.CalcResultText = calcResult.ToString();
            }
            else
            {
                this.CalcResultText = "Not calculable: Division by zero";
            }
        }
    }
}
