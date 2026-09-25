using DesktopTodos.Tasks;

namespace DesktopTodos.Tabs
{
    public partial class NewTaskControl : UserControl
    {
        private readonly Todo _currentTodo;

        public NewTaskControl()
        {
            InitializeComponent();

            cbbRepeatIntervalDays.DataSource = Enum.GetValues(typeof(RepeatIntervalDays));
            cbbRepeatIntervalType.DataSource = Enum.GetValues(typeof(IntervalType));
            
            _currentTodo = new Todo();

            tbTodoText.DataBindings.Add("Text", _currentTodo, nameof(Todo.Text), false, DataSourceUpdateMode.OnPropertyChanged);
            pckrStartDateTime.DataBindings.Add("Value", _currentTodo, nameof(Todo.StartDateTime), false, DataSourceUpdateMode.OnPropertyChanged);
            chbTriggerStartAlert.DataBindings.Add("Checked", _currentTodo, nameof(Todo.IsStartAlert), false, DataSourceUpdateMode.OnPropertyChanged);

            chbHasEndTime.DataBindings.Add("Checked", _currentTodo, nameof(Todo.IsEndDateTimeSelected), false, DataSourceUpdateMode.OnPropertyChanged);
            pckrEndDateTime.DataBindings.Add("Value", _currentTodo, nameof(Todo.EndDateTime), false, DataSourceUpdateMode.OnPropertyChanged);
            chbTriggerEndAlert.DataBindings.Add("Checked", _currentTodo, nameof(Todo.IsEndAlert), false, DataSourceUpdateMode.OnPropertyChanged);

            chbDoRepeat.DataBindings.Add("Checked", _currentTodo, nameof(Todo.IsRepeatable), false, DataSourceUpdateMode.OnPropertyChanged);
            numIntervalValue.DataBindings.Add("Value", _currentTodo, nameof(Todo.RepeatIntervalValue), false, DataSourceUpdateMode.OnPropertyChanged);
            cbbRepeatIntervalType.DataBindings.Add("SelectedItem", _currentTodo, nameof(Todo.RepeatIntervalTimeType), false, DataSourceUpdateMode.OnPropertyChanged);
            cbbRepeatIntervalDays.DataBindings.Add("SelectedItem", _currentTodo, nameof(Todo.RepeatIntervalDays), false, DataSourceUpdateMode.OnPropertyChanged);


        }

        private void OnBtnSave_Click(object sender, EventArgs e)
        {

        }
    }

    public class Todo
    {
        public string Text { get; set; } = string.Empty;
        public DateTime StartDateTime { get; set; } = DateTime.Now;
        public bool IsStartAlert { get; set; }

        public bool IsEndDateTimeSelected { get; set; }
        public DateTime EndDateTime { get; set; } = DateTime.Now;
        public bool IsEndAlert { get; set; }

        public bool IsRepeatable { get; set; }

        public int RepeatIntervalValue { get; set; } = 1;

        public IntervalType RepeatIntervalTimeType { get; set; }
        public RepeatIntervalDays RepeatIntervalDays { get; set; }
    }
}
