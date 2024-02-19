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

    private string _oper = "";

    private string _result = "";

    public string Result
    {
        get { return _result; }

        set
        {
            _result = value;
            OnPropertyChanged(nameof(Result));
        }
    }

    public void OperatorClick(object? value)
    {
        if (value == null)
            return;
        if (double.TryParse(Result, out _num1) == false)
            return;

        string StringValue = value.ToString();
        _oper = StringValue;
        Result = "";
    }

    public void NumberClick(object? value)
    {
        if (value == null) return;
        string stringValue = value.ToString();

        if (stringValue == "," && !stringValue.Contains(","))
        {

            stringValue = "0" + stringValue;
        }

        Result += stringValue;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}