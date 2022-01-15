using System;
using System.Windows.Forms;
using EmployeeManager.Persistence;
using EmployeeManager.ViewModel;

namespace EmployeeManager.WinForms
{
    public partial class MainForm : Form
    {
        private readonly MainViewModel _viewModel;

        public MainForm()
        {
            InitializeComponent();
            _viewModel = new MainViewModel(new EmployeeDataProvider(), new JobRoleDataProvider());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            _viewModel.Load();
            employeesBindingSource.DataSource = _viewModel.Employees;
            lsbEmployees.DataSource = employeesBindingSource;
            lsbEmployees.DisplayMember = "FirstName";

            cboJobRoles.DataSource = _viewModel.JobRoles;
            cboJobRoles.DisplayMember = "RoleName";
            cboJobRoles.ValueMember = "Id";
            var areDataBindingsInitialized = cboJobRoles.DataBindings.Count > 0;
            
            if (areDataBindingsInitialized)
            {
                employeesBindingSource.ResetBindings(false);
                return;
            }
            
            cboJobRoles.DataBindings.Add("SelectedValue", employeesBindingSource, "JobRoleId");

            txtFirstName.DataBindings.Add("Text", employeesBindingSource, "FirstName",
                false, DataSourceUpdateMode.OnPropertyChanged);

            dtpEntryDate.DataBindings.Add("Value", employeesBindingSource, "EntryDateTime");

            chkIsCoffeeDrinker.DataBindings.Add("checked", employeesBindingSource, "IsCoffeeDrinker");

            btnSave.DataBindings.Add("Enabled", employeesBindingSource, "CanSave");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(employeesBindingSource.Current is EmployeeViewModel {CanSave: true} employeeViewModel)
                employeeViewModel.Save();
        }
    }
}
