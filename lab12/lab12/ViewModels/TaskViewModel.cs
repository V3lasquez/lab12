using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace lab12.ViewModels
{
    public class TaskViewModel
    {
        private ObservableCollection<Task> tasks;
        public ObservableCollection<Task> Tasks
        {
            get { return tasks; }
            set
            {
                if (tasks != value)
                {
                    tasks = value;
                    OnPropertyChanged();
                }
            }
        }

        private Task newTask;
        public Task NewTask
        {
            get { return newTask; }
            set
            {
                if (newTask != value)
                {
                    newTask = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand Save { protected set; get; }
        public ICommand Get { protected set; get; }

        public TaskViewModel()
        {
            Tasks = new ObservableCollection<Task>();
            NewTask = new Task();

            Save = new Command(Insertar);
            Get = new Command(Listar);
        }

        private void Insertar()
        {
            if (NewTask != null)
            {
                Tasks.Add(NewTask);
                NewTask = new Task();
            }
        }

        private void Listar()
        {
            Tasks = new ObservableCollection<Task>(Tasks);
        }


        public void Insertar(Task task)
        {
            if (task != null)
            {
                Tasks.Add(task);
            }
        }


        public ObservableCollection<Task> Listar2()
        {
            return Tasks;
        }
    }
}