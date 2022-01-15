using System;
using EmployeeManager.Core.DataProvider;
using EmployeeManager.Core.Entities;
using EmployeeManager.ViewModel.Command;

namespace EmployeeManager.ViewModel;

public class EmployeeViewModel : ViewModelBase
{
    private readonly Employee _employee;
    private readonly IEmployeeDataProvider _employeeDataProvider;

    public EmployeeViewModel(Employee employee, IEmployeeDataProvider employeeDataProvider)
    {
        _employee = employee;
        _employeeDataProvider = employeeDataProvider;

        SaveCommand = new DelegateCommand(Save, () => CanSave);
    }

    public DelegateCommand SaveCommand { get; set; }

    public string FirstName
    {
        get => _employee.FirstName;
        set
        {
            if (_employee.FirstName == value) return;
            _employee.FirstName = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(CanSave));

            SaveCommand.RaiseCanExecuteChanged();
        }
    }

    public DateTimeOffset EntryDate
    {
        get => _employee.EntryDate;
        set
        {
            if (_employee.EntryDate == value) return;
            _employee.EntryDate = value;
            OnPropertyChanged();
        }
    }

    public DateTime EntryDateTime
    {
        get => _employee.EntryDate.DateTime;
        set
        {
            if (_employee.EntryDate == value) return;
            _employee.EntryDate = value;
            OnPropertyChanged();
        }
    }

    public int JobRoleId
    {
        get => _employee.JobRoleId;
        set
        {
            if (_employee.JobRoleId == value) return;
            _employee.JobRoleId = value;
            OnPropertyChanged();
        }
    }

    public bool IsCoffeeDrinker
    {
        get => _employee.IsCoffeeDrinker;
        set
        {
            if (_employee.IsCoffeeDrinker == value) return;
            _employee.IsCoffeeDrinker = value;
            OnPropertyChanged();
        }
    }

    public bool CanSave => !string.IsNullOrEmpty(FirstName);

    public void Save()
    {
        _employeeDataProvider.SaveEmployee(_employee);
    }
}