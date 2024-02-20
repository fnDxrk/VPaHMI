using Avalonia.Controls;
using System;
using System.ComponentModel;
using System.Numerics;
using System.Windows.Input;

namespace Домашнее_задание__3.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private double _num1;

    private double _num2;

    private double _num3;

    private string _oper = "";

    private string _result = "";

    public string Result
    {
        get { return _result; }

        set { _result = value; OnPropertyChanged(nameof(Result)); }
    }

    public void OperatorClick(object? operand)
    {
        if (operand == null) { return; }
        string stringOperand = operand.ToString();

        if (_oper == "")
        {
            if (double.TryParse(Result, out _num1) == false) return;
        }
        else
        {
            if (double.TryParse(Result, out _num2) == false) return;
            OperClick();
            _num1 = double.Parse(Result);
        }

        if (stringOperand == "n!" || stringOperand == "floor" || stringOperand == "tan" || stringOperand == "log" || stringOperand == "ln" ||
    stringOperand == "sin" || stringOperand == "cos" || stringOperand == "ceil")
        {
            if (double.TryParse(Result, out _num1) == false) return;
            _oper = stringOperand;
            OperClick();
            return;
        }

        _oper = stringOperand;
        Result = "";
    }

    public void NumberClick(object? value)
    {
        if (value == null) return;
        string stringValue = value.ToString();

        if (string.IsNullOrEmpty(Result) && stringValue == "-")
        {
            Result += stringValue;
            return;
        }

        if (stringValue == "-" && Result.Contains("-"))
        {
            return;
        }

        if (stringValue == "," && !stringValue.Contains(","))
        {
            stringValue = "0" + stringValue;
        }
        if (stringValue == "," && Result.Contains(","))
        {
            return;
        }

        Result += stringValue;
    }
    public void BackspaceCommand()
    {
        if (!string.IsNullOrEmpty(Result))
        {
            Result = Result.Substring(0, Result.Length - 1);
        }
    }

    public void ClearCommand()
    {
        _num1 = 0;
        _num2 = 0;
        _oper = "";
        Result = "";
    }

    public void OperClick()
    {
        if (double.TryParse(Result, out _num2) == false) return;
        switch (_oper)
        {
            case "+":
                Result = (_num1 + _num2).ToString();
                break;
            case "*":
                Result = (_num1 * _num2).ToString();
                break;
            case "-":
                Result = (_num1 - _num2).ToString();
                break;
            case "/":
                if (_num2 != 0)
                {
                    Result = (_num1 / _num2).ToString();
                }
                else
                {
                    Result = "Error!";
                    return;
                }
                break;
            case "mod":
                if (_num2 != 0)
                {
                    Result = (_num1 % _num2).ToString();
                }
                else
                {
                    Result = "Error!";
                    return;
                }
                break;
            case "^":
                Result = Math.Pow(_num1, _num2).ToString();
                break;
            case "floor":
                Result = Math.Floor(_num1).ToString();
                break;
            case "tan":
                Result = Math.Tan(_num2).ToString();
                break;
            case "log":
                if (_num1 > 0)
                {
                    Result = Math.Log10(_num1).ToString();
                }
                else
                {
                    Result = "Error!";
                    return;
                }
                break;
            case "ln":
                if (_num1 > 0)
                {
                    Result = Math.Log(_num1).ToString();
                }
                else
                {
                    Result = "Error";
                    return;
                }
                break;
            case "n!":
                if (_num1 == 0)
                {
                    Result = "1";
                }
                if (_num1 < 0) return;
                if (_num1 > 0)
                {
                    _num3 = 1;
                    for (int i = 2; i <= _num1; i++)
                    {
                        _num3 *= i;
                    }
                    Result = _num3.ToString();
                }
                break;
            case "sin":
                Result = Math.Sin(_num1).ToString();
                break;
            case "cos":
                Result = Math.Cos(_num1).ToString();
                break;
            case "ceil":
                Result = Math.Ceiling(_num1).ToString();
                break;
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}