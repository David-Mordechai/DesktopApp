using System.Collections.ObjectModel;
using EmployeeManager.Core.DataProvider;
using EmployeeManager.Core.Entities;
using EmployeeManager.ViewModel.Command;

namespace EmployeeManager.ViewModel;

public class MainViewModel : ViewModelBase
{
    private readonly IEmployeeDataProvider _employeeDataProvider;
    private readonly IJobRoleDataProvider _jobRoleDataProvider;
    private EmployeeViewModel _selectedEmployee;

    public MainViewModel(
        IEmployeeDataProvider employeeDataProvider,
        IJobRoleDataProvider jobRoleDataProvider)
    {
        _employeeDataProvider = employeeDataProvider;
        _jobRoleDataProvider = jobRoleDataProvider;

        LoadCommand = new DelegateCommand(Load);
    }

    public DelegateCommand LoadCommand { get; }

    public ObservableCollection<EmployeeViewModel> Employees { get; } = new();
    public ObservableCollection<JobRole> JobRoles { get; } = new();

    public EmployeeViewModel SelectedEmployee
    {
        get => _selectedEmployee;
        set
        {
            if (_selectedEmployee == value) return;
                
            _selectedEmployee = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsEmployeeSelected));
        }
    }

    public bool IsEmployeeSelected => SelectedEmployee != null;

    public void Load()
    {
        var employees = _employeeDataProvider.LoadEmployees();
        var jobRoles = _jobRoleDataProvider.LoadJobRoles();

        Employees.Clear();
        foreach (var employee in employees)
        {
            Employees.Add(new EmployeeViewModel(employee, _employeeDataProvider));
        }

        JobRoles.Clear();
        foreach (var jobRole in jobRoles)
        {
            JobRoles.Add(jobRole);
        }
    }
}