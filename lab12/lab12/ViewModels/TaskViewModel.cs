using lab12.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace lab12.ViewModels
{
    public class TaskViewModel : ViewModelBase
    {
        private ObservableCollection<TaskModel> tasks;
        public ObservableCollection<TaskModel> Tasks
        {
            get => tasks;
            set => SetProperty(ref tasks, value);
        }

        private TaskModel newTask;
        public TaskModel NewTask
        {
            get => newTask;
            set => SetProperty(ref newTask, value);
        }

        public ICommand Save { protected set; get; }
        public ICommand Get { protected set; get; }

        public TaskViewModel()
        {
            Tasks = new ObservableCollection<TaskModel>();
            NewTask = new TaskModel();

            Save = new Command(Insertar);
            Get = new Command(Listar);
        }

        private void Insertar()
        {
            if (NewTask != null)
            {
                Tasks.Add(new TaskModel
                {
                    Title = NewTask.Title,
                    Descripcion = NewTask.Descripcion,
                    Status = NewTask.Status
                });

                NewTask = new TaskModel();
                Console.WriteLine("Tarea agregada a la lista");
            }
        }

        private void Listar()
        {
            // No necesitas crear una nueva ObservableCollection aquí, simplemente notifica de los cambios.
            OnPropertyChanged(nameof(Tasks));
        }

        public void Insertar(TaskModel task)
        {
            if (task != null)
            {
                Tasks.Add(task);
                NewTask = new TaskModel();
                Listar(); // Notificar cambios después de insertar
            }
        }

        public ObservableCollection<TaskModel> Listar2()
        {
            return Tasks;
        }
    }
}
